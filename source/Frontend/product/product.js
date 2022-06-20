import {guidGenerator} from '../helpers/guidGenerator.js'
let addProduct = document.getElementById("addProduct");
let url = "http://localhost:5102/api/Product";
addProduct.addEventListener("click", async () => {
    let date = new Date().toLocaleString("en-US")
    let userKey = guidGenerator();
    let title = document.getElementById("title").value;
    let price = document.getElementById("price").value;
    price = parseInt(price)
    let graphicCard = document.getElementById("graphicCard").value;
    let type = document.getElementById("type").value;
    let cpu = document.getElementById("cpu").value;
    let ram = document.getElementById("ram").value;
    let stock = document.getElementById("stock").value;
    let otherFeatures = document.getElementById("otherFeatures").value
    stock = parseInt(stock)
    console.log(graphicCard)
    let product = {
        "rowState": 1,
        "productKey":userKey,
        "title": title,
        "price": price,
        "type": type,
        "graphicCard": graphicCard,
        "cpu": cpu,
        "ram": ram,
        "otherFeatures": otherFeatures,
        "stock": stock
    }
    if (sessionStorage.getItem("userType") == "admin") {
        let send = await fetch(url, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(product)
        }).then((response) => {
            console.log(response)
            if (response.status == 200){
                alert("product added successfully!");
                console.log("successfull")}
            
        })
    }
   

})