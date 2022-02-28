import { Image } from "./image";
import { Team } from "./team";

export interface Club {
  id: number;
  name: string;
  image: Image;
  teams: Team[];
}
