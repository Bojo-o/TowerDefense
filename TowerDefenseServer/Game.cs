using System;
using System.Collections.Generic;
using System.Linq;
using TowerDefenseServer.Monsters;
using TowerDefenseServer.Tiles.Towers;
using TowerDefenseNetworking;
using TowerDefenseNetworking.Stats;
using TowerDefenseNetworking.TypeEnums;
using TowerDefenseServer.Tiles;

namespace TowerDefenseServer
{
    /// <summary>
    /// The game, which resides on the server side. It stores all game 
    /// entities as players, game map and stats such as
    /// monsters and towers stats. Provides methods for game updation, which means
    /// moves monsters, towers/monsters collison detection, adding new Towers, or destroying them.
    /// </summary>
    public class Game
    {
        /// All stats and constans
        /// 
        /// Towers stats
        private static TowerStats ArcherStats = new TowerStats(10, 200, 2000, 25, 10, 30, 1, 3, 0.4,"Ground tower, single attack towards ground monster");
        private static TowerStats AirStats = new TowerStats(10, 200, 1800, 25, 10, 30, 1, 3, 0.4,"Air tower, single attack towards air monsters");
        private static TowerStats AirTurretStats = new TowerStats(15, 230, 1800, 90, 75, 1, 3, 100, 0.4,"Air tower, multiple attacks towards air monsters");
        private static TowerStats CanonStats = new TowerStats(20, 180, 2000, 65, 50, 80, 1, 3, 0.3,"Ground tower,greater single attack towards ground monster");
        private static TowerStats ExplodeStats = new TowerStats(45, 300, 10000, 300, 210, 1, 3, 330, 0.5, "Hybrid tower, deals Big damage to all nearby monsters");
        private static TowerStats FireStats = new TowerStats(1, 200, 500, 60, 45, 70, 1, 3, 0.7,"Ground tower, deals fire damage to nearby ground monsters");
        private static TowerStats IceStats = new TowerStats(50, 180, 0, 50, 35, 55, 1, 3, 0.25,"Ground tower, slow nearby ground monsters");
        private static TowerStats PoisonStats = new TowerStats(7, 225, 800, 200, 150, 320, 1, 3, 0.5, "Hybrid tower, deals poison damage to nearby monsters");
        private static TowerStats StormStats = new TowerStats(5, 180, 1200, 150, 120, 180, 1, 3, 0.3, "Air tower, deals storm damage to nearby air monsters");
        private static TowerStats TurretStats = new TowerStats(8, 220, 1500, 35, 15, 40, 1, 3, 0.5, "Ground tower, multiple attacks towards ground monsters");
        private static TowerStats WindStats = new TowerStats(50, 180, 0, 130, 100, 140, 1, 3, 0.7, "Air tower, slow nearby air monsters");
        /// Monsters stats
        private static MonsterStats SpiderStats = new MonsterStats(10, 5, 4, 5, 3, "Ground monster,immune against Turret.");
        private static MonsterStats IceSpiderStats = new MonsterStats(10, 5, 4, 7, 4, "Ground monster,immune against Turret, Ice.Fire deal 30% more damage");
        private static MonsterStats BearStats = new MonsterStats(20,7,3,12,8,"Ground monster,Archer (15%),Canon(5%) deal less damage");
        private static MonsterStats IceBearStats = new MonsterStats(20,7,3,14,9,"Same as Bear, plus Fire deals 20% more damage and immune against Ice");
        private static MonsterStats GhoulStats = new MonsterStats(30,9,3,20,12,"Ground monster,Archer (20%),Fire(15%) deal more damage,Poison(50%) deals less damage");
        private static MonsterStats WerewolfStats = new MonsterStats(15, 10, 6, 15, 10, "Fast ground monster,Archer and Ice (30%) deal less damage,Turret and Fire (10%) deal more damage");
        private static MonsterStats GolemStats = new MonsterStats(60, 10, 1, 50, 45, "Slow ground monster,immune against Turret and Fire. Canon (25%),Poison (5%),Explode (30&) deal more damage");
        private static MonsterStats DevilStats = new MonsterStats(45, 15, 2, 40, 40, "Groun monster,immune against Fire. Poison (15%) deals more damage and Canon (20%), Explode (10%) deal less damage");
        private static MonsterStats WyvernStats = new MonsterStats(20, 5, 4, 10, 6, "Air monster");
        private static MonsterStats PterodactylStats = new MonsterStats(25, 8, 7, 15, 11, "Air monster , immune against AirTurret and Wind (25%) deals less damage");
        private static MonsterStats GargoyleStats = new MonsterStats(30, 10, 4, 15,10, "Fast air monster, Air (15%),Poison (10%) deal less damage,Storm and AirTurret (10%) deal more damage");
        private static MonsterStats DragonStats = new MonsterStats(40, 15, 3, 25, 19, "Air monster, Air (20%) deals less damage, Storm and Explode (15%) deal more damage");
        private static MonsterStats GhidorahStats = new MonsterStats(70, 25, 2, 50, 45, "Air monster, immune against Storm and Poison,Air (30%),Wind (5%) deal less damage and Explode (20%) deals more");
        /// Game constans
        private static readonly int PlayersStatingHP = 150;
        private static readonly int PlayersStartingGoldValue = 50;
        private static readonly int IncomeValue = 2;
        private static readonly int IncomeCooldownInMS = 2000;
        private static readonly int MonstersSpawnCooldownTimeInMS = 2000;

