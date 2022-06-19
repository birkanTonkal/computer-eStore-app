let url = "http://localhost:5102/api/Cart"
let getProduct = "/api/Product/{id}"
let products = document.getElementById("product")
async function getAllCarts () {
    let response = await fetch(url);
    let allProducts = await response.json();
    for (const iterator of allProducts) {
        console.log(allProducts)
        let getProduct = await fetch(`http://localhost:5102/api/Product/1?productKey=${iterator.productKey}`)
        let productJson = await getProduct.json()
        var product = document.createElement("div");
        product.className = "product";
        product.innerHTML = `<h1 >${productJson.title}</h1><h2>${productJson.price}</h2>`;
        products.appendChild(product);
    }
   
    
}
getAllCarts();