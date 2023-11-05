﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

using Ookly.Core.Interfaces;
using Ookly.UseCases.SearchUseCase;

namespace Ookly.Web.ModelBinders;

public class SearchUseCaseRequestModelBinder(
    ICountryRepository countryRepository,
    ICategoryRepository categoryRepository,
    ICountryCategoryRepository countryCategoryRepository,
    IFilterRepository filterRepository) : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        var countryName = bindingContext.GetFirstValue("country");
        var country = await countryRepository.FirstByNameAsync(countryName);

        var categoryName = bindingContext.GetFirstValue("category");
        var category = await categoryRepository.FirstByNameAsync(categoryName);

        var countryCategory = await countryCategoryRepository.FirstByCountryIdAndCategoryIdAsync(country.Id, category.Id);

        var filters = await filterRepository.ListByCountryCategoryIdNameAsync(countryCategory.Id);
        var filterNames = filters.Select(f => f.Name).ToList();
        var filterValues = GetFilterValues(filterNames, bindingContext);

        bindingContext.Result = ModelBindingResult.Success(new SearchUseCaseRequest { CountryId = countryName, CategoryId = categoryName, FilterValues = filterValues });
        await Task.CompletedTask;
    }

    private static Dictionary<string, string> GetFilterValues(List<string> categoryFilterIds, ModelBindingContext bindingContext)
    {
        return categoryFilterIds
            .ToDictionary(k => k, v => bindingContext.ValueProvider.GetValue(v).FirstValue ?? string.Empty)
            .Where(i => i.Value != string.Empty)
            .ToDictionary(k => k.Key, v => v.Value);
    }
}
