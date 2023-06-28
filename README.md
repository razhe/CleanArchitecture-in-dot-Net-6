# **Patrón CleanArchitecture**

## **Capas del proyecto**

### **Capa Dominio**
El proyecto de dominio albergará entidades de toda la empresa, modelos, excepciones personalizadas, enumeraciones, etc. pero no tiene dependencias, ni referencia a proyectos o clases, ni lógica de negocio, etc.

### **Capa Aplicación**
Considere estos servicios como la capa de lógica de negocio de su aplicación, un paso a través de la interfaz de usuario al dominio y la realización de la lógica de aplicación necesaria para su solución. La capa de Aplicación consumirá los modelos de Dominio, pero utilizará la capa de Infraestructura para comunicarse con el mundo exterior, utilizando así los resultados para llevar a cabo su lógica de negocio (cortando y cortando los resultados de múltiples llamadas a la Infraestructura, que a su vez se devuelven al cliente como (por ejemplo) un DTO).
Anotación: Solo se añade Dominio como proyecto de referencia.

### **Capa Infraestructura**
Esta capa es responsable de las comunicaciones de infraestructura externa como el almacenamiento de base de datos, sistema de archivos, sistemas externos / API / Servicios y así sucesivamente. Podemos añadir más bibliotecas de clases en esta carpeta del proyecto para plug-ins externos o SDKs.

En esencia, la capa de Infraestructura no es técnicamente necesaria, ya que se puede diseñar una aplicación que no interactúe con el mundo exterior, y haga toda su propia lógica de negocio, ¡esto sería ciertamente la excepción a la norma!

Es la capa más externa del sistema y no debería tener conocimiento de las capas internas.
Anotación: 
1) La clase de aplicación se añade como referencia.
2) La API nunca dependerá de la capa de infraestructura, pero tenemos que hacer referencia a la capa de infraestructura en el proyecto de interfaz de usuario en el caso de registrar la inyección de dependencia de servicios. Así que el proyecto de interfaz de usuario no debe utilizar ningún código de la capa de infraestructura que no sea la inyección de dependencia.
