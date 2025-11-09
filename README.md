# BACKEND SCHOOLME

## COMANDOS DE MIGRACION

1. Para crear la migración
 ```
    Add-Migration dbSchoolMe -Project Entity -StartupProject Web -Context AplicationDbContext
 
 ```
 
2. Para crear la db 
 ```
    Update-Database -Context AplicationDbContext
 
 ```



Para poder desplegar de forma local la api, debe tener instalado el motor de base de datos de **Posgrest 17**


## Migraciones

Si a la hora de bajar el artefacto de software, en la capa de entity tiene la carpeta de Migration, eliminela, para evitar errores, despues de eso puede seguir con los paso

1. Crear la migración
 ``` 
    Add-Migration dbSchoolMe -Project Entity -StartupProject Web -Context AplicationDbContext

```

2. Crea la base de datos
 
```
    Update-Database -Context AplicationDbContext

```