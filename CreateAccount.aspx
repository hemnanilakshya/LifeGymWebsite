<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="LifeGymWebsite.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="custom-container-white">
            <div class="form--container--white">
                <div class="form--heading">Create Account</div>

                <div class="form-group">
                    <label>Select Account Type</label>
                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True"
                        onselectedindexchanged="ddlType_SelectedIndexChanged">
                        <asp:ListItem>-- Select Type --</asp:ListItem>
                        <asp:ListItem>Member</asp:ListItem>
                        <asp:ListItem>Trainer</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label>Select Person Account</label>
                    <asp:DropDownList ID="ddlName" runat="server" onselectedindexchanged="ddlName_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>

                <div>
                    <asp:ImageButton ID="btnAdd" runat="server" Height="66px" ImageUrl="~/images/add-256.png"
                        Width="66px" onclick="ImageButton1_Click" />
                    <asp:ImageButton ID="btnDelete" runat="server" Height="66px" ImageUrl="~/images/icon_error-512.png"
                        Width="66px" onclick="btnDelete_Click" />
                </div>

            </div>
        </div>

    </asp:Content>
