# .NET Template Pack

A personal set of **`dotnet new`** project templates that capture growing opinions.

The goal is simple:

* **Bootstrap quickly** – spin up a test fixtures or editorconfig (happens more often than I expected 🙁).

---

## Quick start

```bash
# 1. Grab the templates
git clone https://github.com/AndrewTziAnChan/helpful-templates.git
cd helpful-templates

# 2. Install locally
dotnet new install .

# 3. See what you got
dotnet new list abtest
dotnet new list csty

# 4. Generate a new abstract test
dotnet new abtest -S SomeService --force

# 5. Generate code style files like .editorconfig and Jetbrains DotSettings
dotnet new csty -S SomeSolutionToReplace --force
```

---

## Example generated test fixture

```csharp
[TestFixture]
public abstract class AbstractSomeServiceTest
{
    protected abstract ISomeService GetSomeService();

    [Test]
    public void MethodGiven_ScenarioEvent_ExpectedOutcome()
    {
        // Arrange/Given
        const string expected = "expected";
        var concreteObject = GetSomeService();

        // Act/When
        var actual = concreteObject.Method();

        // Assert/Then
        Assert.That(actual, Is.EqualTo(expected));
    }
}

public class BaseSomeServiceTest : AbstractSomeServiceTest
{
    protected override ISomeService GetSomeService()
    {
        return new FakeSomeService();
    }
}

public class FakeSomeService : ISomeService
{
    public object Method()
    {
        return "expected";
    }
}

public interface ISomeService
{
    object Method();
}
```

---

## EditorConfig Reasoning

Opinions

- Projects should actually enforce preference for explicit types when possible since the type will be defined explicity in code rather than inferred. At the very least, 'var' should only be used when evident. Without explicit types, code is harder to read and maintain when looking at comparisons and pull requests.
- Curly braces can be omitted unless any body in the series of blocks (like in switch/ifelse conditionals) are multi-statement. (Experimental)
