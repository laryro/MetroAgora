 var activePage, totalPages;

$(document).ready(function () {

    activePage = $(".pagination .active").data("position");
    totalPages = $(".pagination .pagnav").size();

    hideAllPages();
    showPages([1,2,3,4,5,6,7]);


    $(".paged-items .pagnav").click(function () {

        var item = $(this);

        if (item.hasClass("active"))
            return false;

        var parent = item.closest(".paged-items");

        var url = item.find("a").attr("href");
        var position = item.data("position");

        $.post(url, function(result) {
            parent.find(".list").hide().html(result).fadeIn();

            parent.find(".pagnav").removeClass("active");
            parent.find(".pagnav.pag" + position).addClass("active");
        });

        activePage = position;

        hideAllPages(parent);

        if (activePage >= 4 && activePage < totalPages-3) {
            showPages([activePage-3, activePage-2, activePage-1, activePage, activePage+1, activePage+2, activePage+3], parent);
        }
        else if (activePage < 4) {
            showPages([1,2,3,4,6,5,7], parent);
        } else if (activePage >= totalPages-3) {
            showPages([totalPages-6, totalPages-5, totalPages-4, totalPages-3, totalPages-2, totalPages-1, totalPages], parent);

        }

        return false;

    });

});

var hideAllPages = function(parent) {
    if (parent != null && parent != undefined)
        $(parent).find(".pagination .pagnav").hide();
    else
        $(".pagination .pagnav").hide();
}


var showPages = function(pages, parent) {
    $.each(pages, function(index, value) {
        if (parent != null && parent != undefined)
            $(parent).find(".pagnav.pag"+value).show();
        else
            $(".pagnav.pag"+value).show();
    });
};