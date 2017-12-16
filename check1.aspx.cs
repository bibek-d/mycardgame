using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetComm;
using System.Text;

public partial class check1 : System.Web.UI.Page
{
    
    NetComm.Client client;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        client = new NetComm.Client();
        client.Connected += new NetComm.Client.ConnectedEventHandler(client_Connected);
        client.Disconnected += new NetComm.Client.DisconnectedEventHandler(client_Disconnected);
        client.DataReceived += new NetComm.Client.DataReceivedEventHandler(client_DataReceived);
    }


    void client_Connected()
    {
        Label1.Text = "Connected successfully!" +
        Environment.NewLine; //Updates the log with the current connection state
    }

    void client_Disconnected()
    {
        Label1.Text = "Disconnected from host!" +
        Environment.NewLine; //Updates the log with the current connection state
    }

    void client_DataReceived(byte[] Data, string ID)
    {
        Label1.Text = ID + ": " + ConvertBytesToString(Data) +
        Environment.NewLine; //Updates the log with the current connection state
    }

    private string ConvertBytesToString(byte[] Data)
    {
        return Data.ToString();
    }



    byte[] ConvertStringToBytes(string str)
    {
        return ASCIIEncoding.ASCII.GetBytes(str);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        client.Connect("localhost", 2020, "Jack");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        client.SendData(ConvertStringToBytes(TextBox2.Text), "my");
    }
}