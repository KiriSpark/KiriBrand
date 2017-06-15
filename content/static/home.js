$(window).load(function () {
    //set a default timout for the loader animation
    //so people can see it
    setTimeout(function () {
        //hide the loader
        $(".se-pre-con").hide();
        //call page animation
        animateHeader();
        animateSections();
        animateLandingScrollButton();
        $('#landing_actionlist').stickUp({
            topMargin: '0px'
        });
    }, 560);
});
//function to animate the header buttons
function animateHeader() {
    var delay = 100;
    $('.nav-item').each(function (index, item) {
        animateNavButton('#' + item.id, delay);
        delay += 150;
    });
}
//function to animate one particular button by its Id name
//using Velocity library
function animateNavButton(itemName, delay) {
    if (delay === void 0) {
        delay = 0;
    }
    $(itemName).velocity('transition.flipXIn', {
        delay: delay,
        opacity: 1,
        duration: 1000
    });
}
//this will animate sections inside the body
//using scrolReveal library
function animateSections() {
    var config = {
        duration: 300,
        delay: 600,
        distance: '200px',
        origin: 'right',
        easing: 'cubic-bezier(1, 1, 1, 1)'
    };
    var sr = window.sr = ScrollReveal();
    $('.animated').each(function (index, item) {
        sr.reveal(item, config);
    });
}

function animateLandingScrollButton() {
    $('.smoothscroll > i').velocity({
        "margin-top": "8px"
    }, {
        loop: true
    });
    $('.smoothscroll').on('click', function (e) {
        e.preventDefault();

        //using the navbar height as offset because the navbar
        //will be stuck on the top when we scroll, so we need to consider
        //its size in the landing position
        var scrollBarHeight = $('#landing_actionlist').height();
        $('#body_area').velocity("scroll", {
            offset: -(scrollBarHeight) + 5,
            duration: 800,
            easing: "swing"
        })    .velocity({
            opacity: 1
        });
    });
}