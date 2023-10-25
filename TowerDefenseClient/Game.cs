using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using TowerDefenseNetworking;
using TowerDefenseNetworking.Stats;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseClient
{
    /// <summary>
    /// Game on the client side.
    /// </summary>
    /// <remarks>
    /// The main goal is render game map and monsters
    /// and also provides interface for player events processing.
    /// </remarks>
    public class Game
    {       
        private readonly ClientForm _clientForm;
        public List<MonsterRenderInfo> monsterRenderInfos = new List<MonsterRenderInfo>();
        /// <summary>
        /// Stores all monsters images, its indexed by type of monster.
        /// </summary>
        /// <remarks>
        /// Type of monster is enum so all value can be represents as bytes, 
        /// so to the list we address by bytes.
        /// </remarks>
        public static List<Bitmap> MonstersSprites;
        public GameMap GameMap { get; private set; }
        public bool GameIsready { get; private set; } = false;
        public bool GameIsRunning { get; private set; } = false;
        public TowerDefenseNetworking.Point ClickedGrid { get; private set; }
        /// <summary>
        /// For all kind of tower, it stores their tower stats
        /// </summary>
        public Dictionary<TowerTypes, TowerStats> TowersStatsDict { get; private set; }
        /// <summary>
        /// For all kind of monster, it stores their stats.
        /// </summary>
        public Dictionary<MonsterTypes, MonsterStats> MonstersStatsDict { get; private set; }
        /// <summary>
        /// ID of player, it help clients to process clicks,
        /// so if player clicks on the tile which belongs to other player
        /// it ignores that click
        /// </summary>
        public PlayerID PlayerID { get; private set; }
        static Game()
        {
            MonstersSprites = new List<Bitmap>
            {
                Properties.Resources.Spider,
                Properties.Resources.IceSpider,
                Properties.Resources.Bear,
                Properties.Resources.IceBear,
                Properties.Resources.Ghoul,
                Properties.Resources.Werewolf,
                Properties.Resources.Golem,
                Properties.Resources.Devil,
                Properties.Resources.Wyvern,
                Properties.Resources.Pterodactyl,
                Properties.Resources.Gargoyle,
                Properties.Resources.Dragon,
                Properties.Resources.Ghidorah
            };
        }
        /// <summary>
        /// Assing to the game winform, so we can notify form for
        /// some actions such as to update game stats or opens UI menu.
        /// </summary>
        /// <param name="clientForm"></param>
        public Game(ClientForm clientForm)
        {
            _clientForm = clientForm;
        }
        /// <summary>
        /// Calls when connection with the server was lost.
        /// </summary>
        public void ServerDisconection()
        {           
            if (GameIsRunning)
            {
                _clientForm.ServerNotConnected();
            }
            GameIsRunning = false;
            _clientForm.AppendToInfo("Connection with server was lost");
        }
        /// <summary>
        /// If the server sends, that it is full, game notify form to set the client to null.
        /// </summary>
        public void ServerIsFull()
        {
            _clientForm.ResetClient();
        }
        /// <summary>
        /// Set property, which indicates if game is running to be false. Also open game end status.
        /// </summary>
        /// <param name="status">stores data, whether the player won or lose</param>
        public void EndGame(GameEndStatus status)
        {
            GameIsRunning = false;
            _clientForm.OpenEndScreen(status);
        }
        /// <summary>
        /// Process action and invokes right method for this type of action.
        /// </summary>
        /// <param name="towerAction">stores data about action of tower</param>
        public void ProcessTowerAction(TowerAction towerAction)
        {
            switch (towerAction.TowerActionType)
            {
                case TowerActionTypes.Build:
                    GameMap.BuildTower(towerAction);
                    break;
                case TowerActionTypes.Destroy:
                    GameMap.DestroyTower(towerAction);
                    break;
                case TowerActionTypes.Upgrade:
                    GameMap.UpgradeTower(towerAction);
                    break;
            }
        }
        public void LoadTowersStats(Dictionary<TowerTypes, TowerStats> towersStatsDict)
        {
            TowersStatsDict = towersStatsDict;
        }
        public void LoadMonstersStats(Dictionary<MonsterTypes, MonsterStats> monstersStatsDict)
        {
            MonstersStatsDict = monstersStatsDict;
        }
        /// <summary>
        /// Start game, so it set property,which indicates game running to be true.
        /// </summary>
        public void Start()
        {
            GameIsRunning = true;
        }
        public void LoadMap(GameMap gameMap)
        {
            this.GameMap = gameMap;
            GameIsready = true;
        }
        public void SetPlayerID(PlayerID playerID)
        {
            this.PlayerID = playerID;
        }
        /// <summary>
        /// Opens UI menu for some kind of action.
        /// </summary>
        /// <param name="menuType">type of menu,which will be openned</param>
        public void OpenMenu(UITypes menuType)
        {
            _clientForm.OpenUI(menuType);
        }
        /// <summary>
        /// If player clicks by mouse on game map tile, which exists,
        /// it invoke action on that tile.
        /// </summary>
        /// <remarks>
        /// So if tile is empty spaces for new tower it opens game UI menu for the construction of a new tower.
        /// </remarks>
        /// <param name="x"> X coordinates of mouse click</param>
        /// <param name="y"> Y coordinates of mouse click</param>
        public void ProcessMouseClick(int x,int y)
        {
            var grid = new TowerDefenseNetworking.Point { X = x / GameMap.TileSize, Y = y / GameMap.TileSize };
            if (GameMap.ExistTileAtGrid(grid))
            {
                ClickedGrid = grid;
                GameMap.GetTileAt(grid).Action(this);          
            }
        }
        /// <summary>
        /// Draw certain monster on the screen.
        /// </summary>
        /// <param name="g">graphics, to which will be monster rendered</param>
        /// <param name="info"></param>
        private void DrawMonster(Graphics g,MonsterRenderInfo info)
        {
            var tileSize = GameMap.TileSize;
            var leftUpCornerX = info.Location.X;
            var leftUpCornerY = info.Location.Y;
            g.DrawImage(MonstersSprites.ElementAt((int)info.MonsterType), new Rectangle(leftUpCornerX,leftUpCornerY, tileSize, tileSize));          
            g.FillRectangle( Brushes.Red, leftUpCornerX, leftUpCornerY - (tileSize / 2), tileSize, tileSize / 4);
            g.FillRectangle(Brushes.Green, leftUpCornerX, leftUpCornerY - (tileSize / 2), (int)((double)tileSize * ((double)info.RemainingHP.Value / 100.0)), tileSize / 4);
        }
        /// <summary>
        /// Draw whole game map and monsters on the screen.
        /// </summary>
        /// <param name="g">graphics, to which will be whole game map and monsters rendered</param>
        public void Draw(Graphics g)
        {
            GameMap.Draw(g);
            foreach (var monsterRenderInfo in monsterRenderInfos)
            {
                DrawMonster(g, monsterRenderInfo);
            }
        }
    }
}
