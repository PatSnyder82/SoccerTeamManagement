import { Lookup } from "./lookup";

export interface CountryLookup extends Lookup {
  alpha2Code: string;
  alpha3Code: string;
}
