

function TextBoxChange(textId) {
    $(document).ready(function () {
        var a = new ControlInitializer();
        //Modify by  on 7-Nov-2014  Bug #973
        var valueInvalid = a.ZeroNotAllowed;
        //var txtvalue = $("#" + textId).val();
        var txtvalue = parseFloat($("#" + textId).val()); //read the textbox value
        txtvalue = txtvalue.toFixed(2);

        if (txtvalue <= "0.00") {
            alert(valueInvalid);
            $("#" + textId).Value = '';
            $("#" + textId).focus();
            return false;
        }
        return true;
    });
}



