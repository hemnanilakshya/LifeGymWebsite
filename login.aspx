<%@ Page Title="" Language="C#" MasterPageFile="~/FirstMaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="LifeGymWebsite.WebForm3" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <!-- Breadcrumb Section Begin -->
        <section class="breadcrumb-section set-bg" data-setbg="assets/img/breadcrumb-bg.jpg">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 text-center">
                        <div class="breadcrumb-text">
                            <h2>Login</h2>
                            <div class="bt-option">
                                <a href="./Home.aspx">Home</a>
                                <span>Login</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- Breadcrumb Section End -->

        <div class="custom-container">
            <div class="form--container">

                <div class="form--heading">Login</div>
                <div class="form-group">
                    <label>E-mail</label>
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" OnTextChanged="txtEmail_TextChanged"
                        placeholder="E-mail"></asp:TextBox>
                    *<p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtEmail" ErrorMessage="PLEASE ENTER A EMAIL-ID!!!" Display="None">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txtEmail" Display="None" ErrorMessage="PLEASE ENTER A VALID EMAIL-ID!!!"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        </asp:RegularExpressionValidator>
                    </p>
                </div>

                <div class="form-group">
                    <label>Password</label>
                    <asp:TextBox ID="txtPass" runat="server" placeholder="Enter Password" TextMode="Password"
                        MaxLength="50">
                    </asp:TextBox>
                    *<p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtPass" ErrorMessage="PLEASE ENTER PASSWORD!!!" Display="None">
                        </asp:RequiredFieldValidator>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" />
                </div>



                <asp:Button ID="btnCreate" runat="server" Text="Login" OnClick="btnCreate_Click" />


                <asp:HyperLink class="link" ID="HyperLink1" runat="server" NavigateUrl="~/ForgotPass.aspx">Forgot
                    Password?</asp:HyperLink>


            </div>
        </div>
    </asp:Content>