        private Server _server;
        public GameMap Map { get; private set; }
        /// <summary>
        /// Represent one of two players. Name this player player A, for identification.
        /// </summary>
        public Player PlayerA { get; private set; }
        /// <summary>
        /// Represent one of two players. Name this player player B, for identification.
        /// </summary>
        public Player PlayerB { get; private set; }
        private static readonly int TileSize = 64;
        /// <summary>
        /// Stores all towers stats. Is Indexed by type of tower.
        /// </summary>
        public static Dictionary<TowerTypes, TowerStats> TowerStatsDict{ get; private set; }
        /// <summary>
        /// Stores all monsters stats. Is Indexed by type of monster.
        /// </summary>
        public static Dictionary<MonsterTypes, MonsterStats> MonsterStatsDict { get; private set; }
        private Cooldown _incomeCooldown;
        /// <summary>
        /// Stores all factories, which produces monsters.
        /// </summary>
        public static List<IMonsterFactory> MonsterFactories { get; private set; }
        /// <summary>
        /// Stores all factories, which produces towers.
        /// </summary>
        public static List<ITowerFactory> TowerFactories { get; private set; }

        static Game()
        {
            TowerStatsDict = new Dictionary<TowerTypes, TowerStats>();
            TowerFactories = new List<ITowerFactory>();
            TowerStatsDict.Add(TowerTypes.Archer, ArcherStats);
            TowerFactories.Add(new TowerFactory<ArcherTower>(ArcherStats,TileSize));
            TowerStatsDict.Add(TowerTypes.Turret, TurretStats);
            TowerFactories.Add(new TowerFactory<TurretTower>(TurretStats,TileSize));
            TowerStatsDict.Add(TowerTypes.Ice,IceStats);
            TowerFactories.Add(new TowerFactory<IceTower>(IceStats,TileSize));
            TowerStatsDict.Add(TowerTypes.Fire, FireStats);
            TowerFactories.Add(new TowerFactory<FireTower>(FireStats,TileSize));
            TowerStatsDict.Add(TowerTypes.Canon, CanonStats);
            TowerFactories.Add(new TowerFactory<CanonTower>(CanonStats,TileSize));
            TowerStatsDict.Add(TowerTypes.Air, AirStats);
            TowerFactories.Add(new TowerFactory<AirTower>(AirStats,TileSize));
            TowerStatsDict.Add(TowerTypes.AirTurret, AirTurretStats);
            TowerFactories.Add(new TowerFactory<AirTurretTower>(AirTurretStats,TileSize));
            TowerStatsDict.Add(TowerTypes.Wind, WindStats);
            TowerFactories.Add(new TowerFactory<WindTower>(WindStats,TileSize));
            TowerStatsDict.Add(TowerTypes.Storm, StormStats);
            TowerFactories.Add(new TowerFactory<StormTower>(StormStats,TileSize));
            TowerStatsDict.Add(TowerTypes.Poison, PoisonStats);
            TowerFactories.Add(new TowerFactory<PoisonTower>(PoisonStats,TileSize));
            TowerStatsDict.Add(TowerTypes.Explode, ExplodeStats);
            TowerFactories.Add(new TowerFactory<ExplodeTower>(ExplodeStats,TileSize));

            MonsterStatsDict = new Dictionary<MonsterTypes, MonsterStats>();
            MonsterFactories = new List<IMonsterFactory>();
            MonsterStatsDict.Add(MonsterTypes.Spider, SpiderStats);
            MonsterFactories.Add(new MonsterFactory<Spider>(SpiderStats,TileSize));
            MonsterStatsDict.Add(MonsterTypes.IceSpider, IceSpiderStats);
            MonsterFactories.Add(new MonsterFactory<IceSpider>(IceSpiderStats,TileSize));
            MonsterStatsDict.Add(MonsterTypes.Bear, BearStats);
            MonsterFactories.Add(new MonsterFactory<Bear>(BearStats,TileSize));
            MonsterStatsDict.Add(MonsterTypes.IceBear, IceBearStats);
            MonsterFactories.Add(new MonsterFactory<IceBear>(IceBearStats,TileSize));
            MonsterStatsDict.Add(MonsterTypes.Ghoul, GhoulStats);
            MonsterFactories.Add(new MonsterFactory<Ghoul>(GhoulStats,TileSize));
            MonsterStatsDict.Add(MonsterTypes.Werewolf, WerewolfStats);
            MonsterFactories.Add(new MonsterFactory<Werewolf>(WerewolfStats,TileSize));
            MonsterStatsDict.Add(MonsterTypes.Golem, GolemStats);
            MonsterFactories.Add(new MonsterFactory<Golem>(GolemStats, TileSize));
            MonsterStatsDict.Add(MonsterTypes.Devil, DevilStats);
            MonsterFactories.Add(new MonsterFactory<Devil>(DevilStats,TileSize));

            MonsterStatsDict.Add(MonsterTypes.Wyvern,WyvernStats);
            MonsterFactories.Add(new MonsterFactory<Wyvern>(WyvernStats,TileSize));
            MonsterStatsDict.Add(MonsterTypes.Pterodactyl, PterodactylStats);
            MonsterFactories.Add(new MonsterFactory<Pterodactyl>(PterodactylStats,TileSize));
            MonsterStatsDict.Add(MonsterTypes.Gargoyle, GargoyleStats);
            MonsterFactories.Add(new MonsterFactory<Gargoyle>(GargoyleStats,TileSize));
            MonsterStatsDict.Add(MonsterTypes.Dragon, DragonStats);
            MonsterFactories.Add(new MonsterFactory<Dragon>(DragonStats,TileSize));
            MonsterStatsDict.Add(MonsterTypes.Ghidorah, GhidorahStats);
            MonsterFactories.Add(new MonsterFactory<Ghidorah>(GhidorahStats,TileSize));
        }      
        /// <summary>
        /// Obratain player object.
        /// </summary>
        /// <param name="PlayerID">ID of player</param>
        /// <returns>concrate Player object</returns>
        public Player GetPlayer(PlayerID PlayerID)
        {
            if (PlayerID == PlayerID.PlayerA)              
            {
                return PlayerA;
            }
            return PlayerB;
        }
        /// <summary>
        /// Obtain enemy player object. Its helpful when players monsters come to the end
        /// and, what cases the damage of enemy player.
        /// </summary>
        /// <param name="player">Id of player</param>
        /// <returns>other player as provided</returns>
        private Player GetEnemyPlayer(Player player)
        {
            if (player.PlayerID == PlayerID.PlayerA)
            {
                return PlayerB;
            }
            return PlayerA;
        }
        public void SetUpServer(Server server)
        {
            this._server = server;
        }
        public void LoadGameMap(TileTypes[,] worldMap)
        {
            Map = new GameMap(worldMap);
        }
        /// <summary>
        /// Creates players and init their monster spawners.
        /// </summary>
        public void SetUpPlayers()
        {
            PlayerA = new Player(PlayersStatingHP, PlayersStartingGoldValue, PlayerID.PlayerA);
            PlayerA.InitMonsterSpawner(_server.Clock, MonstersSpawnCooldownTimeInMS);
            PlayerB = new Player(PlayersStatingHP, PlayersStartingGoldValue, PlayerID.PlayerB);
            PlayerB.InitMonsterSpawner(_server.Clock, MonstersSpawnCooldownTimeInMS);
        }
        /// <summary>
        /// Obtain tile from the game map.
        /// </summary>
        /// <param name="grid">tile location</param>
        /// <returns>game tile, if it exists at given location</returns>
        private Tile GetTile(Point grid)
        {
            if (Map.ExistTileAtGrid(grid))
            {
                return Map.GetTile(grid);
            }
            throw new Exception("Try access to not existed tile");
        }
        /// <summary>
        /// Removes players tower from player.
        /// Replace tower tile for empty tile for tower.
        /// </summary>
        /// <param name="tower">concrate tower, which will be removed</param>
        /// <param name="action">tower action, stores location</param>
        private void RemoveTower(Tower tower, TowerAction action)
        {
            var emptyTowerTile = new EmptyTowerTile();
            emptyTowerTile.SetOwner(action.PlayerID);
            Map.ChangeTile(emptyTowerTile, action.Location);
            GetPlayer(action.PlayerID).RemoveTower(tower);            
        }
        /// <summary>
        /// Add a new tower to the game map and to player list of towers.
        /// </summary>
        /// <param name="tower">concarte tower, which will be added</param>
        /// <param name="action">tower action, stores location, where tower will be located</param>
        private void AddTower(Tower tower,TowerAction action)
        {
            Map.ChangeTile(tower, action.Location);
            GetPlayer(action.PlayerID).RegisterTower(tower);           
        }
        /// <summary>
        /// The server broadcastly sends information to clients about tower upgradation, so they can update info about the game.
        /// </summary>
        /// <param name="action">tower action, stores information about action</param>
        public void UpgradeTower(TowerAction action)
        {
            _server.SendTowerActionBroadcast(action);
        }
        /// <summary>
        /// On the Server side, it destroys tower and sends over the network info to the clients.
        /// </summary>
        /// <param name="tower">concrate tower, which will be destroyed</param>
        /// <param name="action">tower action, stores location of tower</param>
        public void DestroyTower(Tower tower,TowerAction action)
        {
            _server.SendTowerActionBroadcast(action);
            RemoveTower(tower, action);
        }
        /// <summary>
        /// Create a new tower from tower factory and sends info about it over the network.
        /// </summary>
        /// <param name="action">tower action, stores location of tower</param>
        public void BuildTower(TowerAction action)
        {
            _server.SendTowerActionBroadcast(action);          
            var newTower = TowerFactories.ElementAt((int)action.TowerType).CreateTower(action.PlayerID,action.Location);
            if (newTower.HaveCooldown)
            {
                newTower.SetTowerCooldown(_server.Clock);
            }
            AddTower(newTower,action);

        }
        /// <summary>
        /// Find out a right tile and at the that tile invokes action.
        /// </summary>
        /// <param name="action">tower action, which stores information about tower</param>
        public void Action(TowerAction action)
        {
            GetTile(action.Location).Action(this, action);            
        }
        /// <summary>
        /// If player has enough golds, it takes them from players and then creates a new monster.
        /// </summary>
        /// <param name="monsterType">type of monster, which player wants to buy</param>
        /// <param name="PlayerID">ID of player, who wants to buy the monster</param>
        public void TryAddMonster(MonsterTypes monsterType,PlayerID PlayerID)
        {
            var player = GetPlayer(PlayerID);
            MonsterStatsDict.TryGetValue(monsterType, out MonsterStats stats);
            if (player.UseGolds(stats.Price))
            {               
                if (PlayerID == PlayerID.PlayerA)
                {                    
                    player.MonsterSpawner.AddMonster(MonsterFactories.ElementAt((int)monsterType).CreateMonster(Map, Map.StartPositionB));
                }
                else
                {
                    player.MonsterSpawner.AddMonster(MonsterFactories.ElementAt((int)monsterType).CreateMonster(Map, Map.StartPositionA));                    
                }                               
            }           
        }
  
