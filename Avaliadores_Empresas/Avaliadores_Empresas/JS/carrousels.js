
$(document).ready(function () {
    $("#owl").owlCarousel();
});

$('#owl').owlCarousel({
    loop: true,
    dots: false,
    nav: false,
    autoplay: true,
    autoplayTimeout: 20000,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        }
    }
});