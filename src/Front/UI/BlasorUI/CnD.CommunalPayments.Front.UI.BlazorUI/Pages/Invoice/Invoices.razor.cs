using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using CnD.CommunalPayments.Front.ApiClient;
using CnD.CommunalPayments.Front.ApiClient.Base;
using CnD.CommunalPayments.Contracts.Models.Providers.Response;
using CnD.CommunalPayments.Contracts.Models.Periods.Response;
using CnD.CommunalPayments.Contracts.Models.Invoices.Response;
using CnD.CommunalPayments.Front.UI.BlazorUI.Components;

namespace CnD.CommunalPayments.Front.UI.BlazorUI.Pages.Invoice;

public class InvoicesBase : ComponentBase
{
    #region Поля, Инициализация формы, Модальное окно

    /// <summary>
    /// Модель представления
    /// </summary>
    protected InvoiceViewModel InvoiceViewModel;

    [Parameter]
    public IInvoiceClientService Repository { get; set; }

    [Parameter]
    public List<ProviderResponse> Providers { get; set; }

    [Parameter]
    public List<PeriodResponse> Periods { get; set; }

    [Parameter]
    public EventCallback<InvoiceResponse> OnClickSetService { get; set; }

    /// <summary>
    /// Список квитанций
    /// </summary>
    protected IEnumerable<InvoiceResponse> invoices;

    /// <summary>
    /// Квитанция
    /// </summary>
    protected InvoiceResponse invoice;

    protected bool pay;
    protected bool isNotPaided = true;
    protected bool isPay;

    //Providers
    protected ProviderResponse provider;
    protected List<ProviderResponse> providersList;
    protected int IdProvider;

    //Periods
    protected PeriodResponse period;

    protected int IdPeriod;

    protected int[] pageSizeList = new int[] { 10, 25, 50 };
    private int pageOfSet = 0;
    private int pageSize;
    protected int totalItems = 0;

    //Модальное окно
    protected Modal modal;
    protected void CloseModal()
    {
        invoice = default;
        modal.Close();
    }
    protected void OpenModal()
    {
        modal.ModalSize = "modal-lg";
        modal.Open();
    }

    protected async Task SetPageOfSet(int[] page)
    {
        pageOfSet = page[0];
        pageSize = page[1];
        await StateUpdate(isNotPaided);
    }

    protected override async Task OnInitializedAsync()
    {
        InvoiceViewModel = new InvoiceViewModel();
        invoice = default;
        isPay = default;
        pageSize = pageSizeList[0];
        await StateUpdate(isNotPaided);
    }

    #endregion

    #region Обработка нажатия кнопок

    ///// <summary>
    ///// Добавить или отредактировать
    ///// </summary>
    //protected async Task AddAsync()
    //{
    //    //Получаем из модели представления id
    //    IdProvider = int.Parse(InvoiceViewModel.IdProvider);
    //    IdPeriod = int.Parse(InvoiceViewModel.IdPeriod);

    //    //Проверяем, есть ли текущая квитанция
    //    if (invoice == null)
    //    {
    //        //Создаем и инициализируем экземпляр квитанции
    //        invoice = new InvoiceResponse()
    //        {

    //            PeriodId = IdPeriod,
    //            ProviderId = IdProvider,
    //            Sum = InvoiceViewModel.InvoiceSum,
    //        };

    //        //Если квитанция уникальная записываем ее в БД
    //        if (invoices.FirstOrDefault(i => i.Equals(invoice)) == null)
    //        {
    //            await Repository.AddAsync(invoice);
    //        }
    //    }
    //    else
    //    {
    //        //Меняем модель и вносим изменения в БД
    //        invoice.IdPeriod = IdPeriod;
    //        invoice.IdProvider = IdProvider;
    //        invoice.InvoiceSum = InvoiceViewModel.InvoiceSum;

    //        await Repository.EditAsync(invoice);
    //    }

    //    await StateUpdate(isNotPaided);

    //    CloseModal();
    //}

    /// <summary>
    /// Изменить запись
    /// </summary>
    protected void Edit(InvoiceResponse item)
    {
        ////Готовим модель представления
        //invoice = item;
        //OpenModal();

        //InvoiceViewModel.IdPeriod = invoice.IdPeriod.ToString();
        //InvoiceViewModel.IdProvider = invoice.IdProvider.ToString();
        //InvoiceViewModel.InvoiceSum = invoice.InvoiceSum;
    }

    /// <summary>
    /// Удалить запись
    /// </summary>
    /// <param name="item"></param>
    protected async Task Remove(InvoiceResponse item)
    {
        //await Repository.RemoveAsync(item.IdInvoice);
        //await StateUpdate(isNotPaided);
    }

    /// <summary>
    /// Устанавливаем в квитанцию услуги
    /// </summary>
    /// <param name="item"></param>
    protected void SetService(InvoiceResponse item)
    {
        OnClickSetService.InvokeAsync(item);
    }

    /// <summary>
    /// Переходим к оплате квитанции
    /// </summary>
    /// <param name="item"></param>
    protected void Pay(InvoiceResponse item)
    {
        invoice = item;
        isPay = true;
    }

    /// <summary>
    /// Скрыть / Показать оплаченные квитанции
    /// </summary>
    /// <returns></returns>
    protected async Task ShowPaided()
    {
        isNotPaided = !isNotPaided;
        totalItems = 0;
        pageOfSet = 0;
        await StateUpdate(isNotPaided);
    }

    /// <summary>
    /// Возврат к интерфейсу списка квитанций после оплаты
    /// </summary>
    protected void ReturnToPayment()
    {
        isPay = false;
    }

    #endregion

    private async Task StateUpdate(bool show)
    {
        await GetAllAsync();
        if (show)
        {
            invoices = invoices.Where(i => i.IsPaid == false);
            totalItems = invoices.Count();
        }
    }

    protected async Task GetAllAsync()
    {
        if (totalItems == 0)
        {
            invoices = (await Repository.GetAllAsync()).ToList();//.OrderByDescending(p => p.PeriodId.ToSort());
            totalItems = invoices.Count();
            invoices = invoices.Skip(pageOfSet).Take(pageSize);
        }
        else
        {
            invoices = (await Repository.GetAllAsync()).ToList();//.OrderByDescending(p => p.Period.ToSort()).Skip(pageOfSet).Take(pageSize);
        }
    }

    /// <summary>
    /// Получить URL к личному кабинету на сайте поставщика услуг
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    protected string GetWeb(int id) => Providers.FirstOrDefault(p => p.Id == id).WebSite;
}

/// <summary>
/// Модель представления
/// </summary>
public class InvoiceViewModel
{
    /// <summary>
    /// Период
    /// </summary>
    [Required(ErrorMessage = "Необходимо выбрать период!")]
    public string IdPeriod { get; set; } = "";

    /// <summary>
    /// Поставщик услуг
    /// </summary>
    [Required(ErrorMessage = "Необходимо выбрать поставщика!")]
    public string IdProvider { get; set; } = "";

    /// <summary>
    /// Сумма квитанции
    /// </summary>
    [Required(ErrorMessage = "Необходимо указать сумму квитанции!")]
    [Range(0, 100000, ErrorMessage = "Сумма должна быть неотрицательным числом!")]
    public decimal InvoiceSum { get; set; }
}
