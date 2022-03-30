import { OnInit } from '@angular/core';
import { Component, Input } from '@angular/core';
import { faPlus as fasPlus, IconDefinition } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'sm-button-create',
  templateUrl: './button-create.component.html',
  styleUrls: ['./button-create.component.scss']
})
export class ButtonCreateComponent implements OnInit {
  //#region Properties

  @Input() navigateTo = "/";
  @Input() toolTip = "Create New";
  public plusIcon: IconDefinition;

  //#endregion

  //#region Constructor

  constructor() {
    this.plusIcon = fasPlus;
  }

  //#endregion

  //#region Events

  ngOnInit(): void {
    this.navigateTo = this._leadingSlash(this.navigateTo);
    console.log("NAVIGATE TO: " + this.navigateTo);
  }

  //#endregion

  //#region Methods

  private _leadingSlash(url: string) {
    console.log("URL: " + url);
    if (url.charAt(0) === '/')
      return url;

    return '/' + url;
  }

  //#endregion
}
