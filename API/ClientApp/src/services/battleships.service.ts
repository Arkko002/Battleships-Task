/*eslint-disable*/
import Api from "./api";
import { GameState } from "@/models/GameState";

export function getGameState(): Promise<GameState> {
  return Api.get<GameState>("/state").then((res) => res.data);
}

export function nextMove(): Promise<GameState> {
  return Api.post<GameState>("/move").then((res) => res.data);
}

export function startNewGame(): Promise<GameState> {
  return Api.post<GameState>("/start").then((res) => res.data);
}
