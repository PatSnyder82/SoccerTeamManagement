import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IEntity } from '../../../interfaces/entity';
import { BaseService } from '../../../services/base.service';

@Component({
  selector: 'app-details-base',
  templateUrl: './details-base.component.html',
  styleUrls: ['./details-base.component.scss']
})
export abstract class DetailsBaseComponent<T> implements OnInit, OnDestroy {
  //#region Properties

  public controls;
  public abstract entity: IEntity;
  public errorMessage: string;
  public form: FormGroup;
  public id: number;
  public isCreateMode: boolean;
  public isReadOnly: boolean;
  public isLoading: boolean;
  public subscriptions: Subscription[];
  public title: string;

  //#endregion

  constructor(@Inject(String) public entityName: string, @Inject(String) public apiEndpoint: string, @Inject(String) public navEndpoint: string, public route: ActivatedRoute, public entityService: BaseService<IEntity>, public router: Router) {
    this.isLoading = true;
    this.subscriptions = new Array<Subscription>();
    this.id = this._initializeId();
    this.isCreateMode = this._intializeIsCreateMode(this.id);
    this.isReadOnly = this._intializeIsReadOnly(this.id);
    this.apiEndpoint = this._intializeApiEndPoint(this.apiEndpoint);
    this.title = this._setTitle(this.isCreateMode);
  }

  //#region Life Cycle Hooks

  public ngOnDestroy() {
    if (this.subscriptions) {
      this.subscriptions.forEach(subscription => subscription.unsubscribe);
    }
  }

  public ngOnInit() {
    this.form = this.initializeForm();

    if (this.isCreateMode) {
      this.isLoading = false;
    }
    else {
      this._disableForm();
      this.getEntity();
    }

    this.controls = this.initializeControlReferences();
  }

  //#endregion

  //#region Abstract Methods

  protected abstract initializeControlReferences();

  protected abstract initializeForm(): FormGroup;

  //protected abstract getEntity(): void;

  //#endregion

  public debugInvalidControls(): string[] {
    console.log("DEBUGGING INVALID FORM CONTROLS: >>>>>>>>>");
    const invalid = [];
    const controls = this.form.controls;
    for (const name in controls) {
      if (controls[name].invalid) {
        console.log("INVALID CONTROL: " + name);
        invalid.push(name);
      }
    }
    return invalid;
  }

  protected getEntity(): void {
    this.subscriptions.push(this.entityService.getById(this.id)
      .subscribe(
        data => {
          this.form.patchValue(data);
          this.isLoading = false;
          this.entity = data;
        },
        error => this.errorMessage = error as string));
  }

  public onReadonlyChange($event: MatSlideToggleChange): void {
    if (!this.isCreateMode) {
      if ($event.checked) {
        this._disableForm();
      }
      else {
        this._enableForm();
      }
    }
    else {
      this._enableForm();
    }
  }

  public onCreate(): void {
    this.subscriptions.push(this.entityService.create(this._getFormData())
      .subscribe(
        data => this.router.navigate([this.navEndpoint]),
        error => this.errorMessage = error as string));
  }

  public onUpdate(): void {
    this.subscriptions.push(this.entityService.update(this._getFormData())
      .subscribe(
        data => this.router.navigate([this.navEndpoint]),
        error => this.errorMessage = error as string));
  }

  public onSubmit(): void {
    if (this.form.valid) {
      if (this.isCreateMode) {
        this.onCreate();
      }
      else {
        this.onUpdate();
      }
    }
    else {
      this.form.markAllAsTouched();
    }
  }

  private _disableForm(): void {
    this.isReadOnly = true;
    this.form.disable();
  }

  private _enableForm(): void {
    this.isReadOnly = false;
    this.form.enable();
  }

  private _getFormData(): IEntity {
    let entity = {} as IEntity;
    entity = this.form.value;
    entity.id = this.id;

    return entity;
  }

  private _intializeApiEndPoint(endPoint: string) {
    endPoint = endPoint.trim();

    if (endPoint) {
      if (endPoint[endPoint.length - 1] !== '/') {
        endPoint += '/';
      }
    }

    return endPoint;
  }

  private _initializeId(): number {
    return +this.route.snapshot.paramMap.get('id');
  }

  private _intializeIsCreateMode(id: number): boolean {
    return ((id && id > 0) ? this.isCreateMode = false : this.isCreateMode = true);
  }

  private _intializeIsReadOnly(id: number): boolean {
    return ((id && id > 0) ? this.isReadOnly = true : this.isReadOnly = false);
  }

  private _setTitle(isCreateMode: boolean): string {
    return (isCreateMode ? 'Create ' : 'Edit ') + this.entityName;
  }
}
