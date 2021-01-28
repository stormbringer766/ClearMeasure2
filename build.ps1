dotnet restore 
dotnet test FizzBuzz.Tests/FizzBuzz.Tests.csproj --no-restore -c Debug /p:CollectCoverage=true
dotnet pack FizzBuzz/FizzBuzz.csproj -c Release --no-restore --include-source --include-symbols