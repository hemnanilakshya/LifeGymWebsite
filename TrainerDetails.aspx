﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TrainerDetails.aspx.cs" Inherits="LifeGymWebsite.WebForm5" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="custom-container-white">
            <div class="form--container--white">
                <div class="form--heading">Trainer Details</div>

                <asp:Label ID="lblid" runat="server" Text=""></asp:Label>

                <div class="form-row-4">
                    <div class="form-group">
                        <label>Name</label>
                        <asp:TextBox ID="txtname" onkeypress="return isCharKey(event)" placeholder="Trainer Name"
                            runat="server" MaxLength="50">
                        </asp:TextBox>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtname" Display="None" ErrorMessage="Enter your name">
                            </asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="txtname" Display="None" ErrorMessage="Enter your name">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="txtname" ErrorMessage=" Enter only alphabets."
                                ValidationExpression="^[A-Za-z ]+$"></asp:RegularExpressionValidator>
                        </p>
                    </div>


                    <div class="form-group">
                        <label>Gender</label>
                        <asp:DropDownList ID="DropDownListdept" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label>Email Id</label>
                        <asp:TextBox ID="txtemail" runat="server" placeholder="Trainer Email"
                            ontextchanged="txtemail_TextChanged" MaxLength="50"></asp:TextBox>
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

                    <div class="form-group">
                        <label>Mobile</label>
                        <asp:TextBox ID="txtMobile" onkeypress="return isNumberKey(event)" runat="server"
                            placeholder="Trainer Mobile" MaxLength="10"></asp:TextBox>
                        <p>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                ControlToValidate="txtMobile" ErrorMessage="Mobile No. can only consist of numberss"
                                ValidationExpression="^[0-9]{10}$" Display="None"></asp:RegularExpressionValidator>
                        </p>

                    </div>

                    <div class="form-group">
                        <label>Full Address</label>
                        <asp:TextBox ID="txtadd" TextMode="MultiLine" runat="server" placeholder="Trainer Address"
                            MaxLength="500"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>City</label>
                        <asp:TextBox placeholder="Trainer City" ID="txtcity" onkeypress="return isCharKey(event)"
                            runat="server" MaxLength="50">
                        </asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>State</label>
                        <asp:TextBox placeholder="Trainer State" ID="txtState" runat="server"
                            onkeypress="return isCharKey(event)" MaxLength="50">
                        </asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Landmark</label>
                        <asp:TextBox placeholder="Trainer Landmark" ID="txtLandmark" runat="server" MaxLength="50">
                        </asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>PT Cost</label>
                        <asp:TextBox placeholder="Trainer PT Cost" ID="txtpt" onkeypress="return isNumberKey(event)"
                            runat="server" MaxLength="50">
                        </asp:TextBox>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                ErrorMessage="Enter PT Cost" ControlToValidate="txtpt" Display="None">
                            </asp:RequiredFieldValidator>

                        </p>
                    </div>

                    <div class="form-group">
                        <label>Picture</label>
                        <div>
                            <asp:Image ID="Image1" runat="server" Height="129px" ImageUrl="~/images/nopic.jpg"
                                Width="161px" />
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                ControlToValidate="FileUpload1" Display="None" ErrorMessage="Enter a Profile Picture.">
                            </asp:RequiredFieldValidator>
                        </p>
                    </div>

                </div>

                <div class="form-btn-group">
                    <asp:ImageButton ID="btnNew" runat="server" Height="70px" ImageUrl="~/images/new pro.png"
                        onclick="btnNew_Click" Width="70px" CausesValidation="False" />
                    <asp:ImageButton ID="btnModify" runat="server" Height="70px" ImageUrl="~/images/modify pro.png"
                        Width="70px" onclick="btnModify_Click" CausesValidation="False" />
                    <asp:ImageButton ID="btnSave" runat="server" Height="70px" ImageUrl="~/images/save pro.png"
                        Width="70px" onclick="btnSave_Click" />
                    <asp:ImageButton ID="btnRemove" runat="server" Height="70px" ImageUrl="~/images/remove pro.png"
                        Width="70px" onclick="btnRemove_Click" CausesValidation="False" />
                    <asp:ImageButton ID="btnCancel" runat="server" Height="70px" ImageUrl="~/images/cancel pro.png"
                        onclick="btnCancel_Click" Width="70px" CausesValidation="False" />
                </div>


            </div>

            <div class="table--container">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="686px"
                    onselectedindexchanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#CC9966"
                    BorderStyle="None" BorderWidth="1px">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
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
