# Springly Language (Currently under development 🚧)
![.NET Core](https://github.com/Springly-lang/springly-cli/workflows/.NET%20Core/badge.svg)


## Introduction
Springly is a scripting language that brings **Test Driven Development** practices into the end to end testing world!

## Setup using Command Line
- Download and Install the Springly tool.
- Open the command line and type:
  ```
  springly --version
  ```
  This should display the installed version of the application.
- Now Create a new file named `first-test.spr` with following content:
  ```
  test case 'My First Springly Script!'
    # This will opens the chrome browser
    open 'chrome' browser
    
    # navigates to the Google home page
    navigate to 'https://www.google.com'

    # and closes it...
    close 'chrome' browser
  ```
  And save the changes.
- In the terminal type:
  ```
  springly run first-test-spr
  ```
  This should run the script and as result, you should see the Google Chrome browser opens, navgates to the Google home page and then closes.


## Setup using Visual Studio Code

- Install Visual Studio Code
- Install the Springly Language Service extension
- Create a new file named `first-test.spr` with following content:
  ```
  test case 'My First Springly Script!'
    # This will opens the chrome browser
    open 'chrome' browser
    
    # navigates to the Google home page
    navigate to 'https://www.google.com'

    # and closes it...
    close 'chrome' browser
  ```
- And save it
- Now hit the `F5` button. This should run the script and as result, you should see the Google Chrome browser opens, navgates to the Google home page and then closes.


# Visual Studio Code Extension
By the way, check out our [Visual Studio Code extension for Springly!](https://marketplace.visualstudio.com/items?itemName=Springly.springly-laguage-service). It provides syntax highlighting for the Springly language.
