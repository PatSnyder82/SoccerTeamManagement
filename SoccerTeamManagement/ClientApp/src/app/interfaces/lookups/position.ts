import { Lookup } from "./lookup";
import { PositionCategory } from "./position-category";

export interface Position extends Lookup {
  abbreviation: string;

  positionCategoryId: number;
  positionCategory: PositionCategory;
}
