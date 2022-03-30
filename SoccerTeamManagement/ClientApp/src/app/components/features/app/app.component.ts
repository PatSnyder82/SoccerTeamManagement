import { Component } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'sm-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  //#region Properties

  errorMessage: string;
  isNavigationExpanded: boolean;
  subscriptions: Subscription[];
  title = 'app';

  //#endregion

  //#region Constructor

  constructor() {
    this.isNavigationExpanded = true;
  }

  //#endregion
}
