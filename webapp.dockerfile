FROM microsoft/dotnet:2.1-aspnetcore-runtime as runtime
FROM microsoft/dotnet:2.1-sdk AS build
#Define default args
ARG WEBAPP_VERSION=1.0.0
ARG URL_HTTP_INT_PORT=80

LABEL maintainer=ramos.isw@gmail.com \
    Name=ramosisw_todoapi_release \
    Version=${WEBAPP_VERSION}
## Will be the path mapped to the external volume.
WORKDIR /build

## Get nodejs to build frontend ReactJs
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o publish

# Build runtime image
FROM runtime
WORKDIR /app
COPY --from=build /build/publish .
ENV NUGET_XMLDOC_MODE skip
ENV ASPNETCORE_ENVIRONMENT Production
ENV ASPNETCORE_URLS http://*:${URL_HTTP_INT_PORT}
ENTRYPOINT ["dotnet", "TodoAPI.dll"]