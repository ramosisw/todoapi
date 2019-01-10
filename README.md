# TodoAPI

Repositorio de ejemplo utilizando 
* ASP.NET core 2.1
* Docker & Docker-compose
* MySql 5.7 / MySql 5.5 (para RaspberryPi)

# Como probar
Esta opción compilara los fuentes y generara las imagenes.

## Compilado
```sh
$ git clone https://github.com/ramosisw/todoapi.git
$ cd todoapi
$ docker-compose up --build
```

## Docker hub
Esta opcion obtendra las imagenes ya compiladas desde https://hub.docker.com/r/ramosisw/todoapi/tags

```sh
$ git clone https://github.com/ramosisw/todoapi.git
$ cd todoapi/hub.docker.com
$ docker-compose up
```
