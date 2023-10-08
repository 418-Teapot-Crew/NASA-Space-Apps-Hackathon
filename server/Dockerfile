#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Teapot.WebAPI/Teapot.WebAPI.csproj", "Teapot.WebAPI/"]
COPY ["Business/Teapot.Business/Teapot.Business.csproj", "Business/Teapot.Business/"]
COPY ["Core/Teapot.Core/Teapot.Core.csproj", "Core/Teapot.Core/"]
COPY ["DataAccess/Teapot.DataAccess/Teapot.DataAccess.csproj", "DataAccess/Teapot.DataAccess/"]
COPY ["Entities/Teapot.Entities/Teapot.Entities.csproj", "Entities/Teapot.Entities/"]
RUN dotnet restore "Teapot.WebAPI/Teapot.WebAPI.csproj"
COPY . .
WORKDIR "/src/Teapot.WebAPI"
RUN dotnet build "Teapot.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Teapot.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Teapot.WebAPI.dll"]