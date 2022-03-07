import { IImage } from "./image";
import { ITeam } from "./team";

export interface IClub {
  id: number;
  name: string;
  image: IImage;
  teams: ITeam[];
}
