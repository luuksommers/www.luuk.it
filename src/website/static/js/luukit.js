$(function () {
    $("#more").click(function(){
        if($("#connect-more-list").is(':visible')) {
        	$("#connect-more-list").hide();
        } else {
        	$("#connect-more-list").show();
        }
    });
    
    $("#imagescroll img").mouseover(function () {
        var text = $(this).data("text");
        $("#imagedescription").html(text);
    });
});