<%@ Page Title="" Language="C#" MasterPageFile="~/Member.Master" AutoEventWireup="true" CodeBehind="memberProfile.aspx.cs" Inherits="LifeGymWebsite.WebForm16" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="profile--container">
            <div class="profile--wrapper">
                <div class="wrapper--heading">Welcome, <asp:Label ID=lblsid runat=server></asp:Label>
                </div>

                <div class="details--cont">
                    <div class="detail-group">
                        <label>Name</label>
                        <p>
                            <asp:Label ID="txtname" runat="server"></asp:Label>
                        </p>
                    </div>
                    <!-- Label End -->
                    <div class="detail-group">
                        <label>Email-id</label>
                        <p>
                            <asp:Label ID="txtemail" runat="server"></asp:Label>
                        </p>
                    </div>
                    <!-- Label End -->
                    <div class="detail-group">
                        <label>Full Address</label>
                        <p>
                            <asp:Label ID="lbladdress" runat="server"></asp:Label>
                        </p>
                    </div>
                    <!-- Label End -->
                    <div class="detail-group">
                        <label>City</label>
                        <p>
                            <asp:Label ID="lblcity" runat="server"></asp:Label>
                        </p>
                    </div>
                    <!-- Label End -->
                    <div class="detail-group">
                        <label>State</label>
                        <p>
                            <asp:Label ID="lblstate" runat="server"></asp:Label>
                        </p>
                    </div>
                    <!-- Label End -->
                    <div class="detail-group">
                        <label>LandMark</label>
                        <p>
                            <asp:Label ID="lblland" runat="server"></asp:Label>
                        </p>
                    </div>
                    <!-- Label End -->
                    <div class="detail-group">
                        <label>Mobile*</label>
                        <p>
                            <asp:Label ID="lblMobile" runat="server"></asp:Label>
                        </p>
                    </div>
                    <!-- Label End -->
                    <div class="detail-group">
                        <label>Picture</label>
                        <div>
                            <asp:Image ID="Image1" runat="server" Height="129px" ImageUrl="~/images/nopic.jpg"
                                Width="161px" />
                            *</div>
                    </div>
                    <!-- Label End -->
                </div>

            </div>
        </div>

    </asp:Content>