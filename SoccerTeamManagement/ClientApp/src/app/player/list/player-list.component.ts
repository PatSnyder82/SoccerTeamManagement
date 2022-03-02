import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { Player } from '../../interfaces/player';

@Component({
  selector: 'app-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.scss']
})
export class PlayerListComponent implements OnInit {
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
  }

  //#endregion

  //#region Events

  ngOnInit() {
    this.initialize();
  }

  onFilterTextChanged(filterText: string) {
    if (this.filterTextChanged.observers.length === 0) {
      this.filterTextChanged
        .pipe(debounceTime(1000), distinctUntilChanged())
        .subscribe(query => {
          this.loadData(query);
        });
    }
    this.filterTextChanged.next(filterText);
  }

  //#endregion

  //#region Methods

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

  private initialize() {
    this.defaultPageIndex = 0;
    this.defaultPageSize = 10;
    this.defaultSortColumn = "id";
    this.defaultSortOrder = "asc";
    this.defaultFilterColumn = "name";
    this.filterQuery = null;
    this.filterTextChanged = new Subject<string>();

    this.loadData(null);
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

  private setParameters(event: PageEvent): HttpParams {
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

  //#endregion
}
