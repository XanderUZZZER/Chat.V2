using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class ServerMainForm : Form
    {
        public ServerMainForm()
        {
            InitializeComponent();
        }

        private void btStartServer_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            server.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
