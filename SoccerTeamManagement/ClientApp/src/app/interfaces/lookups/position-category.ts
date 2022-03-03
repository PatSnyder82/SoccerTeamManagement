import { Lookup } from "./lookup";
import { Position } from "./position";

export interface PositionCategory extends Lookup {
  positions: Position[];
}
