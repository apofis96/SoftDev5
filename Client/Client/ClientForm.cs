using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            using(ManagerServiceReference.ManagerServiceClient client = new ManagerServiceReference.ManagerServiceClient())
            {
                if(client.CompileOrder(productNameTextBox.Text, (int)amountNumericUpDown.Value))
                {
                    MessageBox.Show("OK!");
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }
    }
}
