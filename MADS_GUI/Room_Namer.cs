using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MADS_GUI
{
    public partial class Room_Namer : Form
    {
        public bool textAccepted = false;
        public string textValue;
        public Room_Namer()
        {
            InitializeComponent();
        }

        private void Room_Namer_Load(object sender, EventArgs e)
        {

        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            textValue = this.roomName.Text;
            textAccepted = true;
            this.Close();
        }
    }
}
