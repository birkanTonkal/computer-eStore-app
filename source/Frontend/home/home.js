const openMenu = document.querySelector(".js-open-menu");
const closeCart = document.querySelector(".close-cart");
const overlay = document.querySelector(".overlay");
openMenu.addEventListener("click", (e) => {
	e.preventDefault();
	document.body.classList.add("nav-open");
});

closeCart.addEventListener("click", (e) => {
	e.preventDefault();
	document.body.classList.remove("nav-open");
});

overlay.addEventListener("click", (e) => {
	e.preventDefault();
	document.body.classList.remove("nav-open");
});


