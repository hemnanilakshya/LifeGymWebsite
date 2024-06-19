<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer.Master" AutoEventWireup="true" CodeBehind="CreateDietChart.aspx.cs" Inherits="LifeGymWebsite.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="custom-container-white">
            <div class="form--container--white">
                <div class="form--heading">Diet Chart</div>
                <div class="form-row-4">
                    <div class="form-group">
                        <label>Select Member</label>
                        <asp:DropDownList ID="ddlmember" runat="server"></asp:DropDownList>

                    </div>

                    <div class="form-group">
                        <label>Select Month</label>
                        <asp:DropDownList ID="ddlmonth" runat="server"
                            OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem>January</asp:ListItem>
                            <asp:ListItem>February</asp:ListItem>
                            <asp:ListItem>March</asp:ListItem>
                            <asp:ListItem>April</asp:ListItem>
                            <asp:ListItem>May</asp:ListItem>
                            <asp:ListItem>June</asp:ListItem>
                            <asp:ListItem>July</asp:ListItem>
                            <asp:ListItem>August</asp:ListItem>
                            <asp:ListItem>September</asp:ListItem>
                            <asp:ListItem>October</asp:ListItem>
                            <asp:ListItem>November</asp:ListItem>
                            <asp:ListItem>December</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label>Select Year</label>
                        <asp:DropDownList ID="ddlyear" runat="server">
                            
                            <asp:ListItem>2024</asp:ListItem>
                            <asp:ListItem>2025</asp:ListItem>
                            <asp:ListItem>2026</asp:ListItem>
                            <asp:ListItem>2027</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label>Monday</label>
                        <asp:TextBox ID="txtmonday" runat="server" MaxLength="50" >
                        </asp:TextBox>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="txtmonday" Display="None" ErrorMessage="Enter Monday Desc">
                            </asp:RequiredFieldValidator>
                        </p>
                    </div>
                    <div class="form-group">
                        <label>Tuesday</label>
                        <asp:TextBox ID="txttue" runat="server" MaxLength="50" >
                        </asp:TextBox>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txttue" Display="None" ErrorMessage="Enter Tuesday Desc">
                            </asp:RequiredFieldValidator>

                        </p>
                    </div>
                    <div class="form-group">
                        <label>Wednesday</label>
                        <asp:TextBox ID="txtwed" runat="server" MaxLength="50"></asp:TextBox>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtwed" Display="None" ErrorMessage="Enter Wed Desc">
                            </asp:RequiredFieldValidator>

                        </p>
                    </div>
                    <div class="form-group">
                        <label>Thursday</label>
                        <asp:TextBox ID="txtthu" runat="server" MaxLength="50" >
                        </asp:TextBox>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="txtthu" Display="None" ErrorMessage="Enter Thursday Desc">
                            </asp:RequiredFieldValidator>

                        </p>
                    </div>
                    <div class="form-group">
                        <label>Friday</label>
                        <asp:TextBox ID="txtfri" runat="server" MaxLength="50" >
                        </asp:TextBox>

                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txtfri" Display="None" ErrorMessage="Enter Friday Desc">
                            </asp:RequiredFieldValidator>

                        </p>
                    </div>
                    <div class="form-group">
                        <label>Saturday</label>
                        <asp:TextBox ID="txtsat" runat="server" MaxLength="50">
                        </asp:TextBox>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="txtsat" Display="None" ErrorMessage="Enter Sat Desc">
                            </asp:RequiredFieldValidator>

                        </p>
                    </div>
                    <div class="form-group">
                        <label>Sunday</label>
                        <asp:TextBox ID="txtsun" runat="server" MaxLength="50" >
                        </asp:TextBox>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="txtsun" Display="None" ErrorMessage="Enter Sunday Desc">
                            </asp:RequiredFieldValidator>

                        </p>
                    </div>


                </div>

                <div>
                    <asp:ImageButton ID="btnSave" runat="server" Height="80px" ImageUrl="~/images/save pro.png"
                        Width="80px" onclick="btnSave_Click" />
                </div>

            </div>

        </div>

    </asp:Content>