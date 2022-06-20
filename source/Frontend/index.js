let url = "http://localhost:5102/api/Product";
let cartUrl = "http://localhost:5102/api/Cart";
let allProducts;
const nowType = document.getElementsByClassName("productType");

let goCart = document.getElementById("cart");
let products = document.getElementById("products");
let addProduct = document.getElementById("addProduct");
let cart = document.getElementById("cart");
if (sessionStorage.getItem("userType") == "admin") {
     cart.style.display = "none"
}else {
    addProduct.style.display = "none"
    
}
goCart.addEventListener("click", () => {
    window.location.href = "./cart/cart.html"
}) 
/*

*/

addProduct.addEventListener("click", () => {
    window.location.href = "./product/product.html"
})
async function getAllProducts() {
    let response = await fetch(url);
    allProducts = await response.json();
    console.log(allProducts);
    let i=0;
    const images = ["casper.png", "devices.png", "devices.png","devices.png","devices.png"];
    if (sessionStorage.getItem("userType") == "admin") {
        products.innerHTML='<h1>ALL PRODUCTS</h1><br><table><tr><th width="14.28%">Title</th><th width="14.28%">Price</th><th width="14.28%">Type</th><th width="14.28%">Ram</th><th width="14.28%">Graphic Card</th><th width="14.28%">CPU</th><th width="14.28%" >Stock</th></tr></table>'

        for (const iterator of allProducts) {
            var product = document.createElement("div");
            product.className = "product";
            product.innerHTML = `<table><tr><td>${iterator.title}</td><td>${iterator.price}</td><td>${iterator.type}</td><td>${iterator.ram}</td><td>${iterator.graphicCard}</td><td>${iterator.cpu}</td><td>${iterator.stock}</td></tr></table>
            <p class="productKey" style="display:none">${iterator.productKey}</p>`;
            products.appendChild(product);
          
        }
    }else {
        for (const iterator of allProducts) {
            var container = document.createElement("div");
            container.className = "container";
            
            container.innerHTML = `<div class="container page-wrapper"><div class="page-inner"><div class="row"><div class="el-wrapper"><div class="box-up"><img class="img" src=${images[i]} ;alt="photo"><div class="img-info"><div class="info-inner"><span class="p-name">${iterator.title}</span><p class="productKey" style="display:none"><span class="p-company">${iterator.type}</span></div><div class="a-size">Features:<span class="size">${iterator.ram} RAM <br>${iterator.graphicCard}<br>${iterator.cpu}</span></div></div></div><div class="box-down"><div class="h-bg"><div class="h-bg-inner"></div></div><a class="cart" href="#"><span class="price">${iterator.price}₺</span><button class="addCart"><span class="txt">Add in cart</span></button></a></div></div></div></div></div>`
            products.appendChild(container); 
            i++;
    }
       
        
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
