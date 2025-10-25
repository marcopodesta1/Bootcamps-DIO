import { PlayerModel } from "../models/player-model";
import { StatisticsModel } from "../models/statistics-model";
import * as PlayerRepository from "../repositories/players-repository";
import * as HttpResponse from "../utils/http-helper";

export const getPlayerService = async () => {
  const data = await PlayerRepository.findAllPlayers();
  let response = null;

  response = data ? await HttpResponse.ok(data)
                  : await HttpResponse.noContent();

  return response;
};

export const getPlayerByIdService = async (id: number) => {
  //pedir pro positório de daddos
  const data = await PlayerRepository.findPlayerById(id);
  let response = null;

  response = data ? await HttpResponse.ok(data)
                  : await HttpResponse.noContent();

  return response;
};

export const createPlayerService = async (player: PlayerModel) => {
  let response = null;
  
  // verifica se está vazio 
  if (player) { 
    await PlayerRepository.insertPlayer(player);
    response = await HttpResponse.created();
  } else {
    response = await HttpResponse.badRequest(); 
  }

  return response
};

export const deletePlayerService = async (id: number) => {
  const isDeleted = await PlayerRepository.deleteOnePlayer(id);

  let response = isDeleted ? await HttpResponse.ok({ message: "deleted" })
                           : await HttpResponse.badRequest(); 

  return response;
}

export const updatePlayerService = async (id: number, statistics: StatisticsModel) => {
  const data = await PlayerRepository.findAndModifyPlayer(id, statistics);

  let response = data ? await HttpResponse.ok(data)
                      : await HttpResponse.badRequest(); 

  return response;
};
