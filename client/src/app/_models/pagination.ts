
export interface Pagination
{
    currentPage: number;
    itemsPerPage: number;
    totalItems: number;
    totalPages: number;
}

export class PaginatedResult<T>{
    /* T is a an array of members , Members[]*/
    result: T;
    pagination: Pagination;
}