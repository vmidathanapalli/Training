//For preventing Navigation on Back Button Click


    window.location.hash = "no-back-button";
    window.location.hash = "Again-No-back-button";//again because google chrome don't insert first hash into history
    window.onhashchange = function () { window.location.hash = "no-back-button"; }

//Closing particular page
function cancel() {
    window.parent.document.getElementById('btnCancel').click();
}
//Checking For Characters
function CheckNum() {

    if ((event.keyCode > 64 && event.keyCode < 91) || (event.keyCode > 96 && event.keyCode < 123) || event.keyCode == 8)
        return true;
    else {
        alert("Please enter only char");
        return false;
    }
}
//Checking For Integer  values
function CheckInteger() {

    if ((event.keyCode >= 48 && event.keyCode <= 57))
        return true;
    else {
        alert("Please enter only One Integers");
        return false;
    }

}
//hide Menu
function HideControls() {
    var obj = document.getElementById("menu");
    obj.style.display = "none"; //.visibility= "hidden";
    var obj = document.getElementById("nav");
    obj.style.display = "none";
    var obj = document.getElementById("footer");
    obj.style.display = "none";
}
