using Xunit;
using my_solution;

namespace my_solution.Tests;

// TODO: Add your test code here
public class ExampleTests
{
    [Fact]
    public void ExampleTest()
    {
        // Arrange
        var example = new ExampleClass();
        
        // Act
        int result = example.ExampleMethod(1, 2);
        
        // Assert
        Assert.Equal(3, result);
    }
}
