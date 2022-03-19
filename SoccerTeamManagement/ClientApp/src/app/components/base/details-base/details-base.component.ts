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
  public errorMessage: string;
  public form: FormGroup;
  public id: number;
  public isCreateMode: boolean;
  public isLoading: boolean;
  public isReadOnly: boolean;
  public subscriptions: Subscription[];
  public title: string;

  //#endregion

  constructor(@Inject(String) public entityName: string, @Inject(String) public navEndpoint: string, public route: ActivatedRoute, public entityService: BaseService<IEntity>, public router: Router) {
    this.errorMessage = '';
    this.id = this._initializeId();
    this.isCreateMode = this._intializeIsCreateMode(this.id);
    this.isLoading = true;
    this.isReadOnly = this._intializeIsReadOnly(this.id);
    this.subscriptions = new Array<Subscription>();
    this.title = this._setTitle(this.isCreateMode);
  }

  //#region Life Cycle Hooks

  public ngOnDestroy() {
    if (this.subscriptions) {
      this.subscriptions.forEach(subscription => subscription.unsubscribe);
    }
  }

  public ngOnInit() {
    this.form = this.entityService.getFormGroup();

    if (this.isCreateMode) {
      this.isLoading = false;
    }
    else {
      this._disableForm();
      this.getEntity();
    }

    this.controls = this.initializeControlReferences();
    //this.intializeComponent();
  }

  //#endregion

  //#region Abstract Methods
  protected abstract onEntityLoaded();
  protected abstract initializeControlReferences();
  
  //#endregion

  protected debugInvalidControls(): string[] {
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
          console.log("Entity Retrieved from API: " + JSON.stringify(data, null, 2));
          this.form.patchValue(data);
          this.isLoading = false;
        },
        error => this.errorMessage = error as string,
        () => this.onEntityLoaded()));
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

  public onCreate(entity: IEntity): void {
    this.subscriptions.push(this.entityService.create(entity)
      .subscribe(
        data => this.router.navigate([this.navEndpoint]),
        error => this.errorMessage = error as string));
  }

  public onUpdate(entity: IEntity): void {
    this.subscriptions.push(this.entityService.update(entity)
      .subscribe(
        data => this.router.navigate([this.navEndpoint]),
        error => this.errorMessage = error as string));
  }

  public onSubmit(): void {
    if (this.form.valid) {
      const entity = this.form.value;
      if (this.form.get('id').value < 1) {
        this.onCreate(entity);
      }
      else {
        this.onUpdate(entity);
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
