FROM microsoft/dotnet:2.1-sdk AS build-env
## Can be Debug or Release.
ARG BUILD_CONFIG=Debug
ARG BUILDER_VERSION=0.0.1
ARG BUILD_LOCATION=/app/out
LABEL maintainer=ramos.isw@gmail.com \
    Name=webapp-build-${BUILD_CONFIG} \
    Version=${BUILDER_VERSION}
## Will be the path mapped to the external volume.


WORKDIR /app

## Get nodejs to build frontend ReactJs
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -r linux-arm -c ${BUILD_CONFIG} -o ${BUILD_LOCATION}

# Build runtime image
FROM microsoft/dotnet:2.1.6-runtime-stretch-slim-arm32v7
WORKDIR /app
ARG URL_HTTP_INT_PORT=1880
COPY --from=build-env ${BUILD_LOCATION} .
ENV NUGET_XMLDOC_MODE skip
ENV ASPNETCORE_URLS http://*:${URL_HTTP_INT_PORT}
ENTRYPOINT ["dotnet", "TodoAPI.dll"]