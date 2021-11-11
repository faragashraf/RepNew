<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ZZZTest.aspx.vb" Inherits="VOCAPlus.ZZZTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
.mynav_navbar {
            overflow: hidden;
            background-color: #333;
            font-family: Arial, Helvetica, sans-serif;
            width:100%
        }
 
        .mynav_navbar a {
                float: left;
                font-size: 16px;
                color: white;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
            }
 
        .mynav_dropdown {
            float: left;
            overflow: hidden;
        }
 
        .mynav_dropdown .mynav_dropbtn {
                font-size: 16px;
                border: none;
                outline: none;
                color: white;
                padding: 14px 16px;
                background-color: inherit;
                font-family: inherit;
                margin: 0;
            }
 
        .mynav_navbar a:hover, .mynav_dropdown:hover .mynav_dropbtn {
                background-color: red;
            }
 
        .mynav_dropdown-content {
            display: none;
            position: absolute;
            background-color: #f9f9f9;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
        }
 
        .mynav_dropdown-content a {
                float: none;
                color: black;
                padding: 12px 16px;
                text-decoration: none;
                display: block;
                text-align: left;
            }
 
        .mynav_dropdown-content a:hover {
                    background-color: #ddd;
                }
 
        .mynav_dropdown:hover .mynav_dropdown-content {
            display: block;
        }

    </style>
</head>
<body style="width:1500px">
    <form id="form1" runat="server">
        <div>
         <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <a asp-area="" asp-controller="Home" asp-action="Index" class="navbar-brand">AspNav</a>
            </div>
            <div class="mynav_navbar">
                <a asp-area="" asp-controller="Home" asp-action="Index">Home</a>
                <a href="#news">News</a>
                <div class="mynav_dropdown">
                    <button class="mynav_dropbtn">
                        ..
                        <i class="fa fa-caret-down"></i>
                    </button>
                    <div class="mynav_dropdown-content">
                        <a asp-area="" asp-controller="Home" asp-action="About">About</a>
                        <a asp-area="" asp-controller="Home" asp-action="Contact">Contact</a>
                    </div>
                </div>
            </div>
        </div>
    </nav> 

</div>
                  <div >
                <h1>Fixed Top Menu</h1>
                <h2>Scroll this page to see the effect</h2>
                <h2>The navigation bar will stay at the top of the page while scrolling</h2>

                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                                            <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                                            <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                                            <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
                <p>Some text some text some text some text..</p>
            </div>
    </form>
</body>
</html>
