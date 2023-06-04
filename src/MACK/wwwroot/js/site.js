// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var backToTopButton = document.getElementById('back-to-top-btn');
var scrollThreshold = 200;

function handleScroll() {
    if (window.pageYOffset > scrollThreshold) {
        backToTopButton.style.display = 'block';
    } else {
        backToTopButton.style.display = 'none';
    }
}

function scrollToTop() {
    if (window.pageYOffset > 0) {
        window.scrollBy(0, -800);
        requestAnimationFrame(scrollToTop);
    }
}

window.addEventListener('scroll', handleScroll);

backToTopButton.addEventListener('click', function () {
    scrollToTop();
});