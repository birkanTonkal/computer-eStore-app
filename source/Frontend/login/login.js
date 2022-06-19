
let count = 1
let url = "http://localhost:5102/api/User"
let loginButton = document.getElementById("login")


loginButton.addEventListener("click", async () => {
    let email = document.getElementById("email")
    let password = document.getElementById("password").value
    let response = await fetch(url)
    let allUsers = await response.json()
    for (const iterator of allUsers) {
       window.location.href = "/Frontend/index.html"
       if (iterator.password == password && iterator.email == email) {
        console.log(window.location.href)
       }
    }
})

const element = document.querySelector('form');
element.addEventListener('submit', event => {
  event.preventDefault();
});
