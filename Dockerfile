#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Src/WebUI/WebUI.csproj", "WebUI/"]
COPY ["Src/Persistences/Persistences.csproj", "Persistences/"]
COPY ["Src/Domain/Domain.csproj", "Domain/"]
COPY ["Src/Application/Application.csproj", "Application/"]
COPY ["Src/Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "WebUI/WebUI.csproj"
COPY ["Src", ""]
WORKDIR "/src/WebUI"
RUN dotnet build "WebUI.csproj" -c Release  -o /app/build
RUN chmod +x "entrypoint.sh"
CMD /bin/bash "entrypoint.sh"

FROM build AS publish
RUN dotnet publish "WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebUI.dll"]
