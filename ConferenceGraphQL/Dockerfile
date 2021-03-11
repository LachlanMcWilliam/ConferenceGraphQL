#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ConferenceGraphQL/ConferenceGraphQL.csproj", "ConferenceGraphQL/"]
COPY ["ConferenceGraphQL.Data/ConferenceGraphQL.Data.csproj", "ConferenceGraphQL.Data/"]
RUN dotnet restore "ConferenceGraphQL/ConferenceGraphQL.csproj"
COPY . .
WORKDIR "/src/ConferenceGraphQL"
RUN dotnet build "ConferenceGraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConferenceGraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConferenceGraphQL.dll"]
