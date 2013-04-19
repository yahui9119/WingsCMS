$(function () {
    ShowDep('0');
    $("#btnSave").click(function () {
        var ids = "";
        $(":checkbox").each(function () {
            if (this.checked == true)
                ids += this.id + ",";
        });
        $.post("Sys/Users/RoleEdit.ashx", { jsons: ids, oid: $("#hidoid").val(), uid: $("#hiduid").val(), date: Date() }, function (data) {
            if (data != "") {
                eval(data);
            }
        });
    });
});
function ChangeRoleStatus(CategoryID) {
    var li_father = document.getElementById("li_r_" + CategoryID);
    if (li_father.className == "Closed") {
        li_father.className = "Opened";
    }
    else {
        li_father.className = "Closed";
    }
}
function ShowDep(categoryID) {
    $.post("Sys/Users/RoleEdit.ashx", { id: categoryID, oid: $("#hidoid").val(), uid: $("#hiduid").val(), date: Date() }, function (data) {
        if (data != "") {
            $("#RoleTree").empty();
            $("#RoleTree").append(data);
        }
    });
}