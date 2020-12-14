using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NetflixApp.DbHelper;

namespace NetflixApp
{
    public partial class FrmMyAccount : Form
    {

        private int flag = 1;

        public static int signFlag = 0;//Bu flag kullanıcı kayıt ekranından mı buraya geldi?
                                       //Ona göre içerik sağlamak için, kontrol amaçlı tanımlanmıştır.
        public static ProgramInfo selectedProgram; //seçilen program bilgilerini tutan nesne.

        public static UserInfo user;   // User bilgilerini KullaniciProgram tablosuna kayıt eklerken
                                       // kullancağımız için login veya kayıt esnasında bu static nesneye atıyoruz.
        private Thread thread;  //formlar arasında geçiş yapmamımızı sağlar.

        private string sqlQuery;

        DataTable dataTable = new DataTable(); //veritabanından gelen verileri koyduğumuz tablo.

        public FrmMyAccount()
        {
            InitializeComponent();
        }
        
        
    
        //Bu form açıldığı zaman tüm programları form üzerindeki datagridview nesnesine 
        //atayan metod.
        private void listele()
        {
            clearDataTable(dataTable);
            sqlQuery = "select * from program ";
            dataTable = OleDbHelper.GetData(dataTable, sqlQuery);
            dataGridView1.DataSource = dataTable;
 
        }

        //DataTable içerisine farklı tablolar ve alanlar atamak için;
        private void clearDataTable(DataTable dataTable)
        {
                 dataTable.Clear();
                dataTable.Rows.Clear();
                dataTable.Columns.Clear();
        }
        //form açıldığı anda load eventi.
        private void FrmMyAccount_Load_1(object sender, EventArgs e)
        {
            filterBySelectedCategory(FrmSelectCategory.CategoriIdList);
            if(flag==1)
            {
                listele();
            }
        }

        //Datatable'ın kolon isimlerini değiştiren metod.
        private DataTable changeColumnName(DataTable dataTable)
        {
            dataTable.Columns[0].ColumnName = "ID";
            dataTable.Columns[1].ColumnName = "Adı";
            dataTable.Columns[2].ColumnName = "Tipi";
            dataTable.Columns[3].ColumnName = "Bolum Sayısı";
            dataTable.Columns[4].ColumnName = "Süre";
            if (dataTable.Columns.Count == 6)
            {
                dataTable.Columns[5].ColumnName = "Tür Adı";
            }
            else if (dataTable.Columns.Count == 7)
            {
                dataTable.Columns[5].ColumnName = "Tür Adı";
                dataTable.Columns[6].ColumnName = "Ortalama Puan";
            }
            return dataTable;
        }
     
        //Program ismine göre arama yaparken textbox her değiştiği zaman tetiklenecek metod.
        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {

            if (tbxSearch.Text == "")
            {
                listele();
            }
            sqlQuery = "select * from program where Ad LIKE '" + tbxSearch.Text + "%' ";
            clearDataTable(dataTable);
            dataTable = OleDbHelper.GetData(dataTable, sqlQuery);
            dataTable = changeColumnName(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        //Program adına ve tür adına göre seçimi kontrol eden comboboxın her tetiklenmesinde gerçeleşen olay.
        private void cbxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(cbxSelect.Text == "Film/Dizi adına göre")
            {
                cbxTur.Visible = false;
                tbxSearch.Visible = true;
            }
           else if(cbxSelect.Text == "Türüne göre")
            {
                tbxSearch.Visible = false;
                cbxTur.Visible = true;
            }
        }

        //Tür adına göre arama yaparken combobox her tür değişiminde tetiklenecek metod.
        private void cbxTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlQuery= "SELECT Program.*, Tur.AD  FROM Tur INNER JOIN(Program INNER JOIN ProgramTur ON Program.ID = ProgramTur.ProgramID) ON Tur.ID = ProgramTur.TurID WHERE (([ProgramTur].[TurID]=" + ((cbxTur.SelectedIndex) + 1) + "))";
            clearDataTable(dataTable);
            dataTable = OleDbHelper.GetData(dataTable,sqlQuery);
            dataTable = changeColumnName(dataTable);
            dataGridView1.DataSource = dataTable;
            
        }

      
        //Herhangi bir program seçildiği zaman izle butonunu aktifleştiriyoruz.
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnWatch.Enabled = true;
            btnWatch.Visible = true;
        }

