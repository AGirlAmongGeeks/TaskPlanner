$().ready(function () {
    $('.btn-delete-member').on('click', function () {
        deleteFamilyMember($(this));
    });
});

function deleteFamilyMember(btn) {
    var email = btn.attr('data-email');
    var familyId = 5;// btn.attr('data-familyId');
    url = btn.attr('data-url');
    console.log(url);
   
    $.ajax({
        url: url + "?email=" + email + '&familyId=' + familyId,
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