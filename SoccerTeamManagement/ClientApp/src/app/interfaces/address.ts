import { Country } from './lookups/country';
import { State } from './lookups/state';

export interface Address {
  id: number;
  addressLine1: string;
  addressLine2: string;
  city: string;
  zipCode: string;

  countryId: number;
  country: Country;
  stateId: number;
  state: State;
}
