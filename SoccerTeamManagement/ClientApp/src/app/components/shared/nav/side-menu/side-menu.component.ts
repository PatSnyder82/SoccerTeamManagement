import { Component, Input } from '@angular/core';
import { TooltipPosition } from '@angular/material/tooltip';
import { ActivatedRoute, Router } from '@angular/router';
import { faFutbol as farFutbol, IconDefinition } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'sm-nav-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.scss']
})
export class SideMenuComponent {
  // #region Properties

  @Input() isExpanded: boolean;
  @Input() isHidden: boolean;
  tooltipPosition: TooltipPosition;
  public futbolIcon: IconDefinition;
  // #endregion

  // #region Constructor

  constructor(protected router: Router, private route: ActivatedRoute) {
    this._initialize();
    this.futbolIcon = farFutbol;
    this._registerRoutesToHideOn(router);
  }

  // #endregion

  // #region Methods

  private _initialize() {
    this.isExpanded = true;
    this.isHidden = false;
    this.tooltipPosition = 'above';
  }

  private _registerRoutesToHideOn(router: Router) {
    router.events.subscribe(() => {
      if (router.url === '/')
        this.isHidden = true;
      else
        this.isHidden = false;
    });
  }

  // #endregion
}
