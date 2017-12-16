using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.IO;
using Image = System.Drawing.Image;

public partial class Game : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // String user = Session["user_id"];
        if (Session["user_id"] != null)
        {
            String dt = DateTime.Now.ToString("dd/MM/yyyy");

            //   Image1.ImageUrl = "~/images/a" + Session["user_id"].ToString() + ".jpg";
            if (System.IO.File.Exists(Server.MapPath("~/images/a" + Session["user_id"].ToString() + ".jpg")))
                Image1.ImageUrl = "~/images/a" + Session["user_id"].ToString() + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("~/images/a" + Session["user_id"].ToString() + ".png")))
                Image1.ImageUrl = "~/images/a" + Session["user_id"].ToString() + ".png";
            else if (System.IO.File.Exists(Server.MapPath("~/images/a" + Session["user_id"].ToString() + ".jpeg")))
                Image1.ImageUrl = "~/images/a" + Session["user_id"].ToString() + ".jpeg";
            else if (System.IO.File.Exists(Server.MapPath("~/images/a" + Session["user_id"].ToString() + ".gif")))
                Image1.ImageUrl = "~/images/a" + Session["user_id"].ToString() + ".gif";
            else if (System.IO.File.Exists(Server.MapPath("~/images/a" + Session["user_id"].ToString() + ".bmp")))
                Image1.ImageUrl = "~/images/a" + Session["user_id"].ToString() + ".bmp";
            else
                Image1.ImageUrl = "images/aabc.png";
            GridView1.Columns[5].Visible = false;
            if (Session["name"] == null)
            {
                Label1.Text = "Welcome :" + (String)Session["user_id"];
            }
            else
            {
                Label1.Text = "Welcome :" + (String)Session["name"];

            }
            SqlConnection con = dbconnection.newconnection();
            String cs = Session["user_id"].ToString();
            SqlCommand cmd = new SqlCommand("select * from user_data where username ='" + cs + "'", con);
            con.Open();
            SqlDataReader dr4 = cmd.ExecuteReader();
            dr4.Read();
            if (dr4.HasRows)
            {
                int coins = int.Parse(dr4["chips"].ToString());

                String current = DateTime.Now.ToString("dd/MM/yyyy");
                string prev = dr4["last_login"].ToString();
                if (prev == current)
                {

                }
                else
                {
                    dr4.Close();

                    // Response.Write("<script>alert('Congrats you won 1000 chips.. keep playing');</script>");
                    SqlCommand cmd1 = new SqlCommand("update user_data set last_login='" + current + "', chips=" + (coins + 1000) + " where username='" + cs + "'", con);
                    cmd1.ExecuteNonQuery();
                    Panel1.Visible = true;
                }
                con.Close();
            }
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }
    }

    protected void logout(object sender, EventArgs e)
    {
        Response.Redirect("~/logout.aspx");
    }
    protected void OnRowSelected(object sender, GridViewSelectEventArgs e)
    {
        // Get the datakey of the selected row
        var id = Convert.ToInt32(GridView2.DataKeys[e.NewSelectedIndex].Value);
        // Redirect to second page
        //    Response.Write(id.ToString());
        Response.Redirect("Play.aspx?Id=" + id + "&" + "u_name=" + Session["user_id"]);
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
}



























