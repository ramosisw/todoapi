FROM microsoft/dotnet:2.1-sdk AS build-env
## Can be Debug or Release.
ARG BUILD_CONFIG=Debug
ARG BUILDER_VERSION=0.0.1
LABEL maintainer=ramos.isw@gmail.com \
    Name=webapp-build-${BUILD_CONFIG} \
    Version=${BUILDER_VERSION}
## Will be the path mapped to the external volume.
ARG BUILD_LOCATION=/app/out
ENV NUGET_XMLDOC_MODE skip
WORKDIR /app

## Get nodejs to build frontend ReactJs
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

COPY *.csproj .
RUN dotnet restore
COPY . /app
RUN dotnet publish -r linux-arm --output ${BUILD_LOCATION} --configuration ${BUILD_CONFIG}