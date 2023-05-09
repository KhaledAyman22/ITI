Feature: FizzBuzz
Return Fizz When user enters number divisible by 3

@tag1
Scenario: Print Fizz
	Given User enters number 3
	When Print function is called
	Then "Fizz" should be printed
