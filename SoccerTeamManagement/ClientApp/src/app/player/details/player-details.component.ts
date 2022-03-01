import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators, AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Player } from '../../interfaces/player';
import { CountryLookup } from '../../interfaces/countryLookup';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-player-details',
  templateUrl: './player-details.component.html',
  styleUrls: ['./player-details.component.css']
})
export class PlayerDetailsComponent implements OnInit {
  //#region Properties

  title: string;
  form: FormGroup;

  player: Player;
  countries: CountryLookup[];
  id: number;

  //#endregion

  //#region Constructor

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  //#endregion

  //#region Events

  ngOnInit() {
    this.initialize();
  }

  onSubmit() {
    /*var player = (this.id) ? this.player : <Player>{};

    player.name = this.form.get("name").value;
    player.lat = +this.form.get("lat").value;
    player.lon = +this.form.get("lon").value;
    player.countryId = +this.form.get("countryId").value;

    if (this.id) {
      // EDIT mode

      var url = this.baseUrl + "api/Cities/" + this.city.id;
      this.http
        .put<City>(url, city)
        .subscribe(result => {
          console.log("City " + city.id + " has been updated.");

          // go back to cities view
          this.router.navigate(['/cities']);
        }, error => console.error(error));
    }
    else {
      // ADD NEW mode
      var url = this.baseUrl + "api/Cities";
      this.http
        .post<City>(url, city)
        .subscribe(result => {
          console.log("City " + result.id + " has been created.");

          // go back to cities view
          this.router.navigate(['/cities']);
        }, error => console.error(error));
    }*/
  }

  //#endregion

  //#region Methods
  private initialize() {
    this.intializeFormGroup();
    this.loadData();
    this.loadCountries();
  }

  private intializeFormGroup() {
    this.form = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      nickName: new FormControl('', Validators.required),
      isAdult: new FormControl('', Validators.required),
      height: new FormControl('', Validators.required),
      weight: new FormControl('', Validators.required),
      foot: new FormControl('', Validators.required),
      flareRating: new FormControl('', Validators.required),
      nation: new FormControl('', Validators.required)
      /*//Phone
      countryCode: new FormControl('', Validators.required),
      areaCode: new FormControl('', Validators.required),
      extension: new FormControl('', Validators.required),
      number: new FormControl('', Validators.required),
      phoneType: new FormControl('', Validators.required),
      //Address
      addressLine1: new FormControl('', Validators.required),
      addressLine2: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      country: new FormControl('', Validators.required),
      state: new FormControl('', Validators.required),
      zipCode: new FormControl('', Validators.required),
      //Photo
      image: new FormControl('', Validators.required),
      //Nation
      nation: new FormControl('', Validators.required),
      //Attributes
      //Teams
      teams: new FormControl('', Validators.required),
      positions: new FormControl('', Validators.required),
      parents: new FormControl('', Validators.required),*/
    });
  }

  loadCountries() {
    // fetch all the countries from the server
    var url = this.baseUrl + "api/CountryLookup/";

    var params = new HttpParams()
      .set("pageIndex", "0")
      .set("pageSize", "9999")
      .set("sortColumn", "SortOrder")
      .set("sortOrder", "ASC");

    this.http.get<any>(url, { params }).subscribe(result => {
      this.countries = result.data;
    }, error => console.error(error));
  }

  loadData() {
    // retrieve the ID from the 'id'
    this.id = +this.activatedRoute.snapshot.paramMap.get('id');

    var url = this.baseUrl + "api/Players/" + this.id;

    this.http.get<Player>(url).subscribe(result => {
      this.player = result;
      this.title = "Edit - " + this.player.firstName + " " + this.player.lastName;

      this.form.patchValue(this.player);
    }, error => console.error(error));
  }

  //#endregion
}
