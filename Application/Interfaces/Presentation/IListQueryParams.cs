namespace Application.Interfaces.Presentation;

public interface IListQueryParams
{
    /*
     * Поиск.
     * Сервер сам решает по каким полям он будет производить поиск.
     */
    string? Search { get; set; }
    // string? Search2 { get; set; }

    /*
     * Фильтры.
     */
    int? CompanyId { get; set; }

    /*
     * Сортировка.
     * Варианты использования:
     *   sortBy=поле         - по возрастанию
     *   sortBy=поле&desc=1  - по убыванию
     */
    string? SortBy { get; set; }

    bool? Desc { get; set; }

    // string? SortBy2 { get; set; }
    // public bool? Desc2 { get; set; }

    /*
     * Пагинация.
     */
    int? From { get; set; }
    int? Step { get; set; }
}