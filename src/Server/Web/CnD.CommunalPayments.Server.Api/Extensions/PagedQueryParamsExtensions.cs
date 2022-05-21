﻿using CnD.CommunalPayments.Server.Domen.Core.Query;

namespace CnD.CommunalPayments.Server.Api.Extensions;

public static class PagedQueryParamsExtensions
{
    private static int _defaultPageSize = 20;
    private static int _defaultPageIndex = 0;

    public static PagedListQueryParams ParseToPages(this IQueryCollection query)
    {
        var pageSize = query.FirstOrDefault(x => x.Key == "pageSize").Value;
        var pageIndex = query.FirstOrDefault(x => x.Key == "pageIndex").Value;
        var sortDirection = query.FirstOrDefault(x => x.Key == "sortDirection").Value;
        var search = query.FirstOrDefault(x => x.Key == "search").Value;

        if (!int.TryParse(pageIndex, out int intPageIndex))
            intPageIndex = _defaultPageIndex;

        if (!int.TryParse(pageSize, out int intPageSize))
            intPageSize = _defaultPageSize;

        var pagedListQueryParams = new PagedListQueryParams
        {
            PageIndex = intPageIndex < 0 ? _defaultPageIndex : intPageIndex,
            PageSize = intPageSize <= 0 ? _defaultPageSize : intPageSize,
            SortDirection = string.IsNullOrWhiteSpace(sortDirection) ? QueryParamsSortDirection.Ascending : QueryParamsSortDirection.Descending,
            Search = string.IsNullOrWhiteSpace(search) ? string.Empty : search
        };

        return pagedListQueryParams;
    }
}