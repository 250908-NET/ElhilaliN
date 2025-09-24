using Xunit;

namespace ProjectManagementApi.Tests;

public class DummyTests
{
    [Fact]
    public void True_ShouldBeTrue()
    {
        // Arrange
        bool value = true;

        // Assert
        Assert.True(value);
    }

    [Fact]
    public void Sum_TwoNumbers_ShouldReturnCorrectResult()
    {
        // Arrange
        int a = 5;
        int b = 3;

        // Act
        int result = a + b;

        // Assert
        Assert.Equal(8, result);
    }
}
