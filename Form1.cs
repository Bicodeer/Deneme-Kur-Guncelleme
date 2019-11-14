using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DövizKurGüncelleme
{
    public partial class Form1 : Form
    {
        List<kur> kurList = new List<kur>();
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-NU88O7L\SQLEXPRESS01;Initial Catalog=Kur;Integrated Security=True");
        DataSet ds = null;
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }
        private void gridDoldur()
        {
            try
            {
                string sql = "SELECT Kod, Currency_Name, ForexBuying, ForexSelling FROM tblDovizKur1 Where  Kod='USD' OR Kod='EUR' OR Kod='GBP'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds, "tblDovizKur1");
                dataGridKur.DataSource = ds.Tables["tblDovizKur1"];
                dataGridKur.Columns[0].HeaderText = "Döviz";
                dataGridKur.Columns[1].HeaderText = "Açıklama";
                dataGridKur.Columns[2].HeaderText = "Döviz Alış";
                dataGridKur.Columns[3].HeaderText = "Döviz Satış";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            kurList = new List<kur>();
            if (conn.State == ConnectionState.Closed) conn.Open();
            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            string sql = "";
            XmlNodeList secilen = xmlDoc.DocumentElement.SelectNodes("Currency");
            foreach (XmlNode ekle in secilen)
            {

                string Kod = ekle.Attributes["Kod"].Value;
                string Unit = ekle.SelectSingleNode("Unit").InnerText;
                string Currency_Name = ekle.SelectSingleNode("CurrencyName").InnerText;
                string ForexBuying = ekle.SelectSingleNode("ForexBuying").InnerText;
                string ForexSelling = ekle.SelectSingleNode("ForexSelling").InnerText;
                string BanknoteBuying = ekle.SelectSingleNode("BanknoteBuying").InnerText;
                string BanknoteSelling = ekle.SelectSingleNode("BanknoteSelling").InnerText;
                string date = DateTime.Now.ToString();
                kurList.Add(new kur
                {
                    Kod = Kod,
                    Unit = Unit,
                    Currency_Name = Currency_Name,
                    ForexBuying = ForexBuying,
                    ForexSelling = ForexSelling,
                    BanknoteBuying = BanknoteBuying,
                    BanknoteSelling = BanknoteSelling,
                    Date = date
                }); ;
            }
            foreach (var item in kurList)
            {
                try
                {
                    var Kod = item.Kod;
                    var Unit = item.Unit;
                    var Currency_Name = item.Currency_Name;
                    var ForexBuying = item.ForexBuying;
                    var ForexSelling = item.ForexSelling;
                    var BanknoteBuying = item.BanknoteBuying;
                    var BanknoteSelling = item.BanknoteSelling;
                    var Date = item.Date;
                    // insert işlemi yapılabilir.
                    //sql = "INSERT INTO tblDovizKur1 VALUES ('" +
                    //                    Kod + "','" +
                    //                    Unit.Replace("'", "''") + "','" +
                    //                    Currency_Name.Replace("'", "''") + "','" +
                    //                    ForexBuying + "','" +
                    //                    ForexSelling + "','" +
                    //                    BanknoteBuying + "','" +
                    //                    BanknoteSelling + "','" +
                    //                    Date + "');";
                    //SqlCommand cmd = new SqlCommand(sql, conn);
                    //cmd.ExecuteNonQuery();
                    //Console.WriteLine("veritabanına kayıt edildi.");
                    sql = "update tblDovizKur1 set Kod=@Kod, Unit=@Unit, Currency_Name=@Currency_Name, ForexBuying=@ForexBuying, ForexSelling=@ForexSelling, BanknoteBuying=@BanknoteBuying, BanknoteSelling=@BanknoteSelling, Date=@Date where Kod=@Kod ";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Kod", Kod);
                    cmd.Parameters.AddWithValue("@Unit", Unit);
                    cmd.Parameters.AddWithValue("@Currency_Name", Currency_Name);
                    cmd.Parameters.AddWithValue("@ForexBuying", ForexBuying);
                    cmd.Parameters.AddWithValue("@ForexSelling", ForexSelling);
                    cmd.Parameters.AddWithValue("@BanknoteBuying", BanknoteBuying);
                    cmd.Parameters.AddWithValue("@BanknoteSelling", BanknoteSelling);
                    cmd.Parameters.AddWithValue("@Date", Date);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("veritabanı güncellendi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            gridDoldur();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridDoldur();
        }
    }
}
