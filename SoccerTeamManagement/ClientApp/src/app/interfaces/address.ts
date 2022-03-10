import { IEntity } from './entity';
import { ICountry } from './lookups/country';
import { IState } from './lookups/state';

export interface IAddress extends IEntity  {
  addressLine1: string;
  addressLine2: string;
  city: string;
  zipCode: string;

  countryId: number;
  country: ICountry;
  stateId: number;
  state: IState;
}
