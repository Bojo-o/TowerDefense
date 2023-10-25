
namespace TowerDefenseClient
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.labelHP = new System.Windows.Forms.Label();
            this.labelGold = new System.Windows.Forms.Label();
            this.labelEnemyHP = new System.Windows.Forms.Label();
            this.panelTowerMenu = new System.Windows.Forms.Panel();
            this.labelStatsName = new System.Windows.Forms.Label();
            this.labelBuildPrice = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelRange = new System.Windows.Forms.Label();
            this.labelDamage = new System.Windows.Forms.Label();
            this.labelTowerDesc = new System.Windows.Forms.Label();
            this.labelTowerName = new System.Windows.Forms.Label();
            this.labelTowers = new System.Windows.Forms.Label();
            this.buttonExplodeTower = new System.Windows.Forms.Button();
            this.buttonPoisonTower = new System.Windows.Forms.Button();
            this.buttonAirTower = new System.Windows.Forms.Button();
            this.buttonStormTower = new System.Windows.Forms.Button();
            this.buttonWindTower = new System.Windows.Forms.Button();
            this.buttonAirTurretTower = new System.Windows.Forms.Button();
            this.buttonFireTower = new System.Windows.Forms.Button();
            this.buttonIceTower = new System.Windows.Forms.Button();
            this.buttonCanonTower = new System.Windows.Forms.Button();
            this.buttonTurretTower = new System.Windows.Forms.Button();
            this.buttonArcherTower = new System.Windows.Forms.Button();
            this.pictureTower = new System.Windows.Forms.PictureBox();
            this.textBoxTowerDesc = new System.Windows.Forms.TextBox();
            this.panelUpgradeMenu = new System.Windows.Forms.Panel();
            this.buttonSell = new System.Windows.Forms.Button();
            this.buttonUpgrade = new System.Windows.Forms.Button();
            this.labelUpgradeSpeed = new System.Windows.Forms.Label();
            this.labelUpgradeRange = new System.Windows.Forms.Label();
            this.labelUpgradeDamage = new System.Windows.Forms.Label();
            this.labelUpgradeStatsName = new System.Windows.Forms.Label();
            this.labelUpgradeTowerName = new System.Windows.Forms.Label();
            this.panelMonsterMenu = new System.Windows.Forms.Panel();
            this.textBoxMonsterDesc = new System.Windows.Forms.TextBox();
            this.labelMonsterReward = new System.Windows.Forms.Label();
            this.labelMonsterStats = new System.Windows.Forms.Label();
            this.labelMonsterPrice = new System.Windows.Forms.Label();
            this.labelMonsterSpeed = new System.Windows.Forms.Label();
            this.labelMonsterDamage = new System.Windows.Forms.Label();
            this.labelMonsterHP = new System.Windows.Forms.Label();
            this.labelMonsterDesc = new System.Windows.Forms.Label();
            this.labelMonsterName = new System.Windows.Forms.Label();
            this.pictureBoxMonster = new System.Windows.Forms.PictureBox();
            this.buttonGolem = new System.Windows.Forms.Button();
            this.buttonGhidorah = new System.Windows.Forms.Button();
            this.buttonDragon = new System.Windows.Forms.Button();
            this.buttonGargoyle = new System.Windows.Forms.Button();
            this.buttonPterodactyl = new System.Windows.Forms.Button();
            this.buttonWyvern = new System.Windows.Forms.Button();
            this.buttonWerewolf = new System.Windows.Forms.Button();
            this.buttonGhoul = new System.Windows.Forms.Button();
            this.buttonIceBear = new System.Windows.Forms.Button();
            this.buttonDevil = new System.Windows.Forms.Button();
            this.buttonBear = new System.Windows.Forms.Button();
            this.buttonIceSpider = new System.Windows.Forms.Button();
            this.buttonSprider = new System.Windows.Forms.Button();
            this.labelMonsters = new System.Windows.Forms.Label();
            this.panelGameEnd = new System.Windows.Forms.Panel();
            this.labelEndResult = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.pictureBoxHP = new System.Windows.Forms.PictureBox();
            this.pictureBoxGolds = new System.Windows.Forms.PictureBox();
            this.labelChat = new System.Windows.Forms.Label();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.panelTowerMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTower)).BeginInit();
            this.panelUpgradeMenu.SuspendLayout();
            this.panelMonsterMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMonster)).BeginInit();
            this.panelGameEnd.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGolds)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.Location = new System.Drawing.Point(266, 129);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(151, 36);
            this.buttonConnect.TabIndex = 16;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.Color.Black;
            this.labelInfo.Location = new System.Drawing.Point(261, 168);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(54, 26);
            this.labelInfo.TabIndex = 15;
            this.labelInfo.Text = "Info:";
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(266, 197);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(452, 110);
            this.textBoxInfo.TabIndex = 14;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(541, 100);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(45, 20);
            this.textBoxPort.TabIndex = 13;
            this.textBoxPort.Text = "13000";
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(331, 101);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(139, 20);
            this.textBoxHost.TabIndex = 12;
            this.textBoxHost.Text = "127.0.0.1";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPort.ForeColor = System.Drawing.Color.Black;
            this.labelPort.Location = new System.Drawing.Point(476, 96);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(58, 26);
            this.labelPort.TabIndex = 11;
            this.labelPort.Text = "Port:";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHost.ForeColor = System.Drawing.Color.Black;
            this.labelHost.Location = new System.Drawing.Point(261, 96);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(63, 26);
            this.labelHost.TabIndex = 10;
            this.labelHost.Text = "Host:";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelTitle.Location = new System.Drawing.Point(269, 17);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(460, 51);
            this.labelTitle.TabIndex = 9;
            this.labelTitle.Tag = "Launcher";
            this.labelTitle.Text = "Tower Defense - Client";
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Location = new System.Drawing.Point(266, 322);
            this.textBoxMsg.Multiline = true;
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.Size = new System.Drawing.Size(452, 49);
            this.textBoxMsg.TabIndex = 17;
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.Location = new System.Drawing.Point(567, 393);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(151, 36);
            this.buttonSend.TabIndex = 18;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.Color.Salmon;
            this.buttonStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartGame.Location = new System.Drawing.Point(266, 393);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(295, 36);
            this.buttonStartGame.TabIndex = 19;
            this.buttonStartGame.Text = "Start Game";
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Visible = false;
            this.buttonStartGame.Click += new System.EventHandler(this.ButtonStartGame_Click);
            // 
            // labelHP
            // 
            this.labelHP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelHP.AutoSize = true;
            this.labelHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHP.ForeColor = System.Drawing.Color.Green;
            this.labelHP.Location = new System.Drawing.Point(79, 24);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(122, 37);
            this.labelHP.TabIndex = 20;
            this.labelHP.Text = "HP :  0";
            this.labelHP.Visible = false;
            // 
            // labelGold
            // 
            this.labelGold.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelGold.AutoSize = true;
            this.labelGold.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGold.ForeColor = System.Drawing.Color.Gold;
            this.labelGold.Location = new System.Drawing.Point(79, 123);
            this.labelGold.Name = "labelGold";
            this.labelGold.Size = new System.Drawing.Size(46, 51);
            this.labelGold.TabIndex = 21;
            this.labelGold.Text = "0";
            this.labelGold.Visible = false;
            // 
            // labelEnemyHP
            // 
            this.labelEnemyHP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelEnemyHP.AutoSize = true;
            this.labelEnemyHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnemyHP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelEnemyHP.Location = new System.Drawing.Point(9, 75);
            this.labelEnemyHP.Name = "labelEnemyHP";
            this.labelEnemyHP.Size = new System.Drawing.Size(189, 31);
            this.labelEnemyHP.TabIndex = 22;
            this.labelEnemyHP.Text = "Enemy Hp : 0";
            this.labelEnemyHP.Visible = false;
            // 
            // panelTowerMenu
            // 
            this.panelTowerMenu.Controls.Add(this.labelStatsName);
            this.panelTowerMenu.Controls.Add(this.labelBuildPrice);
            this.panelTowerMenu.Controls.Add(this.labelSpeed);
            this.panelTowerMenu.Controls.Add(this.labelRange);
            this.panelTowerMenu.Controls.Add(this.labelDamage);
            this.panelTowerMenu.Controls.Add(this.labelTowerDesc);
            this.panelTowerMenu.Controls.Add(this.labelTowerName);
            this.panelTowerMenu.Controls.Add(this.labelTowers);
            this.panelTowerMenu.Controls.Add(this.buttonExplodeTower);
            this.panelTowerMenu.Controls.Add(this.buttonPoisonTower);
            this.panelTowerMenu.Controls.Add(this.buttonAirTower);
            this.panelTowerMenu.Controls.Add(this.buttonStormTower);
            this.panelTowerMenu.Controls.Add(this.buttonWindTower);
            this.panelTowerMenu.Controls.Add(this.buttonAirTurretTower);
            this.panelTowerMenu.Controls.Add(this.buttonFireTower);
            this.panelTowerMenu.Controls.Add(this.buttonIceTower);
            this.panelTowerMenu.Controls.Add(this.buttonCanonTower);
            this.panelTowerMenu.Controls.Add(this.buttonTurretTower);
            this.panelTowerMenu.Controls.Add(this.buttonArcherTower);
            this.panelTowerMenu.Controls.Add(this.pictureTower);
            this.panelTowerMenu.Controls.Add(this.textBoxTowerDesc);
            this.panelTowerMenu.Location = new System.Drawing.Point(12, 56);
            this.panelTowerMenu.MaximumSize = new System.Drawing.Size(500, 340);
            this.panelTowerMenu.MinimumSize = new System.Drawing.Size(500, 340);
            this.panelTowerMenu.Name = "panelTowerMenu";
            this.panelTowerMenu.Size = new System.Drawing.Size(500, 340);
            this.panelTowerMenu.TabIndex = 23;
            this.panelTowerMenu.Visible = false;
            // 
            // labelStatsName
            // 
            this.labelStatsName.AutoSize = true;
            this.labelStatsName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatsName.Location = new System.Drawing.Point(241, 192);
            this.labelStatsName.Name = "labelStatsName";
            this.labelStatsName.Size = new System.Drawing.Size(115, 24);
            this.labelStatsName.TabIndex = 25;
            this.labelStatsName.Text = "Tower stats: ";
            this.labelStatsName.Visible = false;
            // 
            // labelBuildPrice
            // 
            this.labelBuildPrice.AutoSize = true;
            this.labelBuildPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuildPrice.Location = new System.Drawing.Point(243, 270);
            this.labelBuildPrice.Name = "labelBuildPrice";
            this.labelBuildPrice.Size = new System.Drawing.Size(105, 18);
            this.labelBuildPrice.TabIndex = 24;
            this.labelBuildPrice.Text = "Price to build : ";
            this.labelBuildPrice.Visible = false;
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeed.Location = new System.Drawing.Point(243, 252);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(62, 18);
            this.labelSpeed.TabIndex = 20;
            this.labelSpeed.Text = "Speed : ";
            this.labelSpeed.Visible = false;
            // 
            // labelRange
            // 
            this.labelRange.AutoSize = true;
            this.labelRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRange.Location = new System.Drawing.Point(242, 234);
            this.labelRange.Name = "labelRange";
            this.labelRange.Size = new System.Drawing.Size(63, 18);
            this.labelRange.TabIndex = 19;
            this.labelRange.Text = "Range : ";
            this.labelRange.Visible = false;
            // 
            // labelDamage
            // 
            this.labelDamage.AutoSize = true;
            this.labelDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDamage.Location = new System.Drawing.Point(242, 216);
            this.labelDamage.Name = "labelDamage";
            this.labelDamage.Size = new System.Drawing.Size(72, 18);
            this.labelDamage.TabIndex = 18;
            this.labelDamage.Text = "Damage: ";
            this.labelDamage.Visible = false;
            // 
            // labelTowerDesc
            // 
            this.labelTowerDesc.AutoSize = true;
            this.labelTowerDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTowerDesc.Location = new System.Drawing.Point(241, 106);
            this.labelTowerDesc.Name = "labelTowerDesc";
            this.labelTowerDesc.Size = new System.Drawing.Size(173, 24);
            this.labelTowerDesc.TabIndex = 16;
            this.labelTowerDesc.Text = "Tower Description :";
            this.labelTowerDesc.Visible = false;
            // 
            // labelTowerName
            // 
            this.labelTowerName.AutoSize = true;
            this.labelTowerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTowerName.Location = new System.Drawing.Point(241, 36);
            this.labelTowerName.Name = "labelTowerName";
            this.labelTowerName.Size = new System.Drawing.Size(79, 48);
            this.labelTowerName.TabIndex = 15;
            this.labelTowerName.Text = "Tower  :\r\nArcher\r\n";
            this.labelTowerName.Visible = false;
            // 
            // labelTowers
            // 
            this.labelTowers.AutoSize = true;
            this.labelTowers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTowers.Location = new System.Drawing.Point(15, 9);
            this.labelTowers.Name = "labelTowers";
            this.labelTowers.Size = new System.Drawing.Size(83, 24);
            this.labelTowers.TabIndex = 14;
            this.labelTowers.Text = "Towers :";
            // 
            // buttonExplodeTower
            // 
            this.buttonExplodeTower.BackgroundImage = global::TowerDefenseClient.Properties.Resources.ExplodeTowerButton;
            this.buttonExplodeTower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonExplodeTower.ForeColor = System.Drawing.Color.White;
            this.buttonExplodeTower.Location = new System.Drawing.Point(87, 246);
            this.buttonExplodeTower.Name = "buttonExplodeTower";
            this.buttonExplodeTower.Size = new System.Drawing.Size(64, 64);
            this.buttonExplodeTower.TabIndex = 11;
            this.buttonExplodeTower.Text = "Explode Tower";
            this.buttonExplodeTower.UseVisualStyleBackColor = true;
            this.buttonExplodeTower.Click += new System.EventHandler(this.ButtonExplodeTower_Click);
            this.buttonExplodeTower.MouseEnter += new System.EventHandler(this.ButtonExplodeTower_MouseEnter);
            this.buttonExplodeTower.MouseLeave += new System.EventHandler(this.ButtonExplodeTower_MouseLeave);
            // 
            // buttonPoisonTower
            // 
            this.buttonPoisonTower.BackgroundImage = global::TowerDefenseClient.Properties.Resources.PoisonTowerButton;
            this.buttonPoisonTower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonPoisonTower.ForeColor = System.Drawing.Color.White;
            this.buttonPoisonTower.Location = new System.Drawing.Point(15, 246);
            this.buttonPoisonTower.Name = "buttonPoisonTower";
            this.buttonPoisonTower.Size = new System.Drawing.Size(64, 64);
            this.buttonPoisonTower.TabIndex = 10;
            this.buttonPoisonTower.Text = "Poison Tower";
            this.buttonPoisonTower.UseVisualStyleBackColor = true;
            this.buttonPoisonTower.Click += new System.EventHandler(this.ButtonPoisonTower_Click);
            this.buttonPoisonTower.MouseEnter += new System.EventHandler(this.ButtonPoisonTower_MouseEnter);
            this.buttonPoisonTower.MouseLeave += new System.EventHandler(this.ButtonPoisonTower_MouseLeave);
            // 
            // buttonAirTower
            // 
            this.buttonAirTower.BackgroundImage = global::TowerDefenseClient.Properties.Resources.AirTowerButton;
            this.buttonAirTower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAirTower.ForeColor = System.Drawing.Color.White;
            this.buttonAirTower.Location = new System.Drawing.Point(157, 106);
            this.buttonAirTower.Name = "buttonAirTower";
            this.buttonAirTower.Size = new System.Drawing.Size(64, 64);
            this.buttonAirTower.TabIndex = 9;
            this.buttonAirTower.Text = "Air Tower";
            this.buttonAirTower.UseVisualStyleBackColor = true;
            this.buttonAirTower.Click += new System.EventHandler(this.ButtonAirTower_Click);
            this.buttonAirTower.MouseEnter += new System.EventHandler(this.ButtonAirTower_MouseEnter);
            this.buttonAirTower.MouseLeave += new System.EventHandler(this.ButtonAirTower_MouseLeave);
            // 
            // buttonStormTower
            // 
            this.buttonStormTower.BackgroundImage = global::TowerDefenseClient.Properties.Resources.StormTowerButton;
            this.buttonStormTower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonStormTower.ForeColor = System.Drawing.Color.White;
            this.buttonStormTower.Location = new System.Drawing.Point(157, 176);
            this.buttonStormTower.Name = "buttonStormTower";
            this.buttonStormTower.Size = new System.Drawing.Size(64, 64);
            this.buttonStormTower.TabIndex = 8;
            this.buttonStormTower.Text = "Storm Tower";
            this.buttonStormTower.UseVisualStyleBackColor = true;
            this.buttonStormTower.Click += new System.EventHandler(this.ButtonStormTower_Click);
            this.buttonStormTower.MouseEnter += new System.EventHandler(this.ButtonStormTower_MouseEnter);
            this.buttonStormTower.MouseLeave += new System.EventHandler(this.ButtonStormTower_MouseLeave);
            // 
            // buttonWindTower
            // 
            this.buttonWindTower.BackgroundImage = global::TowerDefenseClient.Properties.Resources.WindTowerButton;
            this.buttonWindTower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonWindTower.ForeColor = System.Drawing.Color.White;
            this.buttonWindTower.Location = new System.Drawing.Point(87, 176);
            this.buttonWindTower.Name = "buttonWindTower";
            this.buttonWindTower.Size = new System.Drawing.Size(64, 64);
            this.buttonWindTower.TabIndex = 7;
            this.buttonWindTower.Text = "Wind Tower";
            this.buttonWindTower.UseVisualStyleBackColor = true;
            this.buttonWindTower.Click += new System.EventHandler(this.ButtonWindTower_Click);
            this.buttonWindTower.MouseEnter += new System.EventHandler(this.ButtonWindTower_MouseEnter);
            this.buttonWindTower.MouseLeave += new System.EventHandler(this.ButtonWindTower_MouseLeave);
            // 
            // buttonAirTurretTower
            // 
            this.buttonAirTurretTower.BackgroundImage = global::TowerDefenseClient.Properties.Resources.AirTurretTowerButton;
            this.buttonAirTurretTower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAirTurretTower.ForeColor = System.Drawing.Color.White;
            this.buttonAirTurretTower.Location = new System.Drawing.Point(15, 176);
            this.buttonAirTurretTower.Name = "buttonAirTurretTower";
            this.buttonAirTurretTower.Size = new System.Drawing.Size(64, 64);
            this.buttonAirTurretTower.TabIndex = 6;
            this.buttonAirTurretTower.Text = "AirTurret Tower";
            this.buttonAirTurretTower.UseVisualStyleBackColor = true;
            this.buttonAirTurretTower.Click += new System.EventHandler(this.ButtonAirTurretTower_Click);
            this.buttonAirTurretTower.MouseEnter += new System.EventHandler(this.ButtonAirTurretTower_MouseEnter);
            this.buttonAirTurretTower.MouseLeave += new System.EventHandler(this.ButtonAirTurretTower_MouseLeave);
            // 
            // buttonFireTower
            // 
            this.buttonFireTower.BackgroundImage = global::TowerDefenseClient.Properties.Resources.FireTowerButton;
            this.buttonFireTower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonFireTower.ForeColor = System.Drawing.Color.White;
            this.buttonFireTower.Location = new System.Drawing.Point(85, 106);
            this.buttonFireTower.Name = "buttonFireTower";
            this.buttonFireTower.Size = new System.Drawing.Size(64, 64);
            this.buttonFireTower.TabIndex = 5;
            this.buttonFireTower.Text = "Fire Tower";
            this.buttonFireTower.UseVisualStyleBackColor = true;
            this.buttonFireTower.Click += new System.EventHandler(this.ButtonFireTower_Click);
            this.buttonFireTower.MouseEnter += new System.EventHandler(this.ButtonFireTower_MouseEnter);
            this.buttonFireTower.MouseLeave += new System.EventHandler(this.ButtonFireTower_MouseLeave);
            // 
            // buttonIceTower
            // 
            this.buttonIceTower.BackgroundImage = global::TowerDefenseClient.Properties.Resources.IceTowerButton;
            this.buttonIceTower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonIceTower.ForeColor = System.Drawing.Color.White;
            this.buttonIceTower.Location = new System.Drawing.Point(155, 36);
            this.buttonIceTower.Name = "buttonIceTower";
            this.buttonIceTower.Size = new System.Drawing.Size(64, 64);
            this.buttonIceTower.TabIndex = 4;
            this.buttonIceTower.Text = "Ice Tower";
            this.buttonIceTower.UseVisualStyleBackColor = true;
            this.buttonIceTower.Click += new System.EventHandler(this.ButtonIceTower_Click);
            this.buttonIceTower.MouseEnter += new System.EventHandler(this.ButtonIceTower_MouseEnter);
            this.buttonIceTower.MouseLeave += new System.EventHandler(this.ButtonIceTower_MouseLeave);
            // 
            // buttonCanonTower
            // 
            this.buttonCanonTower.BackgroundImage = global::TowerDefenseClient.Properties.Resources.CanonTowerButton;
            this.buttonCanonTower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCanonTower.ForeColor = System.Drawing.Color.White;
            this.buttonCanonTower.Location = new System.Drawing.Point(15, 106);
            this.buttonCanonTower.Name = "buttonCanonTower";
            this.buttonCanonTower.Size = new System.Drawing.Size(64, 64);
            this.buttonCanonTower.TabIndex = 3;
            this.buttonCanonTower.Text = "Canon Tower";
            this.buttonCanonTower.UseVisualStyleBackColor = true;
            this.buttonCanonTower.Click += new System.EventHandler(this.ButtonCanonTower_Click);
            this.buttonCanonTower.MouseEnter += new System.EventHandler(this.ButtonCanonTower_MouseEnter);
            this.buttonCanonTower.MouseLeave += new System.EventHandler(this.ButtonCanonTower_MouseLeave);
            // 
            // buttonTurretTower
            // 
            this.buttonTurretTower.BackgroundImage = global::TowerDefenseClient.Properties.Resources.TurretTowerButton;
            this.buttonTurretTower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTurretTower.ForeColor = System.Drawing.Color.White;
            this.buttonTurretTower.Location = new System.Drawing.Point(85, 36);
            this.buttonTurretTower.Name = "buttonTurretTower";
            this.buttonTurretTower.Size = new System.Drawing.Size(64, 64);
            this.buttonTurretTower.TabIndex = 2;
            this.buttonTurretTower.Text = "Turret Tower";
            this.buttonTurretTower.UseVisualStyleBackColor = true;
            this.buttonTurretTower.Click += new System.EventHandler(this.ButtonTurretTower_Click);
            this.buttonTurretTower.MouseEnter += new System.EventHandler(this.ButtonTurretTower_MouseEnter);
            this.buttonTurretTower.MouseLeave += new System.EventHandler(this.ButtonTurretTower_MouseLeave);
            // 
            // buttonArcherTower
            // 
            this.buttonArcherTower.BackgroundImage = global::TowerDefenseClient.Properties.Resources.ArcherTowerButton;
            this.buttonArcherTower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonArcherTower.ForeColor = System.Drawing.Color.White;
            this.buttonArcherTower.Location = new System.Drawing.Point(15, 36);
            this.buttonArcherTower.Name = "buttonArcherTower";
            this.buttonArcherTower.Size = new System.Drawing.Size(64, 64);
            this.buttonArcherTower.TabIndex = 1;
            this.buttonArcherTower.Text = "Archer Tower";
            this.buttonArcherTower.UseVisualStyleBackColor = true;
            this.buttonArcherTower.Click += new System.EventHandler(this.ButtonArcherTower_Click);
            this.buttonArcherTower.MouseEnter += new System.EventHandler(this.ButtonArcherTower_MouseEnter);
            this.buttonArcherTower.MouseLeave += new System.EventHandler(this.ButtonArcherTower_MouseLeave);
            // 
            // pictureTower
            // 
            this.pictureTower.Image = global::TowerDefenseClient.Properties.Resources.ArcherTower;
            this.pictureTower.InitialImage = global::TowerDefenseClient.Properties.Resources.AirTower;
            this.pictureTower.Location = new System.Drawing.Point(372, 36);
            this.pictureTower.Name = "pictureTower";
            this.pictureTower.Size = new System.Drawing.Size(64, 64);
            this.pictureTower.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureTower.TabIndex = 0;
            this.pictureTower.TabStop = false;
            this.pictureTower.Visible = false;
            // 
            // textBoxTowerDesc
            // 
            this.textBoxTowerDesc.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBoxTowerDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTowerDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTowerDesc.Location = new System.Drawing.Point(244, 136);
            this.textBoxTowerDesc.Multiline = true;
            this.textBoxTowerDesc.Name = "textBoxTowerDesc";
            this.textBoxTowerDesc.ReadOnly = true;
            this.textBoxTowerDesc.Size = new System.Drawing.Size(239, 55);
            this.textBoxTowerDesc.TabIndex = 30;
            // 
            // panelUpgradeMenu
            // 
            this.panelUpgradeMenu.Controls.Add(this.buttonSell);
            this.panelUpgradeMenu.Controls.Add(this.buttonUpgrade);
            this.panelUpgradeMenu.Controls.Add(this.labelUpgradeSpeed);
            this.panelUpgradeMenu.Controls.Add(this.labelUpgradeRange);
            this.panelUpgradeMenu.Controls.Add(this.labelUpgradeDamage);
            this.panelUpgradeMenu.Controls.Add(this.labelUpgradeStatsName);
            this.panelUpgradeMenu.Controls.Add(this.labelUpgradeTowerName);
            this.panelUpgradeMenu.Location = new System.Drawing.Point(636, 86);
            this.panelUpgradeMenu.MaximumSize = new System.Drawing.Size(380, 230);
            this.panelUpgradeMenu.MinimumSize = new System.Drawing.Size(380, 230);
            this.panelUpgradeMenu.Name = "panelUpgradeMenu";
            this.panelUpgradeMenu.Size = new System.Drawing.Size(380, 230);
            this.panelUpgradeMenu.TabIndex = 24;
            this.panelUpgradeMenu.Visible = false;
            // 
            // buttonSell
            // 
            this.buttonSell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonSell.BackgroundImage = global::TowerDefenseClient.Properties.Resources.SellButton;
            this.buttonSell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSell.Location = new System.Drawing.Point(209, 155);
            this.buttonSell.Name = "buttonSell";
            this.buttonSell.Size = new System.Drawing.Size(148, 52);
            this.buttonSell.TabIndex = 27;
            this.buttonSell.Text = "Sell";
            this.buttonSell.UseVisualStyleBackColor = false;
            this.buttonSell.Click += new System.EventHandler(this.ButtonSell_Click);
            // 
            // buttonUpgrade
            // 
            this.buttonUpgrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonUpgrade.BackgroundImage = global::TowerDefenseClient.Properties.Resources.UpgradeButton;
            this.buttonUpgrade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonUpgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpgrade.Location = new System.Drawing.Point(20, 155);
            this.buttonUpgrade.Name = "buttonUpgrade";
            this.buttonUpgrade.Size = new System.Drawing.Size(183, 52);
            this.buttonUpgrade.TabIndex = 25;
            this.buttonUpgrade.Text = "Upgrade";
            this.buttonUpgrade.UseVisualStyleBackColor = false;
            this.buttonUpgrade.Click += new System.EventHandler(this.ButtonUpgrade_Click);
            // 
            // labelUpgradeSpeed
            // 
            this.labelUpgradeSpeed.AutoSize = true;
            this.labelUpgradeSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpgradeSpeed.Location = new System.Drawing.Point(17, 124);
            this.labelUpgradeSpeed.Name = "labelUpgradeSpeed";
            this.labelUpgradeSpeed.Size = new System.Drawing.Size(62, 18);
            this.labelUpgradeSpeed.TabIndex = 26;
            this.labelUpgradeSpeed.Text = "Speed : ";
            // 
            // labelUpgradeRange
            // 
            this.labelUpgradeRange.AutoSize = true;
            this.labelUpgradeRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpgradeRange.Location = new System.Drawing.Point(17, 106);
            this.labelUpgradeRange.Name = "labelUpgradeRange";
            this.labelUpgradeRange.Size = new System.Drawing.Size(63, 18);
            this.labelUpgradeRange.TabIndex = 26;
            this.labelUpgradeRange.Text = "Range : ";
            // 
            // labelUpgradeDamage
            // 
            this.labelUpgradeDamage.AutoSize = true;
            this.labelUpgradeDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpgradeDamage.Location = new System.Drawing.Point(17, 85);
            this.labelUpgradeDamage.Name = "labelUpgradeDamage";
            this.labelUpgradeDamage.Size = new System.Drawing.Size(72, 18);
            this.labelUpgradeDamage.TabIndex = 26;
            this.labelUpgradeDamage.Text = "Damage: ";
            // 
            // labelUpgradeStatsName
            // 
            this.labelUpgradeStatsName.AutoSize = true;
            this.labelUpgradeStatsName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpgradeStatsName.Location = new System.Drawing.Point(16, 55);
            this.labelUpgradeStatsName.Name = "labelUpgradeStatsName";
            this.labelUpgradeStatsName.Size = new System.Drawing.Size(168, 20);
            this.labelUpgradeStatsName.TabIndex = 26;
            this.labelUpgradeStatsName.Text = "Upgrade Tower Stats :";
            // 
            // labelUpgradeTowerName
            // 
            this.labelUpgradeTowerName.AutoSize = true;
            this.labelUpgradeTowerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpgradeTowerName.Location = new System.Drawing.Point(16, 15);
            this.labelUpgradeTowerName.Name = "labelUpgradeTowerName";
            this.labelUpgradeTowerName.Size = new System.Drawing.Size(141, 24);
            this.labelUpgradeTowerName.TabIndex = 26;
            this.labelUpgradeTowerName.Text = "Tower  : Archer\r\n";
            // 
            // panelMonsterMenu
            // 
            this.panelMonsterMenu.Controls.Add(this.textBoxMonsterDesc);
            this.panelMonsterMenu.Controls.Add(this.labelMonsterReward);
            this.panelMonsterMenu.Controls.Add(this.labelMonsterStats);
            this.panelMonsterMenu.Controls.Add(this.labelMonsterPrice);
            this.panelMonsterMenu.Controls.Add(this.labelMonsterSpeed);
            this.panelMonsterMenu.Controls.Add(this.labelMonsterDamage);
            this.panelMonsterMenu.Controls.Add(this.labelMonsterHP);
            this.panelMonsterMenu.Controls.Add(this.labelMonsterDesc);
            this.panelMonsterMenu.Controls.Add(this.labelMonsterName);
            this.panelMonsterMenu.Controls.Add(this.pictureBoxMonster);
            this.panelMonsterMenu.Controls.Add(this.buttonGolem);
            this.panelMonsterMenu.Controls.Add(this.buttonGhidorah);
            this.panelMonsterMenu.Controls.Add(this.buttonDragon);
            this.panelMonsterMenu.Controls.Add(this.buttonGargoyle);
            this.panelMonsterMenu.Controls.Add(this.buttonPterodactyl);
            this.panelMonsterMenu.Controls.Add(this.buttonWyvern);
            this.panelMonsterMenu.Controls.Add(this.buttonWerewolf);
            this.panelMonsterMenu.Controls.Add(this.buttonGhoul);
            this.panelMonsterMenu.Controls.Add(this.buttonIceBear);
            this.panelMonsterMenu.Controls.Add(this.buttonDevil);
            this.panelMonsterMenu.Controls.Add(this.buttonBear);
            this.panelMonsterMenu.Controls.Add(this.buttonIceSpider);
            this.panelMonsterMenu.Controls.Add(this.buttonSprider);
            this.panelMonsterMenu.Controls.Add(this.labelMonsters);
            this.panelMonsterMenu.Location = new System.Drawing.Point(36, 32);
            this.panelMonsterMenu.MaximumSize = new System.Drawing.Size(550, 350);
            this.panelMonsterMenu.MinimumSize = new System.Drawing.Size(550, 350);
            this.panelMonsterMenu.Name = "panelMonsterMenu";
            this.panelMonsterMenu.Size = new System.Drawing.Size(550, 350);
            this.panelMonsterMenu.TabIndex = 25;
            this.panelMonsterMenu.Visible = false;
            // 
            // textBoxMonsterDesc
            // 
            this.textBoxMonsterDesc.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBoxMonsterDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMonsterDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMonsterDesc.Location = new System.Drawing.Point(312, 149);
            this.textBoxMonsterDesc.Multiline = true;
            this.textBoxMonsterDesc.Name = "textBoxMonsterDesc";
            this.textBoxMonsterDesc.ReadOnly = true;
            this.textBoxMonsterDesc.Size = new System.Drawing.Size(223, 55);
            this.textBoxMonsterDesc.TabIndex = 29;
            // 
            // labelMonsterReward
            // 
            this.labelMonsterReward.AutoSize = true;
            this.labelMonsterReward.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonsterReward.Location = new System.Drawing.Point(310, 302);
            this.labelMonsterReward.Name = "labelMonsterReward";
            this.labelMonsterReward.Size = new System.Drawing.Size(133, 18);
            this.labelMonsterReward.TabIndex = 51;
            this.labelMonsterReward.Text = "Reward for killing : ";
            this.labelMonsterReward.Visible = false;
            // 
            // labelMonsterStats
            // 
            this.labelMonsterStats.AutoSize = true;
            this.labelMonsterStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonsterStats.Location = new System.Drawing.Point(308, 206);
            this.labelMonsterStats.Name = "labelMonsterStats";
            this.labelMonsterStats.Size = new System.Drawing.Size(129, 24);
            this.labelMonsterStats.TabIndex = 50;
            this.labelMonsterStats.Text = "Monster stats: ";
            this.labelMonsterStats.Visible = false;
            // 
            // labelMonsterPrice
            // 
            this.labelMonsterPrice.AutoSize = true;
            this.labelMonsterPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonsterPrice.Location = new System.Drawing.Point(310, 284);
            this.labelMonsterPrice.Name = "labelMonsterPrice";
            this.labelMonsterPrice.Size = new System.Drawing.Size(58, 18);
            this.labelMonsterPrice.TabIndex = 49;
            this.labelMonsterPrice.Text = "Price  : ";
            this.labelMonsterPrice.Visible = false;
            // 
            // labelMonsterSpeed
            // 
            this.labelMonsterSpeed.AutoSize = true;
            this.labelMonsterSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonsterSpeed.Location = new System.Drawing.Point(310, 266);
            this.labelMonsterSpeed.Name = "labelMonsterSpeed";
            this.labelMonsterSpeed.Size = new System.Drawing.Size(62, 18);
            this.labelMonsterSpeed.TabIndex = 48;
            this.labelMonsterSpeed.Text = "Speed : ";
            this.labelMonsterSpeed.Visible = false;
            // 
            // labelMonsterDamage
            // 
            this.labelMonsterDamage.AutoSize = true;
            this.labelMonsterDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonsterDamage.Location = new System.Drawing.Point(309, 248);
            this.labelMonsterDamage.Name = "labelMonsterDamage";
            this.labelMonsterDamage.Size = new System.Drawing.Size(76, 18);
            this.labelMonsterDamage.TabIndex = 47;
            this.labelMonsterDamage.Text = "Damage : ";
            this.labelMonsterDamage.Visible = false;
            // 
            // labelMonsterHP
            // 
            this.labelMonsterHP.AutoSize = true;
            this.labelMonsterHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonsterHP.Location = new System.Drawing.Point(309, 230);
            this.labelMonsterHP.Name = "labelMonsterHP";
            this.labelMonsterHP.Size = new System.Drawing.Size(37, 18);
            this.labelMonsterHP.TabIndex = 46;
            this.labelMonsterHP.Text = "HP :";
            this.labelMonsterHP.Visible = false;
            // 
            // labelMonsterDesc
            // 
            this.labelMonsterDesc.AutoSize = true;
            this.labelMonsterDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonsterDesc.Location = new System.Drawing.Point(308, 120);
            this.labelMonsterDesc.Name = "labelMonsterDesc";
            this.labelMonsterDesc.Size = new System.Drawing.Size(187, 24);
            this.labelMonsterDesc.TabIndex = 44;
            this.labelMonsterDesc.Text = "Monster Description :";
            this.labelMonsterDesc.Visible = false;
            // 
            // labelMonsterName
            // 
            this.labelMonsterName.AutoSize = true;
            this.labelMonsterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonsterName.Location = new System.Drawing.Point(308, 50);
            this.labelMonsterName.Name = "labelMonsterName";
            this.labelMonsterName.Size = new System.Drawing.Size(93, 72);
            this.labelMonsterName.TabIndex = 43;
            this.labelMonsterName.Text = "Monster  :\r\nSpider\r\n\r\n";
            this.labelMonsterName.Visible = false;
            // 
            // pictureBoxMonster
            // 
            this.pictureBoxMonster.Image = global::TowerDefenseClient.Properties.Resources.Spider;
            this.pictureBoxMonster.InitialImage = global::TowerDefenseClient.Properties.Resources.AirTower;
            this.pictureBoxMonster.Location = new System.Drawing.Point(408, 50);
            this.pictureBoxMonster.Name = "pictureBoxMonster";
            this.pictureBoxMonster.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxMonster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMonster.TabIndex = 42;
            this.pictureBoxMonster.TabStop = false;
            this.pictureBoxMonster.Visible = false;
            // 
            // buttonGolem
            // 
            this.buttonGolem.BackgroundImage = global::TowerDefenseClient.Properties.Resources.Golem;
            this.buttonGolem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGolem.ForeColor = System.Drawing.Color.White;
            this.buttonGolem.Location = new System.Drawing.Point(157, 115);
            this.buttonGolem.Name = "buttonGolem";
            this.buttonGolem.Size = new System.Drawing.Size(64, 64);
            this.buttonGolem.TabIndex = 41;
            this.buttonGolem.Text = "Golem";
            this.buttonGolem.UseVisualStyleBackColor = true;
            this.buttonGolem.Click += new System.EventHandler(this.ButtonGolem_Click);
            this.buttonGolem.MouseEnter += new System.EventHandler(this.ButtonGolem_MouseEnter);
            this.buttonGolem.MouseLeave += new System.EventHandler(this.ButtonGolem_MouseLeave);
            // 
            // buttonGhidorah
            // 
            this.buttonGhidorah.BackgroundImage = global::TowerDefenseClient.Properties.Resources.Ghidorah;
            this.buttonGhidorah.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGhidorah.ForeColor = System.Drawing.Color.White;
            this.buttonGhidorah.Location = new System.Drawing.Point(17, 255);
            this.buttonGhidorah.Name = "buttonGhidorah";
            this.buttonGhidorah.Size = new System.Drawing.Size(64, 64);
            this.buttonGhidorah.TabIndex = 40;
            this.buttonGhidorah.Text = "Ghidorah";
            this.buttonGhidorah.UseVisualStyleBackColor = true;
            this.buttonGhidorah.Click += new System.EventHandler(this.ButtonGhidorah_Click);
            this.buttonGhidorah.MouseEnter += new System.EventHandler(this.ButtonGhidorah_MouseEnter);
            this.buttonGhidorah.MouseLeave += new System.EventHandler(this.ButtonGhidorah_MouseLeave);
            // 
            // buttonDragon
            // 
            this.buttonDragon.BackgroundImage = global::TowerDefenseClient.Properties.Resources.Dragon;
            this.buttonDragon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDragon.ForeColor = System.Drawing.Color.White;
            this.buttonDragon.Location = new System.Drawing.Point(227, 185);
            this.buttonDragon.Name = "buttonDragon";
            this.buttonDragon.Size = new System.Drawing.Size(64, 64);
            this.buttonDragon.TabIndex = 39;
            this.buttonDragon.Text = "Dragon";
            this.buttonDragon.UseVisualStyleBackColor = true;
            this.buttonDragon.Click += new System.EventHandler(this.ButtonDragon_Click);
            this.buttonDragon.MouseEnter += new System.EventHandler(this.ButtonDragon_MouseEnter);
            this.buttonDragon.MouseLeave += new System.EventHandler(this.ButtonDragon_MouseLeave);
            // 
            // buttonGargoyle
            // 
            this.buttonGargoyle.BackgroundImage = global::TowerDefenseClient.Properties.Resources.Gargoyle;
            this.buttonGargoyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGargoyle.ForeColor = System.Drawing.Color.White;
            this.buttonGargoyle.Location = new System.Drawing.Point(157, 185);
            this.buttonGargoyle.Name = "buttonGargoyle";
            this.buttonGargoyle.Size = new System.Drawing.Size(64, 64);
            this.buttonGargoyle.TabIndex = 38;
            this.buttonGargoyle.Text = "Gargoyle";
            this.buttonGargoyle.UseVisualStyleBackColor = true;
            this.buttonGargoyle.Click += new System.EventHandler(this.ButtonGargoyle_Click);
            this.buttonGargoyle.MouseEnter += new System.EventHandler(this.ButtonGargoyle_MouseEnter);
            this.buttonGargoyle.MouseLeave += new System.EventHandler(this.ButtonGargoyle_MouseLeave);
            // 
            // buttonPterodactyl
            // 
            this.buttonPterodactyl.BackgroundImage = global::TowerDefenseClient.Properties.Resources.Pterodactyl;
            this.buttonPterodactyl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonPterodactyl.ForeColor = System.Drawing.Color.White;
            this.buttonPterodactyl.Location = new System.Drawing.Point(87, 185);
            this.buttonPterodactyl.Name = "buttonPterodactyl";
            this.buttonPterodactyl.Size = new System.Drawing.Size(64, 64);
            this.buttonPterodactyl.TabIndex = 37;
            this.buttonPterodactyl.Text = "Pterodactyl";
            this.buttonPterodactyl.UseVisualStyleBackColor = true;
            this.buttonPterodactyl.Click += new System.EventHandler(this.ButtonPterodactyl_Click);
            this.buttonPterodactyl.MouseEnter += new System.EventHandler(this.ButtonPterodactyl_MouseEnter);
            this.buttonPterodactyl.MouseLeave += new System.EventHandler(this.ButtonPterodactyl_MouseLeave);
            // 
            // buttonWyvern
            // 
            this.buttonWyvern.BackgroundImage = global::TowerDefenseClient.Properties.Resources.Wyvern;
            this.buttonWyvern.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonWyvern.ForeColor = System.Drawing.Color.White;
            this.buttonWyvern.Location = new System.Drawing.Point(17, 185);
            this.buttonWyvern.Name = "buttonWyvern";
            this.buttonWyvern.Size = new System.Drawing.Size(64, 64);
            this.buttonWyvern.TabIndex = 36;
            this.buttonWyvern.Text = "Wyvern";
            this.buttonWyvern.UseVisualStyleBackColor = true;
            this.buttonWyvern.Click += new System.EventHandler(this.ButtonWyvern_Click);
            this.buttonWyvern.MouseEnter += new System.EventHandler(this.ButtonWyvern_MouseEnter);
            this.buttonWyvern.MouseLeave += new System.EventHandler(this.ButtonWyvern_MouseLeave);
            // 
            // buttonWerewolf
            // 
            this.buttonWerewolf.BackgroundImage = global::TowerDefenseClient.Properties.Resources.Werewolf;
            this.buttonWerewolf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonWerewolf.ForeColor = System.Drawing.Color.White;
            this.buttonWerewolf.Location = new System.Drawing.Point(87, 116);
            this.buttonWerewolf.Name = "buttonWerewolf";
            this.buttonWerewolf.Size = new System.Drawing.Size(64, 64);
            this.buttonWerewolf.TabIndex = 35;
            this.buttonWerewolf.Text = "Werewolf";
            this.buttonWerewolf.UseVisualStyleBackColor = true;
            this.buttonWerewolf.Click += new System.EventHandler(this.ButtonWerewolf_Click);
            this.buttonWerewolf.MouseEnter += new System.EventHandler(this.ButtonWerewolf_MouseEnter);
            this.buttonWerewolf.MouseLeave += new System.EventHandler(this.ButtonWerewolf_MouseLeave);
            // 
            // buttonGhoul
            // 
            this.buttonGhoul.BackgroundImage = global::TowerDefenseClient.Properties.Resources.Ghoul;
            this.buttonGhoul.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGhoul.ForeColor = System.Drawing.Color.White;
            this.buttonGhoul.Location = new System.Drawing.Point(17, 115);
            this.buttonGhoul.Name = "buttonGhoul";
            this.buttonGhoul.Size = new System.Drawing.Size(64, 64);
            this.buttonGhoul.TabIndex = 34;
            this.buttonGhoul.Text = "Ghoul";
            this.buttonGhoul.UseVisualStyleBackColor = true;
            this.buttonGhoul.Click += new System.EventHandler(this.ButtonGhoul_Click);
            this.buttonGhoul.MouseEnter += new System.EventHandler(this.ButtonGhoul_MouseEnter);
            this.buttonGhoul.MouseLeave += new System.EventHandler(this.ButtonGhoul_MouseLeave);
            // 
            // buttonIceBear
            // 
            this.buttonIceBear.BackgroundImage = global::TowerDefenseClient.Properties.Resources.IceBear;
            this.buttonIceBear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonIceBear.ForeColor = System.Drawing.Color.White;
            this.buttonIceBear.Location = new System.Drawing.Point(227, 46);
            this.buttonIceBear.Name = "buttonIceBear";
            this.buttonIceBear.Size = new System.Drawing.Size(64, 64);
            this.buttonIceBear.TabIndex = 33;
            this.buttonIceBear.Text = "Ice Bear";
            this.buttonIceBear.UseVisualStyleBackColor = true;
            this.buttonIceBear.Click += new System.EventHandler(this.ButtonIceBear_Click);
            this.buttonIceBear.MouseEnter += new System.EventHandler(this.ButtonIceBear_MouseEnter);
            this.buttonIceBear.MouseLeave += new System.EventHandler(this.ButtonIceBear_MouseLeave);
            // 
            // buttonDevil
            // 
            this.buttonDevil.BackgroundImage = global::TowerDefenseClient.Properties.Resources.Devil;
            this.buttonDevil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDevil.ForeColor = System.Drawing.Color.White;
            this.buttonDevil.Location = new System.Drawing.Point(227, 116);
            this.buttonDevil.Name = "buttonDevil";
            this.buttonDevil.Size = new System.Drawing.Size(64, 64);
            this.buttonDevil.TabIndex = 32;
            this.buttonDevil.Text = "Devil";
            this.buttonDevil.UseVisualStyleBackColor = true;
            this.buttonDevil.Click += new System.EventHandler(this.ButtonDevil_Click);
            this.buttonDevil.MouseEnter += new System.EventHandler(this.ButtonDevil_MouseEnter);
            this.buttonDevil.MouseLeave += new System.EventHandler(this.ButtonDevil_MouseLeave);
            // 
            // buttonBear
            // 
            this.buttonBear.BackgroundImage = global::TowerDefenseClient.Properties.Resources.Bear;
            this.buttonBear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonBear.ForeColor = System.Drawing.Color.White;
            this.buttonBear.Location = new System.Drawing.Point(157, 46);
            this.buttonBear.Name = "buttonBear";
            this.buttonBear.Size = new System.Drawing.Size(64, 64);
            this.buttonBear.TabIndex = 31;
            this.buttonBear.Text = "Bear";
            this.buttonBear.UseVisualStyleBackColor = true;
            this.buttonBear.Click += new System.EventHandler(this.ButtonBear_Click);
            this.buttonBear.MouseEnter += new System.EventHandler(this.ButtonBear_MouseEnter);
            this.buttonBear.MouseLeave += new System.EventHandler(this.ButtonBear_MouseLeave);
            // 
            // buttonIceSpider
            // 
            this.buttonIceSpider.BackgroundImage = global::TowerDefenseClient.Properties.Resources.IceSpider;
            this.buttonIceSpider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonIceSpider.ForeColor = System.Drawing.Color.White;
            this.buttonIceSpider.Location = new System.Drawing.Point(87, 46);
            this.buttonIceSpider.Name = "buttonIceSpider";
            this.buttonIceSpider.Size = new System.Drawing.Size(64, 64);
            this.buttonIceSpider.TabIndex = 30;
            this.buttonIceSpider.Text = "Ice Spider";
            this.buttonIceSpider.UseVisualStyleBackColor = true;
            this.buttonIceSpider.Click += new System.EventHandler(this.ButtonIceSpider_Click);
            this.buttonIceSpider.MouseEnter += new System.EventHandler(this.ButtonIceSpider_MouseEnter);
            this.buttonIceSpider.MouseLeave += new System.EventHandler(this.ButtonIceSpider_MouseLeave);
            // 
            // buttonSprider
            // 
            this.buttonSprider.BackgroundImage = global::TowerDefenseClient.Properties.Resources.Spider;
            this.buttonSprider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSprider.ForeColor = System.Drawing.Color.White;
            this.buttonSprider.Location = new System.Drawing.Point(17, 46);
            this.buttonSprider.Name = "buttonSprider";
            this.buttonSprider.Size = new System.Drawing.Size(64, 64);
            this.buttonSprider.TabIndex = 29;
            this.buttonSprider.Text = "Spider";
            this.buttonSprider.UseVisualStyleBackColor = true;
            this.buttonSprider.Click += new System.EventHandler(this.ButtonSprider_Click);
            this.buttonSprider.MouseEnter += new System.EventHandler(this.ButtonSprider_MouseEnter);
            this.buttonSprider.MouseLeave += new System.EventHandler(this.ButtonSprider_MouseLeave);
            // 
            // labelMonsters
            // 
            this.labelMonsters.AutoSize = true;
            this.labelMonsters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonsters.Location = new System.Drawing.Point(13, 14);
            this.labelMonsters.Name = "labelMonsters";
            this.labelMonsters.Size = new System.Drawing.Size(97, 24);
            this.labelMonsters.TabIndex = 28;
            this.labelMonsters.Text = "Monsters :";
            // 
            // panelGameEnd
            // 
            this.panelGameEnd.BackColor = System.Drawing.SystemColors.Control;
            this.panelGameEnd.Controls.Add(this.labelEndResult);
            this.panelGameEnd.Location = new System.Drawing.Point(36, 425);
            this.panelGameEnd.Name = "panelGameEnd";
            this.panelGameEnd.Size = new System.Drawing.Size(412, 130);
            this.panelGameEnd.TabIndex = 26;
            this.panelGameEnd.Visible = false;
            // 
            // labelEndResult
            // 
            this.labelEndResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEndResult.AutoSize = true;
            this.labelEndResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndResult.ForeColor = System.Drawing.Color.Black;
            this.labelEndResult.Location = new System.Drawing.Point(122, 35);
            this.labelEndResult.Name = "labelEndResult";
            this.labelEndResult.Size = new System.Drawing.Size(155, 51);
            this.labelEndResult.TabIndex = 0;
            this.labelEndResult.Text = "Victory";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.Silver;
            this.panelInfo.Controls.Add(this.pictureBoxHP);
            this.panelInfo.Controls.Add(this.pictureBoxGolds);
            this.panelInfo.Controls.Add(this.labelChat);
            this.panelInfo.Controls.Add(this.textBoxChat);
            this.panelInfo.Controls.Add(this.textBoxMessage);
            this.panelInfo.Controls.Add(this.buttonSendMessage);
            this.panelInfo.Controls.Add(this.labelGold);
            this.panelInfo.Controls.Add(this.labelHP);
            this.panelInfo.Controls.Add(this.labelEnemyHP);
            this.panelInfo.Location = new System.Drawing.Point(771, 12);
            this.panelInfo.MaximumSize = new System.Drawing.Size(300, 0);
            this.panelInfo.MinimumSize = new System.Drawing.Size(300, 600);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(300, 600);
            this.panelInfo.TabIndex = 28;
            this.panelInfo.Visible = false;
            // 
            // pictureBoxHP
            // 
            this.pictureBoxHP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxHP.Image = global::TowerDefenseClient.Properties.Resources.HP;
            this.pictureBoxHP.Location = new System.Drawing.Point(9, 12);
            this.pictureBoxHP.Name = "pictureBoxHP";
            this.pictureBoxHP.Size = new System.Drawing.Size(64, 60);
            this.pictureBoxHP.TabIndex = 30;
            this.pictureBoxHP.TabStop = false;
            // 
            // pictureBoxGolds
            // 
            this.pictureBoxGolds.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxGolds.Image = global::TowerDefenseClient.Properties.Resources.SellButton;
            this.pictureBoxGolds.Location = new System.Drawing.Point(9, 121);
            this.pictureBoxGolds.Name = "pictureBoxGolds";
            this.pictureBoxGolds.Size = new System.Drawing.Size(64, 56);
            this.pictureBoxGolds.TabIndex = 29;
            this.pictureBoxGolds.TabStop = false;
            // 
            // labelChat
            // 
            this.labelChat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelChat.AutoSize = true;
            this.labelChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChat.ForeColor = System.Drawing.Color.Black;
            this.labelChat.Location = new System.Drawing.Point(6, 189);
            this.labelChat.Name = "labelChat";
            this.labelChat.Size = new System.Drawing.Size(124, 26);
            this.labelChat.TabIndex = 28;
            this.labelChat.Text = "Game Chat";
            // 
            // textBoxChat
            // 
            this.textBoxChat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxChat.Location = new System.Drawing.Point(6, 226);
            this.textBoxChat.Multiline = true;
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.ReadOnly = true;
            this.textBoxChat.Size = new System.Drawing.Size(291, 260);
            this.textBoxChat.TabIndex = 14;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxMessage.Location = new System.Drawing.Point(6, 494);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(291, 49);
            this.textBoxMessage.TabIndex = 17;
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSendMessage.Location = new System.Drawing.Point(6, 556);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(291, 36);
            this.buttonSendMessage.TabIndex = 18;
            this.buttonSendMessage.Text = "Send Message";
            this.buttonSendMessage.UseVisualStyleBackColor = false;
            this.buttonSendMessage.Click += new System.EventHandler(this.ButtonSendMessage_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(988, 601);
            this.Controls.Add(this.panelMonsterMenu);
            this.Controls.Add(this.panelTowerMenu);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelGameEnd);
            this.Controls.Add(this.panelUpgradeMenu);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxHost);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelHost);
            this.Controls.Add(this.labelTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1004, 640);
            this.Name = "ClientForm";
            this.Text = "Tower Defense";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ClientForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClientForm_MouseClick);
            this.panelTowerMenu.ResumeLayout(false);
            this.panelTowerMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTower)).EndInit();
            this.panelUpgradeMenu.ResumeLayout(false);
            this.panelUpgradeMenu.PerformLayout();
            this.panelMonsterMenu.ResumeLayout(false);
            this.panelMonsterMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMonster)).EndInit();
            this.panelGameEnd.ResumeLayout(false);
            this.panelGameEnd.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGolds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.Label labelGold;
        private System.Windows.Forms.Label labelEnemyHP;
        private System.Windows.Forms.Panel panelTowerMenu;
        private System.Windows.Forms.PictureBox pictureTower;
        private System.Windows.Forms.Button buttonTurretTower;
        private System.Windows.Forms.Button buttonArcherTower;
        private System.Windows.Forms.Label labelTowerDesc;
        private System.Windows.Forms.Label labelTowerName;
        private System.Windows.Forms.Label labelTowers;
        private System.Windows.Forms.Button buttonExplodeTower;
        private System.Windows.Forms.Button buttonPoisonTower;
        private System.Windows.Forms.Button buttonAirTower;
        private System.Windows.Forms.Button buttonStormTower;
        private System.Windows.Forms.Button buttonWindTower;
        private System.Windows.Forms.Button buttonAirTurretTower;
        private System.Windows.Forms.Button buttonFireTower;
        private System.Windows.Forms.Button buttonIceTower;
        private System.Windows.Forms.Button buttonCanonTower;
        private System.Windows.Forms.Label labelRange;
        private System.Windows.Forms.Label labelDamage;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelBuildPrice;
        private System.Windows.Forms.Label labelStatsName;
        private System.Windows.Forms.Panel panelUpgradeMenu;
        private System.Windows.Forms.Label labelUpgradeSpeed;
        private System.Windows.Forms.Label labelUpgradeRange;
        private System.Windows.Forms.Label labelUpgradeDamage;
        private System.Windows.Forms.Label labelUpgradeStatsName;
        private System.Windows.Forms.Label labelUpgradeTowerName;
        private System.Windows.Forms.Button buttonSell;
        private System.Windows.Forms.Button buttonUpgrade;
        private System.Windows.Forms.Panel panelMonsterMenu;
        private System.Windows.Forms.Button buttonGolem;
        private System.Windows.Forms.Button buttonGhidorah;
        private System.Windows.Forms.Button buttonDragon;
        private System.Windows.Forms.Button buttonGargoyle;
        private System.Windows.Forms.Button buttonPterodactyl;
        private System.Windows.Forms.Button buttonWyvern;
        private System.Windows.Forms.Button buttonWerewolf;
        private System.Windows.Forms.Button buttonGhoul;
        private System.Windows.Forms.Button buttonIceBear;
        private System.Windows.Forms.Button buttonDevil;
        private System.Windows.Forms.Button buttonBear;
        private System.Windows.Forms.Button buttonIceSpider;
        private System.Windows.Forms.Button buttonSprider;
        private System.Windows.Forms.Label labelMonsters;
        private System.Windows.Forms.Label labelMonsterReward;
        private System.Windows.Forms.Label labelMonsterStats;
        private System.Windows.Forms.Label labelMonsterPrice;
        private System.Windows.Forms.Label labelMonsterSpeed;
        private System.Windows.Forms.Label labelMonsterDamage;
        private System.Windows.Forms.Label labelMonsterHP;
        private System.Windows.Forms.Label labelMonsterDesc;
        private System.Windows.Forms.Label labelMonsterName;
        private System.Windows.Forms.PictureBox pictureBoxMonster;
        private System.Windows.Forms.Panel panelGameEnd;
        private System.Windows.Forms.Label labelEndResult;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelChat;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.PictureBox pictureBoxGolds;
        private System.Windows.Forms.PictureBox pictureBoxHP;
        private System.Windows.Forms.TextBox textBoxTowerDesc;
        private System.Windows.Forms.TextBox textBoxMonsterDesc;
    }
}

