$(function () {
    ShowDep('0');
    $("#btnSave").click(function () {
        var ids = "";
        $(":checkbox").each(function () {
            if (this.checked == true)
                ids += this.id + ",";
        });
        $.post("Sys/Users/EditUserOrgan.ashx", { jsons: ids, type: "2", uid: $("#dep_hiduid").val(), date: Date() }, function (data) {
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
    $.post("Sys/Users/EditUserOrgan.ashx", { type: "1", uid: $("#dep_hiduid").val(), date: Date() }, function (data) {
        if (data != "") {
            $("#DepTree").empty();
            $("#DepTree").append(data);
        }
    });
}