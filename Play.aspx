<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Play.aspx.cs" Inherits="Play" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<link rel="Stylesheet" type="text/css" href="css/Style.css" />
<link rel="shortcut icon" href="image/ti.png" type="image/png" />
<style type="text/css" >


</style>
 <script type="text/javascript" >
      
 </script>
    <title></title>
</head>
 <body id="back">
    <form id="form1" runat="server" enableviewstate="True">
    <div class="head">
    <asp:Button ID="lgout" runat="server" CssClass="button" Text="Back" OnClick="leave_tbl" />
    </div>
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <div class="main">
    <div id="game1">
    <asp:Image CssClass="loading" ID="loading" runat="server" ImageUrl="~/image/loading.gif" Visible="False" />
    

        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>
        <asp:Panel ID="Panel3" CssClass="winner_div" runat="server" Visible="False">
            <asp:Label ID="Label3" runat="server" CssClass="label1" Text=""></asp:Label>
        <asp:Label ID="Label8" runat="server" CssClass="label2" Text=""></asp:Label>
            <asp:Label ID="start_in_time" runat="server" CssClass="label3" Text=""></asp:Label>
        </asp:Panel>
        </ContentTemplate>
        <Triggers><asp:AsyncPostBackTrigger ControlID="Timer3"  /></Triggers>
        </asp:UpdatePanel>

   
            <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Always"  runat="server">
            <ContentTemplate>
            <div class="timer_box">
            <asp:Label ID="label11" runat="server" Text="" CssClass="round_number"></asp:Label>
                <asp:Label ID="time_wait" CssClass="time_left" runat="server" Text="Time Left"></asp:Label>
            </div>
            </ContentTemplate>
           <Triggers><asp:AsyncPostBackTrigger ControlID="Timer2"  /></Triggers>
            </asp:UpdatePanel>
       
        <asp:Panel ID="Panel2" runat="server" Enabled="true">
        <div class="func1">
            
            <asp:UpdatePanel ID="UpdatePanel3"  ChildrenAsTriggers="true" runat="server" 
                UpdateMode="Conditional">
            <ContentTemplate>
            <asp:Button ID="Button3"  runat="server" CssClass="circ-button1" Text="Call" onclick="call_Click" Visible="false" />
            <asp:Button ID="Button2" CssClass="circ-button2" runat="server" Text="Fold"  Visible="false" onclick="fold_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
               </div>
   </asp:Panel>
  
   <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>

            <asp:Panel ID="seatpanel1" runat="server" Visible="true">
          <div class="seat1">
       <div class="seat_f"></div>
          <div class="seat_back"></div>
        <div class="seatpic1">
           
           <asp:Image ID="Image5" ImageUrl="" CssClass="picinside1"  runat="server" />
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
       
        <asp:Image ID="Image6" ImageUrl="" CssClass="picinside1"  runat="server" />
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
        
        <asp:Image ID="Image7" ImageUrl="" CssClass="picinside"  runat="server" />
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
        
        <asp:Image ID="Image8" ImageUrl="" CssClass="picinside"  runat="server" />
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
            <asp:Image ID="Image10" CssClass="img2"  runat="server" Visible="false" />
            <asp:Image ID="Image1" CssClass="img2" ImageUrl="" runat="server" Visible="false" />
        </div>
        <div class="card3">
            <asp:Image ID="Image11" CssClass="img3" runat="server" />
        </div>
     
        </ContentTemplate>
        
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
        <ContentTemplate>
        <div class="potarea">  
            <asp:Label ID="Label4" runat="server" CssClass="label420" Text="Pot Chips:"></asp:Label>
            <asp:Label ID="pot_chips" CssClass="label421" runat="server" Text=""></asp:Label>
            </div>
        </ContentTemplate>
               
        </asp:UpdatePanel>
      </ContentTemplate>
      <Triggers>
         <asp:AsyncPostBackTrigger ControlID="Timer1" />
     </Triggers>
     </asp:UpdatePanel>
    </div>
   

   
    </div>

  
    <asp:Panel ID="Panel1" Visible="true" runat="server">
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    
    </asp:Panel>
    <div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>  
    </div>
    <asp:UpdatePanel ID="UpdatePanel7" ChildrenAsTriggers="true" runat="server"><ContentTemplate>
    <asp:Timer ID="Timer1" runat="server" Interval="2000" ontick="Timer1_Tick">
    </asp:Timer>
    <asp:Timer ID="Timer2" runat="server" Interval="1000" ontick="Timer2_Tick" Enabled="False">
    </asp:Timer>
    <asp:Timer ID="Timer3" Interval="1000" runat="server" Enabled="False" ontick="Timer3_Tick">
    </asp:Timer>
        <asp:Timer ID="Timer4" runat="server" Interval="3000" Enabled="False" 
            ontick="Timer4_Tick">
        </asp:Timer>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
