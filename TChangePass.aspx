<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer.Master" AutoEventWireup="true" CodeBehind="TChangePass.aspx.cs" Inherits="LifeGymWebsite.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <link rel="stylesheet" href="./assets/css/forms.css" />

                <div class="custom-container-white">
                        <div class="form--container--white">
                                <div class="form--heading">Change Trainer Password</div>

                                <div class="form-group">
                                        <label>Old Password</label>
                                        <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password" MaxLength="50"
                                                placeholder="Old Password"></asp:TextBox>
                                        <p>
                                                <asp:RequiredFieldValidator ID="RfvOldPass" runat="server"
                                                        ControlToValidate="txtOldPass" Display="Dynamic"
                                                        ErrorMessage="Enter your old password.">
                                                </asp:RequiredFieldValidator>
                                        </p>

                                </div>

                                <div class="form-group">
                                        <label>New Password</label>
                                        <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" MaxLength="50">
                                        </asp:TextBox>
                                        <p>
                                                <asp:RequiredFieldValidator ID="RfvNewPass" runat="server"
                                                        ControlToValidate="txtNewPass" Display="Dynamic"
                                                        ErrorMessage="Enter your new password.">
                                                </asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="CVPass" runat="server"
                                                        ClientValidationFunction="CVPass_ServerValidate"
                                                        ControlToValidate="txtNewPass" Display="None"
                                                        ErrorMessage="Password must be of 6 characters."
                                                        onservervalidate="CVPass_ServerValidate"></asp:CustomValidator>
                                        </p>

                                </div>
                                <div class="form-group">
                                        <label>Retype Password</label>
                                        <asp:TextBox ID="txtRetypePass" runat="server" TextMode="Password"
                                                MaxLength="50"></asp:TextBox>
                                        <p>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server"
                                                        ControlToCompare="txtNewPass" ControlToValidate="txtRetypePass"
                                                        Display="Dynamic" ErrorMessage="Password does not match.">
                                                </asp:CompareValidator>
                                        </p>

                                </div>

                                <div>
                                        <asp:ImageButton ID="ImgChangePass" runat="server" Height="55px" Width="125px"
                                                ImageAlign="Middle" ImageUrl="~/images/Submit.png"
                                                onclick="ImgChangePass_Click" />
                                </div>

                                <p>
                                        <asp:Label ID="lblPassword" runat="server" ForeColor="#33CC33"
                                                Text="Password Changed Successfully" Visible="False" Font-Bold="True">
                                        </asp:Label>
                                        <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
                                </p>

                        </div>
                </div>
        </asp:Content>