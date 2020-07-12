CREATE TABLE TIPO_USUARIO(
    id_tipo_usuario integer not null,
    descripcion varchar(45) not null,
    estatus integer not null,
    CONSTRAINT pk_id_tipo_usuario PRIMARY KEY (id_tipo_usuario)
);

CREATE TABLE TIPO_IDENTIFICACION(
    id_tipo_identificacion integer not null,
    codigo char(1) not null,
    descripcion varchar(45) not null,
    estatus integer not null,
    CONSTRAINT pk_id_tipo_identificacion PRIMARY KEY (id_tipo_identificacion)
);

CREATE TABLE USUARIO (
    id_usuario integer not null,
    usuario varchar(20) not null,
    fecha_registro date,
    num_identificacion integer not null,
    email varchar(200) not null,
    telefono varchar(12) not null,
    direccion varchar(500) not null,
    estatus integer not null,
    id_tipo_usuario integer not null,
    id_tipo_identificacion integer not null,
    CONSTRAINT pk_id_usuario PRIMARY KEY (id_usuario),
    CONSTRAINT fk_id_tipo_usuario FOREIGN KEY (id_tipo_usuario) REFERENCES TIPO_USUARIO(id_tipo_usuario),
    CONSTRAINT fk_id_tipo_identificacion FOREIGN KEY (id_tipo_identificacion) REFERENCES TIPO_IDENTIFICACION(id_tipo_identificacion)
);

CREATE TABLE COMERCIO(
    id_comercio integer not null,
    razon_social varchar(200) not null,
    nombre_representante varchar(45) not null,
    apellido_representante varchar(45) not null,
    id_usuario integer not null,
    CONSTRAINT pk_id_comercio PRIMARY KEY (id_comercio),
    CONSTRAINT fk_id_usuario FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario)
);

CREATE TABLE CONTRASENA(
    id_contrasena integer not null,
    contrasena varchar(20) not null,
    intentos_fallidos integer not null,
    estatus integer not null,
    id_usuario integer not null,
    CONSTRAINT pk_id_contrasena PRIMARY KEY (id_contrasena),
    CONSTRAINT fk_id_usuario FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario)
);

CREATE TABLE ESTADO_CIVIL(
    id_estado_civil integer not null,
    descripcion varchar(45) not null,
    codigo char(1) not null,
    estatus integer not null,
    CONSTRAINT pk_id_estado_civil PRIMARY KEY (id_estado_civil)
);

CREATE TABLE PERSONA(
    nombre varchar(45) not null,
    apellido varchar(45) not null,
    fecha_nacimiento date not null,
    id_usuario integer not null,
    id_estado_civil integer not null,
    CONSTRAINT fk_id_usuario FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario),
    CONSTRAINT fk_id_estado_civil FOREIGN KEY (id_estado_civil) REFERENCES  ESTADO_CIVIL(id_estado_civil)
);

CREATE TABLE APLICACION(
    id_aplicacion integer not null,
    nombre varchar(45) not null,
    descripcion varchar(45) not null,
    estatus varchar(45) not null,
    CONSTRAINT pk_id_aplicacion PRIMARY KEY (id_aplicacion)
);

CREATE TABLE OPCION_MENU(
    id_opcion_menu integer not null,
    nombre varchar(45) not null,
    descripcion varchar(45) not null,
    url varchar(200) not null,
    posicion integer not null,
    estatus integer not null,
    id_aplicacion integer not null,
    CONSTRAINT pk_id_opcion_menu PRIMARY KEY (id_opcion_menu),
    CONSTRAINT fk_id_aplicacion FOREIGN KEY (id_aplicacion) REFERENCES APLICACION(id_aplicacion)
);

CREATE TABLE USUARIO_OPCION_MENU(
    estatus integer not null,
    id_usuario integer not null,
    id_opcion_menu integer not null,
    CONSTRAINT fk_id_usuario FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario),
    CONSTRAINT fk_id_opcion_menu FOREIGN KEY (id_opcion_menu) REFERENCES  OPCION_MENU(id_opcion_menu)
);

CREATE TABLE EVENTO(
    id_evento integer not null,
    codigo_evento varchar(4) not null,
    evento varchar(45) not null,
    estatus integer,
    CONSTRAINT pk_id_evento PRIMARY KEY (id_evento)
);

CREATE TABLE BITACORA(
    id_auditoria integer not null,
    fecha_bitacora date not null,
    datos_operacion varchar(2500) not null,
    causa_error varchar(2500),
    id_evento integer not null,
    id_usuario integer not null,
    CONSTRAINT pk_id_auditoria PRIMARY KEY (id_auditoria),
    CONSTRAINT fk_id_evento FOREIGN KEY (id_evento) REFERENCES EVENTO(id_evento),
    CONSTRAINT fk_id_usuario FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario)
);

CREATE TABLE REINTEGRO(
    id_reintegro integer not null,
    fecha_solicitud varchar(45) not null,
    referencia varchar(45) not null,
    estatus varchar(45) not null,
    id_usuario_solicitante integer not null,
    id_usuario_receptor integer not null,
    CONSTRAINT pk_id_reintegro PRIMARY KEY (id_reintegro),
    CONSTRAINT fk_id_usuario_solicitante FOREIGN KEY (id_usuario_solicitante) REFERENCES USUARIO(id_usuario),
    CONSTRAINT fk_id_usuario_receptor FOREIGN KEY (id_usuario_receptor) REFERENCES USUARIO(id_usuario)
);

CREATE TABLE TIPO_OPERACION(
    id_tipo_operacion integer not null,
    descripcion varchar(45) not null,
    estatus integer not null,
    CONSTRAINT pk_id_operacion PRIMARY KEY (id_tipo_operacion)
);

