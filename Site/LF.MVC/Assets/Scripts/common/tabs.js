 
$(document).ready(function () {
    $("#navigation .nav li").click(function () {
        var navigation = $(this).closest("#navigation");
        var timeline = navigation.next(".timeline");

        timeline.find(".nav-item").hide();
        navigation.find(".nav li").removeClass("active");

        var rel = $(this).data("target");
        var myContent = timeline.find(".nav-item#" + rel);
        myContent.show();

        $(this).addClass("active");
    });

    var active = $("#navigation .nav li.active");

    if (!active.length)
        active = $("#navigation .nav li").last();

    active.click();
});