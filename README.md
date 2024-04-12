# LibroExpress - Tienda de Libros Online
> HADA- Práctica Grupal

## Datos Grupo
### Integrantes del grupo

| Nombre        | Apellidos         | DNI           |
|---------------|-------------------|---------------|
| Aitana        | Cantó Rico        | DNI000001     |
| Rafael        | Carballo Lorenzo  | DNI000002     |
| Bruno         | Vilella Martínez  | DNI000003     |
| Darío         | Pastor Fuentes    | DNI000004     |
| Alberto       | Boronat López     | DNI000005     |
| Manuel José   | Tornero Fuster    | DNI000006     |

### Descripción
La aplicación web que implementaremos es una **tienda online de libros**. En nuestra tienda online habrá **tres tipos de usuarios**, de esta categoría dependrán los permisos que este usuario tenga en la web.

En primer lugar, los **usuarios no registrados** que podrán visualizar los productos y añadirlos al carrito. Después, los **usuarios registrados** que podrán hacer lo mismo que los anteriores y además realizar pedidos y acceder al estado de su pedido, entre otras cosas. Por último, los **administradores de la web** que podrán controlar el stock, añadir productos y eliminarlos si es necesario.

### Parte Pública
> Funcionalidad de la parte pública de la web (sin estar registrado).
- Ver el listado de productos.

- Conocer las especificaciones y ficha técnica de cada producto.
- Buscar o filtrar en el listado de productos.
- Añadir productos al carrito.
- Posibilidad de registrarse en la web.

### Listado EN Pública
- **ENProducto**: Representa los libros disponibles para la venta en la tienda.
- **ENCategoría**: Categorías a las que pertenecen los libros para facilitar la búsqueda.
- **ENUsuario**: Usuarios no registrados que visitan la tienda y pueden añadir productos al carrito.
- **ENCarrito**: Carrito de compras que contiene los productos seleccionados por el usuario.
- **ENLinCarrito**: Relación entre el carrito de compras y los productos seleccionados.
- **ENOfertas**: Ofertas especiales disponibles para los usuarios públicos.


### Parte Privada
> Funcionalidad de la parte privada de la web (una vez registrado)
- Hacer pedidos.

- Ver el estado de los pedidos realizados.
- Suscribirse a diferentes paquetes en los que recibirán libros de forma mensual o anual.
- Programa de fidelización donde los usuarios puedan acumular puntos por cada compra realizada y luego canjear esos puntos por descuentos o productos gratuitos.
- Si eres administrador, añadir o eliminar productos y controlar el stock.

### Listado EN Privada
- **ENPedido**: Pedidos realizados por los usuarios registrados.
- **ENLinPedido**: Relación entre el pedido y los productos seleccionados.
- **ENSuscripción**: Suscripciones a paquetes de libros mensuales o anuales.
- **ENPaquete**: Paquetes de libros disponibles para suscripción.
- **ENPuntos**: Puntos acumulados por los usuarios por compras realizadas.
- **ENTransportista**: Información sobre la empresa de transporte encargada de la entrega.
- **ENTracking**: Seguimiento de los pedidos en tiempo real.
- **ENReseña**: Reseñas y valoraciones de los productos realizadas por los usuarios.

### Posibles mejoras
- Añadir una sección biblioteca en la que también se puedan alquilar libros por determinado tiempo, el precio de alquiler dependerá de este tiempo.

- Implementar un chat de atención al cliente con inteligencia artificial para una mejor experiencia de usuario.

- Mostrar en tiempo real la ubicación de los pedidos mediante una integración con Google Maps.

- Recomendaciones personalizadas: Utilizar algoritmos de recomendación basados en el historial de compras de los usuarios para ofrecer recomendaciones personalizadas de libros que podrían interesarles.

- Integración con redes sociales: Permitir a los usuarios compartir sus compras, reseñas y listas de deseos en redes sociales como Facebook, Twitter o Instagram, lo que puede ayudar a aumentar la visibilidad de la tienda y atraer a nuevos clientes.