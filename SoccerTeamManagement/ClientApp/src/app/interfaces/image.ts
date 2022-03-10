import { IEntity } from "./entity";

export interface IImage extends IEntity {
  alternativeText: string;
  width: number;
  height: number;
  style: string;
  title: string;
  caption: string;
  url: string;
}
