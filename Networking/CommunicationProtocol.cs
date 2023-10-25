using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using TowerDefenseNetworking.Stats;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseNetworking
{
    /// <summary>
    /// Abstraction of networking communication between the server(TCPListener) and clients(TCPClients).
    /// </summary>
    /// <remarks>
    /// When clients connect to the server,it creates <c>NetworkStream</c>, which provides methods for sending
    /// and receiving data.This class provides methods for sending and receving data, which represent
    /// Tower Defense game items, over this Stream.
    /// </remarks>
    public class CommunicationProtocol
    {
        /// <summary>
        /// Constants for header or payload sizes used in sending and receiving data blocks.
        /// </summary>
        private const int MapXSize = 1, MapYSize = 1;
        private const int monsterRenderInfo = 13;
        private const int PacketTypeSize = 1;
        private const int PlayerIDSize = 1;
        private const int TowerTypeSize = 1;
        private const int MonsterTypeSize = 1;
        private const int TowerActionHeaderSize = 11;
        private const int TextLenghtSize = 4;
        private const int PlayerStatusHeader = 12;
        private const int TowerStatsHeaderSize = 45;
        /// <value>
        /// The <c>_networkStream</c>is network stream of data for network acces.
        /// </value>
        private readonly NetworkStream _networkStream;
        /// <summary>
        /// Obtain stream from connection and assing it.
        /// </summary>
        /// <param name="client">Client connection to the server</param>
        public CommunicationProtocol(TcpClient client)
        {
            _networkStream = client.GetStream();
        }
        /// <summary>
        /// Help method, for converting number to bytes.
        /// </summary>
        /// <param name="value">Number, which will be represent as bytes</param>
        /// <returns>Array of bytes representing the integer number</returns>
        private byte[] ConvertIntToByteArr(int value)
        {
            var intAsByteArr = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(intAsByteArr);
            }
            return intAsByteArr;
        }
        /// <summary>
        /// Help method, for converting a number to bytes.
        /// </summary>
        /// <param name="value">Number,which will be represent as bytes</param>
        /// <returns>Array of bytes representing the double number</returns>
        private byte[] ConvertDoubleToByteArr(double value)
        {
            var doubleAsByteArr = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(doubleAsByteArr);
            }
            return doubleAsByteArr;
        }
        /// <summary>
        /// Help method, create new <c>OffsetStorer</c>,data array and assing the packet type type to beginning of the array.
        /// </summary>
        /// <param name="packetType">Represent type of packet, to know what data its represents over network</param>
        /// <param name="payloadSize">Size of payload of data block</param>
        /// <param name="offsetStorer">Help object to remember the offset, which is used at writing data to the stream</param>
        /// <returns>Array of bytes,with starting packet type,when will be stored data for sending over network</returns>
        private byte[] InitEmptyDataPackat(PacketTypes packetType, int payloadSize, out OffsetStorer offsetStorer)
        {
            var data = new byte[PacketTypeSize + payloadSize];
            offsetStorer = new OffsetStorer(0);
            WriteByte(data, (byte)packetType, offsetStorer);
            return data;
        }
        /// <summary>
        /// Writes byte value to the provided data.
        /// </summary>
        /// <remarks>
        /// Increase the offset, after writing the value to the data.
        /// </remarks>
        /// <param name="data">Data to which will be writed </param>
        /// <param name="value">Value, which will be writed to the data</param>
        /// <param name="offsetStorer">It remembers the offset in data, but can throw an exception index out range,
        /// because it stores only number. It serves to not must remember where we write in the data.
        /// </param>
        private void WriteByte(byte[] data, byte value, OffsetStorer offsetStorer)
        {
            data[offsetStorer.Offset] = value;
            offsetStorer.Increase(1);
        }

        private void WriteInt(byte[] data, int value, OffsetStorer offsetStorer)
        {
            var intAsBytes = ConvertIntToByteArr(value);
            Array.Copy(intAsBytes, 0, data, offsetStorer.Offset, 4);
            offsetStorer.Increase(4);
        }

        private void WriteDouble(byte[] data, double value, OffsetStorer offsetStorer)
        {
            var doubleAsBytes = ConvertDoubleToByteArr(value);
            Array.Copy(doubleAsBytes, 0, data, offsetStorer.Offset, 8);
            offsetStorer.Increase(8);
        }

        private void WriteString(byte[] data, string text, OffsetStorer positionStorer)
        {
            var textPayload = Encoding.ASCII.GetBytes(text);
            Array.Copy(textPayload, 0, data, positionStorer.Offset, text.Length);
            positionStorer.Increase(text.Length);
        }
        /// <summary>
        /// Read one byte value from the Stream.
        /// </summary>
        /// <param name="offset">Index where it begin read the data</param>
        /// <returns>Byte from Stream</returns>
        private byte ReadByte(int offset)
        {
            byte[] data = new byte[1];
            _networkStream.Read(data, offset, 1);
            return data[0];
        }

        private int ReadInt(int offset)
        {
            byte[] data = new byte[4];
            _networkStream.Read(data, offset, 4);
            return BitConverter.ToInt32(data, 0);
        }

        private double ReadDouble(int offset)
        {
            byte[] data = new byte[8];
            _networkStream.Read(data, offset, 8);
            return BitConverter.ToDouble(data, 0);
        }
        /// <summary>
        /// Read text value from the Stream.
        /// </summary>
        /// <param name="lenght">Represent lenght of text,for knowing how much to read from stream for obtaining text</param>
        /// <returns>Text from Stream</returns>
        private string ReadString(int offset, int lenght)
        {
            byte[] data = new byte[lenght];
            _networkStream.Read(data, offset, lenght);
            return Encoding.ASCII.GetString(data);
        }
        /// <summary>
        /// Writes the data to the Network stream, which represents sending data blocks to server/client.
        /// </summary>
        /// <param name="data">Data ready for sending over Stream</param>
        private void SendData(byte[] data)
        {
            _networkStream.Write(data, 0, data.Length);
        }
        /// <summary>
        /// Obtain type of receiving data from the Stream, to know how represents the data.
        /// </summary>
        /// <returns>Type of receiving packet</returns>        
        public PacketTypes GetPacketType()
        {
            return (PacketTypes)ReadByte(0);           
        }
        /// <summary>
        /// Indicates if data are available in the Stream.    
        /// </summary>
        /// <returns>true if Stream stores not yet processed data</returns>
        public bool DataAvailable()
        {
            return _networkStream.DataAvailable;
        }
        /// <summary>
        /// Send the text message over the network.
        /// </summary>
        /// <param name="message">Text, which will be sent over the network stream</param>
        public void SendMessage(string message)
        {
            var data = InitEmptyDataPackat(PacketTypes.Message, TextLenghtSize + message.Length, out OffsetStorer offsetStorer);
            WriteInt(data, message.Length, offsetStorer);
            WriteString(data, message, offsetStorer);
            SendData(data);
        }
        /// <summary>
        /// Read the text message from the network.
        /// </summary>
        /// <returns>Text message</returns>
        public string ReadMessage()
        {
            var messageLength = ReadInt(0);
            return ReadString(0, messageLength);
        }
        /// <summary>
        /// Send the Tower action, for example to notify the server that player want destory tower at the curtain grid, over the network.
        /// </summary>
        /// <param name="action">Stores the data of tower, such as what action we want do with the tower, where is this tower ..</param>
        public void SendTowerAction(TowerAction action)
        {
            var data = InitEmptyDataPackat(PacketTypes.TowerAction, TowerActionHeaderSize, out OffsetStorer offsetStorer);
            WriteInt(data, action.Location.X, offsetStorer);
            WriteInt(data, action.Location.Y, offsetStorer);
            WriteByte(data, (byte)action.TowerActionType, offsetStorer);
            WriteByte(data, (byte)action.TowerType, offsetStorer);
            WriteByte(data, (byte)action.PlayerID, offsetStorer);
            SendData(data);
        }
        /// <summary>
        /// Read the Tower action from the network.
        /// </summary>
        /// <returns>Struct, which stores items such as grid location, what action will be done with the tower</returns>
        public TowerAction ReadTowerAction()
        {            
            return new TowerAction
            {
                Location = new Point { X = ReadInt(0), Y = ReadInt(0) },
                TowerActionType = (TowerActionTypes)ReadByte(0),
                TowerType = (TowerTypes)ReadByte(0),
                PlayerID = (PlayerID)ReadByte(0)
            };
        }
        /// <summary>
        /// Send over the network action of monster,
        /// <remarks>
        /// Client send to notify the server that the player want buy a monster,
        /// server then procces that action and if acknowledges it, then send this action back to client,
        /// to know that action was successful.
        /// </summary>
        /// </remarks>
        /// <param name="monsterType">Stores all stats(damage,HP,movement speed..) representing some kind of monster</param>
        public void SendMonsterAction(MonsterTypes monsterType)
        {
            var data = InitEmptyDataPackat(PacketTypes.MonsterAction, MonsterTypeSize, out OffsetStorer offsetStorer);
            WriteByte(data,(byte)monsterType,offsetStorer);          
            SendData(data);
        }
        /// <summary>
        /// Read action of monster from the network.
        /// </summary>
        /// <returns>Type of monster, to know what type of the monster is it</returns>
        public MonsterTypes ReadMonsterAction()
        {            
            return (MonsterTypes)ReadByte(0);
        }
        /// <summary>
        /// Send flag over the network, which is only type of packet without playload.
        /// </summary>
        /// <param name="packetType">Type of packet</param>
        public void SendFlag(PacketTypes packetType)
        {
            var data = InitEmptyDataPackat(packetType, 0, out _);
            SendData(data);
        }
        /// <summary>
        /// Send the game map over the network. The client do not know game map,the server send the game map to client,
        /// so client know then render game map.
        /// </summary>
        /// <param name="map">Game map, represented as two dim array of tiles types,
        /// which represent kind of tile on that location in the game</param>
        public void SendWorldMap(TileTypes[,] map)
        {            
            var xSize = map.GetLength(1);
            var ySize = map.GetLength(0);
            var data = InitEmptyDataPackat(PacketTypes.WorldMap, MapXSize + MapYSize + (xSize * ySize), out OffsetStorer offsetStorer);
            WriteByte(data, (byte)xSize, offsetStorer);
            WriteByte(data, (byte)ySize, offsetStorer);

            for (byte y = 0; y < ySize; y++)
            {
                for (byte x = 0; x < xSize; x++)
                {
                    WriteByte(data, (byte)map[y, x], offsetStorer);
                }
            }
            SendData(data);
        }
        /// <summary>
        /// Read the game Map from the network.
        /// </summary>
        /// <returns>Game map as two dim array</returns>
        public TileTypes[,] ReadWorldMap()
        {           
            byte xSize = ReadByte(0);
            byte ySize = ReadByte(0);       
            TileTypes[,] map = new TileTypes[ySize, xSize];
            for (byte y = 0; y < ySize; y++)
            {
                for (byte x = 0; x < xSize; x++)
                {
                    map[y, x] = (TileTypes)ReadByte(0);
                }
            }
            return map;
        }
        /// <summary>
        /// Send over the network the status of player, what is state of HP ,how many golds player has available to buying, to that
        /// client can display current player stats.
        /// </summary>
        /// <param name="playerStatus">Stores all data which player need about his status of HP,Golds and enemy HP</param>
        public void SendPlayerState(PlayerStatus playerStatus)
        {
            var data = InitEmptyDataPackat(PacketTypes.PlayersStatus, PlayerStatusHeader, out OffsetStorer offsetStorer);
            WriteInt(data, playerStatus.HP, offsetStorer);
            WriteInt(data, playerStatus.Gold, offsetStorer);
            WriteInt(data, playerStatus.EnemyHP, offsetStorer);
            SendData(data);
        }
        /// <summary>
        /// Read the  player state over the network.
        /// </summary>
        /// <returns>Struct ,storing data of player stats</returns>
        public PlayerStatus ReadPlayerState()
        {
            var HP = ReadInt(0);
            var Gold = ReadInt(0);
            var EnemyHP = ReadInt(0);
            return new PlayerStatus { HP = HP, EnemyHP = EnemyHP, Gold = Gold };
        }
        /// <summary>
        /// Send the player ID over the network, the server assing player ID and then send it to player.
        /// Thanks to that client can filter player action, which means that client will not allow player do action on not his tiles,towers..
        /// </summary>
        /// <param name="playerID">ID of player ,to know identified players</param>
        public void SendPlayerID(PlayerID playerID)
        {
            var data = InitEmptyDataPackat(PacketTypes.PlayerID, PlayerIDSize, out OffsetStorer offsetStorer);
            WriteByte(data, (byte)playerID, offsetStorer);
            SendData(data);
        }
        /// <summary>
        /// Read the player ID from the network. The client received that from the server before game begin.
        /// </summary>
        /// <returns>ID of player</returns>
        public PlayerID ReadPlayerID()
        { 
            return (PlayerID)ReadByte(0);
        }
        /// <summary>
        /// Send the Tower stats over the network,the server it send to client, then client can display info about towers stats in UI.
        /// </summary>
        /// <param name="towerType">Represent type of the tower, to know identified tower</param>
        /// <param name="towerStats">Stats of tower such as damage, range ..</param>
        public void SendTowerStats(TowerTypes towerType, TowerStats towerStats)
        {
            var descText = towerStats.Desc;
            var data = InitEmptyDataPackat(PacketTypes.TowerStats, TowerTypeSize + TowerStatsHeaderSize + TextLenghtSize + descText.Length, out OffsetStorer offsetStorer);
            WriteByte(data, (byte)towerType, offsetStorer);
            WriteInt(data, towerStats.Damage, offsetStorer);
            WriteInt(data, towerStats.Range, offsetStorer);
            WriteInt(data, towerStats.Speed, offsetStorer);
            WriteInt(data, towerStats.BuildPrice, offsetStorer);
            WriteInt(data, towerStats.SellPrice, offsetStorer);
            WriteInt(data, towerStats.UpgradePrice, offsetStorer);
            WriteInt(data, towerStats.TowerLevel, offsetStorer);
            WriteInt(data, towerStats.TowerMaxLevel, offsetStorer);
            WriteDouble(data, towerStats.UpgradeRatio, offsetStorer);
            WriteInt(data, descText.Length, offsetStorer);
            WriteString(data, descText, offsetStorer);
            SendData(data);
        }
        /// <summary>
        /// Read the tower stats. The client received that from the server before game begin.
        /// </summary>
        /// <param name="towerType"></param>
        /// <returns>Tower stats</returns>
        public TowerStats ReadTowerStats(out TowerTypes towerType)
        {           
            towerType = (TowerTypes)ReadByte(0);
            int damage = ReadInt(0);
            int range = ReadInt(0);
            int speed = ReadInt(0);
            int buildPrice = ReadInt(0);
            int sellPrice = ReadInt(0);
            int upgradePrice = ReadInt(0);
            int level = ReadInt(0);
            int maxLevel = ReadInt(0);
            double upgradeRatio = ReadDouble(0);
            var textLenght = ReadInt(0);
            string text = ReadString(0, textLenght);
            return new TowerStats(damage, range, speed, buildPrice, sellPrice, upgradePrice, level, maxLevel, upgradeRatio, text);
        }
        /// <summary>
        /// Send the Monster stats over the network,the server it send to client, then client can display info about monsters stats in UI.
        /// </summary>
        /// <param name="monsterType">Type of monster to identified for what kind of monster this stas belongs</param>
        /// <param name="monsterStats">Struct storing stats such as damage , movement speed .. of monster</param>
        public void SendMonsterStats(MonsterTypes monsterType, MonsterStats monsterStats)
        {
            var descText = monsterStats.Desc;
            var data = InitEmptyDataPackat(PacketTypes.MonstersStats, TowerTypeSize + TowerStatsHeaderSize + TextLenghtSize + descText.Length, out OffsetStorer offsetStorer);
            WriteByte(data, (byte)monsterType, offsetStorer);       
            WriteInt(data, monsterStats.HP, offsetStorer);
            WriteInt(data, monsterStats.Damage, offsetStorer);
            WriteInt(data, monsterStats.Speed, offsetStorer);
            WriteInt(data, monsterStats.Price, offsetStorer);
            WriteInt(data, monsterStats.Reward, offsetStorer);
            WriteInt(data, descText.Length, offsetStorer);
            WriteString(data, descText, offsetStorer);
            SendData(data);
        }
        /// <summary>
        /// Read the monsters stats. The client received that from the server before game begin.
        /// </summary>
        /// <param name="towerType"></param>
        /// <returns>Monster stats</returns>
        public MonsterStats ReadMonsterStats(out MonsterTypes monsterType)
        {           
            monsterType = (MonsterTypes)ReadByte(0);
            int hp = ReadInt(0);
            int damage = ReadInt(0);
            int speed = ReadInt(0);
            int price = ReadInt(0);
            int reward = ReadInt(0);
            int textlenght = ReadInt(0);
            string text = ReadString(0, textlenght);
            return new MonsterStats(hp, damage, speed, price, reward, text);
        }
        /// <summary>
        /// Send monsters states. Always when the server updates the game,it sends over network new state of monsters
        /// in game to let know the client about new state of monsters in game , so client can this changes render.
        /// </summary>
        /// <param name="listOfMonsters">List of data, which client needs to be able render monsters in game, 
        /// of all existed monsters in game</param>
        public void SendMonstersState(List<MonsterRenderInfo> listOfMonsters)
        {
            var data = InitEmptyDataPackat(PacketTypes.MonsterState, 4 + (listOfMonsters.Count * monsterRenderInfo), out OffsetStorer positionStorer);
            WriteInt(data, listOfMonsters.Count, positionStorer);
            foreach (var monster in listOfMonsters)
            {
                WriteByte(data, (byte)monster.MonsterType, positionStorer);
                WriteInt(data, monster.RemainingHP.Value, positionStorer);
                WriteInt(data, monster.Location.X, positionStorer);
                WriteInt(data, monster.Location.Y, positionStorer);
            }
            SendData(data);
        }
        /// <summary>
        /// Read the state of monsters in game over the network.
        /// </summary>
        /// <returns>List of monsters data to render monsters in game</returns>
        public List<MonsterRenderInfo> ReadMonsterState()
        {
            var countOfMonsters = ReadInt(0);
            var resultList = new List<MonsterRenderInfo>();
            for (int i = 0; i < countOfMonsters; i++)
            {
                var monsterType = (MonsterTypes)ReadByte(0);
                var percentageOfRemainingHP = ReadInt(0);
                var x = ReadInt(0);
                var y = ReadInt(0);
                resultList.Add(new MonsterRenderInfo
                {
                    Location = new Point { X = x, Y = y },
                    RemainingHP = new Percentage(percentageOfRemainingHP),
                    MonsterType = monsterType
                });
            }
            return resultList;
        }
        /// <summary>
        /// Send over the network the result at the end of game, when some player is defeated.
        /// </summary>
        /// <param name="gameEndStatus">Represents that if player wins or loses</param>
        public void SendGameEndStatus(GameEndStatus gameEndStatus)
        {
            var data = InitEmptyDataPackat(PacketTypes.GameEnd, PlayerIDSize, out OffsetStorer offsetStorer);
            WriteByte(data, (byte)gameEndStatus, offsetStorer);
            SendData(data);
        }
        /// <summary>
        /// Read from the network the result at the end of game.
        /// </summary>
        /// <returns>Status if player wins or loses</returns>
        public GameEndStatus ReadGameEndStatus()
        {
            return (GameEndStatus)ReadByte(0);
        }
    }
}
