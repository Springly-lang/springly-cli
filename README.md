# Springly-cli
![.NET Core](https://github.com/Springly-lang/springly-cli/workflows/.NET%20Core/badge.svg)

# This project is still under development. 🚧

### Motivation
Writing automation tests for web applications have many challenges like:

* Most QA members don't have enough skills in programming languages or web development technologies.

* Current automation tests are tightly coupled with the design and small changes in design can break related automated tests.

* QA's responsibilites and concerns are different from design and development.

The solution is, implementing a language that resolves those challenges by separating each team's responsibilities. Springly offers:

* An easy to write language that almost anyone with minimum skills in web and English language can learn and understand.

* Decoupling design and web knowledge from test scenario scripts so changes in one have minimum effect on the other party.

* QA members can focus on writing automation tests (even before the actual implementation!) and web developers can continue doing anything that is directly related to the implementation details.

Here is a sample Springly script:
```
use "google-page-definitions.json"

test case "Search Google"
	// Arrange
	open chrome browser
	navigate to "https://google.com"
	
	// Act
	type "pluto" in @search-box
	click on @search-button

	// Assert
	expect @url contains "https://www.google.com/search?q=pluto"
	expect @search-result-title contains "About 78,300,000 results"
	expect 1st @search-result-tile-title contains "pluto"

	close browser
```

And `google-page-definitions.json` file that contains:
```json
{
	"search-box":{
		"css-selector": "input[name='q']"
	},
	"search-button":{
		"css-selector": "input[name='btnK'][type='submit']"
	},
	"search-result-title":{
		"css-selector": "div#resultStats"
	},
	"search-result-tile-title":{
		"css-selector": "div.rc a"
	}
}
```

Easy, isn't it?

### Visual Studio Code Extension
By the way, check out our [Visual Studio Code extension for Springly!](https://marketplace.visualstudio.com/items?itemName=Springly.springly-laguage-service). It provides syntax highlighting for the Springly language.
