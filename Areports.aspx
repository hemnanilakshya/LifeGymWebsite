<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Areports.aspx.cs" Inherits="LifeGymWebsite.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <style>
            .main--container {
                width: 100%;
                height: 100vh;
                display: flex;
                justify-content: center;
                align-items: center;
            }

            .btn {
                padding: 12px 28px;
                background-color: #f36100;
                color: white;
                border: none;
            }

            .btn:nth-child(1) {
                margin-right: 24px;
            }
        </style>

        <div class="main--container">
            <asp:Button ID="Button1" runat="server" Text="TRAINERS" OnClick="Button1_Click" CssClass="btn" />
            <asp:Button ID="Button2" runat="server" Text="MEMBERS" OnClick="Button2_Click" CssClass="btn" />
        </div>











    </asp:Content>