CREATE TABLE OPERACIONES_MONEDERO(
    id_operaciones_monedero integer not null,
    monto integer not null,
    fecha date not null,
    hora time not null,
    referencia varchar(45),
    id_usuario integer not null,
    id_tipo_operacion integer not null,
    CONSTRAINT pk_id_operaciones_monedero PRIMARY KEY (id_operaciones_monedero),
    CONSTRAINT fk_id_usuario FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario),
    CONSTRAINT fk_id_tipo_operacion FOREIGN KEY (id_tipo_operacion) REFERENCES TIPO_OPERACION(id_tipo_operacion)
);

CREATE TABLE TIPO_PARAMETRO(
    id_tipo_parametro integer not null,
    descripcion varchar(45) not null,
    estatus integer not null,
    CONSTRAINT pk_id_tipo_parametro PRIMARY KEY (id_tipo_parametro)
);

CREATE TABLE FRECUENCIA(
    id_frecuencia integer not null,
    codigo char(1) not null,
    descripcion varchar(45) not null,
    estatus integer not null,
    CONSTRAINT pk_id_frecuencia PRIMARY KEY (id_frecuencia)
);

CREATE TABLE PARAMETRO(
    id_parametro integer not null,
    nombre varchar(45) not null,
    estatus integer not null,
    id_tipo_parametro integer not null,
    id_frecuencia integer not null,
    CONSTRAINT pk_id_parametro PRIMARY KEY (id_parametro),
    CONSTRAINT fk_id_tipo_parametro FOREIGN KEY (id_tipo_parametro) REFERENCES TIPO_PARAMETRO(id_tipo_parametro),
    CONSTRAINT fk_id_frecuencia FOREIGN KEY (id_frecuencia) REFERENCES FRECUENCIA(id_frecuencia)
);

CREATE TABLE USUARIO_PARAMETRO(
    validacion varchar(45) not null,
    estatus integer not null,
    id_usuario integer not null,
    id_parametros integer not null,
    CONSTRAINT fk_id_usuario FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario),
    CONSTRAINT fk_id_parametros FOREIGN KEY (id_parametros) REFERENCES PARAMETRO(id_parametro)
);

CREATE TABLE TIPO_CUENTA(
    id_tipo_cuenta integer not null,
    descripcion varchar(45) not null,
    estatus integer not null,
    CONSTRAINT pk_id_tipo_cuenta PRIMARY KEY (id_tipo_cuenta)
);

CREATE TABLE BANCO(
    id_banco integer not null,
    nombre varchar(45) not null,
    estatus integer not null,
    CONSTRAINT pk_id_banco PRIMARY KEY (id_banco)
);

CREATE TABLE CUENTA(
    id_cuenta integer not null,
    numero_cuenta varchar(20) not null,
    id_usuario integer not null,
    id_tipo_cuenta integer not null,
    id_banco integer not null,
    CONSTRAINT pk_id_cuenta PRIMARY KEY (id_cuenta),
    CONSTRAINT fk_id_usuario FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario),
    CONSTRAINT fk_id_tipo_cuenta FOREIGN KEY (id_tipo_cuenta) REFERENCES TIPO_CUENTA(id_tipo_cuenta),
    CONSTRAINT fk_id_banco FOREIGN KEY (id_banco) REFERENCES BANCO(id_banco)
);

CREATE TABLE OPERACION_CUENTA(
    id_operacion_cuenta integer not null,
    fecha date not null,
    hora time not null,
    monto decimal not null,
    referencia varchar(45) not null,
    id_cuenta integer not null,
    id_usuario_receptor integer not null,
    CONSTRAINT pk_id_operacion_cuenta PRIMARY KEY (id_operacion_cuenta),
    CONSTRAINT fk_id_cuenta FOREIGN KEY (id_cuenta) REFERENCES CUENTA(id_cuenta),
    CONSTRAINT fk_id_usuario_receptor FOREIGN KEY (id_usuario_receptor) REFERENCES USUARIO(id_usuario)
);

CREATE TABLE TIPO_TARJETA(
    id_tipo_tarjeta integer not null,
    descripcion varchar(45),
    estatus integer not null,
    CONSTRAINT pk_id_tipo_tarjeta PRIMARY KEY (id_tipo_tarjeta)
);

CREATE TABLE TARJETA(
    id_tarjeta integer not null,
    numero_tarjeta integer not null,
    fecha_vencimiento date not null,
    cvc integer not null,
    estatus integer not null,
    id_usuario integer not null,
    id_tipo_tarjeta integer not null,
    id_banco integer not null,
    CONSTRAINT pk_id_tarjeta PRIMARY KEY (id_tarjeta),
    CONSTRAINT fk_id_usuario FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario),
    CONSTRAINT fk_id_tipo_tarjeta FOREIGN KEY (id_tipo_tarjeta) REFERENCES TIPO_TARJETA(id_tipo_tarjeta),
    CONSTRAINT fk_id_banco FOREIGN KEY (id_banco) REFERENCES BANCO(id_banco)
);

CREATE TABLE OPERACION_TARJETA(
    id_operacion_tarjeta integer not null,
    fecha date not null,
    hora time not null,
    monto decimal not null,
    referencia varchar(45) not null,
    id_usuario_receptor integer not null,
    id_tarjeta integer not null,
    CONSTRAINT pk_id_operacion_tarjeta PRIMARY KEY (id_operacion_tarjeta),
    CONSTRAINT fk_id_usuario_receptor FOREIGN KEY (id_usuario_receptor) REFERENCES USUARIO(id_usuario),
    CONSTRAINT fk_id_tarjeta FOREIGN KEY (id_tarjeta) REFERENCES TARJETA(id_tarjeta)
);
