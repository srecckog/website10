using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //int i1 = 0; // info pult
        //i1 = 1; // hala1 pauza
        //i1 = 2; // hala3 pauza
        //i1 = 0;
        int  i1 = (int.Parse)(ConfigurationManager.AppSettings["tipporuke"]);
        
        if (i1 == 1)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            DateTime tv = DateTime.Now;
            lblDateToday.Text = DateTime.Now.ToString("dddd, dd.MM.yyyy") + "<br>";
           
            tdole2t.Text = "";
            myPanel.Visible = true;

            //Image1.Visible = true;
            if (((tv.Hour == 9 && tv.Minute > 44) || (tv.Hour == 10 && tv.Minute <= 14)) || (tv.Hour == 18 && tv.Minute <= 30) || (tv.Hour == 2 && tv.Minute <= 30))
            {
                //tdole211.Visible = false;
                myPanel.Visible=false;
                tdole2t.Text = "P A U Z A";                
                //Image1.Visible = false;               
            }
        }
        else if (i1==2)
        {

            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            DateTime tv = DateTime.Now;
            lblDateToday.Text = DateTime.Now.ToString("dddd, dd.MM.yyyy") + "<br>";
            tdole2t.Text = "";
            myPanel.Visible = true;
            if (((tv.Hour == 10 && tv.Minute <= 30)) || (tv.Hour == 18 && tv.Minute <= 30) || (tv.Hour == 2 && tv.Minute <= 30))
            {
                myPanel.Visible = false;
                tdole2t.Text = "P A U Z A";
            }
        }

        else
        {


            // ispis poruke na tv ekran iz rfin.tv_poruka
           

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tv_poruka where status='1' and tip='1'", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();
                if (rdr.HasRows)
                    lblDateToday.Text = rdr[0].ToString();
                //  tdole2t.Text = rdr[0].ToString();
                //
                //Response.Write(rdr[0].ToString()); //read a value
                cn.Close();
            }
            
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tv_poruka where status='1' and tip='2'", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();
                if (rdr.HasRows)
                    //tdolet.Text = rdr[0].ToString();
                //Response.Write(rdr[0].ToString()); //read a value
                cn.Close();
            }
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tv_poruka where status='1' and tip='3'", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();
                if (rdr.HasRows)
                    tdole2t.Text = rdr[0].ToString();
                //    lblDateToday.Text = rdr[0].ToString();

                //
                //Response.Write(rdr[0].ToString()); //read a value
                cn.Close();
            }

        }
    }

    public string wogrid()
    {
        int kolicinad = 0, kolicinat = 0, kolicinam = 0;
        string sql1 = "",hala1="1";
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
        {
            //sql1 = "select * from rfind.dbo.tvinfo_pult where hala='" + hala1 + "'  order by datum desc";
            sql1 = "select * from rfind.dbo.tvinfo_pult  order by datum desc";
            SqlCommand cmd = new SqlCommand(sql1, cn);
            cn.Open();

            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string htmlStr = "";

            while (rdr.Read())
            {
                kolicinad = rdr.GetInt32(2);
                kolicinat = rdr.GetInt32(3);
                kolicinam = rdr.GetInt32(4);
            }
            kolicinad = 40000;
            kolicinat = kolicinad / 3 * 17;
            kolicinam = kolicinad / 3 * 68;

            cn.Close();
        }

        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
        {
            sql1 = "rfind.dbo.tv_dpr " + hala1 + " ,4";
            SqlCommand cmd = new SqlCommand(sql1, cn);
            cn.Open();

            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string htmlStr = "";
            while (rdr.Read())
            {
                if (rdr.HasRows)
                    {
                    int h = 0;
                }
                int kolicina = rdr.GetInt32(3);
                string tip = rdr.GetString(1);
                int oznaka = rdr.GetInt32(2);
                DateTime dat1 = DateTime.Now.AddDays(oznaka);
                string sdate1 = dat1.Day.ToString() + '-' + dat1.Month.ToString() + '-' + dat1.Year.ToString();
                sdate1 = dat1.Day.ToString() + '.' + dat1.Month.ToString() + '.' + dat1.Year.ToString();

                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                System.Globalization.Calendar cal = dfi.Calendar;
                int week1 = cal.GetWeekOfYear(dat1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                int month1 = dat1.Month;


                if (tip == "D")
                {
                    htmlStr += "<tr><td>Dan " + sdate1 + "</td><td>" + kolicinad.ToString() + "</td><td>" + kolicina.ToString() + "</td></tr>";
                }
                if (tip == "T")
                {
                    htmlStr += "<tr><td> Tjedan " + week1.ToString() + "</td><td>" + kolicinat.ToString() + "</td><td>" + kolicina.ToString() + "</td></tr>";
                }
                if (tip == "M")
                {
                    htmlStr += "<tr><td> Mjesec " + month1.ToString() + "</td><td>" + kolicinam.ToString() + "</td><td>" + kolicina.ToString() + "</td></tr>";
                }


            }

            cn.Close();
            return htmlStr;
        }

    }
    protected void TimerTime_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        lblDateToday.Text= DateTime.Now.ToString("dd:MM:yyyy");

    }
}