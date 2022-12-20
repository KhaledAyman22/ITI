for (var i = 0; i < 3; i++) {
    for (var j = 0; j < 4; j++) {
        document.getElementById(`i${i}${j}`).onclick = flip;
    }
}

var board =  shuffle([1,2,3,4,5,6,1,2,3,4,5,6]);

var first_flipped = false, counter = 0, timer,
    card1 = null, card2 = null;

function flip(event) {
    if (event.target.src.indexOf('assets/moon.gif') === -1) return;

    if (card2 != null) {
        clearTimeout(timer);
        hide();
    }

    var r = parseInt(event.target.id[1]), c = parseInt(event.target.id[2]);

    if (card1 == null) card1 = `${r}${c}`;
    else card2 = `${r}${c}`;

    event.target.src = `assets/${board[r * 4 + c]}.gif`;

    if (first_flipped) {
        var row1 = parseInt(card1[0]), col1 = parseInt(card1[1]),
            row2 = parseInt(card2[0]), col2 = parseInt(card2[1]);

        if (board[row1 * 4 + col1] === board[row2 * 4 + col2]) {
            playCorrect();
            card1 = card2 = null;
            counter++;
        } else {
            playWrong();
            timer = setTimeout(hide, 1000);
        }

        first_flipped = false;
    } else first_flipped = true;

    if (counter === 6) alert("Congratulations!!");
}

function hide() {
    document.getElementById(`i${card1[0]}${card1[1]}`).src = 'assets/moon.gif';
    document.getElementById(`i${card2[0]}${card2[1]}`).src = 'assets/moon.gif';
    card1 = card2 = null;
}

function showHint() {
    for (var i = 0; i < document.images.length; i++) {
        var crnt = document.images[i], r = parseInt(crnt.id[1]), c = parseInt(crnt.id[2]);
        crnt.src = `assets/${board[r * 4 + c]}.gif`;
    }

    var tmp = function(){
        for (var i = 0; i < document.images.length; i++) {
            document.images[i].src = 'assets/moon.gif';
        }
    }
    setTimeout(tmp, 1500);
}

function shuffle(arr) {
    var crnt = arr.length,  rand;

    while (crnt !== 0) {
        rand = Math.floor(Math.random() * crnt);
        crnt--;
        [arr[crnt], arr[rand]] = [arr[rand], arr[crnt]];
    }

    return arr;
}

function playCorrect(){
    new Audio('assets/correct.mp3').play();
}

function playWrong(){
    new Audio('assets/wrong.mp3').play();
}