import { Lookup } from "./lookup";
import { State } from "./state";

export interface Country extends Lookup {
  alpha2Code: string;
  alpha3Code: string;

  states: State[];
}
