let url = "http://localhost:5102/api/Product"
let allProducts;
async function getAllProducts () {
   let response = await fetch(url)
   allProducts = await response.json()
   for (const iterator of allProducts) {
    console.log(iterator.price)
}
}

getAllProducts();
