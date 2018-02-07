$().ready(function () {
    $('.btn-delete-member').on('click', function () {
        deleteFamilyMember($(this));
    });
});

function deleteFamilyMember(btn) {
    var email = btn.attr('data-email');
    var familyId = btn.attr('data-familyid');
    url = btn.attr('data-url');
    console.log(url);
   
    $.ajax({
        url: url + "?email=" + email + '&familyId=' + familyId,
        type: "POST",
        success: function (data) {
            if (data.Message) {
                //A msg is returned - something went wrong.
                alert(data.Message);
            }
            else {
                $('.js-members-list').html(data);
            }
        }
    });
}