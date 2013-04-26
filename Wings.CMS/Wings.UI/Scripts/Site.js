// o.Type is being set in Crudere.cs to the entity's type name (lower case)

//removes the item from the html
function del(o) {
    $('#' + o.Type + o.Id).fadeOut(300, function () { $(this).remove(); });
    if (o.Type == "dinner") refreshDinnersGrid();
}

//update the item in html
function edit(o) {
    $('#' + o.Type + o.Id).fadeOut(300, function () {
        $(this).after($.trim(o.Content)).remove();
        if (o.Type == "meal") adjustMeals();
    });
    
    if (o.Type == "dinner") refreshDinnersGrid();
}

//append the html for the created country
function createCountry(o) {
    $('#Countries').prepend(o.Content);
    $('#Countries .awe-li:first').hide().fadeIn();
}

//append the html for the created meal
function createMeal(o) {
    $('#Meals').parent().find('ul').prepend($.trim(o.Content));
}

//append the html for the created country (inside the lookup popup)
function lookupCreateCountry(o) {
    $('#CountryId-awepw .awe-srl').prepend(o.Content);
    $('#CountryId-awepw .awe-srl .awe-li:first').hide().fadeIn();
}

function createDinner(o) {
    $('#Dinners').prepend(o.Content);
    $('#Dinners li:first').hide().fadeIn();
}

function passchanged(o) {
    $("<div> password for " + o.Login + " was successfuly changed </div>").dialog();
}

function createUser(o) {
    $('#Users').parent().find('tbody').prepend(o.Content);
}

function refreshChefGrid() {
    $('#ChefGrid').data('api').load();
}

function refreshDinnersGrid() {
    if ($('#DinnersGrid').length) {
        $('#DinnersGrid').data('api').load();
    }
}

function loadDinnersGrid(r) {
    $('#gridContainer').html(r);
    $('.showGrid').hide();
}

// used for the grid to generate the delete button, will show a restore button if the item is deleted
function dinnersDelFormat(o) {
    var format = "<form class='" + (o.IsDeleted ? "DinnerRestore" : "DinnerConfirm") + "' method='post'>"
        + "<input type='hidden' name='Id' value='" + o.Id + "'/>"
        + "<button type='submit' class='awe-btn'>";
    
    if (o.IsDeleted) {
        format += "re";
    } else {
        format += "<span class='ico-del'></span>";
    }

    format += "</button>";
    format += "</form>";
    return format;
}

// adjusts the layout of the meal items
function adjustMeals() {
    if ($.support.cors)
        $(".notcool").hide();
    else
        $(".cool").hide();

    var w = $('#main').width();
    var space = w % 492;
    var cat = (w - space) / 492;
    var u = (space / cat);
    var nw = 448 + u;
    $('.meal').width(nw);
    $('.comments').css('width', $('.comments:first').parent().width() - $('.comments:first').prev().width() - 20);
}

$(function () {

    $("input:text:visible:first").focus();
    
    //bind the window min-height to window size
    $(window).bind("resize", function (e) { $("#main-container").css("min-height", ($(window).height() - 120) + "px"); });
    
    $("#main-container").css("min-height", ($(window).height() - 120) + "px").addClass("ui-widget-content");

    //fix for IE to trigger change on enter
    if (!$.support.cors) {
        $("input[type=text]")
            .on("change", function (e) {
                $.data(this, "value", this.value);
            })
            .on("keydown", function (e) {
                if (e.which === 13)
                    e.preventDefault();
            })
            .on("keyup", function (e) {
                e.preventDefault();
                if (e.which === 13 && this.value != $.data(this, "value")) {
                    $(this).change();
                }
            });
    }
});

function CKupdate() {
    for (instance in CKEDITOR.instances)
        CKEDITOR.instances[instance].updateElement();
    return true;
}

//http://www.w3schools.com/JS/js_cookies.asp
function setCookie(c_name, value, exdays) {
    var exdate = new Date();
    exdate.setDate(exdate.getDate() + exdays);
    var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
    document.cookie = c_name + "=" + c_value;
}

function getCookie(c_name) {
    var i, x, y, ARRcookies = document.cookie.split(";");
    for (i = 0; i < ARRcookies.length; i++) {
        x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("="));
        y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1);
        x = x.replace(/^\s+|\s+$/g, "");
        if (x == c_name) {
            return unescape(y);
        }
    }
}