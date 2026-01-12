# C# 3.0 - Additional Samples

Extra demos that dive deeper into C# 3.0 beyond the core set (P57–P64).

## Projects
- **P57_ImplicitlyTypedArrays** — `new[] { ... }` element type inference.
- **P58_LINQJoins** — `join` and `group join` with anonymous projections.
- **P59_LINQOrderLet** — `let`, `orderby`/`thenby` multiple keys.
- **P60_ClosuresAndCapturedVariables** — Classic closure-capture pitfall + fix.
- **P61_ExpressionTreesVsDelegates** — Difference + simple tree rewrite.
- **P62_ExtensionMethodsGenerics** — Generic extension methods with chaining.
- **P63_LinqToXml** — LINQ to XML with `XDocument`/`XElement`.
- **P64_QueryContinuationInto** — Using `into` to continue queries after `group`.

## Build
```bash
dotnet restore
dotnet build
dotnet run --project P53_ImplicitlyTypedArrays
```
Targets `.NET 10.0` with `<LangVersion>3</LangVersion>`.
