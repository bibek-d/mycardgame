using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class login : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        lblNotice.Visible = false;
        pass.TextMode = TextBoxMode.Password;
    }

    protected void register(object sender, EventArgs e)
    {
        SqlConnection con = dbconnection.newconnection();
        String userexists = TextBox1.Text;
        // Labelinfo.Text = userexists;
        con.Open();
        SqlCommand cmd = new SqlCommand("select username from user_data where username='" + userexists + "'", con);

        SqlDataReader dr4 = cmd.ExecuteReader();
        if (!dr4.Read())
        {

            if (TextBox2.Text == TextBox3.Text)
            {
                SqlCommand com = new SqlCommand("storlogin134", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("username", TextBox1.Text);
                SqlParameter p2 = new SqlParameter("email", TextBox4.Text);
                SqlParameter p3 = new SqlParameter("password", TextBox2.Text);
                SqlParameter p4 = new SqlParameter("chips", 2000);
                com.Parameters.Add(p1);
                com.Parameters.Add(p2);
                com.Parameters.Add(p3);
                com.Parameters.Add(p4);
                con.Close();
                con.Open();
                com.ExecuteNonQuery();
                Labelinfo.Text = "registered successful.";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
            }
            else
            {
                Labelinfo.Text = "Password not Match";
            }

        }
        else
        {
            Labelinfo.Text = "Username already exists";
        }
    }

    
    protected void logon(object sender, EventArgs e)
    {
        SqlConnection con = dbconnection.newconnection();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM user_data WHERE username='"+uname.Text+"' AND password='"+pass.Text+"'", con);
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.HasRows)
        {
            rd.Read();
            Session["user_id"] = uname.Text;
            Response.Redirect("~/game.aspx"); 
        }

        else
        {
            lblNotice.Visible = true;
            lblNotice.Text = "Invalid username or password.";

        }
    }
}
