FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TecNM.Proyecto.Api/TecNM.Proyecto.Api.csproj", "TecNM.Proyecto.Api/"]
RUN dotnet restore "TecNM.Proyecto.Api/TecNM.Proyecto.Api.csproj"
COPY . .
WORKDIR "/src/TecNM.Proyecto.Api"
RUN dotnet build "TecNM.Proyecto.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TecNM.Proyecto.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TecNM.Proyecto.Api.dll"]
