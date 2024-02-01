import Splide from '@splidejs/splide/dist/js/splide';

window.CarouselSlider = {
    Bootstrap: function (className, type = "loop", perPage = 3) {
        new Splide("." + className, {
            type   : type,
            autoWidth: true,
            gap    : '.5rem',
            height : '30rem',
            autoplay: true,
            breakpoints: {
                768: {
                    perPage: 2,
                    gap    : '.3rem',
                    height : '18rem',
                },
                480: {
                    perPage: 1,
                    gap    : '.7rem',
                    height : '18rem',
                },
            },
        }).mount();
    }
};
