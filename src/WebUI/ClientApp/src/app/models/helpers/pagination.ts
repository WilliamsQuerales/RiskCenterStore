export class Pagination {
    currentPage: number;
    totalItems: number;
    paginationSize: number;

    constructor() {
        this.currentPage = 0;
        this.totalItems = 0;
        this.paginationSize = 10;
    }

    get totalPages() : number {
        return Math.ceil(this.totalItems / this.paginationSize);
    }

    get pages() {
        let pages = [];
        
        for(let i = 1; i < this.totalPages; i++ )
            pages.push(i)
        
        return pages;
    }
}