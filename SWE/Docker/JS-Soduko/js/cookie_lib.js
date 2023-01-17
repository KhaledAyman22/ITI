var cookie_pairs;

function Parse() {
    cookie_pairs = [];
    if (document.cookie === '') return;
    var cookie = document.cookie.split(';');

    for (var i = 0; i < cookie.length; i++) {
        var tmp = cookie[i].indexOf('=');
        cookie_pairs[cookie[i].slice(0, tmp).trim()] = cookie[i].slice(tmp + 1, cookie[i].length).trim();
    }
}

function getCookie(cookieName) {
    if (arguments.length !== 1) throw new Error('Must pass one parameter');

    Parse();

    if (hasCookie(cookieName))
        return cookie_pairs[cookieName];
    else return null;

}

function setCookie(cookieName, cookieValue, expiryDate) {
    if (arguments.length !== 2 && arguments.length !== 3)
        throw new Error('Must pass 2 parameters name, value and one optional expiry date');

    var cookie = '';

    cookie += `${cookieName}=${cookieValue}; path=/`;

    if (expiryDate !== undefined) {
        cookie += `; expires=${expiryDate}`;
    }

    SaveCookie(cookie);
}

function deleteCookie(cookieName) {
    var cookie = '';
    if (hasCookie(cookieName)) {

        cookie += `${cookieName}= ;expires=1-1-1999`;
    }
    else throw new Error('No cookie with the given name');

    SaveCookie(cookie);
}

function allCookieList() {
    Parse();
    return cookie_pairs;
}

function hasCookie(cookieName) {
    Parse();
    return cookie_pairs[cookieName] !== undefined;
}

function SaveCookie(cookie) {
    document.cookie = cookie;
}