FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Development 

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Aeronave.WebApi/Aeronave.WebApi.csproj", "Aeronave.WebApi/"]
RUN dotnet restore "Aeronave.WebApi/Aeronave.WebApi.csproj"
COPY . .
WORKDIR "/src/Aeronave.WebApi"
RUN dotnet build "Aeronave.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aeronave.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aeronave.WebApi.dll"]
