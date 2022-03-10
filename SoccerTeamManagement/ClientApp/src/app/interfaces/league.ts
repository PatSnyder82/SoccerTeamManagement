import { IEntity } from "./entity";
import { IImage } from "./image";
import { ITeam } from "./team";

export interface ILeague extends IEntity {
  id: number;
  name: string;
  logo: IImage;
  teams: ITeam[];
}
