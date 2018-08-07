# Automated-Unit-Tests

Some of the automated unit tests using NUnit & Selenium WebDriver and build with Page Object Model, triple A, fluent assertions.

1.http://flagpedia.net/index - Iterate through a list of countries and take screenshot of each element  
and save it with a specific name 

2.http://services.ce3c.be/ciprg/ - Get all IP Ranges for all countries in the world and save them as .txt

3.https://www.automatetheplanet.com/ - While arriving on a section of the page a list of links is verified  
that each link points out to a section with the same name. IF the hierarchy in the quick navigation section   
is represented in the HTML with h2 and h3 is also asserted.


## Installation
When in visual studio click on rebuild solution. If it's not working :

NUnit
1.	Manage Nuget Packages -> install Nunit + Nunit Test Adapter + Microsoft.Test.SDK + NETStandard.Library
2.	Extensions and updates -> install Nunit Template

Selenium 
1.	Manage Nuget Packages -> install Selenium.Webdriver + Support + ChromeDriver + FluentAssertions

