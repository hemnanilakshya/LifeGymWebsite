<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Treport.aspx.cs" Inherits="LifeGymWebsite.WebForm21" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:GridView ID="GridView1" runat="server" Width="800px" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile" />
            <asp:BoundField DataField="ptcost" HeaderText="ptcost" SortExpression="ptcost" />
        </Columns>
</asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lifeConnectionString9 %>" SelectCommand="SELECT [Id], [Name], [Email], [Gender], [Address], [Mobile], [ptcost] FROM [trainer]"></asp:SqlDataSource>

    <br />
    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Export to PDF" />

</asp:Content>
