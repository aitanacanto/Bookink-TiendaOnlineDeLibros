# LibroExpress - Tienda de Libros Online
> HADA- Práctica Grupal

## Datos Grupo
### Integrantes del grupo

| Nombre        | Apellidos         | DNI       | Entidades asociadas          |
|---------------|-------------------|-----------|------------------------------|
| Aitana        | Cantó Rico        | DNI000001 | ENTienePaquete, ENPaquete    |
| Rafael        | Carballo Lorenzo  | DNI000002 | ENPedido, ENLinPedido_pa     |
| Bruno         | Vilella Martínez  | DNI000003 | ENCarrito, ENLinCarrito      |
| Darío         | Pastor Fuentes    | DNI000004 | EnProducto, EnLinPedido      |
| Alberto       | Boronat López     | DNI000005 | ENCategoria, EnTieneCategoria|
| Manuel José   | Tornero Fuster    | DNI000006 | ENUsuario, ENReseña          |
| Jorge         | Paredes Soler     | DNI000007 | ENDireccion, ENTieneDireccion|

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
- **ENTieneCategoria**: Relación que indica qué productos están asociados a una categoría.
- **ENUsuario**: Usuarios no registrados que visitan la tienda y pueden añadir productos al carrito.
- **ENCarrito**: Carrito de compras que contiene los productos seleccionados por el usuario.
- **ENLinCarrito**: Relación entre el carrito de compras y los productos seleccionados.
- **ENPaquete**: Paquetes de libros disponibles.
- **ENTienePaquete**: Relación que indica qué productos están incluidos en un paquete.


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
- **ENLinPedido_pa**: Relación entre el pedido y los paquetes de productos.
- **ENReseña**: Reseñas y valoraciones de los productos realizadas por los usuarios.
- **ENDireccion**: Información de dirección asociada a un usuario.
- **ENTieneDireccion**: Relación que indica qué usuarios están asociados a una dirección.


### Posibles mejoras
- Añadir una sección biblioteca en la que también se puedan alquilar libros por determinado tiempo, el precio de alquiler dependerá de este tiempo.

- Implementar un chat de atención al cliente con inteligencia artificial para una mejor experiencia de usuario.

- Mostrar en tiempo real la ubicación de los pedidos mediante una integración con Google Maps.

- Recomendaciones personalizadas: Utilizar algoritmos de recomendación basados en el historial de compras de los usuarios para ofrecer recomendaciones personalizadas de libros que podrían interesarles.

- Integración con redes sociales: Permitir a los usuarios compartir sus compras, reseñas y listas de deseos en redes sociales como Facebook, Twitter o Instagram, lo que puede ayudar a aumentar la visibilidad de la tienda y atraer a nuevos clientes.

### Base de Datos
![Base de Datos](BaseDeDatos.png)
*También, está disponible en pdf en el archivo ![bbdd.pdf](bbdd.pdf).*

### Implementaciones de cada integrante:

### - Aitana Cantó Rico:
- **EN/CAD Implementados:** ENPaquete, CADPaquete, ENTienePaquete, CADTienePaquete
- **Páginas aspx implementadas:** paquete.aspx, adminPaquete.aspx, SiteMaster
- **Otras tareas:** Creación script bbdd.
- **Mejora Obligatoria Implementada:** Filtrado de libros por nombre, categoría, etc...
- **Colaboraciones:** mainPage.aspx, catalogo.aspx

### - Rafael Carballo Lorenzo:
- **EN/CAD Implementados:**
- **Páginas aspx implementadas:**
- **Otras tareas:** 
- **Mejora Obligatoria Implementada:**
- **Colaboraciones:**

### - Bruno Vilella Martínez:

- **EN/CAD Implementados:** ENCarrito, CadCarrito
- **Páginas aspx implementadas:** carrito.aspx
- **Otras tareas:** Base de Datos
- **Mejora Obligatoria Implementada:** Top 8 Ventas por Categoria
- **Colaboraciones:** catalogo.aspx implementación de top8VentasCategoria,  
ENCategoria y CADCategoria implementación de top8VentasCategoria, ENProducto y CadProducto lo referente a carrito que creo que fue un constructor, producto.aspx lo referente a carrito, mainpage.aspx lo referente a carrito

### - Darío Pastor Fuentes:

- **EN/CAD Implementados:**
- **Páginas aspx implementadas:**
- **Otras tareas:** 
- **Mejora Obligatoria Implementada:**
- **Colaboraciones:**

### - Alberto Boronat López: 
- **EN/CAD Implementados:**
- **Páginas aspx implementadas:**
- **Otras tareas:** 
- **Mejora Obligatoria Implementada:**
- **Colaboraciones:**

### - Manuel José Tornero Fuster: 
- **EN/CAD Implementados:** ENUsuario, ENReseña, CADUsuario, CADReseña
- **Páginas aspx implementadas:** login.aspx, register.aspx, 
- **Otras tareas:** Ayuda en la bbdd
- **Mejora Obligatoria Implementada:**
- **Colaboraciones:** usuario.aspx, implementación de reseñas en producto.aspx, adminusuario.aspx

### - Jorge Paredes Soler: 
- **EN/CAD Implementados:**
- **Páginas aspx implementadas:**
- **Otras tareas:** 
- **Mejora Obligatoria Implementada:**
- **Colaboraciones:**

# Entrega 01 Propuesta - Comentarios

La web que proponeis es correcta y cumple con todos los requisitos. La descripción tiene todo lo que se pide. El git también está perfecto. 

Os pediria que para entender mejor que va a hacer cada uno, añadais a la tabla inicial que EN y/o funcionalidades va a hacer cada uno.

Gracias y buen trabajo, seguro que sale algo genial.
