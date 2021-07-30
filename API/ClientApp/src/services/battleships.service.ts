import Api from "./api"
import {AxiosError} from "axios";
import {GameState} from "@/models/GameState";

export function getGameState(): Promise<GameState | void>  {
    return Api.get<GameState>("/getState")
        .then(res => {
            return res.data;
        }).catch((err: AxiosError) => {
            console.error(err.message);
        });
}

export function nextMove(): Promise<GameState | void> {
    return Api.post<GameState>("/nextMove")
        .then(res => {
            return res.data;
        }).catch((err: AxiosError) => {
            console.error(err.message);
        })
}

export function restartGame(): Promise<GameState | void> {
    return Api.post<GameState>("/restart")
        .then(res => {
            return res.data;
        }).catch((err: AxiosError) => {
            console.error(err.message)
        })
}