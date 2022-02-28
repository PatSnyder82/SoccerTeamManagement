import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { Player } from '../interfaces/player';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {
  //#region Properties

  public displayedColumns: string[] = ['id', 'firstName', 'lastName', 'nation'];
  public players: MatTableDataSource<Player>;

  defaultPageIndex: number;
  defaultPageSize: number;
  public defaultSortColumn: string;
  public defaultSortOrder: string;
  defaultFilterColumn: string;
  filterQuery: string;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  filterTextChanged: Subject<string>;

  //#endregion

  //#region Constructor

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.initializeProperties();
  }

  //#endregion

  ngOnInit() {
    this.initializeProperties();
  }

  loadData(query: string = null) {
    var pageEvent = new PageEvent();
    pageEvent.pageIndex = this.defaultPageIndex;
    pageEvent.pageSize = this.defaultPageSize;

    if (query) {
      this.filterQuery = query;
    }

    this.getData(pageEvent);
  }

  getData(event: PageEvent) {
    var url = this.baseUrl + 'api/Players';
    var params = this.setParameters(event);

    if (this.filterQuery) {
      params = params.set("filterColumn", this.defaultFilterColumn)
        .set("filterQuery", this.filterQuery);
    }

    this.http.get<any>(url, { params }).subscribe(result => {
      this.paginator.length = result.totalCount;
      this.paginator.pageIndex = result.pageIndex;
      this.paginator.pageSize = result.pageSize;
      this.players = new MatTableDataSource<Player>(result.data);
    }, error => console.error(error));
  }

  setParameters(event: PageEvent): HttpParams {
    return new HttpParams()
      .set("pageIndex", event.pageIndex.toString())
      .set("pageSize", event.pageSize.toString())
      .set("sortColumn", (this.sort)
        ? this.sort.active
        : this.defaultSortColumn)
      .set("sortOrder", (this.sort)
        ? this.sort.direction
        : this.defaultSortOrder);
  }

  initializeProperties() {
    this.defaultPageIndex = 0;
    this.defaultPageSize = 10;
    this.defaultSortColumn = "id";
    this.defaultSortOrder = "asc";
    this.defaultFilterColumn = "name";
    this.filterQuery = null;
    this.filterTextChanged = new Subject<string>();

    this.loadData(null);
  }
}
