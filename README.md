# Game´s Attic

Este proyecto va dirigido a coleccionistas de videojuegos que siempre han querido tener acceso a su colección de forma online a través de la web. Estos usuarios podrán recrearse  con las imágenes,contenidos y toda la información relevante sobre sus juegos favoritos..básicamente podrán catalogar su colección y preservar datos sobre sus juegos .
### Analisis Funcional:
El proyecto va a dividirse en varias partes segun la funcionalidad:
  - Registrar un nuevo usuario y poder logarse
  - Mostrar y manipular la colección de videojuegos
  - Administración de usuarios por el administrador

Al **registrar**  una nueva cuenta es un requísito obligatorio que el usuario introduzca un nombre de usuario,dirección de correo electrónico y contraseña.Además los dos primeros deben de ser únicos y no existir anteriormente en la base de datos y la contraseña por seguridad tener un mínimo de seis caractéres.
Para **logarse** el usuario necesita haber registrado una cuenta anteriormente. Y podrá acceder a la aplicación rellenando el nombre de usuario y contraseña con las que se registró. 
Para facilitar la usabilidad se podrá recordar el nombre de usuario para próximos accesos.

&nbsp;
![image](https://user-images.githubusercontent.com/48281298/101494395-91796980-3967-11eb-869d-bbea251b2025.png)
![image](https://user-images.githubusercontent.com/48281298/101493918-f5e7f900-3966-11eb-8530-528f60b7eb27.png)

&nbsp;
La segunda funcionalidad es respecto a los videojuegos.Una vez identificado el usuario automáticamente se le mostrará la colección de videojuegos 'activos' que tiene almacenada en nuestra aplicación.Aparecerá una lista de "portadas de videojuegos" y estarán ordenadas alfabéticamente por el título. **Todos los usuarios se registran con el rol 'user' y esto les dan sólo permiso de ver y manipular su propia colección**.
![image](https://user-images.githubusercontent.com/48281298/101494588-d56c6e80-3967-11eb-8579-2128410210c1.png)
Si el usuario hace click en cualquiera de ellas podrá ver una ficha de detalle del videojuego con todos los datos del mismo.Y en este mismo punto se podrá **editar** ese juego si el usuario necesita modificar algun dato o incluso **desactivar** ese videjuego por lo que dejaría de ser accesible.
Cuando se muestra la colección será siempre visible un botón fijo a la derecha para **añadir** un nuevo videojuego.Para hacerlo se mostrará un formulario donde el usuario podrá incluir la información del videjuego en los distintos campos.Para poder dar de alta es necesario como mínimo que esté relleno el campo del 'título' y 'portada'.
No hay restricciones de campos únicos pues un mismo usuario puede guardar dos juegos con el mismo título..pero en idiomas diferentes por ejemplo..el modelo sería bastante flexible en este sentido. 

Existe un **administrador el cual al identificarse tiene acceso a todos los videojuegos 'activos' de todas las colecciones.A su vez tambien podrá manipular todas ellas e incluso añadir un videojuego**. 
El usuario será informado mediante mensajes tanto en los formularios como por mensajes emergentes si la operación se realizó correctamente o hubo algun problema o error.
&nbsp;
Otra funcionalidad del **administrador es que tiene acceso a un listado de todos los usuarios**.Si estos están activos puede **modificar el rol a 'admin'** y tambien tiene la opción de **desactivarlos**. Por lo contrario si el usuario está desactivado el administrador puede **activarlo** de nuevo.
### Analisis Técnico:
Para el desarrollo de este proyecto se utilizó:

-**MySql como base de datos**. Se implementó una Base de datos con 6 tablas: platform, rol,support,system,user y videogame.Todo los scripts de la creación de la tabla están en **videogamesDLL.txt**

-**Angular para el frontend**. Toda la programación se dividió en componentes para una mejor estructuración y reutilización de los mismos. Es una **spa** donde se han creado dos **guards** : uno para comprobar que estes autenticado y otra para comprobar que tienes rol de administrador. Para **la comunicación** entre el componente **'group-buttons'** con el resto de componentes se hace a traves de **@Input que le indica si es un nuevo videojuego o ya existe** (y así mostrar solo los botones que correspondan) y un ** @Output que emite que botón fue pulsado**. El componente **navbar se comunica con el resto a traves de un observable** que comprueba **si un usuario se ha logado o registrado**.De esta forma muestra de forma actualizada en el navbar el nombre de usuario y las opciones correspondientes dependiendo si su rol es de administrador o usuario. 

-**CSS3 y Boostrap4** para los estilos de la página. se han importado diferentes fuentes de letra y se ha usado los iconos de fontawesome. Para que las alertas fuesen personilazables,bonitas y receptivas se usó **sweetalert2**.   

-**.net core para el backend**.Es una **web api** y se eligió .net core porque es **multiplataforma**.Se ha dividido por capas :**la capa donde el controlador de la aplicación** solo se dedica a recibir la información.Éste llama a **la capa de negocio** donde válida si está es correcta y la lógica necesaria.y luego **la capa repositorio** donde se ha creado el patrón repository para desacoplar la fuente de datos. Para la **autenticación se ha usado el midleware de JWT** que ya provee .net .Se ha configurado para que genere un token cada vez que te loges o registres y no tener que estar constantemente comprobando quien eres.Cada vez que hagas una operación hay que pasarle ese token .Comprueba que el token sea correcto,va a base de datos y comprueba que la password tambien es correcta.ëste contiene una parte pública que es el nombre de usuario y su rol y en función de eso la lógica de negocio comprueba si tiene permisos para hacer esa operación. 
En la parte de administración de usuarios no se ha usado la parte de negocio porque no había apenas lógica y lo ha hecho el mismo el controlador.
