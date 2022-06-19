import {guidGenerator} from '../helpers/guidGenerator.js'
let registerButton = document.getElementById("register")
let url = "http://localhost:5102/api/User"

registerButton.addEventListener("click", async (e) => {
    let userKey = guidGenerator();
    e.preventDefault();
    let email = document.getElementById("email").value
    let password = document.getElementById("password").value
    let user = {
        "rowState": 12,
        "usersKey": userKey,
        "userType": "normal",
        "email": email,
        "password": password,
    }
    let send = await fetch(url, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    }).then((response) => {
        console.log(response)
        if (response.status == 200){window.location.href = "../login/login.html"}
    })

})