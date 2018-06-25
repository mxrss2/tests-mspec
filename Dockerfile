FROM microsoft/dotnet:2.1-sdk-alpine AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /src
COPY dotnet-core-test.csproj ./
RUN dotnet restore 
COPY . .
WORKDIR /src/
RUN dotnet build ./dotnet-core-test.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish dotnet-core-test.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "vstest", "dotnet-core-test.dll", "--Parallel"	]
