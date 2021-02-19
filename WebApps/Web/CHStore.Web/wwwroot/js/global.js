$(document).ready(function () {
    //Show search input event
    $("#ch-search-icon").click(showSearchInput);
    $("#ch-search-icon-primary").click(showSearchInputPrimary);

    $(document).scroll(showMenuOnScroll);
});

function showMenuOnScroll() {
    var secondaryMenu = document.getElementsByClassName('ch-secondary-header')[0];
    console.log(window.scrollY);

    if (window.scrollY > 100) {
        secondaryMenu.style.marginTop = "0px";
    }
    else {
        secondaryMenu.style.marginTop = "-90px";
    }
}

function showSearchInput() {
    var input = document.getElementById('search-input'); 

    if (input.style.transform == "rotateX(-90deg)")
        input.style.transform = 'none';
    else
        input.style.transform = "rotateX(-90deg)"
}

function showSearchInputPrimary() {
    var input = document.getElementById('search-input-primary');

    if (input.style.transform == "rotateX(-90deg)")
        input.style.transform = 'none';
    else
        input.style.transform = "rotateX(-90deg)"
}

function toggleShoppingCart() {
    var shoppingCart = document.getElementById("shopping-cart");

    //Se estiver escondido, aparece
    if (shoppingCart.style.display == "none") {
        shoppingCart.style.display = "block";
        shoppingCart.style.opacity =1;
    }
    else {
        shoppingCart.style.opacity = "0";
        shoppingCart.style.display = "none";
    }
    
}