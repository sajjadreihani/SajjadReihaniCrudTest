That was a test project for BasketAsia Company

Test Details :

Create a simple CRUD application with ASP NET Core that implements the below model:
Customer {
FirstName
LastName
DateOfBirth
PhoneNumber
Email
BankAccountNumber
}

1. It must be a Docker-compose project that loads database service automatically.
2. Domain model must be in a separate project
3. During Create; validate the phone number to be a valid mobile number only.
4. Store phone number in database with minimized space storage (choose varchar, or
ulong whichever store less space).
5. You can use MVC Razor or Blazor UI is a plus.
6. You can also use intl-tel-input at front-end to validate the number as user type : https://intl-tel-input.com
7. You can use Google LibPhoneNumber to validate number at backend: : https://github.com/google/libphonenumber
8. Email must be unique in the database
9. a combination of FirstName, LastName, and DOB must be unique in the database (in
other words: users cannot insert a duplicate record regardless of case sensitivity with
duplicate first-name, last-name and date of birth).
10. Tdd and Bdd is a must!
