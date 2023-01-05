document.body.onload = function () {
    var vid = document.getElementById('vid');

    document.getElementById('playback').max = vid.duration;

    vid.ontimeupdate = function () {
        document.getElementById('playback').value = vid.currentTime;
        var min = (Math.floor(vid.currentTime / 60)).toString();
        var sec = (Math.floor(vid.currentTime % 60)).toString();

        if (min.length < 2) min = '0' + min;
        if (sec.length < 2) sec = '0' + sec;

        document.getElementById('playback_label').innerText = `${min}:${sec}`
    }


    document.getElementById('playback').oninput = function () {
        vid.currentTime = this.value;
    }

    document.getElementById('play').onclick = function () {
        if (vid.paused)
            vid.play();
    }

    document.getElementById('stop').onclick = function () {
        if (!vid.paused)
            vid.pause();
    }

    document.getElementById('f').onclick = function () {
        if (vid.duration > vid.currentTime + 5)
            vid.currentTime += 5;
        else
            vid.currentTime = vid.duration;
    }

    document.getElementById('b').onclick = function () {
        if (0 < vid.currentTime - 5)
            vid.currentTime -= 5;
        else
            vid.currentTime = 0;
    }

    document.getElementById('ff').onclick = function () {
        vid.currentTime = vid.duration;

    }

    document.getElementById('fb').onclick = function () {
        vid.currentTime = 0;
    }

    document.getElementById('mute').onclick = function () {
        vid.volume = 0;
        document.getElementById('vol').value = 0;
    }

    document.getElementById('speed').oninput = function () {
        vid.playbackRate = this.value;
    }

    document.getElementById('vol').oninput = function () {
        vid.volume = this.value;
    }
}