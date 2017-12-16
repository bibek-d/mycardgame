<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test2.aspx.cs" Inherits="test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<link rel="Stylesheet" type="text/css" href="css/style.css" />
</head>
<body id="back">
    <form id="form1" runat="server" enableviewstate="True">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="lgout" runat="server" CssClass="call_button" Text="logout"  />
    <div class="main">

       
    <div id="game1">
       
        
    <asp:Image CssClass="loading" ID="loading" runat="server" ImageUrl="~/image/loading.gif" Visible="False" />
        <asp:Panel ID="Panel3" CssClass="winner_div" runat="server" Visible="true">
        <asp:Label ID="Label3" runat="server" CssClass="label1" Text="Winner"></asp:Label>
            <asp:Label ID="start_in_time" CssClass="label2" runat="server" Text="Deepesh"></asp:Label>
            <asp:Label ID="Label4" runat="server" CssClass="label3" Text="Next game start in 8"></asp:Label>
            </asp:Panel>
       <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Always"  runat="server">
            <ContentTemplate>
            <div class="timer_box">
            <asp:Label ID="label11" runat="server" Text="5" CssClass="round_number"></asp:Label>
                <asp:Label ID="time_wait" CssClass="time_left" runat="server" Text="Time Left"></asp:Label>
            </div>
            </ContentTemplate>
           
            </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
        <asp:Panel ID="Panel2" runat="server" Enabled="true">
        <div class="func1">
            <asp:Button ID="Button3"  runat="server" CssClass="circ-button1" Text="Call"  Visible="True" />
            <asp:Button ID="Button2" CssClass="circ-button2" runat="server" Text="Fold"  Visible="True" />
            
               </div>
        
   </asp:Panel>
  <%-- </ContentTemplate>
   <asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Always" runat="server">
        <ContentTemplate>--%>
            <asp:Panel ID="seatpanel1" runat="server" Visible="true">
          <div class="seat1">
          <div class="seat_f"></div>
          <div class="seat_back"></div>
        <div class="seatpic1">
           
           <asp:Image ID="Image5" ImageUrl="~/image/hhhh.jpg" CssClass="picinside1"  runat="server" />
        </div> 
        <div class="chips_collection">
             <asp:UpdatePanel ID="UpdatePaneseat1" UpdateMode="Always"  runat="server">
       <ContentTemplate>
            <div class="round_bar">
               <asp:Label ID="uname1" runat="server" CssClass="name_label" Text="deepesh"></asp:Label>
               <asp:Label ID="coin1" runat="server" Text="566" CssClass="coin_label"></asp:Label>
            </div>
            
             </ContentTemplate>
        
        
        </asp:UpdatePanel>

        </div>
        </div>
       </asp:Panel>
  
   <asp:Panel ID="seatpanel2" runat="server"  Visible="true">
    <div class="seat2">
    <div class="seat_f2"></div>
          <div class="seat_back2"></div>
        <div class="seatpic2">
       
        <asp:Image ID="Image6" ImageUrl="~/image/hhhh.jpg" CssClass="picinside1"  runat="server" />
        </div>
        <div class="chips_collection">
           <asp:UpdatePanel ID="UpdatePanelseat2" UpdateMode="Always"  runat="server">
        <ContentTemplate>
            <div class="round_bar">
               <asp:Label ID="uname2" runat="server" CssClass="name_label" Text="gfg"></asp:Label>
               <asp:Label ID="coin2" runat="server" Text="54222546" CssClass="coin_label"></asp:Label>
            </div>
            
          </ContentTemplate>
          </asp:UpdatePanel>
        </div>
        </div>
               </asp:Panel>
    <asp:Panel ID="seatpanel3" runat="server"  Visible="true">
    <div class="seat3">
    <div class="seat_f3"></div>
          <div class="seat_back3"></div>
        <div class="seatpic3">
        
        <asp:Image ID="Image7" ImageUrl="~/image/hhhh.jpg" CssClass="picinside"  runat="server" />
        </div>
         
         <div class="chips_collection2">
          <asp:UpdatePanel ID="UpdatePanelseat3" UpdateMode="Always"  runat="server">
        <ContentTemplate>
           <div class="round_bar2">
           <asp:Label ID="uname3" runat="server" CssClass="name_label2" Text="deepeshk22"></asp:Label>
               <asp:Label ID="coin3" runat="server" Text="50000000" CssClass="coin_label2"></asp:Label>
            </div>
            
            </ContentTemplate>
          </asp:UpdatePanel>
        </div>
    </div>
    </asp:Panel>
   <asp:Panel ID="seatpanel4" runat="server"  Visible="true">
    <div class="seat4">
     <div class="seat_f4"></div>
          <div class="seat_back4"></div>
         <div class="seatpic4">
        
        <asp:Image ID="Image8" ImageUrl="~/image/hhhh.jpg" CssClass="picinside"  runat="server" />
        </div>
         <div class="chips_collection2">
             <asp:UpdatePanel ID="UpdatePanelseat4" UpdateMode="Always"  runat="server">
        <ContentTemplate>
           <div class="round_bar2">
            <asp:Label ID="uname4" runat="server" CssClass="name_label2" Text="fddf"></asp:Label>
               <asp:Label ID="coin4" runat="server" Text="dfd" CssClass="coin_label2"></asp:Label>
            </div>
           
            </ContentTemplate>
          </asp:UpdatePanel>
        </div>
    </div>
    </asp:Panel>
        
        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" runat="server">
        <ContentTemplate>
        <div class="card1"> 
            <asp:Image ID="Image9" CssClass="img1" runat="server" />
        </div>
        <div class="card2">
            <asp:Image ID="Image10" CssClass="img2"  runat="server" />
        </div>
        <div class="card3">
            <asp:Image ID="Image11" CssClass="img3" runat="server" />
        </div>
     
        </ContentTemplate>
        
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
        <ContentTemplate>
        <div class="potarea">Pot area  
            <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="pot_chips" runat="server" Text=""></asp:Label>
            </div>
        </ContentTemplate>
               
        </asp:UpdatePanel>
      </ContentTemplate>
      
     </asp:UpdatePanel>
    </div>
   

   
    </div>

  
    <asp:Panel ID="Panel1" Visible="true" runat="server">
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    
    </asp:Panel>
    <div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>  
    </div>
        </form>
</body>
</html>
