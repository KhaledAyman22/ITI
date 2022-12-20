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
    else throw new Error('No cookie with the given name');

}

function setCookie(cookieName, cookieValue, expiryDate) {
    if (arguments.length !== 2 && arguments.length !== 3) throw new Error('Must pass 2 parameters name, value and one optional expiry date');

    Parse();
    cookie_pairs[cookieName] = `${cookieValue}`;

    if (expiryDate !== undefined) {
        cookie_pairs['expires'] = `${expiryDate}`;
    }

    SaveCookies();
}

function deleteCookie(cookieName) {
    if (hasCookie(cookieName)) {
        cookie_pairs[cookieName] = '';
        cookie_pairs['expires'] = '1-1-1999';
    }
    else throw new Error('No cookie with the given name');

    SaveCookies();
}

function allCookieList() {
    Parse();
    return cookie_pairs;
}

function hasCookie(cookieName) {
    Parse();
    return cookie_pairs[cookieName] !== undefined;
}

function SaveCookies() {

    for (var cookie in cookie_pairs)
        document.cookie = `${cookie}=${cookie_pairs[cookie]}`;
}