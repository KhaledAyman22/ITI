var LinkedList = {
    array: [],
    _push: function (i) {
        if (this.array.length === 0 || this.array[this.array.length - 1].val < i) this.array.push({ val: i });
        else throw new Error('Invalid sequence!');
    },
    _enqueue: function (i) {
        if (this.array.length === 0 || this.array[0].val > i) this.array.unshift({ val: i });
        else throw new Error('Invalid sequence!');
    },
    _dequeue: function () {
        this.array.shift();
    },
    _pop: function () {
        this.array.pop();
    },
    _insert: function (i, n) {
        if (this.array[i].val > n && this.array[i + 1].val > n) this.array.splice(i, 0, { val: n });
        else throw new Error('Invalid index!');
    },
    _remove: function (i) {
        if (i > 0 && i < this.array.length) this.array.splice(i, 1);
        else throw new Error('Invalid index!');
    },
    _display: function () {
        this.array.forEach((i) => console.log(i));
    },
}