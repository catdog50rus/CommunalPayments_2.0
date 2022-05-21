﻿namespace CnD.CommunalPayments.Contracts.Models.Periods.Response;

public class CreatePeriodResponse
{
    public int Id { get; init; }

    /// <summary>
    /// Год
    /// </summary>
    public string Year { get; init; }

    /// <summary>
    /// Название месяца
    /// </summary>
    public string Month { get; init; }
}