﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="HomepageEditFacility.aspx.cs" Inherits="login.Admin.HomepageEditFacility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="AdminStyle.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Sofia" />
   <link rel="stylesheet" href="https://maxst.icons8.com/vue-static/landings/line-awesome/font-awesome-line-awesome/css/all.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person" viewBox="0 0 16 16">
  <path d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10z"/>
</svg>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"></script>

    <style>
        .crud:not(:last-child){
            margin-right: 10px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="main-content">
        <header>
            <h1>
                <asp:Label ID="Label2" runat="server" Text="Label">
                    <span class="fa-lastfm la-bars"></span>
                </asp:Label>
                Dashboard
           </h1>

            <div class="search-wrapper">
                <span class="las la-search"></span>
                <input type="search" placeholder="search here" />
            </div>
            <div class="user-wrapper">
                <img src="../Images/UON.png" width="30px" height="30px" alt="" />
                <div>
                    <h4>School Admin</h4>
                    <small>Admin</small>
                </div>
            </div>

        </header>
          </div>

    <br />
<div class="container"  style="margin-left: 345px">

    <div class="form-horizontal">
        <h2>Edit Homepage</h2>
        <hr />

        <div class="form-group">
            <asp:Label ID="lblFirstFacilityName" runat="server"  CssClass="col-md-2 control-label" Text="First Facility Name"></asp:Label>
       <div class="col-md-3"> 
           <asp:TextBox ID="txtFirstFacilityName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
            </div>
      
            <br /><br />

            <div class="form-group">
            <asp:Label ID="lblFirstFacilityDesc" runat="server"  CssClass="col-md-2 control-label" Text="First Facility Desc"></asp:Label>
       <div class="col-md-3">
           <asp:TextBox ID="txtFirstFacilityDesc" runat="server" CssClass="form-control"></asp:TextBox>
       </div>
                </div>
      
            <br /><br />

        <div class="form-group">
            <asp:Label ID="lblFirstFacilityImage" runat="server"  CssClass="col-md-2 control-label" Text="First Facility Image"></asp:Label>
       <div class="col-md-3">
            <asp:FileUpload ID="FuFirstFacilityImg01" CssClass="form-control" runat="server" />
       </div>
        </div>
            <br /><br />

         <div class="form-group">
            <asp:Label ID="lblSecondFacilityName" runat="server"  CssClass="col-md-2 control-label" Text="Second Faccility Name"></asp:Label>
       <div class="col-md-3"> 
           <asp:TextBox ID="txtSecondFacility" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
            </div>
      
            <br /><br />

            <div class="form-group">
            <asp:Label ID="lblSecondFacility" runat="server"  CssClass="col-md-2 control-label" Text="Second Facility Desc"></asp:Label>
       <div class="col-md-3">
           <asp:TextBox ID="txtSecondFaccility" runat="server" CssClass="form-control"></asp:TextBox>
       </div>
                </div>
      
            <br /><br />

        <div class="form-group">
            <asp:Label ID="lblSecondFacilityImage" runat="server"  CssClass="col-md-2 control-label" Text="Second Facility Image"></asp:Label>
       <div class="col-md-3">
            <asp:FileUpload ID="FuImgSecondFacility" CssClass="form-control" runat="server" />
       </div>
        </div>
            <br /><br />

         <div class="form-group">
            <asp:Label ID="lblThirdFacilityName" runat="server"  CssClass="col-md-2 control-label" Text="Third Facility Name"></asp:Label>
       <div class="col-md-3"> 
           <asp:TextBox ID="txtThirdFacilityName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
            </div>
      
            <br /><br />

            <div class="form-group">
            <asp:Label ID="lblThirdFacilityDesc" runat="server"  CssClass="col-md-2 control-label" Text="Third Facility Desc"></asp:Label>
       <div class="col-md-3">
           <asp:TextBox ID="txtCourseThreeDesc" runat="server" CssClass="form-control"></asp:TextBox>
       </div>
                </div>
      
            <br /><br />

        <div class="form-group">
            <asp:Label ID="ThirdFacilityImage" runat="server"  CssClass="col-md-2 control-label" Text="Third Facility Image"></asp:Label>
       <div class="col-md-3">
            <asp:FileUpload ID="FuImageThirdFacility" CssClass="form-control" runat="server" />
       </div>
        </div>
            <br /><br />

            <div id="crud">
                <asp:Button ID="btnCreate" runat="server" Text="Create" CssClass="btn btn-success" />
                <asp:Button ID="btnRun" runat="server" Text="Run" CssClass="btn btn-info" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-warning" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" />
            </div>
            <br /><br />
        <div class="gridview">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
               
</div>
    </div> 


</asp:Content>