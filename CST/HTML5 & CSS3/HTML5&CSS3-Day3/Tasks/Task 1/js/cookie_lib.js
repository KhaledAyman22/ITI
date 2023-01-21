if (typeof window.localStorage == 'undefined' || typeof window.sessionStorage == 'undefined')
    (function () {
        function Parse() {
            cookie_pairs = [];
            if (document.cookie === '') return [];
            var cookie = document.cookie.split(';');

            for (var i = 0; i < cookie.length; i++) {
                var tmp = cookie[i].indexOf('=');
                cookie_pairs[cookie[i].slice(0, tmp).trim()] = cookie[i].slice(tmp + 1, cookie[i].length).trim();
            }
        }
        function SaveCookie(cookie) {
            document.cookie = cookie;
        }
        function hasCookie(cookieName) {
            Parse();
            return cookie_pairs[cookieName] !== undefined;
        }

        var data = Parse();

        var Storage = function (type) {
            function createCookie(cookieName, cookieValue) {
                if (arguments.length !== 2)
                    throw new Error('Must pass 2 parameters name, value');

                var cookie = '';

                cookie += `${cookieName}=${cookieValue}; path=/`;

                if (type == 'local') {
                    var expiryDate = new Date();
                    expiryDate.setTime(expiryDate.getTime()+(30*24*60*60*1000));
                    expiryDate = expiryDate.toUTCString();
                    cookie += `; expires=${expiryDate}`;
                }

                SaveCookie(cookie);
            }

            function readCookie(cookieName) {
                if (arguments.length !== 1) throw new Error('Must pass one parameter');

                Parse();

                if (hasCookie(cookieName))
                    return cookie_pairs[cookieName];
                else return null;
            }

            function setData(data) {
                data = JSON.stringify(data);
                if (type == 'session') {
                    window.name = data;
                } else {
                    createCookie('localStorage', data, 365);
                }
            }

            function deleteCookie(cookieName) {
                var cookie = '';
                if (hasCookie(cookieName)) {
                    cookie += `${cookieName}= ;expires=1-1-1999`;
                    SaveCookie(cookie);
                }
            }

            function allCookieList() {
                Parse();
                return cookie_pairs;
            }

            function clearCookies() {
                for (var argument of data) {
                    deleteCookie(argument)
                }
            }


            return {
                length: 0,
                clear: function () {
                    data = {};
                    this.length = 0;
                    clearCookies();
                },
                getItem: function (key) {
                    return readCookie(key);
                },
                key: function (i) {
                    var ctr = 0;
                    for (var k in data) {
                        if (ctr == i) return k;
                        else ctr++;
                    }
                    return null;
                },
                removeItem: function (key) {
                    this.length--;
                    deleteCookie(key);
                },
                setItem: function (key, value) {
                    createCookie(key, value);
                }
            };
        };

        if (typeof window.localStorage == 'undefined')
            window.localStorage = new Storage('local');
        if (typeof window.sessionStorage == 'undefined')
            window.sessionStorage = new Storage('session');

    })();