﻿namespace Ookly.Core.Entities;

public class Filter : NamedEntity
{
    public int CategoryId { get; init; }
    public Category Category { get; init; } = new();

    public FilterType Type { get; init; }
    public FilterSort Sort { get; init; }
    public int Order { get; init; }

    public int? ParentId { get; init; }
    public Filter? Parent { get; init; } = new();

    public List<CountryCategory> CountryCategories { get; init; } = [];
}

public enum FilterType
{
    Text,
    Numeric,
    Boolean
}

public enum FilterSort
{
    FilterNameAsc,
    FilterNameDesc,
    DocCountAsc,
    DocCountDesc
}
