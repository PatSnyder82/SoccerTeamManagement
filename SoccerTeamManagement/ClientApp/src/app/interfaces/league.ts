import { IImage } from "./image";
import { ITeam } from "./team";

export interface ILeague {
  id: number;
  name: string;
  logo: IImage;
  teams: ITeam[];
}
