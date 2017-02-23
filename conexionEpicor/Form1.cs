using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ice.Core;
using Erp.Common;
using System.Configuration;
namespace conexionEpicor
{
    public partial class Form1 : Form
    {
        String userName;
        String password;
        String environment;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                userName = txtUser.Text;
                password = txtPass.Text;
                environment = @"C:\Epicor\ERP10.0ClientTest\Client\config\Epicor10.sysconfig";

                Session epiSession = new Session(userName, password, Session.LicenseType.Default,environment);
                
                if(epiSession != null)
                {
                    mainPage obj = new mainPage();
                    MessageBox.Show("Sesión Válida", "Epicor Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    obj.Show();
                    epiSession.Dispose();
                    epiSession = null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
