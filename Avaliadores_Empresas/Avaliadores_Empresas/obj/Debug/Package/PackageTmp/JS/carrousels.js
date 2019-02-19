
$(document).ready(function () {
    $("#owl").owlCarousel();
});

$('#owl').owlCarousel({
    loop: true,
    dots: false,
    nav: false,
    autoplay: 2500,
    autoplayTimeout: 20000,
    autoplayHoverPause: true,
    slideTransition: "fade",
    animateOut: 'fadeOut',
    responsive: {
        0: {
            items: 1
        }
    }
});