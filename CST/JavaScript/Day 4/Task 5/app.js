var total = 0, prev_op = '+', prev_num = '', prev_dec = '', dot = false, last_is_num = false, hit_equal = false;

function EnterOperator(op) {
    if (hit_equal) {
        document.getElementById("ans").value = "";
        hit_equal = false;
    }

    if (last_is_num) {
        Calc();
        prev_op = op;
        prev_num = prev_dec = '';
        dot = false;
        document.getElementById("ans").value += op;
    } else if (op !== '*' && op !== '/') {
        prev_op = op;
        document.getElementById("ans").value += op;
    }

}

function EnterNumber(num) {
    if (hit_equal) {
        document.getElementById("ans").value = "";
        hit_equal = false;
    }

    last_is_num = true;

    if (dot) prev_dec += num;
    else prev_num += num;

    document.getElementById("ans").value += num;
}

function EnterClear() {
    Reset();
    document.getElementById("ans").value = "";
}

function EnterEqual() {
    Calc();
    document.getElementById("ans").value = total;
    Reset();
    hit_equal = true;
}

function Calc() {
    var whole = parseFloat(prev_num) || 0, dec = parseFloat(prev_dec) || 0;

    dec += (10 * prev_dec.length) || 0;


    switch (prev_op) {
        case '+':
            total = total + (whole + dec);
            break;
        case '-':
            total = total - (whole + dec);
            break;
        case '*':
            total = total * (whole + dec);
            break;
        case '/':
            total = total * (whole + dec);
            break;
    }
}

function Reset() {
    total = 0;
    prev_op = '+';
    prev_num = '';
    prev_dec = '';
    dot = false;
    last_is_num = false;
}