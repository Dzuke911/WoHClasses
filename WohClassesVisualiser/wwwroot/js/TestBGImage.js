window.onload = function () {
    let canvas = document.getElementById("MainCanvas");
    let ctx = canvas.getContext("2d");
    let bgImage = document.getElementById("TestBgImage");

    let canvasX = canvas.clientWidth;
    let canvasY = canvas.clientHeight;

    let bgImageX = bgImage.naturalWidth;
    let bgImageY = bgImage.naturalHeight;

    let bgImageXStart = (canvasX - bgImageX) / 2;
    let bgImageYStart = (canvasY - bgImageY) / 2;

    let bgImageXClip = canvasX > bgImageX ? bgImageX : canvasX - bgImageXStart;
    let bgImageYClip = canvasY > bgImageY ? bgImageY : canvasY - bgImageYStart;

    //var ctx = c.getContext("2d");
    //var img = document.getElementById("scream");

    ctx.drawImage(bgImage,
        Math.abs(bgImageXStart),
        Math.abs(bgImageYStart),
        bgImageXClip,
        bgImageYClip,
        bgImageXStart,
        bgImageYStart,
        bgImageX,
        bgImageY);
}