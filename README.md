# On XUnit Parallelism and ITestOutputHelper

XUnit provides the interface ITestOutputHelper to capture output
from code under test. This can be useful when exploring a problem.
An example of how to use the interface is showm in the TestBase base class for
all tests in this project in MyLibTests\TestBase.cs.

Problems can occur if running multiple tests at a time with code that write 
a lot of information to the console at once. Xunit runs with
parallelism by default. Essentially what appears to happen is that test output 
continues to be written even when there is no active test. This produces the following error:

    Error Message:
    System.InvalidOperationException : There is no currently active test.

The error can be worked around by disabling parallelism. Parallelism can be
disabled by adding xunit.runner.json to test test project containing:

    {
    "parallelizeAssembly": false,
    "parallelizeTestCollections": false
    }

And referencing the file in the test .csproj using the following:

    <ItemGroup>
        <None Update="xunit.runner.json"> 
            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </None>
    </ItemGroup>

The test can be run (and the error reproduced) with the following:

    dotnet test --logger "console;verbosity=detailed"

The logger parameter is not necessary to trigger the error.
