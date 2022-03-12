import { catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs';

//import 'rxjs/add/operator/do';
//import 'rxjs/add/operator/map';

export abstract class BaseService<T> {
  protected api: string;
  protected endpoint: string;
  public url: string;
  protected version: string;

  protected defaultPageIndex: number;
  protected defaultPageSize: number;
  protected defaultSortColumn: string;
  protected defaultSortOrder: string;
  protected defaultFilterColumn: string;
  protected defaultFilterQuery: string;

  constructor(protected http: HttpClient, endpoint: string, @Inject('BASE_URL') protected baseUrl: string) {
    this.api = 'api/';
    this.version = ''; //TODO: update backend API to include version 'v1/' in url path
    this.endpoint = endpoint;

    this.url = this.baseUrl + this.api + this.version + this.endpoint;

    this.defaultPageIndex = 0;
    this.defaultPageSize = 10;
    this.defaultSortColumn = 'id';
    this.defaultSortOrder = 'asc';
    this.defaultFilterColumn = '';
    this.defaultFilterQuery = '';
  }

  delete(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + id.toString())
      .pipe(catchError(this.handleError));
  }

  getById(id: number): Observable<T> {
    return this.http.get<T>(this.url + id.toString())
      .pipe(catchError(this.handleError));
  }

  getTableData(pageIndex: number = this.defaultPageIndex, pageSize: number = this.defaultPageSize,
    sortColumn: string = this.defaultSortColumn, sortOrder: string = this.defaultSortOrder,
    filterColumn: string = this.defaultFilterColumn, filterQuery: string = this.defaultFilterQuery): Observable<ITableData<T>> {
    const url = this.url + 'tabledata/';
    const params = new HttpParams()
      .set("pageIndex", pageIndex)
      .set("pageSize", pageSize)
      .set("sortColumn", sortColumn)
      .set("sortOrder", sortOrder)
      .set("filterColumn", filterColumn)
      .set("filterQuery", filterQuery);

    return this.http.get<ITableData<T>>(url, { params })
      .pipe(catchError(this.handleError));
  }

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.url)
      .pipe(catchError(this.handleError));
  }

  update(item: T): Observable<T> {
    return this.http.put<T>(this.url, item)
      .pipe(catchError(this.handleError));
  }

  create(item: T): Observable<number> {
    return this.http.post<number>(this.url, item)
      .pipe(catchError(this.handleError));
  }

  // #region Protected Methods

  protected handleError(err: HttpErrorResponse) {
    return throwError(err.message || "server error");
  }

  protected isValidId(id: number) {
    if (id && id > 0) {
      return true;
    }

    return false;
  }

  protected urlOptionsHelper(url: string, options: string[]): string {
    let urlOptions = '';

    if (options) {
      for (const option of options) {
        urlOptions = urlOptions + option + '/';
      }
    }

    if (url.slice(-1) === '/') {
      url = url + urlOptions;
    }
    else {
      url = url + '/' + urlOptions;
    }

    return url;
  }

  // #endregion
}
