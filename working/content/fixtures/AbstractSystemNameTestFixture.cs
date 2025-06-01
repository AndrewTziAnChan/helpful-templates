[TestFixture]
public abstract class AbstractSystemNameTestFixture
{
    protected abstract ISystemName GetSystemName();

    [Test]
    public void MethodGiven_ScenarioEvent_ExpectedOutcome()
    {
        // Arrange/Given
        const string expected = "expected";
        var concreteObject = GetSystemName();

        // Act/When
        var actual = concreteObject.Method();

        // Assert/Then
        Assert.That(actual, Is.EqualTo(expected));
    }
}

public class BaseSystemNameTestFixture : AbstractSystemNameTestFixture
{
    protected override ISystemName GetSystemName()
    {
        return new FakeSystemName();
    }
}

public class FakeSystemName : ISystemName
{
    public object Method()
    {
        return "expected";
    }
}

public interface ISystemName
{
    object Method();
}