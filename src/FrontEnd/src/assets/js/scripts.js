$(function() {
    $('.timepicker').timepicker({
        showInputs: false
    });

    $('#teste').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
});