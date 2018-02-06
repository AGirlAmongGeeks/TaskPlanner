$().ready(function () {
    $('.btn-delete-member').on('click', function () {
        deleteFamilyMember();
    });
});

function deleteFamilyMember() {
    var email = $(this).attr('data-email');
    url = $(this).attr('data-url');
   
    $.ajax({
        url: url,
        type: "POST",
        success: function (data) {
            if (data.Result) {
                alert(data.Message);
                //TODO reload partial view!!!
            }
            else {
                alert(data.Message);
            }
        }
    });
}