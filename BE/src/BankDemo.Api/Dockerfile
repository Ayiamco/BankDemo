#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY . ./BankDemo
COPY ../Shared ./Shared
RUN dotnet restore "BankDemo.Api.csproj"  --disable-parallel
RUN dotnet publish "BankDemo.Api.csproj" -c Release -o /app --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "BankDemo.Api.dll"]