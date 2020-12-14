using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetflixApp
{
    public partial class FrmLogin : Form
    {
        private Thread thread; //Formlar arası geçiş yaparken kullanıldı.
        public FrmLogin()
        {
            InitializeComponent();

        }
        //Veri tabanı bağlantı nesnesi.
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;
                                                        Data Source=|DataDirectory|\NetflixDB.accdb;
                                                         Persist Security Info=true");
        private void openConnection()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabani bağlantısı açılamadı!" + ex.Message);
            }
        }
       

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
       

        private void cbxShowPasswd_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbxShowPasswd.Checked)
            {
                tbxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbxPassword.UseSystemPasswordChar = true;
            }
        }
        
        //Kullanici login butonuna tıkladığı zaman gerçekleşecek olaylar.
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            //kullanıcı bilgileri kontrol edecek select sorgusu.
            string selectString =
           "SELECT * " +
           "FROM Kullanici " +
           "WHERE Email = '" + tbxEmail.Text + "' AND Sifre = '" + tbxPassword.Text + "'";

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectString, connection);
            connection.Open();
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            connection.Close();
            //Eğer datatable içerisinde en az 1 tane satır varsa bu
            //kullanıcı kaydı veri tabanında bulunmaktadır.
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Email veya şifre yanlış!","Hey!");
            }
            else
            {
                //Hesabım kısmında kullanıcı film izlediği zaman veri tabanı işlemleri için user bilgileri gerekir.
                //FrmMyAccount classındaki statik userInfo classına kullanıcı bilgilerini atıyoruz.
                FrmMyAccount.user = new UserInfo(Convert.ToInt32(dataTable.Rows[0]["ID"]),dataTable.Rows[0]["Ad"].ToString(),dataTable.Rows[0]["Email"].ToString(),dataTable.Rows[0]["Sifre"].ToString(),Convert.ToDateTime(dataTable.Rows[0]["DogumTarihi"]));
                this.Close();
                thread = new Thread(openMyAccountForm);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        private void openMyAccountForm()
        {
            Application.Run(new FrmMyAccount());
        }
        
        //Login formundan signup formuna geçiş.
        private void btnSignup_Click_1(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(openRegisterForm);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void openRegisterForm()
        {
            Application.Run(new FrmRegister());
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
