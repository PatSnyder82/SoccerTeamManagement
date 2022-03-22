import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPlayer } from '../interfaces/player';
import { AddressService } from './address.service';
import { BaseService } from './base.service';
import { CountryService } from './country.service';
import { ImageService } from './image.service';
import { PhoneService } from './phone.service';
import { PlayerPositionService } from './player-position.service';

@Injectable({
  providedIn: 'root'
})
export class PlayerService extends BaseService<IPlayer> {
  constructor(
    http: HttpClient,
    @Inject('BASE_URL') protected baseUrl: string,
    public formBuilder: FormBuilder,
    private addressService: AddressService,
    private countryService: CountryService,
    private imageService: ImageService,
    private phoneService: PhoneService,
    private playerService: PlayerService,
    private playerPositionService: PlayerPositionService
  ) {
    super(http, 'players/', baseUrl);
  }

  public getFormGroup(): FormGroup {
    const unsignedInt999Pattern = new RegExp('^[1-9]\\d{0,2}$');

    return this.formBuilder.group({
      id: [0],
      firstName: ['', [Validators.required, Validators.maxLength(100)]],
      lastName: ['', [Validators.required, Validators.maxLength(100)]],
      nickName: ['', [Validators.maxLength(100)]],
      height: [null, [Validators.min(0), Validators.max(999), Validators.pattern(unsignedInt999Pattern)]],
      weight: [null, [Validators.min(0), Validators.max(9999), Validators.pattern(unsignedInt999Pattern)]],
      foot: [1, [Validators.required]],
      weakFootRating: [1, [Validators.required]],
      flareRating: [1, [Validators.required]],
      countryId: [null, [Validators.required]],
      dateOfBirth: [null, [Validators.required]],
      attributesId: [null],
      imageId: [null],
      phoneId: [null],
      phone: this.phoneService.getFormGroup(),
      addressId: [null],
      address: this.addressService.getFormGroup(),
      positions: [null],
      playerPositions: [null],
      image: [null],      //TODO: this.imageService.getFormGroup()
      attributes: [null],
      teamPlayers: [null],
      parents: [null]
    });
  }
}
