using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using TowerDefenseNetworking;
using TowerDefenseNetworking.Stats;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseClient
{
    public partial class ClientForm : Form
    {
        private static readonly int _FPS = 60;
        private Client _client = null;
        private readonly Timer _graphicsRenderTimer;
        private readonly Game _game = null;
        /// <summary>
        /// Set game render timer for certain FPS value, so the game will be rendered that speed.
        /// </summary>
        public ClientForm()
        {
            InitializeComponent();
            _graphicsRenderTimer = new Timer
            {
                Interval = 1000 / _FPS
            };
            _graphicsRenderTimer.Tick += GraphicsTimer_Tick;
            _game = new Game(this);
        }
        /// <summary>
        /// Sets towers descriptions visibility.
        /// </summary>
        /// <param name="visibility">bool value if desc, shoud be display</param>
        private void TowerMenuDescSettings(bool visibility)
        {
            labelTowerName.Visible = visibility;
            labelTowerDesc.Visible = visibility;
            textBoxTowerDesc.Visible = visibility;
            labelStatsName.Visible = visibility;
            labelRange.Visible = visibility;
            labelSpeed.Visible = visibility;
            labelBuildPrice.Visible = visibility;
            labelDamage.Visible = visibility;
            pictureTower.Visible = visibility;
        }
        /// <summary>
        /// Sets monsters descriptions visibility.
        /// </summary>
        /// <param name="visibility">bool value if desc, shoud be display</param>
        private void MonsterMenuDescSettings(bool visibility)
        {
            labelMonsterName.Visible = visibility;
            labelMonsterDesc.Visible = visibility;
            textBoxMonsterDesc.Visible = visibility;
            labelMonsterStats.Visible = visibility;
            labelMonsterHP.Visible = visibility;
            labelMonsterDamage.Visible = visibility;
            labelMonsterSpeed.Visible = visibility;
            labelMonsterPrice.Visible = visibility;
            labelMonsterReward.Visible = visibility;
            pictureBoxMonster.Visible = visibility;
        }
        /// <summary>
        /// Show to player, that server is not connected.
        /// </summary>
        public void ServerNotConnected()
        {
            this.Invoke((MethodInvoker)delegate {
                panelGameEnd.Visible = true;
                labelEndResult.Text = "Disconnected";
            });
        }
        /// <summary>
        /// Set client to null.
        /// </summary>
        public void ResetClient()
        {
            this.Invoke((MethodInvoker)delegate {
                _client = null;
                buttonStartGame.Visible = false;
            });
        }
        /// <summary>
        /// Open certain UI menu.
        /// </summary>
        /// <param name="type">type of menu</param>
        public void OpenUI(UITypes type)
        {
            UISettings(type, true);
        }
        /// <summary>
        /// Open game end state, to show game results.
        /// </summary>
        /// <param name="status">status, whatever playter win or lose</param>
        public void OpenEndScreen(GameEndStatus status)
        {
            this.Invoke((MethodInvoker)delegate {
                panelGameEnd.Visible = true;
                labelEndResult.Text = status.ToString();
                if (status == GameEndStatus.Victory)
                {
                    labelEndResult.ForeColor = Color.BlueViolet;
                }
                else
                {
                    labelEndResult.ForeColor = Color.DarkRed;
                }
            });
            
        }
        /// <summary>
        /// If player click at existed tower, it update for menu information aboud the tower.
        /// </summary>
        private void UpdateTowerUpgradeMenu()
        {
            var tower = _game.GameMap.GetTowerAt(_game.ClickedGrid);
            var stats = tower.Stats;
            labelUpgradeTowerName.Text = "Tower : " + tower.TowerType.ToString();
            if (tower.TowerUpgradeCheckerLevel.Check(stats))
            {
                labelUpgradeStatsName.Text = "Upgrade Tower Stats :";
                labelUpgradeDamage.Text = "Damage : " + stats.Damage;
                labelUpgradeRange.Text = "Range : " + stats.Range;
                labelUpgradeSpeed.Text = "Cooldown : " + Math.Round((double)stats.Speed / 1000.0,1).ToString()  +" s";

                buttonUpgrade.Visible = true;
                buttonUpgrade.Text = "Upgrade(" + stats.UpgradePrice + ")";
                buttonSell.Text = "Sell(" + stats.SellPrice + ")";

                stats.Upgrade(tower.TowerUpgradeCheckerLevel,tower.TowerUpgraderRatio);
                labelUpgradeDamage.Text +=" -> " + stats.Damage.ToString();
                labelUpgradeRange.Text += " -> " + stats.Range.ToString();
                labelUpgradeSpeed.Text += " -> " + Math.Round((double)stats.Speed / 1000.0, 1).ToString() + " s";
            }
            else
            {
                labelUpgradeStatsName.Text = "Already max level";
                labelUpgradeDamage.Text = "";
                labelUpgradeRange.Text = "";
                labelUpgradeSpeed.Text = "";

                buttonSell.Text = "Sell(" + stats.SellPrice + ")";
                buttonUpgrade.Visible = false;
            }   
        }
        /// <summary>
        /// Setting menus panels to be display or not.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="visibility"></param>
        private void UISettings(UITypes type,bool visibility) {
            this.Invoke((MethodInvoker)delegate {
                switch (type)
                {
                    case UITypes.Towers:
                        panelTowerMenu.Visible = visibility;
                        break;
                    case UITypes.Upgrade:
                        panelUpgradeMenu.Visible = visibility;
                        if (visibility)
                        {
                            UpdateTowerUpgradeMenu();
                        }                     
                        break;
                    case UITypes.Monsters:
                        panelMonsterMenu.Visible = visibility;
                        break;
                }
            });
        }
        /// <summary>
        /// Closes UI menu.
        /// </summary>
        /// <param name="type"></param>
        public void CloseUI(UITypes type)
        {
            UISettings(type, false);
        }
        /// <summary>
        /// From game map it resize window. So player can see a whole game map.
        /// </summary>
        /// <param name="map">game map</param>
        public void SetUpNewLauncher(GameMap map)
        {
            labelHP.Visible = true;
            labelGold.Visible = true;
            labelEnemyHP.Visible = true;
                    
            var width = map.MapWidth * GameMap.TileSize + 300 + 20;
            var height = map.MapHeight * GameMap.TileSize;

            if (width < this.Size.Width)
            {
                width = this.Size.Width;
            }
            if (height < this.Size.Height)
            {
                height = this.Size.Height;
            }

            this.Size = new Size(width, height);
            width -= panelInfo.Width + 20;
            panelInfo.Height = height - 40;
            panelInfo.Location = new System.Drawing.Point(width,0);
            panelTowerMenu.Location = new System.Drawing.Point(width/2 - panelTowerMenu.Width/2,height/2 - panelTowerMenu.Height /2);
            panelUpgradeMenu.Location = new System.Drawing.Point(width / 2 - panelUpgradeMenu.Width / 2, height / 2 - panelUpgradeMenu.Height / 2);
            panelMonsterMenu.Location = new System.Drawing.Point(width / 2 - panelMonsterMenu.Width / 2, height / 2 - panelMonsterMenu.Height / 2);
            panelGameEnd.Location = new System.Drawing.Point(width / 2 - panelGameEnd.Width / 2, height / 2 - panelGameEnd.Height / 2);
            panelInfo.Visible = true;

        }
        /// <summary>
        /// Clean up entities, which should not be display during game.
        /// </summary>
        public void CleanLauncher() {
            labelTitle.Visible = false;
            labelHost.Visible = false;
            labelInfo.Visible = false;
            labelPort.Visible = false;
            buttonConnect.Visible = false;
            buttonSend.Visible = false;
            buttonStartGame.Visible = false;
            textBoxHost.Visible = false;
            textBoxInfo.Visible = false;
            textBoxMsg.Visible = false;
            textBoxPort.Visible = false;

            textBoxChat.Text = "";
        }
        /// <summary>
        /// Update info about players to the labels.
        /// </summary>
        /// <param name="status">status of player</param>
        public void UpdatePlayersStatsOnForm(PlayerStatus status)
        {
            this.Invoke((MethodInvoker)delegate {
                labelHP.Text = status.HP.ToString() ;
                labelGold.Text = status.Gold.ToString();
                labelEnemyHP.Text = "Enemy HP : " + status.EnemyHP.ToString();
            });
        }
        /// <summary>
        /// Start game.It loads entity stats,
        /// clean up conncetion state of the screen and
        /// start game renderation.
        /// </summary>
        /// <param name="towersStatsDict">towers stats received from the server</param>
        /// <param name="monstersStatsDict">monsters stats received from the server</param>
        public void StartGame(Dictionary<TowerTypes, TowerStats> towersStatsDict,
             Dictionary<MonsterTypes, MonsterStats> monstersStatsDict)
        {
            this.Invoke((MethodInvoker)delegate {
                CleanLauncher();
                SetUpNewLauncher(_game.GameMap);

                _game.LoadTowersStats(towersStatsDict);
                _game.LoadMonstersStats(monstersStatsDict);
                _game.Start();
                _graphicsRenderTimer.Start();
            });
            
        }
        /// <summary>
        /// Write text to info.
        /// </summary>
        /// <param name="msg">text message</param>
        public void AppendToInfo(string msg)
        {
            this.Invoke((MethodInvoker)delegate {
                textBoxInfo.AppendText(msg);
                textBoxInfo.AppendText(Environment.NewLine);
                textBoxChat.AppendText(msg);
                textBoxChat.AppendText(Environment.NewLine);

            });
        }
        /// <summary>
        /// Button to connect to the server.
        /// It creates network conncetion between the client and server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            if (_client == null || _client.IsClientRunning == false)
            {
                _client = new Client(_game, this);
                buttonStartGame.Visible = true;
                _client.Connect(IPAddress.Parse(textBoxHost.Text), Int32.Parse(textBoxPort.Text));
                
            }
        }
        /// <summary>
        /// When player clicked at this button, it will sent to the server text message written in text area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (_client != null && _client.IsClientRunning)
            {
                _client.SendMessage(textBoxMsg.Text);
            }       
        }
        /// <summary>
        /// When player clicked at button to start game, it will sent flag to the server to inform it of that.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            if (_client.IsClientRunning && _client.IsPlayerReady==false)
            {
                _client.IsPlayerReady = true;
                buttonStartGame.Text = "Waiting for other player";
                _client.SendFlag(PacketTypes.PlayerIsReadyFlag);
            }
            
        }
        /// <summary>
        /// If game is running it renders game to the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientForm_Paint(object sender, PaintEventArgs e)
        {
            if (_game != null)
            {
                if (_game.GameIsRunning)
                {
                    _game.Draw(e.Graphics);
                }
                             
            }
        }
        /// <summary>
        /// When game tick occure, it again call drawing mechanism to render a new game screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
        /// <summary>
        /// If player clicked somewhere to the game, it proccesed that event.
        /// <remakr>
        /// If some game UI menu panel is open, it closed it.
        /// This works as closing mechanism of closing game menus
        /// </remark>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">gets mouse corrdinates when occures click event</param>
        private void ClientForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (panelTowerMenu.Visible)
            {
                panelTowerMenu.Visible = false;
                return;
            }
            if (panelUpgradeMenu.Visible)
            {
                panelUpgradeMenu.Visible = false;
                return;
            }
            if (panelMonsterMenu.Visible)
            {
                panelMonsterMenu.Visible = false;
                return;
            }

            if (_game != null)
            {
                if (_game.GameIsRunning)
                {
                    _game.ProcessMouseClick(e.X, e.Y);
                }
            }         
                     
        }
        /// <summary>
        /// In UI menu for buying monsters, when mouse enter 
        /// button area it updates and display information about that type of monster.
        /// </summary>
        /// <param name="monsterImage">image of monster</param>
        /// <param name="monsterType">type of monster</param>
        private void UpdateMenuMonsterDesc(Bitmap monsterImage, MonsterTypes monsterType)
        {
            MonsterMenuDescSettings(true);
            _game.MonstersStatsDict.TryGetValue(monsterType, out MonsterStats stats);
            labelMonsterName.Text = "Monster \n" + monsterType.ToString();
            textBoxMonsterDesc.Text = stats.Desc;
            labelMonsterHP.Text = "HP : " + stats.HP.ToString();
            labelMonsterDamage.Text ="Damage : " + stats.Damage.ToString();
            labelMonsterSpeed.Text = "Speed : " + stats.Speed.ToString();
            labelMonsterPrice.Text = "Price : " +stats.Price.ToString();
            labelMonsterReward.Text = "Reward :" +stats.Reward.ToString();
            pictureBoxMonster.Image = monsterImage;
        }
        /// <summary>
        /// In UI menu for constructions of towers, when mouse enter 
        /// button area it updates and display information about that type of tower.
        /// </summary>
        /// <param name="towerImage">Tower image</param>
        /// <param name="towerType">type of tower</param>
        private void UpdateMenuTowerDesc(Bitmap towerImage,TowerTypes towerType)
        {
            _game.TowersStatsDict.TryGetValue(towerType, out TowerStats stats);

            TowerMenuDescSettings(true);

            labelTowerName.Text = "Tower:\n" + towerType.ToString();
            textBoxTowerDesc.Text = stats.Desc;
            pictureTower.Image = towerImage;        
            labelDamage.Text = "Damage : " + stats.Damage;
            labelRange.Text = "Range : " + stats.Range;
            labelSpeed.Text = "Cooldown : " + Math.Round((double)stats.Speed / 1000.0, 1).ToString() + " s";
            labelBuildPrice.Text = "Price to build : " + stats.BuildPrice;
        }

        private void ButtonTurretTower_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuTowerDesc(Properties.Resources.TurretTower,TowerTypes.Turret);
        }

        private void ButtonIceTower_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuTowerDesc(Properties.Resources.IceTower, TowerTypes.Ice);
        }

        private void ButtonCanonTower_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuTowerDesc(Properties.Resources.CanonTower, TowerTypes.Canon);
        }

        private void ButtonFireTower_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuTowerDesc(Properties.Resources.FireTower, TowerTypes.Fire);
        }

        private void ButtonAirTower_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuTowerDesc(Properties.Resources.AirTower, TowerTypes.Air);
        }

        private void ButtonAirTurretTower_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuTowerDesc(Properties.Resources.AirTurretTowerButton, TowerTypes.AirTurret);
        }

        private void ButtonWindTower_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuTowerDesc(Properties.Resources.WindTower, TowerTypes.Wind);
        }

        private void ButtonStormTower_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuTowerDesc(Properties.Resources.StormTower, TowerTypes.Storm);
        }

        private void ButtonPoisonTower_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuTowerDesc(Properties.Resources.PoisonTower, TowerTypes.Poison);
        }

        private void ButtonExplodeTower_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuTowerDesc(Properties.Resources.ExplodeTower, TowerTypes.Explode);
        }

        private void ButtonArcherTower_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionBuild(TowerTypes.Archer);
            CloseUI(UITypes.Towers);
        }

        private void ButtonTurretTower_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionBuild(TowerTypes.Turret);
            CloseUI(UITypes.Towers);
        }

        private void ButtonIceTower_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionBuild(TowerTypes.Ice);
            CloseUI(UITypes.Towers);
        }

        private void ButtonCanonTower_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionBuild(TowerTypes.Canon);
            CloseUI(UITypes.Towers);
        }

        private void ButtonFireTower_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionBuild(TowerTypes.Fire);
            CloseUI(UITypes.Towers);
        }

        private void ButtonAirTower_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionBuild(TowerTypes.Air);
            CloseUI(UITypes.Towers);
        }

        private void ButtonAirTurretTower_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionBuild(TowerTypes.AirTurret);
            CloseUI(UITypes.Towers);
        }

        private void ButtonWindTower_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionBuild(TowerTypes.Wind);
            CloseUI(UITypes.Towers);
        }

        private void ButtonStormTower_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionBuild(TowerTypes.Storm);
            CloseUI(UITypes.Towers);
        }

        private void ButtonPoisonTower_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionBuild(TowerTypes.Poison);
            CloseUI(UITypes.Towers);
        }

        private void ButtonExplodeTower_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionBuild(TowerTypes.Explode);
            CloseUI(UITypes.Towers);
        }

        private void ButtonArcherTower_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuTowerDesc(Properties.Resources.ArcherTower, TowerTypes.Archer);
        }

        private void ButtonArcherTower_MouseLeave(object sender, EventArgs e)
        {
            TowerMenuDescSettings(false);
        }

        private void ButtonTurretTower_MouseLeave(object sender, EventArgs e)
        {
            TowerMenuDescSettings(false);
        }

        private void ButtonIceTower_MouseLeave(object sender, EventArgs e)
        {
            TowerMenuDescSettings(false);
        }

        private void ButtonCanonTower_MouseLeave(object sender, EventArgs e)
        {
            TowerMenuDescSettings(false);
        }

        private void ButtonFireTower_MouseLeave(object sender, EventArgs e)
        {
            TowerMenuDescSettings(false);
        }

        private void ButtonAirTower_MouseLeave(object sender, EventArgs e)
        {
            TowerMenuDescSettings(false);
        }

        private void ButtonAirTurretTower_MouseLeave(object sender, EventArgs e)
        {
            TowerMenuDescSettings(false);
        }

        private void ButtonWindTower_MouseLeave(object sender, EventArgs e)
        {
            TowerMenuDescSettings(false);
        }

        private void ButtonStormTower_MouseLeave(object sender, EventArgs e)
        {
            TowerMenuDescSettings(false);
        }

        private void ButtonPoisonTower_MouseLeave(object sender, EventArgs e)
        {
            TowerMenuDescSettings(false);
        }

        private void ButtonExplodeTower_MouseLeave(object sender, EventArgs e)
        {
            TowerMenuDescSettings(false);
        }

        private void ButtonSell_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionSell();
            CloseUI(UITypes.Upgrade);
        }

        private void ButtonUpgrade_Click(object sender, EventArgs e)
        {
            _client.SendTowerActionUpgrade();
            CloseUI(UITypes.Upgrade);
        }

        private void ButtonSprider_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.Spider, MonsterTypes.Spider);
        }

        private void ButtonIceSpider_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.IceSpider, MonsterTypes.IceSpider);
        }

        private void ButtonBear_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.Bear, MonsterTypes.Bear);
        }

        private void ButtonIceBear_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.IceBear, MonsterTypes.IceBear);
        }

        private void ButtonGhoul_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.Ghoul, MonsterTypes.Ghoul);
        }

        private void ButtonWerewolf_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.Werewolf, MonsterTypes.Werewolf);
        }

        private void ButtonGolem_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.Golem, MonsterTypes.Golem);
        }

        private void ButtonDevil_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.Devil, MonsterTypes.Devil);
        }

        private void ButtonWyvern_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.Wyvern, MonsterTypes.Wyvern);
        }

        private void ButtonPterodactyl_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.Pterodactyl, MonsterTypes.Pterodactyl);
        }

        private void ButtonGargoyle_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.Gargoyle, MonsterTypes.Gargoyle);
        }

        private void ButtonDragon_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.Dragon, MonsterTypes.Dragon);
        }

        private void ButtonGhidorah_MouseEnter(object sender, EventArgs e)
        {
            UpdateMenuMonsterDesc(Properties.Resources.Ghidorah, MonsterTypes.Ghidorah);
        }

        private void ButtonSprider_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonIceSpider_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonBear_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonIceBear_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonGhoul_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonWerewolf_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonGolem_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonDevil_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonWyvern_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonPterodactyl_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonGargoyle_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonDragon_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonGhidorah_MouseLeave(object sender, EventArgs e)
        {
            MonsterMenuDescSettings(false);
        }

        private void ButtonSprider_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.Spider);
        }

        private void ButtonIceSpider_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.IceSpider);
        }

        private void ButtonBear_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.Bear);
        }

        private void ButtonIceBear_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.IceBear);
        }

        private void ButtonGhoul_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.Ghoul);
        }

        private void ButtonWerewolf_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.Werewolf);
        }

        private void ButtonGolem_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.Golem);
        }

        private void ButtonDevil_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.Devil);
        }

        private void ButtonWyvern_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.Wyvern);
        }

        private void ButtonPterodactyl_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.Pterodactyl);
        }

        private void ButtonGargoyle_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.Gargoyle);
        }

        private void ButtonDragon_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.Dragon);
        }

        private void ButtonGhidorah_Click(object sender, EventArgs e)
        {
            _client.SendMonsterAction(MonsterTypes.Ghidorah);
        }

        private void ButtonSendMessage_Click(object sender, EventArgs e)
        {
            if (_client.IsClientRunning)
            {
                _client.SendMessage(textBoxMessage.Text);
            }
        }
    }
}
