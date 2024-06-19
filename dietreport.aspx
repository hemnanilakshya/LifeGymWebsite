<%@ Page Title="" Language="C#" MasterPageFile="~/Member.Master" AutoEventWireup="true" CodeBehind="dietreport.aspx.cs" Inherits="LifeGymWebsite.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function onlyprint() {
            var prtGrid = document.getElementById('<%=GridView1.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>

    <br /><br />
select month:
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="month" DataValueField="month">
    </asp:DropDownList><br /><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Width="800" >
        <Columns>
            <asp:BoundField DataField="mon" HeaderText="mon" SortExpression="mon" />
            <asp:BoundField DataField="tue" HeaderText="tue" SortExpression="tue" />
            <asp:BoundField DataField="wed" HeaderText="wed" SortExpression="wed" />
            <asp:BoundField DataField="thur" HeaderText="thur" SortExpression="thur" />
            <asp:BoundField DataField="fri" HeaderText="fri" SortExpression="fri" />
            <asp:BoundField DataField="sat" HeaderText="sat" SortExpression="sat" />
            <asp:BoundField DataField="sun" HeaderText="sun" SortExpression="sun" />
           
           
           
            <asp:BoundField DataField="temailid" HeaderText="temailid" SortExpression="temailid" />
        </Columns>
    </asp:GridView>
    &nbsp;&nbsp;&nbsp
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lifeConnectionString8 %>" SelectCommand="SELECT [month] FROM [dietchart] WHERE ([emailid] = @emailid)">
        <SelectParameters>
            <asp:SessionParameter Name="emailid" SessionField="loginid" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:lifeConnectionString7 %>" SelectCommand="SELECT * FROM [dietchart] WHERE ([month] = @month) and  ([emailid] = @emailid)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="month" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <SelectParameters>
            <asp:SessionParameter Name="emailid" SessionField="loginid" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>


    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Export PDF" CssClass="btn" />


    <br />
   


</asp:Content>