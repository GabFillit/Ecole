FROM microsoft/dotnet:2.1-sdk AS base
WORKDIR /app
EXPOSE 35396
EXPOSE 44352

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Tunder.API/Tunder.API.csproj Tunder.API/
COPY Data/Data.csproj Data/
RUN dotnet restore Tunder.API/Tunder.API.csproj
COPY . .
WORKDIR /src/Tunder.API
RUN dotnet build Tunder.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Tunder.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "Tunder.API.dll"]
