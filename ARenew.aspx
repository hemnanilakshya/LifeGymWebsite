<%@ Page Title="" Language="C#" MasterPageFile="~/Member.Master" AutoEventWireup="true" CodeBehind="ARenew.aspx.cs" Inherits="LifeGymWebsite.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="custom-container-white">
            <div class="form--container--white">
                <div class="form--heading">Trainer Details</div>

                <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>

                <div class="form-row-4">
                    <div class="form-group">
                        <label>Select Package</label>
                        <asp:DropDownList ID="ddlpackage" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlpackage_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label>Duration</label>
                        <asp:TextBox ID="txtduration" Enabled="false" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Select Trainer</label>
                        <asp:DropDownList ID="ddltrainer" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddltrainer_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label>Total Cost</label>
                        <asp:TextBox ID="txttotal" onkeypress="return isNumberKey(event)" runat="server" MaxLength="50">
                        </asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>E-mail</label>
                        <asp:TextBox ID="txtemail" runat="server" Enabled="false" MaxLength="50">
                        </asp:TextBox>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ErrorMessage="Enter email-id" ControlToValidate="txtemail" Display="None">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ErrorMessage="Enter correct email-id" ControlToValidate="txtemail" Display="None"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                            </asp:RegularExpressionValidator>
                        </p>
                    </div>

                </div>

                <div class="form-btn-group">

                    <asp:ImageButton ID="btnSave" runat="server" Height="80px" ImageUrl="~/images/save pro.png"
                        Width="80px" onclick="btnSave_Click" />
                </div>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />

            </div>

        </div>


    </asp:Content>
