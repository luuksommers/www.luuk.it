var consoleText = "Luuk.it";
var refreshCounter = 10; // do 10 refresh in 100ms (1 sec total) to make sure the custom font is loaded.

window.addEventListener('load', function () {
    if (Modernizr.canvas) {
        drawText();
        setkeypresshandler();
    }
});

function drawText() {
    //console.log("drawText: *" + consoleText + "*");
    var canvas = document.getElementById("consoleHeader");
    var context = canvas.getContext("2d");
    var width = 140;
    context.clearRect(0, 0, canvas.width, canvas.height);
    context.font = "bold 140px Roboto";

    var textMetrics = context.measureText(">" + consoleText);
    while (textMetrics.width > (canvas.width - 50)) {
        width -= 5;
        context.font = "bold " + width + "px Roboto";
        textMetrics = context.measureText(">" + consoleText);
    }
    context.textBaseline = "middle";
    context.fillStyle = "#555";
    context.fillText(">" + consoleText, 10, 90);
    context.fillStyle = "#34B4E3";
    context.fillText(">", 10, 90);

    if (refreshCounter > 0) {
        refreshCounter--;
        setTimeout(drawText, 20);
    }
}
var nyanstep = 1;
var nyansnd;
function initializeNyanCat() {
    nyansnd = new Audio("/Content/nyan-cat-download_nyan-cat-mp3.mp3"); // buffers automatically when created
    var images = new Array()
    function preload() {
        for (i = 0; i < preload.arguments.length; i++) {
            images[i] = new Image()
            images[i].src = preload.arguments[i]
        }
    }
    preload(
        '/Images/nyan-cat1.png',
        '/Images/nyan-cat2.png',
        '/Images/nyan-cat3.png',
        '/Images/nyan-cat4.png',
        '/Images/nyan-cat5.png',
        '/Images/nyan-cat6.png'
    )
    consoleText = "";
}

function drawNyanCat() {
    if (consoleText != "") {
        nyansnd.pause();
        nyanstep = 1;
        drawText();
    } else {
        var canvas = document.getElementById("consoleHeader");
        var context = canvas.getContext("2d");
        context.clearRect(0, 0, canvas.width, canvas.height);
        context.fillStyle = "#34B4E3";
        context.fillText(">", 10, 90);
        var img = new Image();
        img.src = '/Images/nyan-cat' + nyanstep + '.png';
        nyansnd.play();
        img.onload = function () {
            context.drawImage(img, 80, 0);
            if (nyanstep < 6) {
                nyanstep++;
            }
            else {
                nyanstep = 1;
            }
            setTimeout(drawNyanCat, 120);
        }
    }
}

function getKeyCode(e) {
    e = window.event || e;

    if (e.keyCode == 13) {
        if (consoleText == "nyan") {
            initializeNyanCat();
            drawNyanCat();
            return;
        }
        if (consoleText == "marion") {
            window.location = "http://www.marionspijkerman.nl";
            return;
        }
        if (consoleText == "connect") {
            window.location.href = "/connect";
            return;
        }
        if (consoleText == "projects") {
            window.location.href = "/projects";
            return;
        }
        if (consoleText == "about") {
            window.location.href = "/about";
            return;
        }
        if (consoleText == "home") {
            window.location.href = "/";
            return;
        }
        consoleText = "NOK";
        drawText();
        consoleText = "Luuk.it";
        setTimeout(drawText, 2000);
    }
    else if (e.keyCode != 16) { // If the pressed key is anything other than SHIFT
        c = String.fromCharCode(e.which);
        if (!e.shiftKey) // If the SHIFT key is down, return the ASCII code for the capital letter
            c = c.toLowerCase(c);

        if (e.which !== 0 && e.keyCode !== 0) {
            if (consoleText == "Luuk.it")
                consoleText = "";
            if (e.keyCode == 8) {
                if (consoleText.length > 0)
                    consoleText = consoleText.substring(0, consoleText.length - 1);
            }
            else {
                consoleText += c;
            }
            drawText();
        }
    }
}

function setkeypresshandler() {
        var d = document;
        if (d.addEventListener) d.addEventListener('keypress', getKeyCode, false);
        else if (d.attachEvent) {
            d = (d.documentElement.clientHeight) ? d.documentElement : d.body;
            d.attachEvent('onkeypress', getKeyCode);
        }
}

$(function () {
    $("#projects li").mouseover(function () {
        var url = $(this).data("url");
        $("#projects li").removeClass("selected");
        $(this).addClass("selected");
        $("#project-details").load(url);
    });

    $("#imagescroll img").mouseover(function () {
        var text = $(this).data("text");
        $("#imagedescription").html(text);
    });
});