        /// <summary>
        /// For all monsters in the game it creates render info about each monster.
        /// </summary>
        /// <returns>list, which stores render info about each monster</returns>
        private List<MonsterRenderInfo> CreateMonsterRenderInfo()
        {
            var resultList = new List<MonsterRenderInfo>();
            foreach(var monster in PlayerA.PlayerMonstersList)
            {
                resultList.Add(monster.GetMonsterRenderInfo());
            }
            foreach (var monster in PlayerB.PlayerMonstersList)
            {
                resultList.Add(monster.GetMonsterRenderInfo());
            }
            return resultList;
        }

        /// <summary>
        /// For all player monsters it invokes methods to moved them.
        /// </summary>
        /// <remarks>
        /// Also check if some monsters is not at the end, if is it,
        /// it kills that monsters, gives player golds and takes other players HP.
        /// </remarks>
        /// <param name="player">player, whose monsters will be moved</param>
        private void MovePlayerMonsters(Player player)
        {
            foreach(var monster in player.PlayerMonstersList)
            {
                if (!monster.Move())
                {
                    player.GetGolds(monster.Reward);
                    player.KillMonster(monster);
                    GetEnemyPlayer(player).TakesDamage(monster.Damage);
                }                
            }
        }
        /// <summary>
        /// For all players towers and other playes monsters ,it invokes methods for processing tower attacks to monsters. 
        /// </summary>
        /// <param name="defender">player, whose towers defends him from enemy monsters</param>
        /// <param name="attacker">player, whose monsters try to attack other player</param>
        private void TowerAttackToMonsters(Player defender,Player attacker)
        {
            foreach (var tower in defender.PlayerTowersList)
            {
                tower.AttackToMonsterArmy(attacker.PlayerMonstersList);
            }
            foreach (var monster in attacker.PlayerMonstersList)
            {
                if (!monster.IsAlive())
                {
                    attacker.KillMonster(monster);
                    defender.GetGolds(monster.Reward);
                }
            }

        }
        /// <summary>
        /// Evokes towers / monsters collisions for both sides.
        /// </summary>
        private void TowerMonsterClash()
        {
            TowerAttackToMonsters(PlayerA, PlayerB);
            TowerAttackToMonsters(PlayerB, PlayerA);
        }
        /// <summary>
        /// Process base the game income, when the timeis right, then players gets golds.
        /// </summary>
        /// <remarks>
        /// If income is not created, its create a new one.
        /// </remarks>
        private void Income()
        {
            if (_incomeCooldown == null)
            {
                _incomeCooldown = new Cooldown(_server.Clock, IncomeCooldownInMS);
            }
            if (_incomeCooldown.IsReady)
            {
                _incomeCooldown.Start();
                PlayerA.GetGolds(IncomeValue);
                PlayerB.GetGolds(IncomeValue);
            }
        }
        /// <summary>
        /// If some monster is waiting to be spawned, it try to spawns it, if monster spawner cooldown reachs zero value.
        /// </summary>
        private void SpawnNewMonsters()
        {
            PlayerA.MonsterSpawner.TrySpawnMonster();
            PlayerB.MonsterSpawner.TrySpawnMonster();
        }
       /// <summary>
       /// Check if player is still alive, if player is dead, the server sends information about, that the game is over 
       /// and who is winner and who loser.
       /// </summary>
       /// <param name="player">concrate player</param>
        private void CheckPlayerHP(Player player)
        {
            if (!player.IsAlive())
            {
                _server.SendGameEndBroadcast(player.PlayerID);
            }
        }
        /// <summary>
        /// Update game, which means to moves monsters, spawns a new monsters, 
        /// detects tower / monster collisons, process game base income, sends render
        /// info about monsters to clients and check if some player is not dead.
        /// </summary>
        public void UpdateGame()
        {
            SpawnNewMonsters();
            MovePlayerMonsters(PlayerA);
            MovePlayerMonsters(PlayerB);
            TowerMonsterClash();
            PlayerA.RemoveDeadMonsters();
            PlayerB.RemoveDeadMonsters();
            Income();
            _server.SendMonstersStateBroadcast(CreateMonsterRenderInfo());
            CheckPlayerHP(PlayerA);
            CheckPlayerHP(PlayerB);
        }
    }
}
