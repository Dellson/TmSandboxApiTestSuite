# TmSandboxApiTestSuite
This solution contains a basic structure to perform series of API tests.

### API endpoint under investigation
https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false

### Acceptance criteria
1. `Name` = `"Carbon credits"`
2. `CanRelist` = `true`
3. The `Promotions` element with `Name` = `"Gallery"` has a description `Description` that contains the text `"Good position in category"`

### Prerequisites
.NET 6.0

### Running tests
There are multiple ways to execute tests:
* Run all tests through a CLI with the command `dotnet test`. To run specific tests, use the `dotnet test --filter <EXPRESSION>` command, for example `dotnet test --filter Name~GetCategory6327Details_WhenCatalogueIsFalse_ReturnsCorrectName`. See Microsoft docs for details - https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test.
* Run test through the Visual Studio's Test Explorer.

### Notes
Tests are meant to check only the acceptance criteria.

##### Configuration
`CategoryDetailsTests` reads a single configuration file, which provides the base url.
If the tests were deployed and run on different environments, an environmental variable containing specific base url could be provided in the `ConfigurationBuilder`.

The provided solution does not read environmental variables to avoid additional setup when running tests on another machine.

##### Acceptance criteria considerations
It should be noted that information regarding the third criteria is not entirely clear - it is not stated whether the `Name` element with value `Gallery` should appear exactly once or whether duplicates are allowed.

That is why there are two tests associated with the third criteria. Both tests assert correctness of the description. Additionally:
* `GetCategory6327Details_WhenCatalogueIsFalse_ReturnsCorrectDescriptionForDistinctPromotionsGallery` asserts that there is only one element with value `Gallery`.
* `GetCategory6327Details_WhenCatalogueIsFalse_ReturnsCorrectDescriptionForEachPromotionsGallery` asserts that every `Gallery` element contains proper description.

In the real life scenario the acceptance criteria should be refined with a business analyst / a product owner and only one of the aforementioned tests would be used.
