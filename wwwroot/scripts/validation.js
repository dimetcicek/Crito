function validateForm(){

   var isValidName = validateName();
   var isValidEmail = validateEmail();
   var isValidMessage = validateMessage();

   var name = document.getElementById('contact-name');
   var email = document.getElementById('contact-email');
   var message = document.getElementById('contact-message');

   name.classList.remove("errorInput");

    if(!isValidName) {
        name.classList.add("errorInput");
    }

   email.classList.remove("errorInput");

    if(!isValidEmail) {
        email.classList.add("errorInput");
    }

   message.classList.remove("errorInput");

    if(!isValidMessage) {
        message.classList.add("errorInput");
    }
    

   if(isValidName && isValidEmail && isValidMessage) {
    var formContainer = document.getElementById('formContainer');
    formContainer.setAttribute("hidden", true);

    var thankYouMessage = document.getElementById('thankYouMessage');
    thankYouMessage.removeAttribute("hidden");
   }
}

function validateName(){
    var name = document.getElementById('contact-name');
    const regEx = /^[a-zåäöA-ZÅÄÖ|\s|-]+$/

    return regEx.test(name.value);
}

function validateEmail(){
   var email = document.getElementById('contact-email');
   const regEx = /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/

   return regEx.test(email.value);
}

function validateMessage(){
   var message = document.getElementById('contact-message');
   
   return message.value.length > 0;
}
