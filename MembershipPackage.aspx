<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="MembershipPackage.aspx.cs" Inherits="LifeGymWebsite.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="custom-container-white">
            <div class="form--container--white">
                <div class="form--heading">Membership Packages</div>
                <asp:Label ID="lblid" runat="server" Text=""></asp:Label>

                <div class="form-row-4">

                    <div class="form-group">
                        <label>Package Name</label>
                        <asp:TextBox placeholder="Package Name" ID="txtname" onkeypress="return isCharKey(event)"
                            runat="server" MaxLength="50">
                        </asp:TextBox>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtname" Display="None" ErrorMessage="Enter Package Name">
                            </asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="txtname" Display="None" ErrorMessage="Enter your name">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="txtname" ErrorMessage="Name can consist of only alphabets."
                                ValidationExpression="^[A-Za-z ]+$"></asp:RegularExpressionValidator>
                        </p>
                    </div>
                    <div class="form-group">
                        <label>Duration(In Months)</label>
                        <asp:TextBox placeholder="Duration" ID="txtMobile" onkeypress="return isNumberKey(event)"
                            runat="server" MaxLength="50"></asp:TextBox>
                        <p>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                ControlToValidate="txtMobile" ErrorMessage="Duration can only consist of numberss"
                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                        </p>
                    </div>
                    <div class="form-group">
                        <label>Cost</label>
                        <asp:TextBox placeholder="Cost" ID="txtcost" onkeypress="return isNumberKey(event)"
                            runat="server" MaxLength="50">
                        </asp:TextBox>
                        <p>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="txtcost" ErrorMessage="Cost can only consist of numberss"
                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                        </p>
                    </div>

                </div>

                <div class="form-btn-group">
                    <asp:ImageButton ID="btnNew" runat="server" Height="80px" ImageUrl="~/images/new pro.png"
                        onclick="btnNew_Click" Width="80px" CausesValidation="False" />
                    <asp:ImageButton ID="btnModify" runat="server" Height="80px" ImageUrl="~/images/modify pro.png"
                        Width="80px" onclick="btnModify_Click" CausesValidation="False" />
                    <asp:ImageButton ID="btnSave" runat="server" Height="80px" ImageUrl="~/images/save pro.png"
                        Width="80px" onclick="btnSave_Click" />
                    <asp:ImageButton ID="btnRemove" runat="server" Height="80px" ImageUrl="~/images/remove pro.png"
                        Width="80px" onclick="btnRemove_Click" CausesValidation="False" />
                    <asp:ImageButton ID="btnCancel" runat="server" Height="80px" ImageUrl="~/images/cancel pro.png"
                        onclick="btnCancel_Click" Width="80px" CausesValidation="False" />
                </div>
            </div>
            <div class="table--container">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="686px"
                    onselectedindexchanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#CC9966"
                    BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                            <ControlStyle BackColor="#0099FF" Font-Bold="True" ForeColor="White" />
                        </asp:CommandField>
                    </Columns>
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />
            </div>
        </div>


    </asp:Content>
