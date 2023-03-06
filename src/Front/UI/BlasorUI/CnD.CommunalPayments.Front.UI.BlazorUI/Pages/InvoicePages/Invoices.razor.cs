using CnD.CommunalPayments.Contracts.Models;
using CnD.CommunalPayments.Contracts.Models.Periods.Response;
using CnD.CommunalPayments.Contracts.Models.Providers.Response;
using CnD.CommunalPayments.Front.ApiClient;
using CnD.CommunalPayments.Front.UI.BlazorUI.Components;
using CnD.CommunalPayments.Front.ViewModels.Invoices;
using CnD.CommunalPayments.Front.ViewModels.Periods;
using CnD.CommunalPayments.Front.ViewModels.Providers;
using Microsoft.AspNetCore.Components;
using System;

namespace CnD.CommunalPayments.Front.UI.BlazorUI.Pages.InvoicePages;

public class InvoicesBase : ComponentBase
{
    #region ����, ������������� �����, ��������� ����

    /// <summary>
    /// ������ �������������
    /// </summary>
    protected InvoiceViewModel InvoiceViewModel = new();

    protected List<InvoicesListItemViewModel> InvoicesListViewModel = new();

    [Inject]
    public IInvoiceClientService InvoiceClientService { get; set; }

    [Inject]
    IPeriodClientService periodClient { get; set; }

    [Inject]
    IProviderClientService providersClient { get; set; }

    public List<Provider> Providers { get; set; }

    public List<Period> Periods { get; set; }

    public EventCallback<Invoice> OnClickSetService { get; set; }

    /// <summary>
    /// ������ ���������
    /// </summary>
    protected IEnumerable<Invoice> invoices;

    /// <summary>
    /// ���������
    /// </summary>
    protected Invoice invoice;

    protected bool isShowPaid = false;

    //Providers
    protected ProviderResponse provider;
    protected List<ProviderResponse> providersList;
    protected int IdProvider;

    //Periods
    protected PeriodResponse period;

    protected int IdPeriod;

    protected static int[] pageSizeList = new int[] { 10, 25, 50 };
    private int _pageOfSet = 0;
    private int _pageSize = pageSizeList[0];
    protected int totalItems = 0;

    //��������� ����
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
        _pageOfSet = page[0];
        _pageSize = page[1];
        await StateUpdate(isShowPaid);
    }

    protected override async Task OnInitializedAsync()
    {
        Periods = (await periodClient.GetAllAsync()).ToList();
        Providers = (await providersClient.GetAllAsync()).ToList();
        
        await StateUpdate(isShowPaid);
    }

    #endregion

    #region ��������� ������� ������

    /// <summary>
    /// �������� ��� ���������������
    /// </summary>
    protected async Task AddAsync()
    {
        //�������� �� ������ ������������� id
        var newInvoice = await InvoiceClientService.CreateAsync(InvoiceViewModel);

        if (newInvoice != null)
            invoice = newInvoice;

        await StateUpdate(isShowPaid);

        CloseModal();
    }

    /// <summary>
    /// �������� ������
    /// </summary>
    protected void Edit(int id)
    {
        ////������� ������ �������������
        //invoice = item;
        //OpenModal();

        //InvoiceViewModel.IdPeriod = invoice.IdPeriod.ToString();
        //InvoiceViewModel.IdProvider = invoice.IdProvider.ToString();
        //InvoiceViewModel.InvoiceSum = invoice.InvoiceSum;
    }

    /// <summary>
    /// ������� ������
    /// </summary>
    /// <param name="item"></param>
    protected async Task Remove(int id)
    {
        //await Repository.RemoveAsync(item.IdInvoice);
        //await StateUpdate(isNotPaided);
    }

    /// <summary>
    /// ������������� � ��������� ������
    /// </summary>
    /// <param name="item"></param>
    protected void SetService(int id)
    {
        //OnClickSetService.InvokeAsync(item);
    }

    /// <summary>
    /// ��������� � ������ ���������
    /// </summary>
    /// <param name="item"></param>
    protected void Pay(int id)
    {
        //invoice = item;
        //isPay = true;
    }

    /// <summary>
    /// ������ / �������� ���������� ���������
    /// </summary>
    /// <returns></returns>
    protected async Task ShowPaided()
    {
        isShowPaid = !isShowPaid;
        totalItems = 0;
        _pageOfSet = 0;
        await StateUpdate(isShowPaid);
    }

    /// <summary>
    /// ������� � ���������� ������ ��������� ����� ������
    /// </summary>
    protected void ReturnToPayment()
    {
        isShowPaid = false;
    }

    #endregion

    private async Task StateUpdate(bool show)
    {
        invoices = (await InvoiceClientService.GetAllAsync(new PageSet(_pageOfSet, _pageSize))).ToList();
        if (show)
        {
            invoices = invoices.Where(i => i.IsPaid == false);
            totalItems = invoices.Count();
        }

        foreach (var item in invoices)
        {
            InvoicesListViewModel.Clear();

            var period = Periods.FirstOrDefault(x => x.Id.Value == item.Id.Value);

            var provider = Providers.FirstOrDefault(x => x.Id.Value == item.Id.Value);

            InvoicesListViewModel.Add(new InvoicesListItemViewModel { Id = item.Id.Value, IsPaid = item.IsPaid, Sum = item.Sum, Period = period.ToString(), Provider = provider.NameProvider });
        }

        if(invoice != null)
        {
            var period = Periods.FirstOrDefault(x => x.Id.Value == invoice.Id.Value);

            var provider = Providers.FirstOrDefault(x => x.Id.Value == invoice.Id.Value);

            InvoicesListViewModel.Add(new InvoicesListItemViewModel { Id = invoice.Id.Value, IsPaid = invoice.IsPaid, Sum = invoice.Sum, Period = period.ToString(), Provider = provider.NameProvider });

            invoice = default;
        }
    }

    /// <summary>
    /// �������� URL � ������� �������� �� ����� ���������� �����
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    protected string GetWeb(int id) => Providers.FirstOrDefault(p => p.Id.Value == id).WebSite;
}