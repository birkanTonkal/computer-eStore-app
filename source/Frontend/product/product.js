let addProduct = document.getElementById("addProduct");
let url = "http://localhost:5102/api/Product";
addProduct.addEventListener("click", () => {
    let title = document.getElementById("title").value;
    let price = document.getElementById("price").value;
    let graphicCard = document.getElementById("graphicCard").value;
    let type = document.getElementById("type").value;
    let cpu = document.getElementById("cpu").value;
    let ram = document.getElementById("ram").value;
    let stock = document.getElementById("stock").value;

    let data = {
        "rowState": 1,
        "productKey": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "title": title,
        "price": price,
        "type": type,
        "dateCreated": "2022-06-19T13:06:46.782Z",
        "graphicCard": graphicCard,
        "cpu": cpu,
        "ram": ram,
        "otherFeatures": otherFeatures,
        "stock": stock
    }

    

})