# Tyromotion C# stylecop and editorconfig rules

## Usage

Create a `Directory.Build.props` file in the solution folder next to your MyProject.sln.
Add the following lines:
```xml
<Project>
    <Choose>
        <When Condition="$(MSBuildProjectName.ToLowerInvariant().Contains('test')) == 'false'">
            <ItemGroup>
                <PackageReference Include="Tyromotion.CodeStyle" Version="0.1.*" />
                <PackageReference Include="SonarAnalyzer.CSharp" Version="8.53.0.*">
                    <PrivateAssets>all</PrivateAssets>
                    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
                </PackageReference>
                <PackageReference Include="StyleCop.Analyzers" Version="1.1.*">
                    <PrivateAssets>all</PrivateAssets>
                    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
                </PackageReference>
            </ItemGroup>
        </When>
    </Choose>
</Project>
```
The condition disables report generation for any project with "test" in the name.

Rebuild the solution and you should have additional warnings in your build log. All warnings should also be available in `codeanalysis.sarif.json` in each project folder.

# Changelog

- 0.1.0 initial release
- 0.1.1 test ci/cd package push
- 0.1.2 update readme
- 0.1.3 initial rule configuration
- 0.1.4 update rules
- 0.1.5 add .razor to code files
- 0.1.6 update editorconfig rules

