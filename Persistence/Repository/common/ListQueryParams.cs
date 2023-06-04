using Microsoft.AspNetCore.Mvc;

namespace Persistence.Repository.common;

public class ListQueryParams
{
    /*
     * Поиск.
     * Сервер сам решает по каким полям он будет производить поиск.
     */
    [FromQuery] public string? Search { get; set; }
    // public string? Search2 { get; set; }

    /*
     * Фильтры.
     */
    [FromQuery] public int? CompanyId { get; set; }

    /*
    * Сортировка.
    * Варианты использования:
    *   sortBy=поле         - по возрастанию
    *   sortBy=поле&desc=1  - по убыванию
    */
    [FromQuery] public string? SortBy { get; set; }

    [FromQuery] public bool? Desc { get; set; }
    // [FromQuery] public string? SortBy2 { get; set; }
    // [FromQuery] public bool? Desc2 { get; set; }

    /*
     * Пагинация.
     */
    [FromQuery] public int? From { get; set; }
    [FromQuery] public int? Step { get; set; }
}