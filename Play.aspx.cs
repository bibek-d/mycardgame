using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using SD = System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;




public partial class Play : System.Web.UI.Page
{
    static int z,count,x, bot, bet,change;
    static int a, b, c, a1, b2, c3,flage=0;
    int id2,id3,id4;
    static string u_name1,u_name2,u_name3,u_name4;
  
    
    protected void Page_Load(object sender, EventArgs e)
    {

       

        id2 = int.Parse(Request.QueryString["Id"]);
        int id1 = id2;
       

        if (Session["user_id"] != null)
        {

             u_name1 = Request.QueryString["u_name"];
             u_name2 = u_name1.ToString();
        }
        if (!IsPostBack )
        {
            if (Session["refresh"] == null)
            {
                Session["f1"] = 0;
                Session["refresh"] = 1;
                update_botbet();
                sitter();
                check_user();
            }
            else
            {
                update();
            }
        }
    }
    protected void sitter()
    {
        SqlConnection con1 = dbconnection.newconnection();
        con1.Open();
        SqlCommand cmd2 = new SqlCommand("select * from game_tbl where tbl_id="+id2, con1);
        SqlDataReader dr3 = cmd2.ExecuteReader();
        dr3.Read();
        for (int i = 1; i <= 4; i++)
        {
            string check1 = "s" + i + "_id";
            string check2 = "s" + i + "_chip";
            string check3 = "s" + i + "_state";
            if (dr3[check1].ToString() == DBNull.Value.ToString())
            {
                
                SqlConnection con2 = dbconnection.newconnection();
                con2.Open();
                SqlCommand cmd3 = new SqlCommand("UPDATE game_tbl  SET " + check1 + " = '" + u_name2 + "', "+check3+"=0 where tbl_id="+id2, con2);
                cmd3.ExecuteNonQuery();
                SqlCommand cmd4 = new SqlCommand("UPDATE game_tbl  SET " + check2 + "=(SELECT chips FROM user_data where username= '" + u_name2 + "') where tbl_id="+id2, con2);
                cmd4.ExecuteNonQuery();
                playerTableUpdate();
                con2.Close();
                con1.Close();
                Session["seat_no"] = i;
                update();
                break;
            }
        }
       
    }
    private void playerTableUpdate()
    {
        SqlConnection con2 = dbconnection.newconnection();
        con2.Open();
        SqlCommand cmd2 = new SqlCommand("select * from pok_tbl where tbl_id="+ id2, con2);
        SqlDataReader dr3 = cmd2.ExecuteReader();
        dr3.Read();
        string aad_player =dr3["no_player"].ToString();
        dr3.Close();
        con2.Close();
        con2.Open();
        SqlCommand cmd6 = new SqlCommand("UPDATE pok_tbl  SET no_player=" + (int.Parse(aad_player)+1) + "where tbl_id=" + id2, con2);
        cmd6.ExecuteNonQuery();
        con2.Close();
    }
    protected void update()
    {
        SqlConnection con1 = dbconnection.newconnection();
        con1.Open();
        SqlCommand cmd5 = new SqlCommand("select * from game_tbl where tbl_id="+id2, con1);
        SqlDataReader dr4 = cmd5.ExecuteReader();
        dr4.Read();
        for (int i = 1; i <= 4; i++)
        {
            string check1 = "s" + i + "_id";
            string check2 = "s" + i + "_chip";
            if (dr4[check1].ToString() != DBNull.Value.ToString())
            {
                switch (i)
                {
                    case 1: uname1.Text = dr4[check1].ToString();
                        coin1.Text = dr4[check2].ToString();
                        Image5.ImageUrl = "~/images/a" + image_display(dr4[check1].ToString());
                        break;
                    case 2: uname2.Text = dr4[check1].ToString();
                        coin2.Text = dr4[check2].ToString();
                        Image6.ImageUrl = "~/images/a" + image_display(dr4[check1].ToString());
                        break;
                    case 3: uname3.Text = dr4[check1].ToString();
                        coin3.Text = dr4[check2].ToString();
                        Image7.ImageUrl = "~/images/a" + image_display(dr4[check1].ToString());
                        break;
                    case 4: uname4.Text = dr4[check1].ToString();
                        coin4.Text = dr4[check2].ToString();
                        Image8.ImageUrl = "~/images/a" + image_display(dr4[check1].ToString());
                        break;
                }
            }
            else
            {
                switch (i)
                {
                    case 1: uname1.Text ="";
                        coin1.Text = "";
                        Image5.ImageUrl = "";
                        break;
                    case 2: uname2.Text = "";
                        coin2.Text = "";
                        Image6.ImageUrl = "";
                        break;
                    case 3: uname3.Text = "";
                        coin3.Text = "";
                        Image7.ImageUrl = "";
                        break;
                    case 4: uname4.Text = "";
                        coin4.Text ="";
                        Image8.ImageUrl = "";
                        break;
                }
            }
        }
        con1.Close();
    }

