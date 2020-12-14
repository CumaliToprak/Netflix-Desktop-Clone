using System;
using System.Collections;
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
    public partial class FrmSelectCategory : Form
    {
        private List<string> categories = new List<string>(); //Seçilen kategori bilgilerini tutmak için ve bu
        public static List<int> CategoriIdList;  //bilgilere diğer formlardan ulaşabilmek için static olan bu listleri tanımladık.

        private Thread thread;  //Form arasında geçişi bu thread yardımı ile yaptık.

        DataTable dataTable = new DataTable();
        private string sqlQuery;

        public FrmSelectCategory()
        {
            InitializeComponent();
        }


       
        //Kullanıcı Onayla butonuna basarsa gerçekleşecek olaylar.
        private void button1_Click(object sender, EventArgs e)
        {
            if(checkCounter==3)
            {
                sqlQuery = "select ID from Tur where Ad='" + categories[0] + "' or Ad='" + categories[1] + "' or Ad='" +
                           categories[2] + "'  ";
                clearDataTable(dataTable);
                dataTable = OleDbHelper.GetData(dataTable, sqlQuery);

                if(dataTable.Rows.Count>0)
                { 
                    //seçilen kategori bilgilerininin listelere atanması
                    CategoriIdList = new List<int>();
                    CategoriIdList.Add(Convert.ToInt32(dataTable.Rows[0][0]));
                    CategoriIdList.Add(Convert.ToInt32(dataTable.Rows[1][0]));
                    CategoriIdList.Add(Convert.ToInt32(dataTable.Rows[2][0]));
                    
                    changeForm();  //Form değiştirme metodu.

                }
            }
            else if(checkCounter<3)
            {
                MessageBox.Show("3 kategori seçmeniz gerekiyor");
            }
           
        }

        //FrmMyAccount formuna geçişi gerçekleştirir.
        private void changeForm()
        {
            this.Close();
            thread = new Thread(openFrmMyAccount);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void openFrmMyAccount()
        {
            FrmMyAccount.signFlag = 1;  //Kayıt ekranından gelindiğini belirtmek için.
            Application.Run(new FrmMyAccount());
        }

        //Tüm tür kategorilerini checkboxlara atar.
        private void listCategory()
        {
            sqlQuery = "select Ad from Tur";
            clearDataTable(dataTable);
            dataTable = OleDbHelper.GetData(dataTable, sqlQuery);
            int i = 0;
            foreach(Control control in this.Controls)
            {
                if(control is CheckBox)
                {
                    control.Text = dataTable.Rows[i][0].ToString();
                    i++;
                }
            }
        }

        private void clearDataTable(DataTable dataTable)
        {
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();
            dataTable.Clear();
        }

        //form yüklendiği zaman;
        private void FrmSelectCategory_Load(object sender, EventArgs e)
        {
            listCategory();
        }


        private int checkCounter;  //3 tür tutacak değişken.
        private void OnCheckedChanged(object sender, EventArgs e)
        {
            // Increase or decrease the check counter
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
            {
                checkCounter++;
                categories.Add(box.Text);
            }
            else
            {
                checkCounter--;
                categories.Remove(box.Text);
            }
                

            // prevent checking
            if (checkCounter == 4)
            {
                MessageBox.Show("En fazla 3 tür seçebilirsiniz", "hey");
                box.Checked = false;
            }

        }
    }
}
