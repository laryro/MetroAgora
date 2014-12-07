$(document).ready(function () {
    masks();
});

var masks = function () {
    $(".mask-cnpj").mask("99.999.999/9999-99");
    $(".mask-cpf").mask("999.999.999-99");
    $(".mask-phone").mask("9999-9999?9");
    $(".form-datepicker").mask("99/99/9999");
};