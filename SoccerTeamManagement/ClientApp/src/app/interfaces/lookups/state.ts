import { Lookup } from "./lookup";
import { Country } from "./country";

export interface State extends Lookup {
  alpha2Code: string;

  countryId: number;
  country: Country;
}
