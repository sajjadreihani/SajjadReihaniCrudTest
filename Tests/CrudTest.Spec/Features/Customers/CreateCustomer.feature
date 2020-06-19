Feature: CreateCustomer
	In order to add new customer
	As a admin
	I want to be able to add customer to database


Scenario: Post Data to UpsertCustomer
	Given We have the following entries
		| Name          | Value             |
	    | FirstName      | test             |
		| LastName   | test      |
		| DateOfBirth   | 15/06/1994      |
		| Email   | test@test.cc      |
		| PhoneNumber   | +989391234567      |
		| BankAccountNumber   | 123456     |
	When I posted data
	Then I get an Unit result
		And there is one result with Email test@test.cc