using CnD.CommunalPayments.Contracts.Models.Periods.Response;
using CnD.CommunalPayments.Front.ApiClient;
using CnD.CommunalPayments.Front.UI.BlazorUI.Components;
using CnD.CommunalPayments.Front.UI.BlazorUI.Shared;
using CnD.CommunalPayments.Front.ViewModels.Periods;
using CnD.CommunalPayments.Front.ViewModels.Periods;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CnD.CommunalPayments.Front.UI.BlazorUI.Pages.PeriodPages;

public class PeriodsBase : ComponentBase
{
    #region Поля, Инициализация формы, Модальное окно

    /// <summary>
    /// Данные модели представления
    /// </summary>
    public PeriodViewModel PeriodModel { get; set; } = new PeriodViewModel();

    /// <summary>
    /// Репозиторий данных
    /// </summary>
    [Inject]
    public IPeriodClientService PeriodsClient { get; set; }

    protected Period period = default;
    protected IEnumerable<PeriodListItemViewModel> Periods;

    protected int[] pageSizeList = new int[] { 10, 25, 50 };
    private int pageOfSet = 0;
    private int pageSize;
    protected int totalItems = 0;

    //Модальное окно
    protected Modal modal;
    protected void CloseModal()
    {
        PeriodModel = new PeriodViewModel();
        period = default;
        modal.Close();
    }
    protected void OpenModal()
    {
        modal.Open();
    }

    //Уведомление
    protected Toast toast;
    protected string message;
    private bool confirm;

    protected async Task SetPageOfSet(int[] page)
    {
        pageOfSet = page[0];
        pageSize = page[1];
        await StateUpdate();
    }

    protected override async Task OnInitializedAsync()
    {
        pageSize = pageSizeList[0];
        await StateUpdate();
        NavMenu.SetSubMenu(true);
    }

    #endregion

    #region Обработка нажатия кнопок

    ///// <summary>
    ///// Добавить или отредактировать
    ///// </summary>
    //protected async Task AddAsync()
    //{
    //    (string, ToastLevel) toastMessage = ("Данные обновлены", ToastLevel.Success);

    //    //Проверяем существует ли текущий период
    //    if (period == null)
    //    {
    //        //Создаем и инициализируем модель
    //        period = new Period()
    //        {
    //            Year = PeriodModel.Year.ToString(),
    //            Month = PeriodModel.Month
    //        };

    //        //Если период уникальный добавляем в БД
    //        if (periods.FirstOrDefault(p => p.Equals(period)) == null)
    //        {
    //            await Repository.AddAsync(period);
    //        }
    //        else
    //        {
    //            toastMessage = ("Такой период уже существует!", ToastLevel.Error);
    //        }

    //    }
    //    else
    //    {
    //        //Меняем текущий период и записываем изменения в БД
    //        period.Year = PeriodModel.Year.ToString();
    //        period.Month = PeriodModel.Month;
    //        await Repository.EditAsync(period);
    //        period = default;
    //    }
    //    CloseModal();
    //    totalItems = 0;
    //    await StateUpdate();
    //    ToastShow(toastMessage.Item1, toastMessage.Item2);
    //}

    /// <summary>
    /// Изменить запись
    /// </summary>
    protected void Edit(PeriodListItemViewModel item)
    {
        //Готовим модель представления
        //period = item;
        //modal.Open();
        //PeriodModel.Year = int.Parse(period.Year);
        //PeriodModel.Month = period.Month;
    }

    /// <summary>
    /// Удалить запись
    /// </summary>
    /// <param name="item"></param>
    protected void Remove(PeriodListItemViewModel item)
    {
        //period = item;
        //ToastShow("Внимание! Данные о периоде будут безвозвратно удалены. Вы уверенны?", ToastLevel.Warning);

    }

    #endregion

    private async Task StateUpdate()
    {
        var periods = (await PeriodsClient.GetAllAsync());
        if (totalItems == 0)
        {
            //.OrderByDescending(p => p.ToSort());
            totalItems = periods.Count();
        }

        periods = periods.Skip(pageOfSet).Take(pageSize);
        Periods = periods.Select(x => new PeriodListItemViewModel { Id = x.Id.Value, Month = x.Month, Year = x.Year });
    }

    //protected void ToastShow(string mes, ToastLevel level)
    //{
    //    message = mes;
    //    toast.ShowToast(level);
    //}

    /// <summary>
    /// Удаляем данные после подтверждения
    /// </summary>
    /// <returns></returns>
    protected async Task Confirm()
    {
        confirm = true;

        await DeleteData();
    }

    /// <summary>
    /// Реализация удаления из БД
    /// </summary>
    /// <returns></returns>
    private async Task DeleteData()
    {

        //if (confirm && period != null)
        //{
        //    await Repository.RemoveAsync(period.IdKey);
        //    totalItems = 0;
        //    await StateUpdate();
        //}
        //confirm = false;

    }
}

/// <summary>
/// Модель представления 
/// </summary>
public class PeriodViewModel
{
    /// <summary>
    /// Год
    /// </summary>
    [Required]
    public int Year { get; set; } = DateTime.Now.Year;
    /// <summary>
    /// Месяц
    /// </summary>
    [Required]
    public MonthName Month { get; set; }
}

public enum MonthName
{
    [Display(Name = "Не выбран")]
    None = 0,

    [Display(Name = "Январь")]
    January = 1,

    [Display(Name = "Февраль")]
    February = 2,

    [Display(Name = "Март")]
    March = 3,

    [Display(Name = "Апрель")]
    April = 4,

    [Display(Name = "Май")]
    May = 5,

    [Display(Name = "Июнь")]
    June = 6,

    [Display(Name = "Июль")]
    Jule = 7,

    [Display(Name = "Август")]
    August = 8,

    [Display(Name = "Сентябрь")]
    September = 9,

    [Display(Name = "Октябрь")]
    October = 10,

    [Display(Name = "Ноябрь")]
    November = 11,

    [Display(Name = "Декабрь")]
    December = 12
}
