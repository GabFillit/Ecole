FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 35396
EXPOSE 44352

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY tunder.csproj ./
COPY ../Data/Data.csproj ../Data/
RUN dotnet restore /tunder.csproj
COPY . .
WORKDIR /src/
RUN dotnet build tunder.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish tunder.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "tunder.dll"]
