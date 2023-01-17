function Copy2DArray(src, dest) {
    for (let i = 0; i < 9; i++) {
        dest.push([]);
        for (let j = 0; j < 9; j++) {
            dest[i].push(src[i][j]);
        }
    }
}

function GetRandom(min, max) {
    if (max === undefined)
        max = min === 0 ? 8 : 9;
    return Math.floor(Math.random() * (max - min + 1) + min)
}

function IsValidBox(r, c, board) {
    r = Math.floor(r / 3) * 3;
    c = Math.floor(c / 3) * 3;

    let arr = [1, 2, 3, 4, 5, 6, 7, 8, 9];

    for (let i = r; i < r + 3; i++) {
        for (let j = c; j < c + 3; j++) {
            let tmp = board[i][j];

            if (tmp !== 0 && arr[tmp - 1] !== 0)
                arr[tmp - 1] = 0;
            else if (tmp !== 0 && arr[tmp - 1] === 0)
                return false;
        }
    }

    return true;
}

function IsValidRow(r, board) {
    let arr = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    for (let i = 0; i < 9; i++) {
        let tmp = board[r][i];

        if (tmp !== 0 && arr[tmp - 1] !== 0) arr[tmp - 1] = 0;
        else if (tmp !== 0 && arr[tmp - 1] === 0) return false;
    }

    return true;
}

function IsValidCol(c, board) {
    let arr = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    for (let i = 0; i < 9; i++) {
        let tmp = board[i][c];

        if (tmp !== 0 && arr[tmp - 1] !== 0) arr[tmp - 1] = 0;
        else if (tmp !== 0 && arr[tmp - 1] === 0) return false;
    }

    return true;
}

function IsValid(r, c, board) {
    return IsValidBox(r, c, board) && IsValidRow(r, board) && IsValidCol(c, board);
}

function AllValid(board) {
    let i = 0;
    while (i < 9 && IsValidRow(i, board) && IsValidCol(i, board)) i++;

    return i === 9 &&
        IsValidBox(0, 0, board) &&
        IsValidBox(0, 3, board) &&
        IsValidBox(0, 6, board) &&
        IsValidBox(3, 0, board) &&
        IsValidBox(3, 3, board) &&
        IsValidBox(3, 6, board) &&
        IsValidBox(6, 0, board) &&
        IsValidBox(6, 3, board) &&
        IsValidBox(6, 6, board);
}

function Generate() {
    var board = [
        [0, 0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0, 0],

        [0, 0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0, 0],

        [0, 0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0, 0],
    ], empty = [];

    function Randomize() {
        var count = 0;
        while (count < 10) {
            let p1 = GetRandom(0), p2 = GetRandom(0), val = GetRandom(1);

            if (board[p1][p2] === 0) {
                board[p1][p2] = val;
                if (!AllValid(board)) {
                    count--;
                    board[p1][p2] = 0;
                }

                count++;
            }
        }

        for (let i = 0; i < 9; i++) {
            for (let j = 0; j < 9; j++) {
                if (board[i][j] === 0) empty.push(`${i}${j}`);
            }
        }
    }

    function Solve(index) {
        if (index === empty.length) return true;
        let r = parseInt(empty[index][0]), c = parseInt(empty[index][1]);

        for (let i = 1; i < 10; i++) {
            board[r][c] = i;

            let valid = IsValid(r, c, board);

            if (valid && Solve(index + 1)) return true;
        }

        board[r][c] = 0;

        return false;
    }

    Randomize();
    Solve(0);

    return board;
}

function ApplyDifficulty(diff, board) {
    if (diff === 'h') diff = 50;
    else if (diff === 'm') diff = 45;
    else diff = 40;

    var num_solutions = { n: 0 }, count = 0, end = 80,
        play_board = [], removed_index = [], removed_val = [], given = [];

    for (let i = 0; i < 9; i++) {
        for (let j = 0; j < 9; j++) {
            given.push(`${i}${j}`);
        }
    }

    Copy2DArray(board, play_board);


    while (count < diff && end !== -1) {
        let pos = GetRandom(0, end);
        let p1 = parseInt(given[pos][0]), p2 = parseInt(given[pos][1]);

        if (pos !== end)
            [given[pos], given[end]] = [given[end], given[pos]];
        end--;

        removed_val.push(play_board[p1][p2]);
        removed_index.push(`${p1}${p2}`);

        play_board[p1][p2] = 0;

        num_solutions.n = 0;
        TryAll(0, play_board, removed_index, num_solutions);

        if (num_solutions.n > 1) {
            play_board[p1][p2] = removed_val.pop();
            removed_index.pop();
        }
        else count++;
    }

    return play_board;
}

function TryAll(index, board, removed_index, num_solutions) {
    if (index === removed_index.length) {
        num_solutions.n++;
        return;
    }

    var r = parseInt(removed_index[index][0]), c = parseInt(removed_index[index][1]);

    for (let i = 1; i < 10; i++) {
        board[r][c] = i;

        if (IsValid(r, c, board)) {
            TryAll(index + 1, board, removed_index, num_solutions);

            if (num_solutions.n > 1) {
                board[r][c] = 0;
                return;
            }
        }
    }

    board[r][c] = 0;
}

function Play(diff) {
    var solved = Generate();
    var unsolved = ApplyDifficulty(diff, solved);

    return [solved, unsolved];
}