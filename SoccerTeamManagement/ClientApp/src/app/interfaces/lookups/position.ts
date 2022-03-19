import { ILookup } from "./lookup";
import { IPositionCategory } from "./position-category";

export interface IPosition extends ILookup {
  abbreviation: string;
  category: string;
  isPrimary: boolean;

  positionCategoryId: number;
  positionCategory: IPositionCategory;
}
