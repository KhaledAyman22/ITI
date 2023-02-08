let obj = {
    [Symbol.replace](string, len) {
        return string.length > len ? string.slice(0, len) + '...' : string;
    }
};
                  //012345678901234567890123
const longString = 'Hello World new replace!';
console.log(longString.replace(obj,15));
