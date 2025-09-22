# C# 3.0 — Additional Samples

Extra demos that dive deeper into C# 3.0 beyond the core set (P42–P52).

## Projects
- **P53_ImplicitlyTypedArrays** — `new[] { ... }` element type inference.
- **P54_LINQJoins** — `join` and `group join` with anonymous projections.
- **P55_LINQOrderLet** — `let`, `orderby`/`thenby` multiple keys.
- **P56_ClosuresAndCapturedVariables** — Classic closure-capture pitfall + fix.
- **P57_ExpressionTreesVsDelegates** — Difference + simple tree rewrite.
- **P58_ExtensionMethodsGenerics** — Generic extension methods with chaining.
- **P59_LinqToXml** — LINQ to XML with `XDocument`/`XElement`.
- **P60_QueryContinuationInto** — Using `into` to continue queries after `group`.

## Build
```bash
dotnet restore
dotnet build
dotnet run --project P53_ImplicitlyTypedArrays
```
Targets `.NET 10.0` with `<LangVersion>3</LangVersion>`.