        //kullanıcı izle butonuna basarsa;
        private void btnWatch_Click(object sender, EventArgs e)   
        {
            //global datatable'in içerisini temizlerken datagridview boş kaldığı için geçici datatable tanımlıyoruz.
            DataTable tempDataTable = new DataTable(); 
            int index = dataGridView1.SelectedCells[0].RowIndex;
            
            //izlenen program bilgilerini diğer formalarda kullanabilmek için static program nesnesine atıyoruz.
             selectedProgram = new ProgramInfo
                (Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value.ToString()),
                dataGridView1.Rows[index].Cells[1].Value.ToString(),
                dataGridView1.Rows[index].Cells[2].Value.ToString(),
                Convert.ToInt32(dataGridView1.Rows[index].Cells[3].Value.ToString()),
                Convert.ToInt32(dataGridView1.Rows[index].Cells[4].Value.ToString()));

             
             sqlQuery = "SELECT * FROM KullaniciProgram WHERE KullaniciID = " + user.Id + " and ProgramID=" + selectedProgram.Id + " "; ;
             
             tempDataTable = OleDbHelper.GetData(tempDataTable, sqlQuery);

            //seçilen program daha önce izlenmemişse
            if (tempDataTable.Rows.Count == 0)
            {
                sqlQuery = " insert into KullaniciProgram VALUES ('" + user.Id + "', '" + selectedProgram.Id + "','30','1', '0', '" + DateTime.Now + "') ";
                if (OleDbHelper.insertData(sqlQuery))
                {
                    MessageBox.Show("Program bilgileri veritabanına eklendi!");
                    openMainForm();
                }

            }
            //film veya dizi daha önce izlenmeye başlanmışsa
            else
            {
                sqlQuery = "select P.*, KP.KalinanBolum AS KalinanBolum, KP.Sure AS Sure from  " +
                               "(Program AS P INNER JOIN KullaniciProgram  AS KP ON P.ID=KP.ProgramID)" +
                               " WHERE KP.ProgramID = " + selectedProgram.Id + " and KP.KullaniciID=" +user.Id+ " ";
                clearDataTable(tempDataTable);
                OleDbHelper.GetData(tempDataTable, sqlQuery);
                
                //Bolum sayisi 1'den buyuk ise dizidir.
                if (selectedProgram.BolumSayisi > 1)
                {
                    int kalinanBolum = Convert.ToInt32(tempDataTable.Rows[0]["KalinanBolum"]);

                    if ( kalinanBolum <= selectedProgram.BolumSayisi)
                    {
                        string message = user.Ad+" bu diziyi zaten izlemektesiniz, sonraki bolume geçmek ister misiniz ?";
                        string title = "Hey!";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);

                        if (result == DialogResult.Yes)
                        {
                            sqlQuery = "update KullaniciProgram set  Sure='30', KalinanBolum=" +
                                           (kalinanBolum + 1) + "" +
                                           ", Tarih='" + DateTime.Now + "' where KullaniciID=" + user.Id +
                                           " and ProgramID=" + selectedProgram.Id + "  ";
                            if (OleDbHelper.insertData(sqlQuery))
                            {
                                MessageBox.Show("Sonraki bölüme geçildi!");
                                openMainForm();
                            }
                            
                        }
                    
                    }
                    else
                    {
                        string message = "Bu diziyi daha önce bitirmişsiniz tekrar başlamak ister misiniz ?";
                        string title = "Hey!";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);

                        if (result == DialogResult.Yes)
                        {
                            sqlQuery = "update KullaniciProgram set  Sure='30', KalinanBolum='1', Tarih='" +
                                           DateTime.Now + "' where KullaniciID=" + user.Id + " and ProgramID=" +
                                           selectedProgram.Id + "  ";
                            if (OleDbHelper.updateData(sqlQuery))
                            {
                                openMainForm();
                            }
                            
                        }
                    }

                }
                //Seçilen programın bolum sayisi 1 ise ve film daha önce yarım kaldıysa;
                else
                {    
                    string message = "Bu filmi daha önce izlemeye başlamışsınız,  kaldığınız yerden devam etmek ister misiniz ?";
                    string title = "Hey!";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        
                        sqlQuery = "update KullaniciProgram set  Sure='" + selectedProgram.BolumUzunluk + "', KalinanBolum='1',  Tarih='" +
                                   DateTime.Now + "' where KullaniciID=" + user.Id + " and ProgramID=" + selectedProgram.Id +
                                   "  ";

                        if (OleDbHelper.updateData(sqlQuery))
                        {
                            openMainForm();
                        }

                        
                    }
                }
            }
            }

        
        private void openMainForm()
        {
           MainFrm mainFrm = new MainFrm();
           mainFrm.ShowDialog();
        }


        //kayıt sonrası seçilen türlere göre 6 filmin filtrelenmesini sağlayan metod
        public void filterBySelectedCategory(List<int> categories)
        {
            if (signFlag == 1)
            {

                clearDataTable(dataTable);
                int i;
                for (i = 0; i < 3; i++)
                {
                    //seçilen türlere göre program ve tür bilgilerini getiren metod.
                    sqlQuery = "SELECT TOP 2 KP.ProgramID AS ProgramID, AVG(KP.Puan)" +
                                         " as  Ortalama_Puan, PT.TurID AS TurID FROM ((Program AS P" +
                                         " INNER JOIN KullaniciProgram AS KP     " +
                                         " ON P.ID = KP.ProgramID) INNER JOIN " +
                                         "ProgramTur AS PT ON P.ID = PT.ProgramID)" +
                                         " WHERE (([PT].[TurID] = " + (categories[i]) + "))" +
                                         " and(([P].[Tip] = 'film'))" +
                                         "GROUP BY KP.ProgramID, PT.TurID " +
                                         "HAVING(avg(KP.Puan)) " +
                                         "ORDER BY  AVG(KP.Puan)  DESC";
                    
                    dataTable = OleDbHelper.GetData(dataTable, sqlQuery);
                }

                DataTable tempDataTable = new DataTable();
                for (i = 0; i < dataTable.Rows.Count; i++)
                {

                    int programId = Convert.ToInt32(dataTable.Rows[i]["ProgramID"].ToString());
                    int TurID = Convert.ToInt32(dataTable.Rows[i]["TurID"].ToString());
                    sqlQuery = "select P.*, T.Ad from (Program AS P INNER JOIN (ProgramTur AS PT INNER JOIN TUR AS T ON PT.TurID=T.ID) ON PT.ProgramID=P.ID)  where P.ID=" + programId + " and PT.TurID=" + TurID + " ";
                    
                    tempDataTable = OleDbHelper.GetData(tempDataTable, sqlQuery);

                    if (i == 0)
                    {
                        tempDataTable.Columns.Add("Ortalama_Puan", typeof(System.Double));
                    }
                    tempDataTable.Rows[i]["Ortalama_Puan"] = dataTable.Rows[i]["Ortalama_Puan"];

                }

                

                tempDataTable = changeColumnName(tempDataTable);
                dataGridView1.DataSource = tempDataTable;
                this.Show();
                MessageBox.Show("Sizin için hazırladığımız içerikler! İsterseniz arama kısmından arayarak diğer içeriklere de bakabilirsiniz.");
                flag = 0;
            }
           

        }

        private void changeForm()
        {
            this.Close();
            thread = new Thread(openLoginForm);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void openLoginForm()
        {
            Application.Run(new FrmLogin());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            signFlag = (signFlag == 1) ? 0 : 0;
            changeForm();
        }
    }
}
