using Application.Interfaces.Presentation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller.common;

public class ListQueryParams : IListQueryParams
{
    /*
     * Поиск.
     */
    [FromQuery] public string? Search { get; set; }

    /*
     * Фильтры.
     */
    [FromQuery] public int? CompanyId { get; set; }

    /*
    * Сортировка.
    */
    [FromQuery] public string? SortBy { get; set; }
    [FromQuery] public bool? Desc { get; set; }

    /*
     * Пагинация.
     */
    [FromQuery] public int? From { get; set; }
    [FromQuery] public int? Step { get; set; }
}