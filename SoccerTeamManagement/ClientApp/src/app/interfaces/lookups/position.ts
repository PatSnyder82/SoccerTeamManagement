import { ILookup } from "./lookup";
import { IPositionCategory } from "./position-category";

export interface IPosition extends ILookup {
  abbreviation: string;

  positionCategoryId: number;
  positionCategory: IPositionCategory;
}
