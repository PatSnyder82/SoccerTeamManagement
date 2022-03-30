import { catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs';
import { IEntity } from '../interfaces/entity';

export abstract class BaseService<T> {
  //#region Properties

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

  //#endregion

  //#region Constructor

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

  //#endregion

  //#region Methods
  public abstract getFormGroup();

  delete(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + id.toString())
      .pipe(catchError(this.handleError));
  }

  getById(id: number): Observable<T> {
    if (id && id > 0) {
      return this.http.get<T>(this.url + id.toString())
        .pipe(catchError(this.handleError));
    }

    return null;
  }

  getTableData(pageIndex: number = this.defaultPageIndex, pageSize: number = this.defaultPageSize,
    sortColumn: string = this.defaultSortColumn, sortOrder: string = this.defaultSortOrder,
    filterColumn: string = this.defaultFilterColumn, filterQuery: string = this.defaultFilterQuery): Observable<ITable<T>> {
    const url = this.url + 'tabledata/';
    const params = new HttpParams()
      .set("pageIndex", pageIndex)
      .set("pageSize", pageSize)
      .set("sortColumn", sortColumn)
      .set("sortOrder", sortOrder)
      .set("filterColumn", filterColumn)
      .set("filterQuery", filterQuery);

    return this.http.get<ITable<T>>(url, { params })
      .pipe(catchError(this.handleError));
  }

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.url)
      .pipe(catchError(this.handleError));
  }

  update(item: T): Observable<boolean> {
    return this.http.put<boolean>(this.url, item)
      .pipe(catchError(this.handleError));
  }

  create(item: T): Observable<number> {
    return this.http.post<number>(this.url, item)
      .pipe(catchError(this.handleError));
  }

  //#endregion

  // #region Protected Methods

  protected isAnEntity(obj: any): obj is IEntity {
    return 'id' in obj;
  }

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
