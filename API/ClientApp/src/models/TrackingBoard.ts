import {TrackingFieldState} from "@/models/TrackingFieldState";

export interface TrackingBoard {
    fields: TrackingFieldState[][]
    destroyedShipsCount: number;
    horizontalSize: number;
    verticalSize: number;
}