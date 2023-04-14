FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY . .
RUN dotnet restore "InterBankSettlement.Api.csproj"  --disable-parallel
RUN dotnet publish "InterBankSettlement.Api.csproj" -c Release -o /app --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "InterBankSettlement.Api.dll"]