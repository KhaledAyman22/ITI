"use strict";
(function () {
    var EMPTY = 'rgb(227, 227, 227)', NORMAL = 'rgb(32, 123, 255)', ERROR = 'rgb(252, 78, 78)',
        DISABLED = 'rgb(110, 110, 110)', ENABLED_NUMBER = 'rgb(255, 164, 32)', SELECTED_NUMBER = 'rgb(182, 226, 161)',
        ENABLED_HELPER = 'rgb(135, 18, 91)', SELECTED_HELPER = 'rgb(120, 175, 255)',
        H_EMPTY = 'rgb(208, 196, 232)', H_AREA = 'rgb(125, 78, 252)', H_CELL = 'rgb(0, 232, 242)',
        H_OCC = 'rgb(123, 73, 166)',

        board_solved, board_unsolved,
        insertable = [], empty = [], undoArr = [],
        numberSelected = null,
        numberUsageArr = [0, 0, 0, 0, 0, 0, 0, 0, 0],
        eraseMode = false, notesMode = false, isOn = true,
        mistakesMade = 0, mistakeCount = 0, hintCount,
        timerInterval, settings = {
            'Timer': true,
            'Mistake Limit': true,
            'Mistakes Checker': true,
            'Hide Numbers': true,
            'Highlight Duplicates': true,
            'Highlight Area': true,
            'Highlight Identical': true,
        }, time = 0;

    BodyLoad();

    function SetIds() {
        var i = 0, j = 0;
        for (let row of document.getElementsByTagName('tr')) {
            for (let col of row.getElementsByTagName('td')) {
                for (let cell of col.getElementsByTagName('button')) {
                    if (cell.nodeType === Node.ELEMENT_NODE) {
                        cell.id = `c${i}${j}`;
                        j++;
                    }
                }
            }
            i++;
            j = 0;
        }
    }

    function SetCellOnClick() {
        for (var btn of document.getElementsByClassName('num_block')) {
            btn.onclick = CellClick;
        }
    }

    function SetSudoku() {
        for (let i = 0; i < 9; i++) {
            for (let j = 0; j < 9; j++) {
                if (board_unsolved[i][j] === 0) {
                    document.getElementById(`c${i}${j}`).style.backgroundColor = EMPTY;
                } else {
                    var tmp = document.getElementById(`c${i}${j}`);
                    tmp.innerText = board_unsolved[i][j];
                    tmp.style.fontFamily = 'BlackIFont';
                }
            }
        }
    }

    function BuildBoard(diff) {
        var game = Play(diff);
        board_solved = game[0];
        board_unsolved = game[1];
    }

    function BodyLoad() {
        var url = new URL(window.location.href);
        var diff = url.searchParams.get("diff");

        SetIds();
        SetCellOnClick();
        BuildBoard(diff);
        SetSudoku();

        SetNumbersOnClick();
        SetHelpersOnClick();

        RetrieveSettings();

        StartTimer();
        SetPLayPauseClick();
        SetHintAndMistakes(diff);

        SetEmptyAndInsertable();
        console.log(board_solved);
    }

    function HighlightBox(r, c) {
        r = Math.floor(r / 3) * 3;
        c = Math.floor(c / 3) * 3;

        for (let i = r; i < r + 3; i++) {
            for (let j = c; j < c + 3; j++) {
                var cell = document.getElementById(`c${i}${j}`);
                if (cell.style.backgroundColor !== ERROR) {
                    if (board_unsolved[i][j] === 0)
                        cell.style.backgroundColor = H_EMPTY;
                    else
                        cell.style.backgroundColor = H_AREA;
                }
            }
        }
    }

    function HighlightRowCol(r, c) {
        for (let i = 0; i < 9; i++) {
            var cell_r = document.getElementById(`c${r}${i}`),
                cell_c = document.getElementById(`c${i}${c}`);

            if (board_unsolved[r][i] === 0)
                cell_r.style.backgroundColor = H_EMPTY;
            else
                cell_r.style.backgroundColor = H_AREA;

            if (board_unsolved[i][c] === 0)
                cell_c.style.backgroundColor = H_EMPTY;
            else
                cell_c.style.backgroundColor = H_AREA;
        }
    }

    function HighlightNumber(n) {
        for (let i = 0; i < 9; i++) {
            for (let j = 0; j < 9; j++) {
                var cell = document.getElementById(`c${i}${j}`);

                if (board_unsolved[i][j] === n)
                    cell.style.backgroundColor = H_OCC;
            }
        }
    }

    function ResetHighlight() {
        for (let i = 0; i < 9; i++) {
            for (let j = 0; j < 9; j++) {
                var cell = document.getElementById(`c${i}${j}`);

                if (board_unsolved[i][j] === 0)
                    cell.style.backgroundColor = EMPTY;
                else
                    cell.style.backgroundColor = NORMAL;
            }
        }
    }

    function Highlight(r, c) {
        var n = board_unsolved[r][c];
        ResetHighlight();
        if (settings['Highlight Area']) {
            HighlightBox(r, c);
            HighlightRowCol(r, c);
        }

        if (settings['Highlight Identical'] && n !== 0) HighlightNumber(n);

        if (settings['Highlight Duplicates']) HighlightRuleError();
        if (settings['Mistakes Checker']) HighlightSolutionError();

        document.getElementById(`c${r}${c}`).style.backgroundColor = H_CELL;
    }

    function HighlightSolutionError() {
        for (let i = 0; i < 9; i++) {
            for (let j = 0; j < 9; j++) {
                if (board_unsolved[i][j] !== 0 && board_unsolved[i][j] !== board_solved[i][j])
                    document.getElementById(`c${i}${j}`).style.backgroundColor = ERROR;
            }
        }
    }

    function HighlightRuleError() {

        // ROWS & COLS
        var all_occ_r = [], all_occ_c = [];
        for (let i = 0; i < 9; i++) {
            var occ1 = {}, occ2 = {};
            for (let j = 0; j < 9; j++) {
                let tmp = board_unsolved[i][j];

                if (tmp !== 0)
                    occ1[tmp] = occ1[tmp] === undefined ? 1 : occ1[tmp] + 1;

                tmp = board_unsolved[j][i];
                if (tmp !== 0)
                    occ2[tmp] = occ2[tmp] === undefined ? 1 : occ2[tmp] + 1;
            }
            all_occ_r.push(occ1);
            all_occ_c.push(occ2);
        }
        for (let i = 0; i < 9; i++) {
            for (let j = 0; j < 9; j++) {
                let tmp = board_unsolved[i][j];
                if (tmp !== 0 && all_occ_r[i][tmp] > 1) {
                    document.getElementById(`c${i}${j}`).style.backgroundColor = ERROR;
                }

                tmp = board_unsolved[j][i];
                if (tmp !== 0 && all_occ_c[i][tmp] > 1) {
                    document.getElementById(`c${j}${i}`).style.backgroundColor = ERROR;
                }
            }
        }

        // BOX
        var r = 0, c = 0;
        var all_occ = []
        for (let i = 0; i < 9; i++) {
            var occ = {};
            for (let j = r; j < r + 3; j++) {
                for (let k = c; k < c + 3; k++) {
                    let tmp = board_unsolved[j][k];
                    if (tmp !== 0)
                        occ[tmp] = occ[tmp] === undefined ? 1 : occ[tmp] + 1;
                }
            }
            c += 3;
            if (c === 9) {
                c = 0;
                r += 3;
            }
            all_occ.push(occ);
        }

        r = 0;
        c = 0;
        for (let i = 0; i < 9; i++) {
            for (let j = r; j < r + 3; j++) {
                for (let k = c; k < c + 3; k++) {
                    let tmp = board_unsolved[j][k];
                    if (tmp !== 0 && all_occ[i][tmp] > 1) {
                        document.getElementById(`c${j}${k}`).style.backgroundColor = ERROR;
                    }
                }
            }
            c += 3;
            if (c === 9) {
                c = 0;
                r += 3;
            }
        }
    }

    function CellClick(evt) {
        var r = parseInt(evt.target.id[1]), c = parseInt(evt.target.id[2]);


        if (eraseMode) {
            Erase(r, c);
            document.getElementById('eraser').click();
        } else if (numberSelected)
            Write(r, c);


        Highlight(r, c);

    }

    function Erase(r, c) {
        if (board_unsolved[r][c] !== 0) {

            if (insertable.indexOf(`${r}${c}`) !== -1) {
                if (settings['Hide Numbers'])
                    NumberUsageTracker('remove', board_unsolved[r][c]);

                undoArr.push(`${0}${board_unsolved[r][c]}${r}${c}`);

                board_unsolved[r][c] = 0;

                document.getElementById(`c${r}${c}`).innerText = "";

                empty.push(`${r}${c}`);
            }
        }
    }

    function Hint() {
        if (empty.length === 0) return;

        var rnd = Math.random();
        var index = Math.floor(empty.length * rnd);

        var row = empty[index][0], col = empty[index][1];

        var value = board_solved[row][col];

        if (settings['Hide Numbers']) NumberUsageTracker('add', value);

        board_unsolved[row][col] = value;

        var elem = document.getElementById(`c${row}${col}`);
        elem.innerText = value;
        elem.style.backgroundColor = NORMAL;

        empty.splice(index, 1);
        insertable.splice(insertable.indexOf(`${row}${col}`), 1);

        Highlight(row, col, true, true);
    }

    function Write(r, c) {
        if (insertable.indexOf(`${r}${c}`) === -1) return;

        var selectedCell = document.getElementById(`c${r}${c}`);

        if (notesMode) {
            if (board_unsolved[r][c] === 0)
                selectedCell.innerText = numberSelected;
        } else {

            var prev = board_unsolved[r][c];

            if (prev === numberSelected) return;

            undoArr.push(`${numberSelected}${board_unsolved[r][c]}${r}${c}`);

            selectedCell.innerText = numberSelected;
            board_unsolved[r][c] = numberSelected;

            var idx = empty.indexOf(`${r}${c}`);
            if (idx !== -1)
                empty.splice(idx, 1);

            if (settings['Hide Numbers']) {
                NumberUsageTracker('add', numberSelected);

                if (board_unsolved[r][c] !== 0) {
                    NumberUsageTracker('remove', prev);
                }
            }

            if (settings['Mistake Limit'] && board_unsolved[r][c] !== board_solved[r][c]) {
                mistakesMade++;
                $('#mistakes').text(`Mistakes: ${mistakesMade}/${mistakeCount}`);
                CheckLose();
            }

            if (empty.length === 0) CheckWin();
        }

    }

    function Undo() {

        if (undoArr.length !== 0) {

            var history = undoArr.pop();

            var _new = parseInt(history[0]);
            var _old = parseInt(history[1]);
            var r = parseInt(history[2]);
            var c = parseInt(history[3]);

            var selectedCell = document.getElementById(`c${r}${c}`);

            if (settings['Hide Numbers']) {
                NumberUsageTracker('remove', _new);
                NumberUsageTracker('add', _old);
            }

            selectedCell.innerText = _old === 0 ? '' : _old;
            board_unsolved[r][c] = _old;

            Highlight(r, c);
        }
    }

    function NumberUsageTracker(operation, targetNumber) {
        if (targetNumber <= 0) return;

        if (operation === 'add') numberUsageArr[targetNumber - 1]++;
        else if (operation === 'remove') numberUsageArr[targetNumber - 1]--;
        else return;

        var tmp = document.getElementById(`n${targetNumber}`);

        if (numberUsageArr[targetNumber - 1] === 9) {
            tmp.disabled = true;
            tmp.style.backgroundColor = DISABLED;
            numberSelected = null;
        } else {
            if (tmp.disabled === null || tmp.disabled === true) {
                tmp.disabled = false;
                tmp.style.backgroundColor = ENABLED_NUMBER;
            }
        }
    }

    function SetNumbersOnClick() {
        for (var elem of document.getElementsByClassName('numControl')) {
            elem.addEventListener("click", NumberClicked);
        }
    }

    function NumberClicked(evt) {
        var _newSelected = parseInt(evt.target.id[1]);

        if (numberSelected === _newSelected) {
            document.getElementById(`n${numberSelected}`).style.backgroundColor = ENABLED_NUMBER;
            numberSelected = null;
        } else {
            if (numberSelected !== null)
                document.getElementById(`n${numberSelected}`).style.backgroundColor = ENABLED_NUMBER;

            document.getElementById(`n${_newSelected}`).style.backgroundColor = SELECTED_NUMBER;

            numberSelected = _newSelected;
        }
    }

    function SetHelpersOnClick() {
        $("#undo").on('click', function () {
            Undo();
        });

        $("#hint").on('click', function () {
            if (hintCount > 0) {
                hintCount--;
                Hint();
            } else {
                var tmp = document.getElementById('hint');
                tmp.disabled = true;
                tmp.style.backgroundColor = DISABLED;
            }
        })

        $("#notes").on('click', function () {
            notesMode = !notesMode;

            var _notes = document.getElementById('notes');
            if (notesMode)
                _notes.style.backgroundColor = SELECTED_HELPER;
            else
                _notes.style.backgroundColor = ENABLED_HELPER;
        });

        $("#eraser").on('click', function () {
            eraseMode = !eraseMode;

            var _eraser = document.getElementById('eraser');
            if (eraseMode)
                _eraser.style.backgroundColor = SELECTED_HELPER;
            else
                _eraser.style.backgroundColor = ENABLED_HELPER;
        })
    }

    function CheckWin() {
        var won = true;

        for (let i = 0; i < 9; i++) {
            for (let j = 0; j < 9; j++) {
                if (board_unsolved[i][j] !== board_solved[i][j]) {
                    won = false;
                    break;
                }
            }
        }

        if (won) {
            $('#end_img').attr('src', '../assets/game/win.png');
            $('#end').css('display', 'block');
            setTimeout(function () {
                history.back();
            }, 5000);
        }
    }

    function CheckLose() {
        if (mistakeCount === mistakesMade) {
            $('#end_img').attr('src', '../assets/game/gameover.png');
            $('#end').css('display', 'block');
            setTimeout(function () {
                history.back();
            }, 5000);
        }
    }

    function RetrieveSettings() {
        var tmp = allCookieList();
        for (var settingsKey in settings) {
            var crnt = tmp[settingsKey];

            if (crnt === undefined || crnt === 'on')
                settings[settingsKey] = true;
            else if (crnt === 'off')
                settings[settingsKey] = false;
        }
    }

    function StartTimer() {
        if (settings['Timer']) {
            timerInterval = setInterval(function () {
                time += 1;

                var seconds = (time % 60).toString();
                var minutes = (Math.floor(time / 60)).toString();

                if (seconds.length === 1) seconds = `0${seconds}`;
                if (minutes.length === 1) minutes = `0${minutes}`;

                $('#playTime').text(`${minutes}:${seconds}`);

            }, 1000);
        } else {
            $('#timerDiv').css('visibility', 'hidden');
        }
    }

    function SetPLayPauseClick() {
        if (settings['Timer']) {
            $('#pause_btn').on('click', function () {
                if (isOn) {
                    clearInterval(timerInterval);

                    $('#board button').each(function (i, obj) {
                        obj.disabled = true;
                    });

                    isOn = false;
                }
            });

            $('#play_btn').on('click', function () {
                if (!isOn) {
                    StartTimer();

                    $('#board button').each(function (i, obj) {
                        obj.disabled = false;
                    });

                    isOn = true;
                }
            });
        } else {
            $('#play_btn, #pause_btn').css('visibility', 'hidden');
        }
    }

    function SetHintAndMistakes(diff) {
        if (diff === 'e') {
            hintCount = 5;
            mistakeCount = 10;
        } else if (diff === 'm') {
            hintCount = 4;
            mistakeCount = 7;
        } else {
            hintCount = 3;
            mistakeCount = 5;
        }

        if (settings['Mistake Limit'])
            $('#mistakes').text(`Mistakes: 0/${mistakeCount}`);
    }

    function SetEmptyAndInsertable() {
        for (let i = 0; i < 9; i++) {
            for (let j = 0; j < 9; j++) {
                let tmp = board_unsolved[i][j];
                if (tmp === 0) {
                    insertable.push(`${i}${j}`);
                    empty.push(`${i}${j}`);
                } else numberUsageArr[tmp - 1]++;
            }
        }
    }
}())