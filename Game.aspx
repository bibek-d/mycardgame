<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="Game" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="Stylesheet" type="text/css" href="css/Style.css" />
<link rel="shortcut icon" href="image/ti.png" type="image/png" />  
    
    <title> Free In-Between, Card Game.</title>
   
    <style type="text/css">
        #center
        {
            width: 525px;
        }
    </style>
   
</head>
<body class="gamebackground">
    <form id="form1" runat="server" >
    <div class="head" > 
    <asp:Button ID="Button1" runat="server" Text="logout" CssClass="button"  OnClick="logout" />

    </div>   
    
    <div style="margin-left:3%;">
<asp:Label ID="Label1" runat="server" Text="Label" Font-Size="Larger" Font-Italic="True"></asp:Label> <br />
<asp:Image ID="Image1" runat="server" CssClass="profile_pic"/><br />
<a href="test.aspx">Change Profile Pics</a> 
        </div>
    <asp:Panel ID="Panel1" CssClass="winner_div" Visible="false" runat="server">
    
        <div >
                 <h3 class="label2"> Congrats you won 1000 chips <br />daily bonus</h3> <br />
            <div class="label3"></div>
            <asp:Button ID="Button2" runat="server" style=" position:absolute; top:10px; background-color:Red; color:White; right:15px;" Text="X" onclick="Button2_Click" /></div>        
        
        </asp:Panel>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="grid1">
        
        <asp:GridView ID="GridView1" runat="server"  CssClass="Grid" 
            PagerStyle-CssClass="pgr" RowStyle-CssClass="alt"
             AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
            DataKeyNames="cat_id">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Maximum Player" HeaderText="Maximum Player" 
                    SortExpression="Maximum Player" />
                <asp:BoundField DataField="Maximum  Bot" HeaderText="Maximum  Bot" 
                    SortExpression="Maximum  Bet" />
                <asp:BoundField DataField="Minimum Bet" HeaderText="Minimum Bet" 
                    SortExpression="Minimum Bet" />
                <asp:BoundField DataField="cat_id" HeaderText="cat_id" InsertVisible="False" 
                    ReadOnly="True" SortExpression="cat_id" />
            </Columns>
            <PagerStyle CssClass="pgr" />
            <RowStyle CssClass="alt" />
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            
            SelectCommand="SELECT cat_name AS Name, max_player AS [Maximum Player], bot AS [Maximum  Bot], bet AS [Minimum Bet], cat_id FROM tbl_cat">
        </asp:SqlDataSource>
        
    </div>
    
     
    <div id="grid2">
    
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
    <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanging="OnRowSelected" AutoGenerateColumns="False" 
            DataKeyNames="tbl_id" DataSourceID="SqlDataSource2" CssClass="Grid"
            PagerStyle-CssClass="pgr" RowStyle-CssClass="alt"
                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                CellPadding="2" ForeColor="Black" GridLines="None">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:CommandField  ShowSelectButton="True" ControlStyle-CssClass="abc" ButtonType="Link" />
            
            <asp:CommandField />
            <asp:BoundField DataField="tbl_id" HeaderText="Table ID" ReadOnly="True" 
                SortExpression="tbl_id" />
            <asp:BoundField DataField="cat_id" HeaderText="Category ID" 
                SortExpression="cat_id" />
            <asp:BoundField DataField="Players" HeaderText="Players" 
                SortExpression="Players" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
        </Triggers>
        </asp:UpdatePanel>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            
            SelectCommand="SELECT tbl_id, cat_id, no_player AS Players FROM pok_tbl WHERE (cat_id = @cat_id AND no_player<=4)">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="cat_id" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
     
    </div>
   
  
    

    <div id="right">
    <h1>How To Play</h1>
    <p id="norm">
    In-Between is not very popular at casinos, but is often played in home Poker games as a break from Poker itself. The rules below are for the home game, which is easily adaptable for casino play.
    </p>
<h2>Rank of Cards</h2>
<p id="P1">
(high) K, Q, J, 10, 9, 8, 7, 6, 5, 4, 3, 2, A.
</p>

<h2>Object of the Game</h2>
<p id="P2">
The goal is to be the player with the most chips at the end of the game.
</p>
<h2>The Ante</h2>
<p id="P3">
Chips are distributed to the players, and each players puts one chip in the center of the table to form a pool or pot.
</p>
<h2>The Draw</h2>
<p id="P4">
Any player deals one card face up, to each player in turn, and the player with the highest card deals first.
</p>
<h2>The Shuffle, Cut, and Deal</h2>
<p id="P5">
Any player may shuffle, and the dealer shuffles last. The player to the dealer's right cuts the cards. The dealer turns up two cards and places them in the middle of the table, positioning them so that there is ample room for a third card to fit in between.
</p>
<h2>The Betting</h2>
<p id="P6">
The player on the dealer's left may bet up to the entire pot or any portion of the number of chips in the pot, but he must always bet a minimum of one chip. When the player has placed a bet, the dealer turns up the top card from the pack and places it between the two cards already face up. If the card ranks between the two cards already face up, the player wins and takes back the amount of his bet plus an equivalent amount from the pot. If the third card is not between the face-up cards, or is of the same rank as either of them, the player loses his bet, and it is added to the pot. If the two face-up cards up are consecutive, the player automatically loses, and a third card need not be turned up. If the two face-up cards are the same, the player wins two chips and, again, no third card is turned up. (In some games, the player is paid three chips when this occurs.)

"Acey-Deucey" (ace, 2) is the best combination, and a player tends to bet the whole pot, if he can. This is because the only way an ace-deuce combination can lose is if the third card turned up is also an ace or a deuce.

After the first player has finished, the dealer clears away the cards and places them face down in a pile. The next player then places a bet, and the dealer repeats the same procedure until all the players, including the dealer, have had a turn.

If at any time, the pot has no more chips in it (because a player has "bet the pot" and won), each player again puts in one chip to restore the pot.

When every player has had a turn to bet, the deal passes to the player on the dealer's left, and the game continues.
</p>
    </div>
    </form>
   
</body>
</html>













