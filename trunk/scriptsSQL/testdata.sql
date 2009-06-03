/*==============================================================*/
/* Test data for FogUM BD                */
/*==============================================================*/

/*==============================================================*/
/* Test data for table "Comandantes".                 */
/*==============================================================*/
insert into COMANDANTE (COD_COMANDANTE, USERNAME, PASSWORD, NOME) values (1, 'cmd1', 'comnd1!', 'João da Silva')
insert into COMANDANTE (COD_COMANDANTE, USERNAME, PASSWORD, NOME) values (2, 'cmd2', 'comnd2!', 'Marco Costa')
insert into COMANDANTE (COD_COMANDANTE, USERNAME, PASSWORD, NOME) values (3, 'cmd3', 'comnd3!', 'Rui Pereira')
insert into COMANDANTE (COD_COMANDANTE, USERNAME, PASSWORD, NOME) values (4, 'cmd4', 'comnd4!', 'José Castro')
insert into COMANDANTE (COD_COMANDANTE, USERNAME, PASSWORD, NOME) values (5, 'cmd5', 'comnd5!', 'Fernando Vaz')
insert into COMANDANTE (COD_COMANDANTE, USERNAME, PASSWORD, NOME) values (6, 'teste', 'teste0!', 'Dummy CMD for Tests')

/*==============================================================*/
/* Test data for table "Concelho".                 */
/*==============================================================*/
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (1, 'Amares')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (2, 'Barcelos')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (3, 'Braga')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (4, 'Cabeceiras de Basto')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (5, 'Celorico de Basto')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (6, 'Esposende')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (7, 'Fafe')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (8, 'Guimarães')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (9, 'Póvoa de Lanhoso')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (10, 'Terras do Bouro')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (11, 'Vieira do Minho')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (12, 'Vila Nova de Famalicão')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (13, 'Vila Verde')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (14, 'Vizela')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (15, 'Arcos de Valdevez')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (16, 'Caminha')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (17, 'Melgaço')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (18, 'Monção')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (19, 'Paredes de Coura')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (20, 'Ponte da Barca')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (21, 'Ponte de Lima')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (22, 'Valença')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (23, 'Viana do Castelo')
insert into CONCELHO (COD_CONCELHO, CONCELHO_DESIGN) values (24, 'Vila Nova de Cerveira')

/*==============================================================*/
/* Test data for table "Tipos_Depos".              */
/*==============================================================*/
insert into TIPOS_DEPOS (COD_TIPO, TIPO_DESIGN) values (1, 'Tanque de Rega')
insert into TIPOS_DEPOS (COD_TIPO, TIPO_DESIGN) values (2, 'Piscina')
insert into TIPOS_DEPOS (COD_TIPO, TIPO_DESIGN) values (3, 'Lago')
insert into TIPOS_DEPOS (COD_TIPO, TIPO_DESIGN) values (4, 'Outro')

/*==============================================================*/
/* Test data for table "Distrito".                 */
/*==============================================================*/
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (234, 'Aveiro')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (284, 'Beja')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (253, 'Braga')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (273, 'Bragança')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (272, 'Castelo Branco')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (239, 'Coimbra')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (266, 'Évora')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (289, 'Faro')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (271, 'Guarda')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (244, 'Leiria')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (21, 'Lisboa')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (245, 'Portalegre')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (22, 'Porto')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (243, 'Santarém')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (265, 'Setúbal')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (258, 'Viana do Castelo')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (259, 'Vila Real')
insert into DISTRITO (COD_DISTRITO, DISTRITO_DESIGN) values (232, 'Viseu')

