/* Tabla TIPO_USUARIO */
INSERT INTO tipo_usuario VALUES (0,'administrador',1);
INSERT INTO tipo_usuario VALUES (1,'comercio',1);
INSERT INTO tipo_usuario VALUES (2,'persona',1);
INSERT INTO tipo_usuario VALUES (3,'ambos',1);

/* Tabla TIPO_IDENTIFICACION */
INSERT INTO tipo_identificacion VALUES (0,'0','administrador',0);
INSERT INTO tipo_identificacion VALUES (1,'1','comercio',0);
INSERT INTO tipo_identificacion VALUES (2,'2','persona',0);
INSERT INTO tipo_identificacion VALUES (3,'3','ambos',0);
INSERT INTO tipo_identificacion VALUES (4,'4','subusuario',0);

/* Tabla USUARIO */
INSERT INTO usuario VALUES (0,'toniguarisco',to_date('12/07/2020','dd/mm/yyyy'),123456789,'toniguarisco@gmail.com','42424892850','el valle',1,0,0);
INSERT INTO usuario VALUES (1,'dexter-bit',to_date('10/07/2020','dd/mm/yyyy'),987654321,'Linkdex456@gmail.com','4129394549','la trinidad',1,1,1);
INSERT INTO usuario VALUES (2,'gabriella',to_date('11/07/2020','dd/mm/yyyy'),122334455,'gabriellassoler@gmail.com','2126720897','la florida',1,2,2);
INSERT INTO usuario VALUES (3,'gregorybustamante',to_date('14/07/2020','dd/mm/yyyy'),458796325,'buslelo16@gmail.com','4163459678','valencia',1,1,1);

/* Tabla COMERCIO */
INSERT INTO comercio VALUES (0,'somos una empresa destinada al desarrollo de software','dexter','ramos',1);
INSERT INTO comercio VALUES (1,'somos una empresa destinada a la seguridad computacional','gregory','bustamante',3);

/* Tabla CONTRASENA */
INSERT INTO contrasena VALUES (0,'12345678',0,1,0);
INSERT INTO contrasena VALUES (1,'12345678',0,1,1);
INSERT INTO contrasena VALUES (2,'12345678',0,1,2);

/* Tabla ESTADO_CIVIL */
INSERT INTO estado_civil VALUES (0,'soltero','0',0);
INSERT INTO estado_civil VALUES (1,'casado','1',0);
INSERT INTO estado_civil VALUES (2,'otro','2',0);

/* Tabla PERSONA */
INSERT INTO persona VALUES (0,'gabriella','alejandra','soler','perez',to_date('07/05/1997','dd/mm/yyyy'),2,0);

/* Tabla APLICACION */
INSERT INTO aplicacion VALUES (0,'Monedero','Monedero virtual de MonyUCAB',1);
INSERT INTO aplicacion VALUES (1,'Portal Web','Portal web de MonyUCAB',1);
INSERT INTO aplicacion VALUES (2,'Post Virtual','Post Virtual de MonyUCAB',1);

/* Tabla OPCION_MENU Por realizar */


/* Tabla USUARIO_OPCION_MENU Por realizar */


/* Tabla EVENTO */
INSERT INTO evento VALUES (0,'0000','transaccion',0);
INSERT INTO evento VALUES (1,'0001','consulta',0);
INSERT INTO evento VALUES (2,'0002','pago',0);

/* Tabla BITACORA */
INSERT INTO bitacora VALUES (0,to_date('dd/mm/yyyy','16/07/2020'),'datos de la operacion','causa del error',1,0);

/* Tabla REINTEGRO */
INSERT INTO reintegro VALUES (0,to_date('12/07/2020','dd/mm/yyyy'),'pago de bienes','en espera',0,1);
INSERT INTO reintegro VALUES (1,to_date('11/07/2020','dd/mm/yyyy'),'Reembolso de mercancia danada','efectuado',0,3);

/* Tabla PAGO */
INSERT INTO pago VALUES (0,to_date('12/07/2020','dd/mm/yyyy'),400000,'realizado','pago de desarrollo de pagina web',0,1);


/* Tabla TIPO_OPERACION */
INSERT INTO tipo_operacion VALUES (0,'consulta',0);
INSERT INTO tipo_operacion VALUES (1,'transaccion',0);
INSERT INTO tipo_operacion VALUES (2,'pago',0);

/* Tabla OPERACIONES_MONEDERO */
INSERT INTO operaciones_monedero VALUES (0,400000,to_date('14/07/2020','dd/mm/yyyy'),'13:45:38','0000000001',0,1);
INSERT INTO operaciones_monedero VALUES (1,2000000,to_date('15/07/2020','dd/mm/yyyy'),'8:06:12','0000000002',2,2);
INSERT INTO operaciones_monedero VALUES (2,1300000,to_date('19/07/2020','dd/mm/yyyy'),'10:43:00','0000000003',1,0);

/* Tabla TIPO_PARAMETRO */
INSERT INTO tipo_parametro VALUES (0,'busqueda',0);
INSERT INTO tipo_parametro VALUES (1,'resultado',0);

/* Tabla FRECUENCIA */
INSERT INTO frecuencia VALUES (0,'0','alta',0);
INSERT INTO frecuencia VALUES (1,'1','media',0);
INSERT INTO frecuencia VALUES (2,'2','baja',0);
INSERT INTO frecuencia VALUES (3,'3','ninguna',1);

/* Tabla PARAMETRO */
INSERT INTO parametro VALUES (0,'fecha',0,0,3);
INSERT INTO parametro VALUES (1,'monto',0,0,3);
INSERT INTO parametro VALUES (2,'cantidad',0,0,1);

/* Tabla USUARIO_PARAMETRO */
INSERT INTO usuario_parametro VALUES ('aprobado',1,0,0);
INSERT INTO usuario_parametro VALUES ('rechazado',0,3,2);

/* Tabla TIPO_CUENTA */
INSERT INTO tipo_cuenta VALUES (0,'corriente',0);
INSERT INTO tipo_cuenta VALUES (1,'ahorro',0);
INSERT INTO tipo_cuenta VALUES (2,'transaccional',0);

/* Tabla BANCO */
INSERT INTO banco VALUES (0,'Banesco',0);
INSERT INTO banco VALUES (1,'Mercantil',0);
INSERT INTO banco VALUES (2,'Bank Of America',0);
INSERT INTO banco VALUES (3,'Provincial',0);

/* Tabla CUENTA */
INSERT INTO cuenta VALUES (0,'01234567890123456789',0,1,1);
INSERT INTO cuenta VALUES (1,'25896314701478523698',1,2,0);
INSERT INTO cuenta VALUES (2,'00100125647895412365',2,0,3);
INSERT INTO cuenta VALUES (3,'78965412365478963210',3,2,0);

/* Tabla OPERACION_CUENTA */
INSERT INTO operacion_cuenta VALUES (0,to_date('15/07/2020','dd/mm/yyyy'),'6:35:23',3000000,'compra de antivirus',2,3);

/*Tabla TIPO_TARJETA */
INSERT INTO tipo_tarjeta VALUES (0,'debito',0);
INSERT INTO tipo_tarjeta VALUES (1,'credito',0);
INSERT INTO tipo_tarjeta VALUES (2,'otro',0);

/* Tabla TARJETA por realizar */


/* Tabla OPERACION_TARJETA por realizar */


