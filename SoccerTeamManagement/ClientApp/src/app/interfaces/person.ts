import { IAddress } from "./address";
import { IImage } from "./image";
import { IPhone } from "./phone";
import { ICountry } from "./lookups/country";

export interface IPerson {
  id: number;
  firstName: string;
  lastName: string;
  nickName: string;

  dateOfBirth: Date;
  phoneId: number;
  phone: IPhone;
  addressId: number;
  address: IAddress;
  imageId: number;
  image: IImage;
  countryId: number;
  country: ICountry;
}
