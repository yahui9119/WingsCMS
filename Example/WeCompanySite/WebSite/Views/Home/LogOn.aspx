﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>企业网站后台——用户登录</title>
    <link href="/Content/Logon.css" type="text/css" rel="stylesheet" />
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        function request(paras) {
            var url = location.href;
            var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
            var paraObj = {}
            for (i = 0; j = paraString[i]; i++) {
                paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
            }
            var returnValue = paraObj[paras.toLowerCase()];
            if (typeof (returnValue) == "undefined") {
                return "";
            } else {
                return returnValue;
            }
        }

        function logOn() {
            var div = $("#msg");
            var account = $("#txtAccount").val();
            var password = $("#txtPassword").val();
            var code = $("#txtCode").val();

            if (account == "" || password == "" || code == "") {
                div.html("请输入用户名，密码和验证码");
                return;
            }

            var loading = "<img alt='载入中，请稍候...' height='28' width='28' src='/Images/loading.gif' />";
            div.html(loading + "载入中，请稍候...");
            var params = { account: account, password: password, code: code };

            $.ajax({
                type: "POST",
                url: "/Home/LogOnByAndPassword/",
                data: $.param(params),
                success: function (msg) {
                    if (msg) {
                        if (msg.IsSuccess) {
                            div.html("登陆成功");
                            var href = unescape(request("ReturnUrl"));
                            if (href == "/" || href == "") {
                                href = "/Admin/";
                            }

                            window.location.href = href;
                        }
                        else {
                            div.html(msg.Message);
                        }
                    }
                    else {
                        div.html("为载入相关数据，请重试");
                    }
                }
            });
        }
    </script>
</head>
<body id="userlogin_body">
    <div>
    </div>
    <div id="user_login">
        <dl>
            <dd id="user_top">
                <ul>
                    <li class="user_top_l"></li>
                    <li class="user_top_c"></li>
                    <li class="user_top_r"></li>
                </ul>
                <dd id="user_main">
                    <ul>
                        <li class="user_main_l"></li>
                        <li class="user_main_c">
                            <div class="user_main_box">
                                <ul>
                                    <li class="user_main_text">用户名： </li>
                                    <li class="user_main_input">
                                        <input class="txtusernamecssclass" id="txtAccount" maxlength="20" name="account" />
                                    </li>
                                </ul>
                                <ul>
                                    <li class="user_main_text">密 码： </li>
                                    <li class="user_main_input">
                                        <input class="txtpasswordcssclass" id="txtPassword" type="password" name="password"/>
                                    </li>
                                </ul>
                                <ul>
                                    <li class="user_main_text">验证码:</li>
                                    <li class="user_main_input">
                                        <table style="width:180px;">
                                            <tr>
                                                <td style="text-align:center;">
                                                    <input id="txtCode" name="code" style="width:80px;" maxlength="4" />
                                                </td>
                                                <td style="text-align:center;">
                                                    <img src="/Home/ValidateCode/" style="cursor: pointer;" 
                                                    alt="点击刷新" onclick="this.src=this.src+'?';" />
                                                </td>
                                            </tr>
                                        </table>
                                    </li>
                                </ul>
                                    <br />
                                    <br />
                                 <div style="text-align:center;color:Red;line-height:30px;height:30px;" id="msg">请输入用户名和密码</div> 
                            </div>
                        </li>
                        <li class="user_main_r">
                            <input class="ibtnentercssclass" id="ibtnenter" style="border-top-width: 0px; border-left-width: 0px;
                                border-bottom-width: 0px; border-right-width: 0px" type="image" src="/Images/user_botton.gif"
                                name="ibtnenter" onclick="logOn();return;"/>
                        </li>
                    </ul>
                    <dd id="user_bottom" />
                    <ul>
                        <li class="user_bottom_l"></li>
                        <li class="user_bottom_c"><span style="margin-top: 40px">企业网站</span> </li>
                        <li class="user_bottom_r"></li>
                    </ul>
                </dd>
        </dl>
    </div>
    <span id="valrusername" style="display: none; color: red"></span><span id="valrpassword"
        style="display: none; color: red"></span><span id="valrvalidatecode" style="display: none;
            color: red"></span>
    <div id="validationsummary1" style="display: none; color: red">
    </div>
    <div>
    </div>
</body>
</html>