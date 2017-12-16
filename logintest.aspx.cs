using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;

public class FaceBookUser
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string PictureUrl { get; set; }
    public string Email { get; set; }

}

public partial class logintest : System.Web.UI.Page 
{
    public void Page_Load(object sender, EventArgs e)
    {
        FaceBookConnect.API_Key =  "952810471446057";
        FaceBookConnect.API_Secret = "507e468015b97c30464309836d970c23";
        if (!IsPostBack)
        {
            if (Request.QueryString["error"] == "access_denied")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User has denied access.')", true);
                return;
            }

            string code = Request.QueryString["code"];
            if (!string.IsNullOrEmpty(code))
            {
                string data = FaceBookConnect.Fetch(code, "me");
                FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
                pnlFaceBookUser.Visible = true;
                lblId.Text = faceBookUser.Id;
                lblUserName.Text = faceBookUser.UserName;
                lblName.Text = faceBookUser.Name;
                lblEmail.Text = faceBookUser.Email;
                ProfileImage.ImageUrl = faceBookUser.PictureUrl;
                btnLogin.Enabled = false;
            }
        }
    }
    public void Login(object sender, EventArgs e)
    {
        FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);
    }
}
