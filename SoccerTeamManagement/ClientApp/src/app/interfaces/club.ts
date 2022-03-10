import { IEntity } from "./entity";
import { IImage } from "./image";
import { ITeam } from "./team";

export interface IClub extends IEntity  {
  name: string;
  image: IImage;
  teams: ITeam[];
}
