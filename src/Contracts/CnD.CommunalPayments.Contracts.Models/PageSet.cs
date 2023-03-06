namespace CnD.CommunalPayments.Contracts.Models;

public struct PageSet
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public PageSet(int pageIndex = 0, int pageSize = 10000)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
    }
}
