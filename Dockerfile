#need latest docker for this to work.
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["stembowl.csproj", "./"]
RUN dotnet restore "./stembowl.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./stembowl.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "./stembowl.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "./stembowl.dll"]
