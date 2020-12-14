using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetflixApp.DbHelper;

namespace NetflixApp
{
    public partial class FrmPoint : Form
    {
        private bool flag = false; //puan kontrolu için.
        private Thread thread; 
        public FrmPoint()
        {
            InitializeComponent();
        }

        
        private void FrmPoint_Load(object sender, EventArgs e)
        {
            //form arayüzün oluşturulması ve comboboxın içerisinin doldurulması
            lblFilmName.Text += FrmMyAccount.selectedProgram.Ad;
            lblEpisode.Text += FrmMyAccount.selectedProgram.BolumSayisi.ToString();

            for (int i = 1; i <= 10; i++)
            {
                cbxPoint.Items.Add(i);
            }
        }
        //Buton click olayı gerçekleştiği zaman ilgili programın puan güncellemesini yap.
        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (cbxPoint.Text != "")
            {
                string sqlQuery = "update KullaniciProgram set   Puan='" + cbxPoint.Text + "'," +
                                  " Tarih='" + DateTime.Now + "' where KullaniciID=" + FrmMyAccount.user.Id + "" +
                                  " and ProgramID=" + FrmMyAccount.selectedProgram.Id + "  ";
                if (OleDbHelper.updateData(sqlQuery))
                {
                    flag = true;
                    MessageBox.Show("Değerlendirmeniz için çok teşekkürler! İyi seyirler..");
                    this.Close();
                }
                
            }
            

        }

     

        private void openFrmMyAccount()
        {
            Application.Run(new FrmMyAccount());
        }

        //Form kapatılmadan puan vermek için hatırlatma yap eğer
        //onay verilmezse değeri değiştirme
        private void FrmPoint_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!flag)
            {
                var window = MessageBox.Show(
                    "Puan vermek ister misiniz?",
                    "Görüşleriniz önemli!",
                    MessageBoxButtons.YesNo);

                e.Cancel = (window == DialogResult.Yes) ;

            }
   
        }

    }
}
