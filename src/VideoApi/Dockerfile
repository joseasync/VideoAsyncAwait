FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CancelaAntesDeConsumir/CancelaAntesDeConsumir.csproj", "CancelaAntesDeConsumir/"]
RUN dotnet restore "CancelaAntesDeConsumir/CancelaAntesDeConsumir.csproj"
COPY . .
WORKDIR "/src/CancelaAntesDeConsumir"
RUN dotnet build "CancelaAntesDeConsumir.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CancelaAntesDeConsumir.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CancelaAntesDeConsumir.dll"]
