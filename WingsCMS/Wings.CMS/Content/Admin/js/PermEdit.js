
$(function () {
    ShowTree('0');
    $("#btnSave").click(function () {
        var ids = "[";
        var count = 8;
        var arr = document.getElementsByName("modules");
        if (arr != null && arr.length > 0) {
            for (var i = 0; i < arr.length; i++) {
                count = 8;
                if (arr[i].checked) {
                    if (document.getElementById("sub_" + arr[i].id + "_1").checked)
                        count += 1;
                    if (document.getElementById("sub_" + arr[i].id + "_2").checked)
                        count += 2;
                    if (document.getElementById("sub_" + arr[i].id + "_4").checked)
                        count += 4;
                    ids += "{ id:" + arr[i].id + ", state:" + count + "},";
                }
            }
        }
        if (ids != "[")
            ids = ids.substr(0, ids.length - 1) + "]";
        else
            ids += "]";
        $.post("Sys/Perm/PermEdit.ashx", { jsons: ids, type: $("#perm_hidtype").val(), id: $("#perm_hidid").val(), uid: $("#perm_hiduid").val(), date: Date() }, function (data) {
            if (data != "0" && data != "2") {
                eval(data);
            }
            else
                alert(data);
        });
    });
});

function ShowTree(categoryID) {
    $.post("Sys/Perm/PermEdit.ashx", { type: $("#perm_hidtype").val(), id: $("#perm_hidid").val(), date: Date() }, function (data) {
        if (data != "") {
            $("#permTree").empty();
            $("#permTree").append(data);
        }
    });
}

function ChangeRoleStatus(CategoryID) {
    var li_father = document.getElementById("li_r_" + CategoryID);
    if (li_father.className == "Closed") {
        li_father.className = "Opened";
    }
    else {
        li_father.className = "Closed";
    }
}

function checkChange(treeid) {

}

function changeTop(obj) {
    debugger
    var parnode = obj.parent().parent().parent().children("input:checkbox");
    if (parnode.length != 0) {
        if (parnode[0].checked == false) {
            parnode[0].checked = true;
            changeTop(parnode);
        }
    }
}

function changeDown(obj, f1, f2) {
    debugger
    var nodesub = obj.parent().children("ul").children("li");
    if (nodesub.length != 0) {
        nodesub.each(function () {
            if (this.children[1].checked == f1) {
                this.children[1].checked = f2;
                changeDown(this, f1, f2);
            }
        });
    }
}