/*==============================================================*/
/* Test data for table "Voluntariado".                 */
/*==============================================================*/
insert into VOLUNTARIADO(COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (1, 253, 'Rui Castro', '253456789', 'rcastro@bmail.com', 0)
insert into VOLUNTARIADO(COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (2, 253, 'João Sousa', '253654321', 'js22@bmail.com', 0)
insert into VOLUNTARIADO(COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (3, 253, 'Pedro Costa', '253222333', 'pedrocosta@bmail.com', 0)
insert into VOLUNTARIADO(COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (4, 253, 'Joana Silva','253333444', 'jsousa@bmail.com', 0)
insert into VOLUNTARIADO(COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (5, 253, 'Alberto Cunha', '221444555', 'albc@bmail.com', 0)
insert into VOLUNTARIADO(COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (6, 22, 'Manuel Pimenta', '222456789', 'mp88@bmail.com', 0)
insert into VOLUNTARIADO(COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (7, 22, 'Carla Marques', '223456789', 'carla_marques@bmail.com', 0)
insert into VOLUNTARIADO(COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (8, 22, 'Alexandra Batista', '224456789', 'abatista@bmail.com', 0)
insert into VOLUNTARIADO(COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (9, 22, 'Bernardo Guedes', '225456789', 'bernaguedes@bmail.com', 0)
insert into VOLUNTARIADO(COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (10, 22, 'António Pereira', '226456789', 'tonip@bmail.com', 0)

/*==============================================================*/
/* Test data for the table "Corporacao".               */
/*==============================================================*/
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (1,'Bombeiros Voluntários de Amares', 1 ,41.626671, -8.370177, 50 ,14)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (2,'Bombeiros Voluntários de Barcelos', 1 ,41.532925, -8.614719, 72 ,15)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (3,'Companhia de Bombeiros Sapadores de Braga', 1 ,41.553461, -8.429216, 85 ,12)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (4,'Bombeiros Voluntários de Braga', 1, 41.547574, -8.428412, 120 ,18)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (5,'Bombeiros Voluntários de Cabeceiras de Basto', 1, 41.514083, -7.990121, 58 ,13)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (6,'Bombeiros Voluntários de Esposende', 1, 41.533558, -8.778852, 65 ,20)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (7,'Bombeiros Voluntários de Fafe', 1 ,41.447822, -8.17529, 63 ,18)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (8,'Bombeiros Voluntários de Guimarães', 1 ,41.44669926365472, -8.29843282699585, 103 ,31)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (9,'Bombeiros Voluntários da Póvoa de Lanhoso', 1 ,41.577395, -8.27284, 83 ,21)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (10,'Bombeiros Voluntários de Vieira do Minho', 1 ,41.631322, -8.143294, 54,15)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (11,'Bombeiros Voluntários de Famalicão', 1 ,41.400993, -8.518058, 74 ,18)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (12,'Bombeiros Voluntários de Vila Verde', 1 ,41.651549, -8.438548, 49 ,17)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (13,'Bombeiros Voluntários de Vizela', 1 ,41.376032, -8.311937, 55 ,14)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (14,'Bombeiros Voluntários de Arcos de Valdevez', 1, 41.84688,-8.4199595, 58 ,15)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (15,'Bombeiros Voluntários de Caminha', 1, 41.874701, -8.840004, 65 ,17)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (16,'Bombeiros Voluntários de Melgaço', 1 ,42.111699, -8.257202, 49 ,16)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (17,'Bombeiros Voluntários de Monção', 1 ,42.073045, -8.484106, 53 ,18)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (18,'Bombeiros Voluntários de Paredes de Coura', 1, 41.911563, -8.558834, 48 ,14)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (19,'Bombeiros Voluntários de Ponte de Lima', 1 ,41.766919, -8.580735, 52 ,17)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (20,'Bombeiros Voluntários de Valença', 1 ,42.025972, -8.647937, 57 ,15)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (21,'Bombeiros Voluntários de Viana do Castelo', 1 ,41.694974, -8.829839, 65 ,20)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (22,'Bombeiros Municipais de Viana do Castelo', 1 ,41.705177, -8.813336, 89 ,13)
insert into CORPORACAO (COD_CORPORACAO, CORPORACAO_DESIGN, DISPONIBILIDADE_CORP, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (23,'Bombeiros Voluntários de Vila Nova de Cerveira', 1, 41.939883, -8.743089, 63 ,11)


/*==============================================================*/
/* Test data for the table "Heli".                     */
/*==============================================================*/
insert into HELI (COD_HELI, HELI_DESIGN, HELI_DISPONIBILIDADE) values (1, 'Helicópetro de Resgate 01', 1)
insert into HELI (COD_HELI, HELI_DESIGN, HELI_DISPONIBILIDADE) values (2, 'Helicópetro de Resgate 02', 1)
insert into HELI (COD_HELI, HELI_DESIGN, HELI_DISPONIBILIDADE) values (3, 'Helicópetro de Resgate 03', 1)
insert into HELI (COD_HELI, HELI_DESIGN, HELI_DISPONIBILIDADE) values (4, 'Helicópetro de Combate 01', 1)
insert into HELI (COD_HELI, HELI_DESIGN, HELI_DISPONIBILIDADE) values (5, 'Helicópetro de Combate 02', 1)
insert into HELI (COD_HELI, HELI_DESIGN, HELI_DISPONIBILIDADE) values (6, 'Helicópetro de Combate 03', 1)
insert into HELI (COD_HELI, HELI_DESIGN, HELI_DISPONIBILIDADE) values (7, 'Helicópetro de Suporte 01', 1)
insert into HELI (COD_HELI, HELI_DESIGN, HELI_DISPONIBILIDADE) values (8, 'Helicópetro de Suporte 02', 1)

/*==============================================================*/
/* Test data for the table "estado_fogo".              */
/*==============================================================*/
insert into ESTADO_FOGO (COD_ESTADO, ESTADO_DESIGN) values (1, 'Não Circunscrito')
insert into ESTADO_FOGO (COD_ESTADO, ESTADO_DESIGN) values (2, 'Circunscrito')
insert into ESTADO_FOGO (COD_ESTADO, ESTADO_DESIGN) values (3, 'Extinto')

/*==============================================================*/
/* Test data for the table "Depositos".                */
/*==============================================================*/
insert into DEPOSITOS (COD_DEPO, COD_TIPO, LATITUDE, LONGITUDE, VOLUME) values (1, 1, 41.847059, -8.813782, 1000)
insert into DEPOSITOS (COD_DEPO, COD_TIPO, LATITUDE, LONGITUDE, VOLUME) values (2, 2, 41.928847, -8.566589, 1000)
insert into DEPOSITOS (COD_DEPO, COD_TIPO, LATITUDE, LONGITUDE, VOLUME) values (3, 3, 41.673938, -8.75473, 5000)
insert into DEPOSITOS (COD_DEPO, COD_TIPO, LATITUDE, LONGITUDE, VOLUME) values (4, 1, 41.750824, -8.453979, 1200)
insert into DEPOSITOS (COD_DEPO, COD_TIPO, LATITUDE, LONGITUDE, VOLUME) values (5, 2, 41.585661, -8.668213, 1500)
insert into DEPOSITOS (COD_DEPO, COD_TIPO, LATITUDE, LONGITUDE, VOLUME) values (6, 3, 41.668809, -8.495178, 4000)
insert into DEPOSITOS (COD_DEPO, COD_TIPO, LATITUDE, LONGITUDE, VOLUME) values (7, 1, 41.531198, -8.530884, 2000)
insert into DEPOSITOS (COD_DEPO, COD_TIPO, LATITUDE, LONGITUDE, VOLUME) values (8, 2, 41.497264, -8.241119, 1500)
insert into DEPOSITOS (COD_DEPO, COD_TIPO, LATITUDE, LONGITUDE, VOLUME) values (9, 3, 41.432431, -8.580322, 3000)
insert into DEPOSITOS (COD_DEPO, COD_TIPO, LATITUDE, LONGITUDE, VOLUME) values (10, 4, 41.617496 ,-8.044739, 2500)

/*==============================================================*/
/* Test data for the table "Fogo".                     */
/*==============================================================*/
/*OS RAIO_SEGURANCA SÃO DISTÂNCIAS AO RAIO FOGO, COMO TINHA SIDO FALADO */
insert into FOGO (COD_FOGO, COD_COMANDANTE, COD_CONCELHO, COD_RELATORIO, COD_ESTADO, LATITUDE_FOGO, LONGITUDE_FOGO, RAIO_FOGO, RAIO_SEGURANCA, DH_START, DH_CIRCUNSCRITO, DH_FIM, BAIXAS_BOMBEIROS, BAIXAS_CIVIS) values (1, 6, 15, null, 1, 41.933444, -8.347549, 500, 600, '2009-05-24T14:25:10', '2009-05-26T18:43:43','2009-05-25T11:43:23', 2, 0)
insert into FOGO (COD_FOGO, COD_COMANDANTE, COD_CONCELHO, COD_RELATORIO, COD_ESTADO, LATITUDE_FOGO, LONGITUDE_FOGO, RAIO_FOGO, RAIO_SEGURANCA, DH_START, DH_CIRCUNSCRITO, DH_FIM, BAIXAS_BOMBEIROS, BAIXAS_CIVIS) values (2, 6, 15, null, 1, 41.899977, -8.31665, 534, 634, '2009-04-21T12:25:10', '2009-04-22T11:43:43','2009-04-22T19:55:23', 1, 10)
insert into FOGO (COD_FOGO, COD_COMANDANTE, COD_CONCELHO, COD_RELATORIO, COD_ESTADO, LATITUDE_FOGO, LONGITUDE_FOGO, RAIO_FOGO, RAIO_SEGURANCA, DH_START, DH_CIRCUNSCRITO, DH_FIM, BAIXAS_BOMBEIROS, BAIXAS_CIVIS) values (3, 6, 3, null, 1, 41.537109, -8.386688, 54, 74, '2009-05-24T11:25:10', '2009-05-24T14:03:43','2009-05-25T18:33:23', 0, 7)
insert into FOGO (COD_FOGO, COD_COMANDANTE, COD_CONCELHO, COD_RELATORIO, COD_ESTADO, LATITUDE_FOGO, LONGITUDE_FOGO, RAIO_FOGO, RAIO_SEGURANCA, DH_START, DH_CIRCUNSCRITO, DH_FIM, BAIXAS_BOMBEIROS, BAIXAS_CIVIS) values (4, 6, 8, null, 1, 41.436582, -8.272104, 103, 133, '2009-05-26T22:25:10', '2009-05-27T22:43:43','2009-05-28T09:13:23', 0, 4)
insert into FOGO (COD_FOGO, COD_COMANDANTE, COD_CONCELHO, COD_RELATORIO, COD_ESTADO, LATITUDE_FOGO, LONGITUDE_FOGO, RAIO_FOGO, RAIO_SEGURANCA, DH_START, DH_CIRCUNSCRITO, DH_FIM, BAIXAS_BOMBEIROS, BAIXAS_CIVIS) values (5, 6, 19, null, 1, 41.904193, -8.570538, 78, 98, '2009-04-24T14:25:10', '2009-05-25T03:33:43','2009-05-25T11:21:23', 1, 3)
insert into FOGO (COD_FOGO, COD_COMANDANTE, COD_CONCELHO, COD_RELATORIO, COD_ESTADO, LATITUDE_FOGO, LONGITUDE_FOGO, RAIO_FOGO, RAIO_SEGURANCA, DH_START, DH_CIRCUNSCRITO, DH_FIM, BAIXAS_BOMBEIROS, BAIXAS_CIVIS) values (6, 6, 11, null, 1, 41.701627, -8.080444, 200, 275, '2009-05-12T23:35:10', '2009-05-14T11:43:43','2009-05-16T11:03:23', 3, 2)
insert into FOGO (COD_FOGO, COD_COMANDANTE, COD_CONCELHO, COD_RELATORIO, COD_ESTADO, LATITUDE_FOGO, LONGITUDE_FOGO, RAIO_FOGO, RAIO_SEGURANCA, DH_START, DH_CIRCUNSCRITO, DH_FIM, BAIXAS_BOMBEIROS, BAIXAS_CIVIS) values (7, 6, 3, null, 1, 41.55243, -8.377161, 150, 200, '2009-05-07T10:45:10', '2009-05-08T11:21:43','2009-05-09T04:05:23', 5, 1)
insert into FOGO (COD_FOGO, COD_COMANDANTE, COD_CONCELHO, COD_RELATORIO, COD_ESTADO, LATITUDE_FOGO, LONGITUDE_FOGO, RAIO_FOGO, RAIO_SEGURANCA, DH_START, DH_CIRCUNSCRITO, DH_FIM, BAIXAS_BOMBEIROS, BAIXAS_CIVIS) values (8, 6, 6, null, 1, 41.545846, -8.750782, 76, 96 , '2009-05-28T09:12:10', '2009-05-28T21:51:43','2009-05-29T06:34:23', 2, 10)
insert into FOGO (COD_FOGO, COD_COMANDANTE, COD_CONCELHO, COD_RELATORIO, COD_ESTADO, LATITUDE_FOGO, LONGITUDE_FOGO, RAIO_FOGO, RAIO_SEGURANCA, DH_START, DH_CIRCUNSCRITO, DH_FIM, BAIXAS_BOMBEIROS, BAIXAS_CIVIS) values (9, 6, 23, null, 1, 41.731995, -8.807602, 89, 119, '2009-05-29T07:51:10', '2009-05-29T12:32:43','2009-05-29T17:21:23', 1, 0)
insert into FOGO (COD_FOGO, COD_COMANDANTE, COD_CONCELHO, COD_RELATORIO, COD_ESTADO, LATITUDE_FOGO, LONGITUDE_FOGO, RAIO_FOGO, RAIO_SEGURANCA, DH_START, DH_CIRCUNSCRITO, DH_FIM, BAIXAS_BOMBEIROS, BAIXAS_CIVIS) values (10, 6, 15, null, 1, 41.86694, -8.445997, 55, 75, '2009-05-26T15:51:10', '2009-05-29T05:41:43','2009-05-29T12:32:23', 0, 2)

/*==============================================================*/
/* Test data for the table "Relatorio".                */
/*==============================================================*/
insert into RELATORIO (COD_RELATORIO, COD_FOGO, COMENTARIO) values (1, 1, 'Gerês. Causa desconhecida. Suspeita de fogo posto.')
UPDATE FOGO
    SET COD_RELATORIO = 1
    FROM FOGO
    WHERE COD_FOGO = 1
insert into RELATORIO (COD_RELATORIO, COD_FOGO, COMENTARIO) values (2, 2, 'Gerês. Fogo Acidental. É preciso aumentar a prevenção.')
UPDATE FOGO
    SET COD_RELATORIO = 2
    FROM FOGO
    WHERE COD_FOGO = 2
insert into RELATORIO (COD_RELATORIO, COD_FOGO, COMENTARIO) values (3, 3, 'Arredores de Braga. Rapidamente circunscrito mas difícil de extinguir.')
UPDATE FOGO
    SET COD_RELATORIO = 3
    FROM FOGO
    WHERE COD_FOGO = 3
insert into RELATORIO (COD_RELATORIO, COD_FOGO, COMENTARIO) values (4, 4, 'Penha, Guimarães. Combate longo e difícil. Algumas baixas civis.')
UPDATE FOGO
    SET COD_RELATORIO = 4
    FROM FOGO
    WHERE COD_FOGO = 4
insert into RELATORIO (COD_RELATORIO, COD_FOGO, COMENTARIO) values (5, 5, 'Zona de Paredes de Coura. Fogo posto confirmado.')
UPDATE FOGO
    SET COD_RELATORIO = 5
    FROM FOGO
    WHERE COD_FOGO = 5
insert into RELATORIO (COD_RELATORIO, COD_FOGO, COMENTARIO) values (6, 6, 'Gerês. Suspeitas de Fogo posto. É necessário aumentar a vigilância.')
UPDATE FOGO
    SET COD_RELATORIO = 6
    FROM FOGO
    WHERE COD_FOGO = 6
insert into RELATORIO (COD_RELATORIO, COD_FOGO, COMENTARIO) values (7, 7, 'Bom Jesus, Braga. Combate longo. Provocou alguns danos ao património.')
UPDATE FOGO
    SET COD_RELATORIO = 7
    FROM FOGO
    WHERE COD_FOGO = 7
insert into RELATORIO (COD_RELATORIO, COD_FOGO, COMENTARIO) values (8, 8, 'Arredores de Esposende. Causa acidental. Nada mais de relevante.')
UPDATE FOGO
    SET COD_RELATORIO = 8
    FROM FOGO
    WHERE COD_FOGO = 8
insert into RELATORIO (COD_RELATORIO, COD_FOGO, COMENTARIO) values (9, 9, 'Zona de Viana do Castelo. Excelente execução. Servirá como bom exemplo.')
UPDATE FOGO
    SET COD_RELATORIO = 9
    FROM FOGO
    WHERE COD_FOGO = 9
insert into RELATORIO (COD_RELATORIO, COD_FOGO, COMENTARIO) values (10, 10, 'Zona dos Arcos de Valdevez. Fogo posto. Muitas complicações logísticas atrasaram o combate.')
UPDATE FOGO
    SET COD_RELATORIO = 10
    FROM FOGO
    WHERE COD_FOGO = 10

/*==============================================================*/
/* Test data for the table "HeliFogo".                 */
/*==============================================================*/
insert into HELIFOGO (COD_FOGO, COD_HELI) values (1, 1)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (1, 2)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (1, 3)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (2, 4)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (2, 5)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (3, 7)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (4, 3)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (6, 4)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (6, 7)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (7, 8)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (7, 1)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (7, 2)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (8, 6)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (9, 6)
insert into HELIFOGO (COD_FOGO, COD_HELI) values (9, 5)

/*==============================================================*/
/* Test data for the table "CorpFogo".                 */
/*==============================================================*/
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (1, 21, 50, 12)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (1, 22, 70, 10)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (2, 21, 40, 8)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (2, 22, 65, 7)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (3, 3, 60, 8)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (3, 4, 90, 16)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (4, 8, 78, 15)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (4, 13, 45, 7)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (5, 18, 40, 10)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (6, 10, 44, 12)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (6, 12, 40, 12)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (7, 3, 65, 10)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (7, 4, 80, 15)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (8, 6, 50, 12)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (9, 21, 50, 10)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (9, 22, 76, 9)
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (10, 13, 45, 8)


