FROM microsoft/dotnet:2.1-aspnetcore-runtime
ARG WEBAPP_VERSION=0.0.1
LABEL maintainer=ramos.isw@gmail.com \
    Name=webapp \
    Version=${WEBAPP_VERSION}
ARG URL_HTTP_INT_PORT
WORKDIR /app
ENV NUGET_XMLDOC_MODE skip
ENV ASPNETCORE_URLS http://*:${URL_HTTP_INT_PORT}
ENTRYPOINT [ "dotnet", "TodoAPI.dll" ]