function LinkedList(start, end, step) {
    var self = this;
    var array = [];

    step = step || 1;

    var fillArray = function () {
        while (start <= end) {
            array.push(start);
            start += step;
        }
    }

    if (start !== undefined && end !== undefined) fillArray();

    Object.defineProperties(self, {
        append: {
            value: function (i) {
                if (array.length === 0 || array[array.length - 1] + step === i)
                    array.push(i);
                else
                    throw new Error('Invalid sequence!');
            }
        },

        prepend: {
            value: function (i) {
                if (array.length === 0 || array[0] - step === i)
                    array.unshift(i);
                else
                    throw new Error('Invalid sequence!');
            }
        },

        dequeue: {
            value: function () {
                array.shift();
            }
        },

        pop: {
            value: function () {
                array.pop();
            }
        },

        toString: {
            value: function () {
                console.log(array.join(', '));
            }
        },

        getList: {
            value: function () {
                return array.map((x) => x);
            }
        }
    });
}

var l = new LinkedList(0, 10,2);
l.toString();

l.append(12);
l.toString();

l.prepend(-2);
l.toString();

l.pop();
l.toString();

l.dequeue();
l.toString();

l.append(15);

