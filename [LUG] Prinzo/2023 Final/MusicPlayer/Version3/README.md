# Sobre MVP

En el patrón MVP (Modelo-Vista-Presentador), cada componente tiene un papel y responsabilidades específicas:

1. Modelo (Model):
   - El modelo representa la capa de datos y la lógica de negocio de la aplicación.
   - Es responsable de almacenar y manipular los datos.
   - Contiene las entidades de negocio (BE - Business Entities) que representan los objetos y conceptos relevantes para la aplicación.
   - Puede incluir componentes adicionales, como servicios, repositorios u otros objetos relacionados con la persistencia de datos.

2. Vista (View):
   - La vista es la interfaz de usuario o la representación visual de la aplicación.
   - Es responsable de mostrar la información al usuario y recibir sus interacciones.
   - No debe contener lógica de negocio, sino que se limita a reflejar el estado del modelo y enviar eventos al presentador.

3. Presentador (Presenter):
   - El presentador actúa como intermediario entre el modelo y la vista.
   - Se encarga de manejar la lógica de presentación y las interacciones entre la vista y el modelo.
   - Recibe eventos de la vista y realiza las acciones correspondientes en el modelo.
   - Actualiza la vista según los cambios en el modelo y la lógica de negocio.

En el patrón MVP, la lógica de negocio generalmente se encuentra en el modelo (también conocido como capa de negocio o capa de servicios). El modelo define las reglas y operaciones que se aplican a los datos, como validaciones, cálculos y manipulaciones. Puede haber componentes adicionales en el modelo, como servicios o repositorios, que se encarguen de la persistencia y acceso a los datos.

Las entidades de negocio (BE - Business Entities) son responsabilidad del modelo. Estas entidades representan los objetos y conceptos clave de la aplicación y encapsulan los datos relacionados con ellos. Las entidades pueden contener métodos y propiedades que reflejen la lógica de negocio asociada a esas entidades.

En cuanto a la capa de acceso a datos (DAL - Data Access Layer), en el patrón MVP no se define explícitamente. Sin embargo, es común que el modelo tenga componentes que se ocupen de la persistencia y acceso a los datos, como servicios o repositorios mencionados anteriormente. Estos componentes pueden interactuar con una capa de acceso a datos subyacente, como una capa de acceso a base de datos (DAL), aunque no es una parte explícita del patrón MVP.

En resumen, el modelo se encarga de la lógica de negocio y las entidades (BE), la vista se ocupa de la interfaz de usuario, y el presentador actúa como intermediario entre ambos, coordinando la comunicación y la actualización de la vista según los cambios en el modelo.
