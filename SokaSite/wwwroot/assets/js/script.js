var titles = ["Soka", "Sport Games","Welcome to my WebSite"];
var counter = 0;
setInterval(function () {
    document.title = titles[counter % titles.length];
    counter++;
}, 2000);