Feature: OrderSummaryTests
	In order to validate an API response
	As a test engineer
	I want to retrieve orders with different numbers of items

Scenario Outline: Retrieve orders with different numbers of items
	Given I have <itemCount> items in my order
	When I view the checkout summary
	Then there is a <discountPercentage> discount applied
Examples: 
| itemCount | discountPercentage |
| 0         | 0                  |
| 10        | 0                  |
| 11        | .05                |
| 20        | .05                |
| 21        | .1                 |
| 30        | .1                 |
| 31        | .2                 |
| 32        | .2                 |
