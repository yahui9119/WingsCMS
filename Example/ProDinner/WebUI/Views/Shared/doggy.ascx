<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="doggy">
</div>
<div id="tip">
    <div id="tipcontent">
    hi, click on the message to show more tips; click on me to hide
    </div>
</div>
<%
    var c = ViewContext.RouteData.Values["Controller"].ToString().ToLower();
    var a = ViewContext.RouteData.Values["Action"].ToString().ToLower();
%>
<script type="text/javascript">
    $(function () {
        var x = Math.random() * 8000;
        if (getCookie("showdoggy") != "false") {
            setTimeout("showTip()", x + 5000);
        }
        setTimeout("doSomething()", x);

        $('#doggy').draggable({
            drag: function () {
                var dl = parseFloat($('#doggy').css('left'));
                var dt = parseFloat($('#doggy').css('top'));
                $('#tip').css('left', (dl - 130) + "px").css('top', (dt - 100) + 'px');
            }
        });
        $('#tip').click(showTip);
        $('#doggy').click(function () {
            if (!$('#tip').is(':visible')) {
                setCookie("showdoggy", true, 10);
                $('#tip').fadeIn();
            }
            else {
                setCookie("showdoggy", false, 10);
                $('#tip').fadeOut();
            }
        });
    });
    function doSomething() {
        if($('#tip').is(':visible')) showTip();
        setTimeout('doSomething()', Math.random() * 25000 + 5000);
    }
    function showTip() {
        $.post('<%=Url.Action("tell","doggy") %>',
        { c: '<%=c %>', a: '<%=a %>' },
        function (d) {
            $('#tipcontent').html(d.o);
            $('#tip').show();            
        });
    }
</script>

