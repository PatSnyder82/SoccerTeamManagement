import { Lookup } from "./lookup";

export interface NationLookup extends Lookup {
  alpha2Code: string;
  alpha3Code: string;
}
