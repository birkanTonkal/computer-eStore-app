let url = "http://localhost:5102/api/Product";
let cartUrl = "http://localhost:5102/api/Cart";
let allProducts;
let goCart = document.getElementById("cart")
let products = document.getElementById("products");
let addProduct = document.getElementById("addProduct");
let cart = document.getElementById("cart");
if (sessionStorage.getItem("userType") == "normal") {
    addProduct.style.display = "none" 
}else {
    cart.style.display = "none"
}
goCart.addEventListener("click", () => {
    window.location.href = "./cart/cart.html"
}) 
    

addProduct.addEventListener("click", () => {
    window.location.href = "./product/product.html"
})
async function getAllProducts() {
    let response = await fetch(url);
    allProducts = await response.json();
    console.log(allProducts);
    for (const iterator of allProducts) {
        var product = document.createElement("div");
        product.className = "product";
        product.innerHTML = `<h1 >${iterator.title}</h1><h2>${iterator.price}</h2><p class="productKey" style="display:none">${iterator.productKey}</p><button class="addCart">addCart</button>`;
        products.appendChild(product);
      
    }
    let addCarts = document.querySelectorAll(".addCart")
    let div_array = [...addCarts];
    div_array.forEach(element =>  {
        console.log(element)
        element.addEventListener("click", async (e) => {
            let userKey = sessionStorage.getItem("usersKey")
            console.log(userKey)
            let productKey = e.target.previousElementSibling.innerHTML
            console.log(productKey)
            let cartObject = {
                "rowState": 2,
                "userKey": userKey,
                "productKey": productKey
              };
              await fetch(cartUrl, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(cartObject)}).then(e => {
                    console.log(e)
            
        })
        })
    })
    
}

getAllProducts();
