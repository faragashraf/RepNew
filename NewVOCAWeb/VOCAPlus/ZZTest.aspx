<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ZZTest.aspx.vb" Inherits="VOCAPlus.ZZTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<<head runat="server">
    <title></title>
    <style>
        body {
            margin: 0;
        }

        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: #333;
            position: fixed;
            top: 0;
            width: 100%;
        }

        li {
            float: left;
        }

            li a {
                display: block;
                color: white;
                padding: 16px;
                text-decoration: none;
            }

        .main {
            padding: 16px;
            margin-top: 30px;
            height: 1500px; /* Used in this example to enable scrolling */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a >Home</a></li>
                <li><a href="#news">News</a></li>
                <li><a href="#contact">Contact</a></li>
            </ul>

            <div class="main">
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
            </div>
        </div>
    </form>
</body>
</html>
