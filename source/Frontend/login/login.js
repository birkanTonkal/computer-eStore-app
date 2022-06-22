import {guidGenerator} from '../helpers/guidGenerator.js'
let user2 = "null"
let count = 1
let url = "http://localhost:5102/api/User"
const signUpButton = document.getElementById('submitRegister');
const signInButton = document.getElementById('submitLogin');
const container = document.getElementById('container');
const singIn = document.getElementById('signIn');
const singUp = document.getElementById('signUp');

singUp.addEventListener('click', () => {
  container.classList.add("right-panel-active");
});

singIn.addEventListener('click', () => {
  container.classList.remove("right-panel-active");
});

signInButton.addEventListener("click", async (e) => {
    let email = document.getElementById("loginEmail").value
    let password = document.getElementById("loginPassword").value
    let response = await fetch(url)
    let allUsers = await response.json()
    for (const iterator of allUsers) {
      console.log(iterator)

      if (iterator.password == password && iterator.email == email) {
        console.log(iterator.usersKey)
        sessionStorage.setItem('userType', iterator.userType);
        sessionStorage.setItem('usersKey', iterator.usersKey);
        window.location.href = "../home/home.html"
       }
    }
})
signUpButton.addEventListener('click', async (e) => {
  let userKey = guidGenerator();
    e.preventDefault();
    let email = document.getElementById("registerEmail").value
    let password = document.getElementById("registerPassword").value
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
        if (response.status == 200){
          window.location.href = "../login/login.html"
          user2 = user.userType
        }
    })
});
const element = document.querySelector('form');
element.addEventListener('submit', event => {
  event.preventDefault();
});
