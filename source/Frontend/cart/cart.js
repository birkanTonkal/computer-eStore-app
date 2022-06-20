let url = "http://localhost:5102/api/Cart"

let getProduct = "/api/Product/{id}"
let products = document.getElementById("product")
async function getAllCarts () {
    let response = await fetch(url);
   
    let allProducts = await response.json();
    console.log(allProducts)
    let price = 0;
    let newPrice = 1; 
   
    for (const iterator of allProducts) {
        console.log(allProducts)
        
        let getProduct = await fetch(`http://localhost:5102/api/Product/1?productKey=${iterator.productKey}`)
        let productJson = await getProduct.json()
        var product = document.createElement("div");
        product.className = "product";
        product.innerHTML = `<div class="content"><div><h1>${productJson.title}</h1><h2>${productJson.price}</h2></div><div class ="counter"><select name="counter" id="counter"><option value="one">1</option><option value="two">2</option><option value="three">3</option><option value="four">4</option><option value="five">5</option></select></div><div class="cop"><img class="deleteCart" src='../trash-bin.png'></div></div>`;
        price += productJson.price;
        products.appendChild(product);
        document.querySelectorAll(".deleteCart").forEach(element => {
            
            element.addEventListener("click", async () => {
                let userId = sessionStorage.getItem("usersKey")
            userId = userId.toString()
            let deleteUrl = `http://localhost:5102/api/Cart/${userId}` 
                let response = await fetch(deleteUrl,{
                    method: "DELETE",
                    headers: {"Content-Type":"application/json"}
                });
                window.location.href = window.location.href;
            })
        })
    } 

    
    
    
    var priceDiv = document.createElement("div");
    priceDiv.className="totalPrice";
    totalPrice.innerHTML = '<h2>Price:</h2>'+price+' ₺ ';
}
getAllCarts();