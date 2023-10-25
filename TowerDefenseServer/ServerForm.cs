using System;
using System.Windows.Forms;
using System.Net;

namespace TowerDefenseServer
{
    public partial class ServerForm : Form
    {
        private Server server = null;
       
       
        public ServerForm()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Prints text message to the server text area.
        /// </summary>
        /// <param name="msg">text message</param>
        public void AppendToServerStatus(string msg)
        {
            this.Invoke((MethodInvoker)delegate {
                textBoxServerStatus.AppendText(msg);
                textBoxServerStatus.AppendText(Environment.NewLine);
            });
        }
        /// <summary>
        /// Start the server to listening.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if(server == null || !server.IsServerRunning())
            {
                if (listBoxMaps.SelectedItem == null)
                {
                    AppendToServerStatus("Select game map");
                    return;
                }
                try
                {
                    server = new Server(this, listBoxMaps.SelectedItem.ToString());
                    
                    server.StartServer(IPAddress.Parse(textBoxHost.Text), Int32.Parse(textBoxPort.Text));
                }
                catch (Exception ex)
                {                    
                    AppendToServerStatus(ex.Message);                  
                }
            }
        }
        /// <summary>
        /// Stop the server.
        /// </summary>
        private void ButtonStop_Click(object sender, EventArgs e)
        { 
            if(server != null)
            {              
                server.StopServer();
                server = null;
            }
        }        
    }
}
