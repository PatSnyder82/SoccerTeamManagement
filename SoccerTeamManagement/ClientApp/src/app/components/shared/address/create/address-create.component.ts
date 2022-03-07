import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupDirective } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ICountry } from '../../../../interfaces/lookups/country';
import { IState } from '../../../../interfaces/lookups/state';

@Component({
  selector: 'sm-address-create',
  templateUrl: './address-create.component.html',
  styleUrls: ['./address-create.component.scss']
})
export class AddressCreateComponent implements OnInit {
  //#region Properties

  parentForm: FormGroup;
  address!: FormGroup;

  countries: ICountry[];
  states: IState[];

  //#endregion

  //#region Constructor

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder, private rootFormGroup: FormGroupDirective) {
  }

  //#endregion

  //#region Event

  ngOnInit(): void {
    this.parentForm = this.rootFormGroup.control;

    this._getCountries();
  }

  onCountryChange(countryId: number) {
    if (countryId === 237 && this.states == null) {
      this._getStates(countryId);
    }
  }

  //#endregion

  //#region Methods

  private _getCountries(): void {
    var url = this.baseUrl + "api/Country/";

    var params = new HttpParams()
      .set("pageIndex", "0")
      .set("pageSize", "9999")
      .set("sortColumn", "SortOrder")
      .set("sortOrder", "ASC");

    this.http.get<any>(url, { params }).subscribe(result => {
      this.countries = result.data;
    }, error => console.error(error));
  }

  private _getStates(countryId: number) {
    // fetch all states for the specified country
    var url = this.baseUrl + "api/State/getstatesbycountry/" + countryId;;

    this.http.get<IState[]>(url,).subscribe(result => {
      this.states = result;
    }, error => console.error(error));
  }

  //#endregion
}
