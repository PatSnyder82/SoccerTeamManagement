import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'sm-nav-top-menu',
  templateUrl: './nav-top-menu.component.html',
  styleUrls: ['./nav-top-menu.component.scss']
})
export class NavTopMenuComponent {
  // #region Properties


  public isExpanded: boolean;
  public isHidden: boolean;

  //#endregion

  //#region Constructor

  constructor(router: Router) {
    this._initialize();
    this._registerRoutesToHideOn(router);
  }

  //#endregion

  //#region Events

  public collapse(): void {
    this.isExpanded = false;
  }

  public toggle(): void {
    this.isExpanded = !this.isExpanded;
  }

  //#endregion

  //#region Methods

  private _initialize(): void {
    this.isExpanded = false;
    this.isHidden = false;
  }

  private _registerRoutesToHideOn(router: Router): void {
    router.events.subscribe(() => {
      if (router.url === '/')
        this.isHidden = true;
      else
        this.isHidden = false;
    });
  }

  //#endregion
}
