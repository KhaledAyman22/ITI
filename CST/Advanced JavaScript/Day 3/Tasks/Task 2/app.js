function Book(title, numberChapters, author, numberPages, publisher, numberCopies) {
    var self = this;

    Object.defineProperties(self, {
        title: {
            value: title || null
        },
        numberChapters: {
            value: numberChapters || null
        },
        author: {
            value: author || null
        },
        numberPages: {
            value: numberPages || null
        },
        publisher: {
            value: publisher || null
        },
        numberCopies: {
            value: numberCopies || 1
        }
    });
}

function Box(height, width, length, material) {
    var self = this;

    Object.defineProperties(self, {
        height: {value: height},

        width: {value: width},

        length: {value: length},

        material: {value: material},

        content: {value: []},

        countBooks: {value: 0, writable:true},

        addBook: {
            value: function (title, numberChapters, author, numberPages, publisher, numberCopies) {
                var index = self.content.findIndex((book) => book.title === title);

                if (index === -1)
                    self.content.push(new Book(title, numberChapters, author, numberPages, publisher, numberCopies));
                else
                    self.content[index].numberCopies = self.content[index].numberCopies + numberCopies;

                Box.count += numberCopies;
                self.countBooks += numberCopies;
            }
        },

        deleteBook: {
            value: function (title) {
                var index = self.content.findIndex((book) => book.title = title);

                if (index === -1) throw new Error('No book with the given title');
                else {
                    if (self.content[index].numberCopies === 1)
                        self.content = self.content.splice(index, 1);
                    else
                        self.content[index].numberCopies--;
                }

                Box.count -= 1;
                self.countBooks -= 1;
            }
        },

    });
}

Box.prototype.valueOf = function () {
    return this.countBooks;
}
Box.prototype.toString = function () {
        var s = `The Box's description is:\n\tHeight = ${this.height}\n\tWidth = ${this.width}\n\tLength = ${this.length}\n\tMaterial = ${this.material}`;
        s += '\nStatus of saved books:\n\t';

        for (let i = 0; i < this.content.length; i++) {
            s += `${this.content[i].title} x${this.content[i].numberCopies}`;
            if (i !== this.content.length - 1) s += ', ';
        }

        return s + '.';
};

Box.count = 0;
Box.getCount = function () {
    return this.count;
};


var bx = new Box(10, 5, 1, 'wood');

bx.addBook('b1', 10, 'aa', 123, 'aa', 5);
bx.addBook('b1', 10, 'aa', 123, 'aa', 5);
bx.addBook('b2', 10, 'aa', 123, 'aa', 5);
console.log('Total ' + Box.getCount());
console.log(bx.toString());


var bx2 = new Box(20, 15, 1, 'plastic');

bx2.addBook('b3', 10, 'aa', 123, 'aa', 5);
bx2.addBook('b4', 10, 'aa', 123, 'aa', 2);
bx2.addBook('b5', 10, 'aa', 123, 'aa', 1);
console.log('Total ' + Box.getCount());
console.log(bx2.toString());

console.log('b1+b2 = ' + (bx + bx2));
