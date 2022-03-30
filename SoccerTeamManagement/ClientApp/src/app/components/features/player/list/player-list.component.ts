import { Component, Inject, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { IPlayer } from '../../../../interfaces/player';
import { PlayerService } from '../../../../services/player.service';

@Component({
  selector: 'sm-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.scss']
})
export class PlayerListComponent implements OnInit, OnDestroy {
  //#region Properties

  displayedColumns: string[];
  players: MatTableDataSource<IPlayer>;
  errorMessage: string;

  defaultPageIndex: number;
  defaultPageSize: number;
  defaultSortColumn: string;
  defaultSortOrder: string;
  defaultFilterColumn: string;
  filterQuery: string;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  filterTextChanged: Subject<string>;
  subscriptions: Subscription[];
  //#endregion

  //#region Constructor

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private playerService: PlayerService) {
    this.displayedColumns = ['id', 'firstName', 'lastName', 'nickName'];
    this.subscriptions = new Array<Subscription>();
    this.players = new MatTableDataSource();
  }

  //#endregion

  //#region Events

  public ngOnDestroy() {
    if (this.subscriptions) {
      this.subscriptions.forEach(subscription => subscription.unsubscribe);
    }
  }

  ngOnInit() {
    this.initialize();
  }

  onFilterTextChanged(filterText: string) {
    if (this.filterTextChanged.observers.length === 0) {
      this.subscriptions.push(this.filterTextChanged
        .pipe(debounceTime(1000), distinctUntilChanged())
        .subscribe(query => {
          this.loadData(query);
        }));
    }

    this.filterTextChanged.next(filterText);
  }

  //#endregion

  //#region Methods

  getData(event: PageEvent) {
    const pageIndex = +event.pageIndex;
    const pageSize = +event.pageSize;
    const sortColumn = this.sort ? this.sort.active : this.defaultSortColumn;
    const sortOrder = this.sort ? this.sort.direction : this.defaultSortOrder;
    const filterColumn = this.defaultFilterColumn;
    const filterQuery = this.filterQuery;

    this.subscriptions.push(this.playerService.getTableData(pageIndex, pageSize, sortColumn, sortOrder, filterColumn, filterQuery)
      .subscribe(
        tableData => {
          this.paginator.length = tableData.totalCount;
          this.paginator.pageIndex = tableData.pageIndex;
          this.paginator.pageSize = tableData.pageSize;
          this.players = new MatTableDataSource<IPlayer>(tableData.data);
        },
        error => this.errorMessage = error as string));
  }

  private initialize() {
    this.defaultPageIndex = 0;
    this.defaultPageSize = 10;
    this.defaultSortColumn = "id";
    this.defaultSortOrder = "asc";
    this.defaultFilterColumn = "lastname";
    this.filterQuery = '';
    this.filterTextChanged = new Subject<string>();

    this.loadData(null);
  }

  loadData(query: string = null) {
    var pageEvent = new PageEvent();
    pageEvent.pageIndex = this.defaultPageIndex;
    pageEvent.pageSize = this.defaultPageSize;

    query = !query ? '' : query;

    this.filterQuery = query;

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
