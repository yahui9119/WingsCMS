﻿<%@ Page Language="C#" MasterPageFile="Template.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Data" runat="server">
    <%= Html.Password("", Model) %>
</asp:Content>