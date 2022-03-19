import { IEntity } from './entity';
import { ICountry } from './lookups/country';
import { IState } from './lookups/state';

export interface IAddress extends IEntity {
  addressLine1: string;
  addressLine2: string;
  city: string;
  zipCode: string;

  country: ICountry;
  countryId: number;
  countryText: string;
  countryAlpha2Code: number;
  state: IState;
  stateId: number;
  stateText: string;
  stateAlpha2Code: number;
}
