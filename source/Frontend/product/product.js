import {guidGenerator} from '../helpers/guidGenerator.js'
console.log("sas")
let addProduct = document.getElementById("addProduct");
let url = "http://localhost:5102/api/Product";
addProduct.addEventListener("click", async () => {
    let userKey = guidGenerator();
    let title = document.getElementById("title").value;
    let price = document.getElementById("price").value;
    let graphicCard = document.getElementById("graphicCard").value;
    let type = document.getElementById("type").value;
    let cpu = document.getElementById("cpu").value;
    let ram = document.getElementById("ram").value;
    let stock = document.getElementById("stock").value;
    console.log(stock)
    let product = {
        "rowState": 1,
        "productKey":userKey,
        "title": title,
        "price": price,
        "type": type,
        /* "dateCreated": "2022-06-19T13:06:46.782Z", */
        "graphicCard": graphicCard,
        "cpu": cpu,
        "ram": ram,
        "otherFeatures": otherFeatures,
        "stock": stock
    }

    let send = await fetch(url, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(product)
    }).then((response) => {
        console.log(response)
        if (response.status == 200){console.log("sa")}
    })

})