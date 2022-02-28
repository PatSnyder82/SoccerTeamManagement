import { Address } from "./address";
import { Image } from "./image";
import { Phone } from "./phone";
import { NationLookup } from "./nationLookup";

export interface Person {
  id: number;
  firstName: string;
  lastName: string;
  nickName: string;
  isAdult: boolean;

  phone: Phone;
  address: Address;
  photo: Image;
  nation: NationLookup;
}
