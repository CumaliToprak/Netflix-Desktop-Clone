using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetflixApp.DbHelper;

namespace NetflixApp
{
    public partial class MainFrm : Form
    {
        private Thread thread;
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnIntro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Seçilen program daha önce puanlanmamışsa
            string sqlQuery =
                "SELECT KullaniciProgram.Puan FROM KullaniciProgram WHERE  KullaniciProgram.KullaniciID=" +
                FrmMyAccount.user.Id + " and KullaniciProgram.ProgramID=" + FrmMyAccount.selectedProgram.Id + " ";
            DataTable dataTable = new DataTable();
            dataTable = OleDbHelper.GetData(dataTable, sqlQuery);
            if (Convert.ToInt32(dataTable.Rows[0]["Puan"]) == 0)
            {
                thread = new Thread(openFrmPoint);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }

        }

        private void openFrmPoint()
        {
            Application.Run(new FrmPoint());
        }
    }
}
