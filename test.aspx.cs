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

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"].ToString() == null)
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string fileName = string.Empty;
        string fname = string.Empty;
        string filePath = string.Empty;
        string extension = string.Empty;
        try
        {
            //Check if Fileupload control has file in it
            if (FileUpload1.HasFile)
            {
                // Get selected image extension
                extension = Path.GetExtension(FileUpload1.FileName).ToLower();
                //Check image is of valid type or not
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".bmp")
                {
                    fileName = Session["user_id"].ToString() + extension;
                    fname ="a"+ Session["user_id"].ToString() + extension;
                    //  fileName = Guid.NewGuid().ToString() + extension;
                    filePath = Path.Combine(Server.MapPath("~/images"), fname);
                    FileUpload1.SaveAs(filePath);
                    System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/images/" + fname));
                    int imageHeight = img.Height;
                    int imageWidth = img.Width;
                    int maxHeight = 600;
                    int maxWidth = 450;
                    imageHeight = (imageHeight * maxWidth) / imageWidth;
                    imageWidth = maxWidth;

                    if (imageHeight > maxHeight)
                    {
                        imageWidth = (imageWidth * maxHeight) / imageHeight;
                        imageHeight = maxHeight;
                    }


                    System.Drawing.Image thumbnail = new Bitmap(imageWidth, imageHeight);
                    
                    Graphics graphic = Graphics.FromImage(thumbnail);
                    graphic.DrawImage(img, 0, 0, imageWidth, imageHeight);

                    string ServerMapPath1 = Server.MapPath("~/images/"+fileName );
                    thumbnail.Save(ServerMapPath1);
                    imageWidth = 0;
                    imageHeight = 0;
                    //Bitmap bitmap = new Bitmap(img, imageWidth, imageHeight);
                    //System.IO.MemoryStream stream = new MemoryStream();
                    //bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //stream.Position = 0;
                    //byte[] image = new byte[stream.Length + 1];
                    //stream.Read(image, 0, image.Length);


                    pnlCrop.Visible = true;
                    imgToCrop.ImageUrl = "~/images/" + fileName;
                }
                else
                {
                    lblMsg.Text = "Please select jpg, jpeg, png, gif or bmp file only";
                }
            }
            else
            {
                lblMsg.Text = "Please select file to upload";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Oops!! error occured : " + ex.Message.ToString();
        }
        finally
        {
            extension = string.Empty;
            fileName = string.Empty;
            filePath = string.Empty;
        }
    }

    protected void btnCrop_Click(object sender, EventArgs e)
    {
        string croppedFileName = string.Empty;
        string croppedFilePath = string.Empty;
        //get uploaded image name
        string fileName = Path.GetFileName(imgToCrop.ImageUrl);
        //get uploaded image path
        string filePath = Path.Combine(Server.MapPath("~/images"), fileName);

        //Check if file exists on the path i.e. in the UploadedImages folder.
        if (File.Exists(filePath))
        {
            //Get the image from UploadedImages folder.
            System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
            
            //Get user selected cropped area
            //Convert.ToInt32(String.Format("{0:0.##}", YCoordinate.Value)),

            Rectangle areaToCrop = new Rectangle(
                Convert.ToInt32(XCoordinate.Value),
                Convert.ToInt32(YCoordinate.Value),
                Convert.ToInt32(Width.Value),
                Convert.ToInt32(Height.Value));
            try
            {

                Bitmap bitMap = new Bitmap(areaToCrop.Width, areaToCrop.Height);
                //Create graphics object for alteration
                using (Graphics g = Graphics.FromImage(bitMap))
                {
                    //Draw image to screen
                    g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), areaToCrop, GraphicsUnit.Pixel);
                }

                //name the cropped image
                croppedFileName = "a" + fileName;
                //Create path to store the cropped image
                croppedFilePath = Path.Combine(Server.MapPath("~/images"), croppedFileName);
                //save cropped image in folder
                bitMap.Save(croppedFilePath);
                orgImg.Dispose();
                bitMap = null;
                //Now you can delete the original uploaded image from folder               
                File.Delete(filePath);
                //Hide the panel
                pnlCrop.Visible = false;
                //Show success message in label
                lblMsg.ForeColor = Color.Green;
                lblMsg.Text = "Image cropped and saved successfully";

                //Show cropped image
                imgCropped.ImageUrl = "~/images/" + croppedFileName;
                SqlConnection con = dbconnection.getConnection();

                //Show Reset button
                btnReset.Visible = true;
                gotoG.Visible = true;
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Oops!! error occured : " + ex.Message.ToString();
            }
            finally
            {
                fileName = string.Empty;
                filePath = string.Empty;
                croppedFileName = string.Empty;
                croppedFilePath = string.Empty;
            }
        }

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        imgCropped.ImageUrl = "";
        lblMsg.Text = string.Empty;
        btnReset.Visible = false;
    }
    protected void gotoGame(object sender, EventArgs e)
    {
        Response.Redirect("~/Game.aspx");
    }


    protected void playsound(object sender, EventArgs e)
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\don\Downloads\Blood.wav");
        player.Play();
    }
}



