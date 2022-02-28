import { Link } from "./link";

export interface Image {
  id: number;
  alternativeText: string;
  width: number;
  height: number;
  style: string;
  title: string;
  caption: string;
  source: Link;
}
