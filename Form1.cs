using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace dovizKuru
{
    public partial class Form1 : Form
    {
        // private static int sqlThreadCount;
        //string str = @"Data Source=DESKTOP-NU88O7L\SQLEXPRESS01;Initial Catalog=Kur;Integrated Security=True";
        List<kur> kurList = new List<kur>();
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-NU88O7L\SQLEXPRESS01;Initial Catalog=Kur;Integrated Security=True");
        SqlCommand cmd;
        DataSet dt = null;
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    while (sqlThreadCount > 3)
            //    {
            //        Console.WriteLine("sql threadleri bekleniyor " + sqlThreadCount);
            //        Thread.Sleep(3000);
            //    }
            //    Task.Run(() =>
            //    {
            //    SqlConnection con = new SqlConnection(str);
            //    SqlDataAdapter da = new SqlDataAdapter();
            //    SqlCommand cmd;
            //    DataSet ds = new DataSet();
            //    XmlReader file;

            //    try
            //    {
            //        sqlThreadCount++;
            //       // con.Open();

            //        Console.WriteLine("sql thread başlatıldı " + sqlThreadCount);
            //        string sql = "";
            //        try
            //        {
            //                //string Currency_Code = null;
            //                //string Unit = null;
            //                //string Currency = null;
            //                //string Forex_Buying = null;
            //                //string Forex_Selling = null;
            //                //string Banknote_Buying = null;
            //                //string Banknote_Selling = null;
            //                //file = XmlReader.Create("http://www.tcmb.gov.tr/kurlar/today.xml", new XmlReaderSettings());
            //                //ds.ReadXml(file);
            //                //con.Open();
            //                //for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
            //                //{

            //                //    Currency_Code = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            //                //    Unit = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            //                //    Currency = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            //                //    Forex_Buying = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            //                //    Forex_Selling = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            //                //    Banknote_Buying = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            //                //    Banknote_Selling = ds.Tables[0].Rows[i].ItemArray[6].ToString();
            //                //    sql = "insert into Doviz_Kur values (" + Currency_Code + ",'" + Unit + "','" + Currency + "','" + Forex_Buying + "','" + Forex_Selling + "','" + Banknote_Buying + "','" + Banknote_Selling + "')";
            //                //    cmd = new SqlCommand(sql, con);
            //                //    da.InsertCommand = cmd;
            //                //    da.InsertCommand.ExecuteNonQuery();

            //                //}
            //                //con.Close();
            //                //MessageBox.Show("Veriler eklendi");

            //                string adres = "http://www.tcmb.gov.tr/kurlar/today.xml";
            //                XmlDocument xdoc = new XmlDocument();
            //                xdoc.Load(adres);

            //                foreach (var item in xdoc)
            //                {
            //                    string Currency_Code = null;
            //                    string Unit = null;
            //                    string Currency = null;
            //                    string Forex_Buying = null;
            //                    string Forex_Selling = null;
            //                    string Banknote_Buying = null;
            //                    string Banknote_Selling = null;
            //                    for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
            //                    {

            //                        Currency_Code = ds.Tables[i].Rows[i].ItemArray[0].ToString();
            //                        Unit = ds.Tables[i].Rows[i].ItemArray[1].ToString();
            //                        Currency = ds.Tables[i].Rows[i].ItemArray[2].ToString();
            //                        Forex_Buying = ds.Tables[i].Rows[i].ItemArray[3].ToString();
            //                        Forex_Selling = ds.Tables[i].Rows[i].ItemArray[4].ToString();
            //                        Banknote_Buying = ds.Tables[i].Rows[i].ItemArray[5].ToString();
            //                        Banknote_Selling = ds.Tables[i].Rows[i].ItemArray[6].ToString();
            //                        sql = "insert into Doviz_Kur values (" + Currency_Code + ",'" + Unit + "','" + Currency + "','" + Forex_Buying + "','" + Forex_Selling + "','" + Banknote_Buying + "','" + Banknote_Selling + "')";
            //                        cmd = new SqlCommand(sql, con);
            //                        da.InsertCommand = cmd;
            //                        da.InsertCommand.ExecuteNonQuery();

            //                    }
            //                    con.Close();
            //                    MessageBox.Show("Veriler eklendi");

            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message);
            //            }
            //        }
            //        catch(Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //    });
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //    HttpWebRequest wrq = (HttpWebRequest)HttpWebRequest.Create("http://www.tcmb.gov.tr/kurlar/today.xml");
            //    HttpWebResponse rsp = (HttpWebResponse)wrq.GetResponse();
            //    Stream sr = rsp.GetResponseStream();
            //    XmlTextReader xtr = new XmlTextReader(sr);
            //    DataSet ds = new DataSet();
            //    ds.ReadXml(xtr);
            //    dataGridView1.DataSource = ds.Tables[1];

            //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NU88O7L\SQLEXPRESS01;Initial Catalog=Kur;Integrated Security=True");
            //    for (int i = 0; i <= dataGridView1.Rows.Count; i++)
            //    {
            //        try
            //        {
            //            //    if (con.State != ConnectionState.Open)
            //            //        con.Open();
            //            //    SqlCommand cmd = new SqlCommand("insert into Doviz_Kur(Currency_Code , Unit, Currency ,Forex_Buying ,Forex_Selling,Banknote_Buying,Banknote_Selling,Date)values" +
            //            //        "(@Currency_Code , @Unit  ,@Currency, @Forex_Buying, @Forex_Selling, @Banknote_Buying, @Banknote_Selling, @Date)", con);
            //            //    cmd.Parameters.AddWithValue("@Currency_Code", dataGridView1.Rows[i].Cells["Kod"].Value.ToString());
            //            //    cmd.Parameters.AddWithValue("@Unit", dataGridView1.Rows[i].Cells["Kod"].Value.ToString());
            //            //    cmd.Parameters.AddWithValue("@Currency", dataGridView1.Rows[i].Cells["Kod"].Value.ToString());
            //            //    cmd.Parameters.AddWithValue("@Forex_Buying", dataGridView1.Rows[i].Cells["Kod"].Value.ToString());
            //            //    cmd.Parameters.AddWithValue("@Forex_Selling", dataGridView1.Rows[i].Cells["Kod"].Value.ToString());
            //            //    cmd.Parameters.AddWithValue("@Banknote_Buying", dataGridView1.Rows[i].Cells["Kod"].Value.ToString());
            //            //    cmd.Parameters.AddWithValue("@Banknote_Selling", dataGridView1.Rows[i].Cells["Kod"].Value.ToString());
            //            //    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
            //            //    cmd.ExecuteNonQuery();
            //            //    foreach(var item in )
            //            //    }
            //            //    catch(Exception ex)
            //            //    {
            //            //        MessageBox.Show(ex.Message);
            //            //    }


            //            //    MessageBox.Show("Kurlar sisteme işlendi.", "mesutx.com");
            //            //    con.Close();
            //        }
            //}
        }
        private void button3_Click(object sender, EventArgs e)
        {
            kurList = new List<kur>();
            if (conn.State == ConnectionState.Closed) conn.Open();
            sda = new SqlDataAdapter(cmd);
            dt = new DataSet();


            string exchangeRate = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(exchangeRate);

            string usd = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='USD'] / BanknoteSelling").InnerXml;
            //  XmlNodeList nodeList = xmlDoc.SelectNodes("Currency[@Kod='USD']/ForexBuying");
            XmlNodeList secilen = xmlDoc.DocumentElement.SelectNodes("Currency");
            foreach (XmlNode ekle in secilen)
            {
               
                string Kod = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']").InnerXml;
                string Unit = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/Unit").InnerXml;
                string Currency_Name = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/CurrencyName").InnerXml;
                string ForexBuying = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexBuying").InnerXml;
                string ForexSelling = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexSelling").InnerXml;
                string BanknoteBuying = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
                string BanknoteSelling = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
                kurList.Add(new kur
                {
                    Kod = Kod,
                    Unit = Unit,
                    Currency_Name = Currency_Name,
                    ForexBuying = ForexBuying,
                    ForexSelling = ForexSelling,
                    BanknoteBuying = BanknoteBuying,
                    BanknoteSelling = BanknoteSelling,

                });




            }


            string USD_Alis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            string USD_Satis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;

            string EURO_Alis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            string EURO_Satis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;


        }
    }
}
