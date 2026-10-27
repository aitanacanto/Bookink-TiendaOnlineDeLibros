# Datos de ejemplo

Ejecuta `01-schema.sql` y después `02-catalogo.sql` en una base SQL Server nueva y vacía. El esquema y el catálogo proceden de los scripts de la práctica original; los datos de cuentas, direcciones y reseñas de usuarios se han separado de la distribución pública.

`catalogo-descripciones.txt` conserva las notas descriptivas originales de los libros. El modelo relacional está en `docs/database/`.

Los scripts no son migraciones idempotentes: no deben ejecutarse repetidamente sobre una base con tablas o datos existentes. Los datos de ventas no se incluyen en el catálogo.
