﻿function isNumber(evt) {
    var iKeyCode = (evt.which) ? evt.which : evt.keyCode
    if (iKeyCode < 48 || iKeyCode > 57)
        return false;

    return true;
}