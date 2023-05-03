#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TestService1/TestService1.csproj", "TestService1/"]
RUN dotnet restore "TestService1/TestService1.csproj"
COPY . .
WORKDIR "/src/TestService1"
RUN dotnet build "TestService1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestService1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestService1.dll"]