var input;
var iti;
function intilizePhone() {
    input = document.querySelector("#phone");
    window.intlTelInput(input, {
        // any initialisation options go here
    });
    iti = intlTelInput(input);
    window.onbeforeunload= () => {
        DisposePhone();
    };
}

function getPhoneNumer() {
    return iti.getNumber(intlTelInputUtils.numberFormat.E164);
}

function setPhoneNumber(number) {
    iti.setNumber(number);
}

function isValid() {
    console.log(iti.getNumberType() === intlTelInputUtils.numberType.MOBILE && iti.isValidNumber());
    return (iti.getNumberType() === intlTelInputUtils.numberType.MOBILE && iti.isValidNumber())
}
function DisposePhone() {
    iti.destroy();
}