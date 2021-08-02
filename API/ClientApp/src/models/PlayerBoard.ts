import {Ship} from "@/models/Ship";

export interface PlayerBoard {
    fields: Ship[][];
    horizontalSize: number;
    verticalSize: number;
}