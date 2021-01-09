$(document).ready(function () {
    //Show search input event
    $("#ch-search-icon").click(showSearchInput);
});

function showSearchInput() {
    document.getElementsByClassName('ch-input-search')[0].style.transform = 'none';
}