import { IAddress } from "./address";
import { IImage } from "./image";
import { IPhone } from "./phone";
import { ICountry } from "./lookups/country";
import { IEntity } from "./entity";

export interface IPerson extends IEntity {
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
