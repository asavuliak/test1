Feature: Complete review for hotel

@mytag
Scenario:As an end user I wanto to complete review for hotel
	Given end user navigates to 'https://www.phptravels.net' website
	When end user enters credentials for login
	| login               | password |
	| user@phptravels.com | demouser |
	Then hotel is displayed
	When end user complete review form for hotel 'Hurghada Sunset Desert Safari'
	| clean | staff | reviews                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
	| 10    | 2     | Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. |
	When end user navigates to invoice page for hotel 'Hurghada Sunset Desert Safari'
	Then invoice page with correct data is displayed
	| DepositNow | Tax&VAT | TotalAmount |
	| 30.80      | 28      | 308         |