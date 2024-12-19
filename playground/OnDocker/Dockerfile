FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

# Install wkhtmltopdf
#RUN apt-get -y update && apt-get -y upgrade
#RUN apt-get -y install wkhtmltopdf
#RUN wkhtmltopdf --version

USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["playground/OnDocker/Html2Pdf.OnDocker.csproj", "playground/OnDocker/"]
RUN dotnet restore "playground/OnDocker/Html2Pdf.OnDocker.csproj"
COPY . .
WORKDIR "/src/playground/OnDocker"
RUN dotnet build "Html2Pdf.OnDocker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Html2Pdf.OnDocker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Html2Pdf.OnDocker.dll"]
