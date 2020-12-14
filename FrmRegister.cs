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
    public partial class FrmRegister : Form
    {
        private Thread thread; //form geçişlerini bu thread yardımı ile yaptık.
        private string sqlQuery;
        DataTable dataTable = new DataTable();
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void clearDataTable(DataTable dataTable)
        {
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();
            dataTable.Clear();
        }
        

        //Kullanıcı signup butonuna tıkladığı zaman gerçekleşecek olaylar.
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation.isValidEmail(tbxEmail.Text) && Validation.isValidName(tbxName.Text) &&
                    Validation.isValidPassword(tbxSifre.Text))
                {
                    //Bu email ile eşleşen veri tabanında var mı?
                    sqlQuery = "select * from Kullanici where email='" + tbxEmail.Text + "' ";
                    dataTable = OleDbHelper.GetData(dataTable, sqlQuery);
                    if (dataTable.Rows.Count == 0) //Kaydedilmek istenen kullanıcı daha önce kayıt edilmemişse;
                    {

                        sqlQuery = "INSERT INTO Kullanici (Ad,Email,Sifre,DogumTarihi) values('" + tbxName.Text +
                                   "','" +
                                   tbxEmail.Text + "' ,'" + tbxSifre.Text + "','" + dateTimePicker1.Text + "' )";
                        if (OleDbHelper.insertData(sqlQuery))
                        {
                            clearDataTable(dataTable);
                            sqlQuery = "select * from Kullanici where email='" + tbxEmail.Text + "' ";
                            dataTable = OleDbHelper.GetData(dataTable, sqlQuery);
                            //Hesabım kısmında kullanıcı film izlediği zaman veri tabanı işlemleri için user bilgileri gerekir.
                            //FrmMyAccount classındaki statik userInfo classına kullanıcı bilgilerini atıyoruz.
                            FrmMyAccount.user = new UserInfo
                            (Convert.ToInt32(dataTable.Rows[0]["ID"]),
                                dataTable.Rows[0]["Ad"].ToString(),
                                dataTable.Rows[0]["Email"].ToString(),
                                dataTable.Rows[0]["Sifre"].ToString(),
                                Convert.ToDateTime(dataTable.Rows[0]["DogumTarihi"].ToString()));

                            MessageBox.Show("Kayıt eklendi.");

                            //thread yardımı ile bu formu kapatıp hesabım formunu açıyor.
                            changeForm();
                        }


                    }
                    else // Bu email daha önce veri tabanında bir email ile eşleşiyor ise;
                    {
                        MessageBox.Show("Bu email daha önce var olan bir email ile eşleşti!");
                        for (int i = 0; i < Controls.Count; i++) //Tüm textboxları temizleme.
                        {
                            if (Controls[i] is TextBox)
                            {
                                Controls[i].Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void changeForm()
        {
            this.Close();
            thread = new Thread(openSelectCategoryForm);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        //Hesabım formunu açan metod.
        private void openSelectCategoryForm()
        {
            Application.Run(new FrmSelectCategory());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Login butonuna tıkladındığı zaman thread yardımı ile login formunun açılma işlemi.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(openLoginForm);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        //login formunu açan metod.
        private void openLoginForm()
        {
            Application.Run(new FrmLogin());
        }
        
        //Şifreyi gör checkboxını kontrol eden event.
        private void cbxShowPasswd_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxShowPasswd.Checked)
            {
                tbxSifre.UseSystemPasswordChar = false;
            }
            else
            {
                tbxSifre.UseSystemPasswordChar = true;
            }
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
