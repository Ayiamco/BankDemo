#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BE/src/InterBankSettlement.Api/Code/InterBankSettlement.Api/InterBankSettlement.Api.csproj", "BE/src/InterBankSettlement.Api/Code/InterBankSettlement.Api/"]
RUN dotnet restore "BE/src/InterBankSettlement.Api/Code/InterBankSettlement.Api/InterBankSettlement.Api.csproj"
COPY . .
WORKDIR "/src/BE/src/InterBankSettlement.Api/Code/InterBankSettlement.Api"
RUN dotnet build "InterBankSettlement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterBankSettlement.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterBankSettlement.Api.dll"]