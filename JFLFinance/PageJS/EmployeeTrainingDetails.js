


$(document).ready(function() {
//    DeactivatePopup(Object);

});

function ShowModalPopup(obj) {
    var a = new ControlInitializer();
    $(a.divPopInactive).show();
}

function DeactivatePopup(obj) {
    var a = new ControlInitializer();
    var curStatus = $('#' + obj.id).val();
    if (curStatus == "0") {
        if (!confirm(a.DeactivatePopupMsg)) {
            $('#' + obj.id).val("1");
            $(a.txtValidTillDate).value = "";
            return;
        }
        else {
            ShowModalPopup(obj);
        }
    }
    else {


        //Simulate autopostback, this triggers SelectedIndexChanged
        __doPostBack(obj.id, '');

    }
}

        function ClickButtonOK(id) {
            __doPostBack($(id).attr('name'), "OnClick");
        }

        function CancelClickEvent(obj) {
            var curStatus = $('#' + obj.id).val();
            if (curStatus == "0") {
                $('#' + obj.id).val("1");
            }
            

        }


       
        