# TrabajoPracticoN3Programacion3Movil
Enciclopedia de Plantas en una Aplicacion Movil.

Contiene lo siguiente:
Base de datos temporal interna para almacenar usuarios.
Base de datos temporal interna para almacenar plantas.
Funcion Login.
Funcion de credenciales.
Menu navegable.
Funciones CRUD para ambas bases de datos.

Esta aplicacion fue probada en el entorno de ejecuccion emulado de Android "Pixel 7 - API 34 (Android 14.0 - API 34)", con las siguientes especificaciones:
Dimension de pantalla: 1080 x 2400
Densidad de pantalla: 420 dpi
Version API: 34
Version Android: 14

Como usar:
Al iniciar la aplicacion, la primera pantalla sera el menu principal, desde aqui se puede navegar al resto de pantallas principales.
  - Tocar en el boton "Iniciar Sesion"  lo trasladara a la pantalla donde se puede logear con una cuenta que exista, las cuentas que existen son las siguientes (escritas como: Nombre, Contraseña, Rol. El rol es irrelevante): A, 11, Basico; B, 22, Admin1; C, 33, Admin2; D, 44, Basico; E, 55, Basico; F, 66, Admin7; G, 77, Basico; H, 88, Basico; I, 99, Basico; J, 1010, Basico.
    - En la pantalla de login, ingrese el Nombre de Usuario de la cuenta en el campo "Nombre de Usuario" y la contraseña de la cuenta en el campo "Contraseña".
    - Pulsar el boton "ingresar" le aumentara las credenciales si introdujo un usuario que existe y sera trasladado al Menu, de no hacerlo, saldra un mensaje que dira "Usuario o contraseña incorrectos" (Cuando me ubique en una pantalla que necesite credenciales, usare ! al lado del simbolo de la ruta).
    - Pulsar el boton "Volver al Menu" lo retornara al menu sin hacer ningun cambio. 

  - Toque el boton "Registrarse" para crear un nuevo registro en la base de datos de Usuario y logearse con ese usuario recien creado.
    - Aqui podra asignar un nombre, contraseña, rol e imagen (definido por ruta local del programa, valor default es "img/generico.jpg") a un nuevo registro en el campo "Nombre", "Contraseña", "Rol" y "Imagen" respectivamente, pulse "Crear" para crear el registro y acceder, o "Cancelar" para volver al Menu, puede dejar los campos vacio.

  - Toque el boton "Cerrar Sesion" para salir de su cuenta actual, de no haber ingresado, un mensaje aparecera diciendo "Usted no esta registrado, inicie sesion o registrese.", si tiene una cuenta, saldra de su cuenta inmediatamente y sera enviado a la pantalla de Log in.
    
  - Tocar en el boton "Ver Enciclopedia" lo trasladara a la pantalla donde se muestra una lista que contiene registros de plantas existentes en la base de datos de plamntas.
    - Acceder a esta pantalla sin registrarse solo permitira ver las plantas, muchas de estas plantas no tienen imagen ni nombre, la ultima planta de la lista deberia tener imagen y nombre cientifico.
    - Pulse el boton "Agregar planta" para agregar un nuevo registro a la base de datos de plantas si esta registrado con una cuenta, pulse el boton con un lapiz en un registro para editar el registro si esta registrado con una cuenta, pulse el boton de tacho de basura en un registro para borrar el registro Inmediatamente si esta registrado con una cuenta, pulse el boton "Volver al Menu" para volver al menu principal.
      - (Agregar Planta) Tras pulsar en el boton "Agregar Planta", sera trasladado a una nueva pagina que le permitira agregar registros al a base de datos de plantas, agrege la informacion que desee en el campo "Nombre Cientifico" y "Nombre Vulgar", el campo "Imagen" debe introducir la ruta local de la imagen para poder mostrar una imagen (valor default es "img/generico.jpg").
      - (Agregar Planta) Pulse el boton "Grabar" para guardar el registro en la base de datos de plantas, o pulse "Cancelar" para volver a la lista de plantas sin hacer ningun cambio.
      - (lapiz) Tras pulsar el boton de lapiz, sera trasladado a una pantalla identica a la pantalla de "Agregar Planta", aparece como placeholder el valor actual que contiene el registro, este placeholder NO sera guardado en el registro al pulsar "Grabar", si desea mantener ese valor, debera reescribirlo, pulse "Grabar" para guardar los cambios o "Cancelar" para volver a la lista de plantas sin hacer ningun cambio.

        
  - Tocar el boton "Ver Miembros" para ver la lista de usuarios guardados en la base de datos de usuarios.
    - Sera trasladado a otra pantalla casi identica a la pantalla que tiene la lista de plantas, pero con cambios en la lista para adaptarse a usuarios y en el boton "Agregar planta" por "Crear Usuario", el boton "Crear Usuario" le permitira agregar registros a la base de datos de usuarios, el boton de lapiz al lado de los registros de usuario permite editar el registro, el boton de tacho de basura al lado del registro borra el registro instantaneamente, el botn "Volver al Menu" lo traslada de vuelta al menu.
    - En la lista de usuarios, solo el primer y segundo registro tienen imagen, nombre, contraseña y rol, los demas solo tienen nombre, contraseña, y rol.
      - (Crear Usuario) Identico a la pantalla de registrarse, pero el boton "Crear" se llama "Grabar", pulsar "Grabar" creara un nuevo registro en la base de datos de usuario y lo devolvera a la lista de usuarios, pulsar "Cancelar" lo devolvera a la lista de usuarios.
      - (lapiz) Esta pantalla es identica a la de crear usuarios, pero en los campos se presentan como placeholder los valores del registro actual, estos placeholders tendran que ser manualmente introducidos si quiere mantenerlos al grabar, pulse "Grabar" para guardar los cambios o "Cancelar" para volver a la lista de Usuarios.

Necesito recomendaciones para mejorar esto de escribir instrucciones en Git, es complicadisimo.