    public string image_display(String abc)
    {
        if (System.IO.File.Exists(Server.MapPath("~/images/a" + abc + ".jpg")))
            return abc + ".jpg";
        else if (System.IO.File.Exists(Server.MapPath("~/images/a" + abc + ".png")))
            return abc + ".png";
        else if (System.IO.File.Exists(Server.MapPath("~/images/a" + abc + ".jpeg")))
            return abc + ".jpeg";
        else if (System.IO.File.Exists(Server.MapPath("~/images/a" + abc + ".gif")))
            return abc + ".gif";
        else if (System.IO.File.Exists(Server.MapPath("~/images/a" + abc + ".bmp")))
            return abc + ".bmp";
        else
            return "abc.png";
    }
    protected void check_user() {
        SqlConnection con1 = dbconnection.newconnection();
        con1.Open();
        SqlCommand cmd5 = new SqlCommand("select * from pok_tbl where tbl_id=" + id2, con1);
        SqlDataReader dr4 = cmd5.ExecuteReader();
        dr4.Read();
        if (int.Parse(dr4["no_player"].ToString()) == 1)
        {
                
       
        }
        if(int.Parse(dr4["no_player"].ToString()) == 2){
            dr4.Close();
            start_game();
        }
        con1.Close();
    }
    protected void user_seat()
    {
        int f = 0;
        SqlConnection con1 = dbconnection.newconnection();
        con1.Open();
        SqlCommand cmd2 = new SqlCommand("select * from pok_tbl where tbl_id=" + id2, con1);
        SqlDataReader dr3 = cmd2.ExecuteReader();
        dr3.Read();
        if ((int.Parse(dr3["no_player"].ToString())) < 2)
        {
            dr3.Close();
            SqlCommand cmd3 = new SqlCommand("UPDATE status_update SET status=NULL WHERE tbl_id=" + id2, con1);
            cmd3.ExecuteNonQuery();
            check_user();
            label11.Visible = false;
            Timer2.Enabled = false;
            flage = 0;
            Button2.Visible = false; 
            Button3.Visible = false;
            UpdatePanel3.Update();
            change = 0;
        }
        else
        {
            dr3.Close();
            con1.Close();
            con1.Open();
            SqlCommand cmd5 = new SqlCommand("select * from game_tbl where tbl_id=" + id2, con1);
            SqlDataReader dr4 = cmd5.ExecuteReader();
            dr4.Read();
            int y = int.Parse(Session["seat_no"].ToString());

            for (int i = 1; i <= 4; i++)
            {
                string a1 = "s" + i + "_id";
                string a2 = "s" + i + "_state";

                if ((dr4[a1].ToString() != DBNull.Value.ToString()) && (i > y) && (dr4[a2].ToString() != "0"))
                {

                    SqlConnection con2 = dbconnection.newconnection();
                    con2.Open();
                    SqlCommand cmd4 = new SqlCommand("UPDATE status_update SET status =" + i + " WHERE tbl_id=" + id2, con2);
                    cmd4.ExecuteNonQuery();
                    f = 1;
                    con2.Close();
                    break;
                }
            }
            con1.Close();
            con1.Open();
            SqlCommand cmd6 = new SqlCommand("select * from game_tbl where tbl_id=" + id2, con1);
            SqlDataReader dr5 = cmd6.ExecuteReader();
            dr5.Read();
            if (f == 0)
            {
                y = 0;
                for (int j = 1; j <= 4; j++)
                {
                    string a3 = "s" + j + "_id";
                    string a4 = "s" + j + "_state";
                    if ((dr5[a3].ToString() != DBNull.Value.ToString()) && (j > y) && (dr5[a4].ToString() != "0"))
                    {
                        SqlConnection con3 = dbconnection.newconnection();
                        con3.Open();
                        SqlCommand cmd3 = new SqlCommand("UPDATE status_update SET status =" + j + " WHERE tbl_id=" + id2, con3);
                        cmd3.ExecuteNonQuery();
                        con3.Close();
                        break;
                    }
                }

            }
        }
        con1.Close();
        flage = 0;
       
    }
    protected void display_cards()
    {
        string seat = Session["seat_no"].ToString();
        SqlConnection con1 = dbconnection.newconnection();
        con1.Open();
        SqlCommand cmd5 = new SqlCommand("select * from display_cards where tbl_id="+ id2, con1);
        SqlDataReader dr4 = cmd5.ExecuteReader();
        dr4.Read();
        if (dr4["status"].ToString() != DBNull.Value.ToString())
       {
        if (seat == dr4["status"].ToString())
        {
            
            Image9.ImageUrl = "~/image/cards/" + dr4["card1"] + ".png";
            Image10.ImageUrl = "~/image/cards/" + dr4["card2"] + ".png";
            Image11.ImageUrl = "~/image/cards/" + dr4["card3"] + ".png";

        }
        else
        {
            Image10.Visible = false;
            Image1.Visible = true;
            Image9.ImageUrl = "~/image/cards/" + dr4["card1"] + ".png";
            Image10.ImageUrl = "~/image/cards/" + dr4["card2"] + ".png";
            Image11.ImageUrl = "~/image/cards/" + dr4["card3"] + ".png";
        }
       }
        con1.Close();
    }
    protected void display_result()
    {
        if (int.Parse(Session["f1"].ToString()) == 0)
        {
            string seat = Session["seat_no"].ToString();
            SqlConnection con1 = dbconnection.newconnection();
            con1.Open();
            SqlCommand cmd5 = new SqlCommand("select * from display_result where tbl_id=" + id2, con1);
            SqlDataReader dr4 = cmd5.ExecuteReader();
            dr4.Read();
            if ("1" == dr4["status"].ToString())
            {
                
                Timer1.Enabled = false;
                Panel3.Visible = true;
                //UpdatePanel7.Update();
                count = 10;
                start_in_time.Visible = true;
                Label3.Text = "--*--WIN--*--";
                Label8.Text =dr4["userid"] + "  Chips =" + dr4["chips"];
                Timer3.Enabled = true;
                Session["f1"] = 1;
            }
            else if ("2" == dr4["status"].ToString())
            {
                Timer1.Enabled = false;
                start_in_time.Visible = false;
                Panel3.Visible = true;
                //UpdatePanel7.Update();
                x = 0;
                Label3.Text = "--*--LOSE--*--";
                Label8.Text = dr4["userid"].ToString() ;
                Timer4.Enabled = true;
                Session["f1"] = 1;
            }

            con1.Close();
        }
    }
    protected void turn()
    {
        if (flage == 0)
        {
            SqlConnection con1 = dbconnection.newconnection();
            con1.Open();
            SqlCommand cmd6 = new SqlCommand("select * from status_update where tbl_id=" + id2, con1);

            SqlDataReader dr5 = cmd6.ExecuteReader();
            dr5.Read();
            if (dr5["status"].ToString() == Session["seat_no"].ToString())
            {
                
                Button2.Visible = true;
                Button3.Visible = true;
                UpdatePanel3.Update();
                suffel_Click();
                SqlConnection con2 = dbconnection.newconnection();
                con2.Open();
                SqlCommand cmd4 = new SqlCommand("UPDATE display_cards  SET card1 =" + a + ",card2 =" + b + ",card3 =" + c + ",status =" + int.Parse(Session["seat_no"].ToString()) + " WHERE tbl_id=" + id2, con2);
                cmd4.ExecuteNonQuery();
                con2.Close();
                z = 30;
                change = 0;
                Timer2.Enabled = true;
                label11.Visible = true;
                label11.Text = z.ToString();
                flage = 1;
            }
            
            con1.Close();
        }
        
    }
    protected void suffel_Click()
    {
        Get_RandomImage1();
        Get_RandomImage2();
        Get_RandomImage3();
    }
    protected int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
    protected void Get_RandomImage1()
    {
        Random random = new Random();
        a = random.Next(1, 52);
        Image9.ImageUrl = "~/image/cards/" + a + ".png";

    }
    protected void Get_RandomImage2()
    {
        Random random = new Random();
        b = random.Next(1, 52);
        while(b == a)
        {
            b = random.Next(1, 52);
        }
        Image10.Visible = false;
        Image10.ImageUrl = "~/image/cards/" + b + ".png";
        Image1.Visible = true;
    }
    protected void Get_RandomImage3()
    {
        Random random = new Random();
        c = random.Next(1, 52);
        while (c == a || c == b)
        {
            c = random.Next(1, 52);

        }
        Image11.ImageUrl = "~/image/cards/" + c + ".png";

    }
    public void bet_loss(int chips)
    {
        Session["f1"] = 0;
        change = 2;
        string seat = Session["seat_no"].ToString();
         string ch1=null;
         string ch2=null;
         for (int i = 1; i <= 4; i++)
         {
             if (seat == i.ToString())
             {
                 ch1 = "s" + i + "_chip";
                 ch2= "s"+ i +"_id";
             }
         }
             SqlConnection con = dbconnection.newconnection();
             con.Open();

             SqlCommand cmd = new SqlCommand("select " + ch1.ToString() +" from game_tbl where tbl_id=" +id2, con);
             SqlDataReader dr1 = cmd.ExecuteReader();
         
        if (dr1.Read())
        {
            var coins = dr1[ch1];
            // coins.Text = coins.ToString();
            int co1 = int.Parse(coins.ToString());
            int co2 = co1 - chips;
            
            con.Close();
            con.Open();
            SqlCommand cmd2 = new SqlCommand("UPDATE game_tbl  SET " + ch1 + " = " + co2 + "WHERE tbl_id="+id2, con);
            SqlCommand cmd1 = new SqlCommand("UPDATE user_data  SET chips = " + co2 + "WHERE username= '" + u_name1 + "'", con);
            SqlCommand cmd4 = new SqlCommand("UPDATE display_result  SET status=2, userid ='" + u_name1 + "',chips= " + chips + " WHERE tbl_id=" + id2, con);
            cmd2.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd4.ExecuteNonQuery();
            con.Close();
            display_result();
            switch (int.Parse(seat)){
            
                case 1:coin1.Text = co2.ToString();
                       break;
                case 2: coin2.Text = co2.ToString();
                       break;
                case 3: coin3.Text = co2.ToString();
                       break;
                case 4: coin4.Text = co2.ToString();
                       break;
            }
            
        }


    }
    public void bet_win(int chips)
    {
        Session["f1"] = 0;
        change = 2;
        string seat = Session["seat_no"].ToString();
        string ch1 = null;
        string ch2 = null;
        for (int i = 1; i <= 4; i++)
        {
            if (seat == i.ToString())
            {
                ch1 = "s" + i + "_chip";
                ch2 = "s" + i + "_id";
            }
        }
        SqlConnection con = dbconnection.newconnection();
        con.Open();

        SqlCommand cmd = new SqlCommand("select " + ch1.ToString() + " from game_tbl where tbl_id="+id2, con);
        SqlDataReader dr1 = cmd.ExecuteReader();

        if (dr1.Read())
        {
            var coins = dr1[ch1];
            // coins.Text = coins.ToString();
            int co1 = int.Parse(coins.ToString());
            int co2 = co1 + chips;
            con.Close();
            con.Open();
            SqlCommand cmd2 = new SqlCommand("UPDATE game_tbl  SET " + ch1 + " = " + co2 + "WHERE " + ch2 + "= '" + u_name1 + "'", con);
            SqlCommand cmd1 = new SqlCommand("UPDATE user_data  SET chips = " + co2 + "WHERE username= '" + u_name1 + "'", con);
            SqlCommand cmd4 = new SqlCommand("UPDATE display_result  SET status=1, userid ='" +u_name1+ "',chips= "+ chips +" WHERE tbl_id="+id2,con);
            cmd2.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd4.ExecuteNonQuery();
            con.Close();
            display_result();
            switch (int.Parse(seat))
            {

                case 1: coin1.Text = co2.ToString();
                    break;
                case 2: coin2.Text = co2.ToString();
                    break;
                case 3: coin3.Text = co2.ToString();
                    break;
                case 4: coin4.Text = co2.ToString();
                    break;
            }          
        }

        
    }
    public int reduce_card(int check)
    {
        for (int i = 1; i <= 13; i++)
        { 
            int temp=i*4;
            if (check <= temp)
            {
                return i;
            }
        }
        return 0;
    }
    protected void call_Click(object sender, EventArgs e)
    {
        Image10.Visible = true;
        Image1.Visible = false;
        a1 = reduce_card(a);
        b2 = reduce_card(b);
        c3 = reduce_card(c);
        Button2.Visible = false;
        Button3.Visible = false;
        UpdatePanel3.Update();
        
        SqlConnection con1 = dbconnection.newconnection();
        con1.Open();
        SqlCommand cmd2 = new SqlCommand("select * from game_tbl where tbl_id=" + id2, con1);
        SqlDataReader dr3 = cmd2.ExecuteReader();
        dr3.Read();
        int y= int.Parse(dr3["pot_chip"].ToString());
        if (a1 <= c3)
        {
            if (a1 < b2)
            {
                if (c3 > b2)
                {
                    
                    pot_update(1, bet);
                    bet_win(y);
                }
                else
                {
                    
                    pot_update(0, bet); 
                    bet_loss(bet);
                }
            }
            else
            {
                
                pot_update(0, bet); 
                bet_loss(bet);
            }
        }
        else
        {
            if (c3 < b2)
            {
                if (a1 > b2)
                {
                   
                    pot_update(1, bet);
                    bet_win(y);
                }
                else
                {
                    
                    pot_update(0, bet); 
                    bet_loss(bet);                    
                }
            }
            else
            {
                
                pot_update(0, bet); 
                bet_loss(bet);                
            }

        }
        
        a = b = c = a1 = b2 = c3 = 0;
        con1.Close();
        
    }
    protected void fold_Click(object sender, EventArgs e)
    {
        
        change = 1;
        Button3.Visible = false;
        Button2.Visible = false;
        UpdatePanel3.Update();
    }
    protected void leave_tbl(object sender, EventArgs e)
    {
        SqlConnection con = dbconnection.newconnection();
        con.Open();

        string aaaa = Session["seat_no"].ToString();

        
        SqlCommand cmd2 = new SqlCommand("select * from pok_tbl where tbl_id=" + id2, con);
        SqlDataReader dr3 = cmd2.ExecuteReader();
        dr3.Read();
        string aad_player = dr3["no_player"].ToString();
        dr3.Close();
        con.Close();
        con.Open();
        SqlCommand cmd6 = new SqlCommand("UPDATE pok_tbl  SET no_player=" + (int.Parse(aad_player) - 1) + "where tbl_id=" + id2, con);
        cmd6.ExecuteNonQuery();
        if (aad_player == "2")
        {
            SqlCommand cmd5 = new SqlCommand("select * from game_tbl where tbl_id=" + id2, con);
            SqlDataReader dr4 = cmd5.ExecuteReader();
            dr4.Read();
            int y = int.Parse(Session["seat_no"].ToString());
            int cch = int.Parse(dr4["pot_chip"].ToString());
            for (int i = 1; i <= 4; i++)
            {
                string a1 = "s" + i + "_id";
                string a2 = "s" + i + "_state";

                string a3 = "s" + i + "_chip";

                if ((dr4[a1].ToString() != DBNull.Value.ToString()) && (i != y) && (dr4[a2].ToString() != "0"))
                {
                    int cch1 = int.Parse(dr4[a3].ToString());

                    SqlConnection con2 = dbconnection.newconnection();
                    con2.Open();
                    SqlCommand cmd4 = new SqlCommand("UPDATE game_tbl SET " + a3 + "=" + (cch + cch1) + ",pot_chip=0 WHERE tbl_id=" + id2, con2);
                    cmd4.ExecuteNonQuery();
                    SqlCommand cmd7 = new SqlCommand("UPDATE display_result SET status=1, userid= '" + dr4[a1].ToString() + "', chips=" + cch + " WHERE tbl_id=" + id2, con2);
                    cmd7.ExecuteNonQuery();

                    con2.Close();
                    
                }
            }
        }
            if (aad_player == "1")
            {
                SqlConnection con11 = dbconnection.newconnection();
                con11.Open();
                SqlCommand cmd = new SqlCommand("update game_tbl SET pot_chip=0  where tbl_id=" + id2, con11);
                cmd.ExecuteNonQuery();
                con11.Close();
                SqlConnection con2 = dbconnection.newconnection();
                con2.Open();
                SqlCommand cmd4 = new SqlCommand("UPDATE display_result SET status=NULL, userid=NULL, chips=NULL WHERE tbl_id=" + id2, con2);
                cmd4.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("UPDATE display_cards SET status=NULL, card1=NULL, card2=NULL, card3=NULL WHERE tbl_id=" + id2, con2);
                cmd1.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("UPDATE status_update SET status=NULL WHERE tbl_id=" + id2, con2);
                cmd3.ExecuteNonQuery();

                con2.Close();
            }
        
        con.Close();
        Session["refresh"] = null;
        Session.Remove("seat_no");
        Session.Remove("refresh");
        
        flage = 0;
        con.Open();

        if (aaaa == "1")
        {

            SqlCommand cmd = new SqlCommand("update game_tbl set s1_id=NULL, s1_chip=NULL, s1_state=NULL where tbl_id=" + id2, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("Game.aspx");
        }
        if (aaaa == "2")
        {
            SqlCommand cmd = new SqlCommand("update game_tbl set s2_id=NULL, s2_chip=NULL, s2_state=NULL where tbl_id=" + id2, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("Game.aspx");
        }
        if (aaaa == "3")
        {
            SqlCommand cmd = new SqlCommand("update game_tbl set s3_id=NULL, s3_chip=NULL, s3_state=NULL where tbl_id=" + id2, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("Game.aspx");
        }
        if (aaaa == "4")
        {
            SqlCommand cmd = new SqlCommand("update game_tbl set s4_id=NULL, s4_chip=NULL, s4_state=NULL where tbl_id=" + id2, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("Game.aspx");
        }

        con.Close();
   }
    public string id1 { get; set; }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        update();
        potarea_update();
        display_cards();
        display_result();
        turn();
    }
    protected void pot_update(int x123, int chip) {
        SqlConnection con = dbconnection.newconnection();
        con.Open();
        SqlCommand cmd5 = new SqlCommand("select * from game_tbl where tbl_id=" + id2, con);
        SqlDataReader dr4 = cmd5.ExecuteReader();
        dr4.Read();
        int cur_coin= (int.Parse(dr4["pot_chip"].ToString()));
        dr4.Close();
        if (x123 == 1)
        {
           
            SqlCommand cmd = new SqlCommand("update game_tbl set pot_chip = 0  where tbl_id=" + id2, con);
            cmd.ExecuteNonQuery();
        }
        
        
        if (x123 == 0)
        {
            SqlCommand cmd = new SqlCommand("update game_tbl set pot_chip = '"+(cur_coin+chip)+"'  where tbl_id="+id2, con);
            cmd.ExecuteNonQuery();
            
        }
        con.Close();
    }
    protected void start_game()
    {
        SqlConnection con1 = dbconnection.newconnection();
        con1.Open();
        SqlCommand cmd2 = new SqlCommand("select * from pok_tbl where tbl_id=" + id2, con1);
        SqlDataReader dr3 = cmd2.ExecuteReader();
        dr3.Read();
        if ((int.Parse(dr3["no_player"].ToString())) > 1)
        {

            dr3.Close();
            SqlConnection con = dbconnection.newconnection();
            con.Open();
            SqlCommand cmd5 = new SqlCommand("select * from game_tbl where tbl_id=" + id2, con);
            SqlDataReader dr4 = cmd5.ExecuteReader();
            dr4.Read();
            for (int i = 1; i <= 4; i++)
            {
                string a1 = "s" + i + "_id";
                string a2 = "s" + i + "_chip";
                string a3 = "s" + i + "_state";
                SqlConnection con2 = dbconnection.newconnection();
                con2.Open();
                if (dr4[a1].ToString() != DBNull.Value.ToString())
                {
                    int ch1 = int.Parse(dr4[a2].ToString());
                    int ch = ch1 - bot;
                    
                    SqlCommand cmd4 = new SqlCommand("update game_tbl set " + a2 + "=" + ch + "," + a3 + "=1 where tbl_id=" + id2, con2);
                    cmd4.ExecuteNonQuery();
                    pot_update(0, bot);

                }
                con2.Close();
            }
            user_seat();
        }
        else
        {
            dr3.Close();
            SqlCommand cmd3 = new SqlCommand("UPDATE status_update SET status=NULL WHERE tbl_id=" + id2, con1);
            cmd3.ExecuteNonQuery();
            check_user();
            label11.Visible = false;
            Timer2.Enabled = false;
            flage = 0;
            Button3.Visible = false;
            Button2.Visible = false;
            
            UpdatePanel3.Update();
            change = 0;
        }
        con1.Close();
   }
    protected void potarea_update() {
        SqlConnection con = dbconnection.newconnection();
        con.Open();
        SqlCommand cmd5 = new SqlCommand("select * from game_tbl where tbl_id=" + id2, con);
        SqlDataReader dr4 = cmd5.ExecuteReader();
        dr4.Read();
        string cur_coin =dr4["pot_chip"].ToString();
        pot_chips.Text = cur_coin;
        con.Close();
    }
    protected void update_botbet() {
        SqlConnection con = dbconnection.newconnection();
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from pok_tbl where tbl_id=" + id2, con);
        SqlDataReader dr3 = cmd.ExecuteReader();
        dr3.Read();
        int k = int.Parse(dr3["cat_id"].ToString());
        con.Close();
        con.Open();
        SqlCommand cmd1 = new SqlCommand("select * from tbl_cat where cat_id=" + k, con);
        SqlDataReader dr2 = cmd1.ExecuteReader();
        dr2.Read();
        bot = int.Parse(dr2["bot"].ToString());
        bet = int.Parse(dr2["bet"].ToString());
        dr2.Close();
        con.Close();
     }
    protected void Timer2_Tick(object sender, EventArgs e)
    {
        if (z >= 0 && change == 0)
        {
            label11.Text = z.ToString();
            z = z - 1;
        }
        else
        {
            label11.Visible = false;
            Timer2.Enabled = false;
            Button2.Visible = false;
            Button3.Visible = false;
            UpdatePanel3.Update();
                if (change == 1 || z<0)
            {
                user_seat();
            }
        }
    }
    protected void Timer3_Tick(object sender, EventArgs e)
    {
        if (count >= 0)
        {
            
            start_in_time.Text = "Next game start in "+ count.ToString();
            count = count - 1;
        }
        else
        {
            SqlConnection con = dbconnection.newconnection();
            con.Open();
            SqlCommand cmd4 = new SqlCommand("UPDATE display_result  SET status=0 WHERE tbl_id=" + id2, con);
            cmd4.ExecuteNonQuery();
            cmd4.Cancel();
            
            Panel3.Visible = false;
            
            Timer1.Enabled = true;
                       
            SqlCommand cmd3 = new SqlCommand("select * from display_result WHERE tbl_id="+id2,con);
            SqlDataReader dr1 = cmd3.ExecuteReader();
            dr1.Read();
            Session["f1"] = 0;
            if(u_name2 == dr1["userid"].ToString())
            {
              start_game();
            }
            con.Close();
            start_in_time.Visible = false;
            Timer3.Enabled = false;
        }
    }
    protected void Timer4_Tick(object sender, EventArgs e)
    {
        if (x != 1)
        {
            Image10.Visible = true;
            Image1.Visible = false;
            x = 1;
        }
        else
        {
            SqlConnection con = dbconnection.newconnection();
            con.Open();
            SqlCommand cmd4 = new SqlCommand("UPDATE display_result  SET status=0 WHERE tbl_id=" + id2, con);
            cmd4.ExecuteNonQuery();
            cmd4.Cancel();

            Panel3.Visible = false;
            
            Timer1.Enabled = true;

            SqlCommand cmd3 = new SqlCommand("select * from display_result WHERE tbl_id=" + id2, con);
            SqlDataReader dr1 = cmd3.ExecuteReader();
            dr1.Read();
            Session["f1"] = 0;
            if (u_name2 == dr1["userid"].ToString())
            {
                user_seat();
            }
            con.Close();
            Session["f1"] = 0;
            Timer4.Enabled = false;
        }
    }
}