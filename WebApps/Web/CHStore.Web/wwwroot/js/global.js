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
    document.getElementById('search-input').style.transform = 'none';
}

function showSearchInputPrimary() {
    document.getElementById('search-input-primary').style.transform = 'none';
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