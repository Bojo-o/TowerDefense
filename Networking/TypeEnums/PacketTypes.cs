using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefenseNetworking.TypeEnums
{
    public enum PacketTypes
    {
        Message, TowerAction, MonsterAction,
        WorldMap, ServerMessage, PlayersStatus, MonsterState,
        StartGameFlag, PlayerIsReadyFlag, PlayerID, TowerStats,
        MonstersStats, GameEnd, ServerIsFull, Connection, ClientDisconnection
    }
}
