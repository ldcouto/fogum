/*==============================================================*/
/* Generate test data for the table "Concelho".                 */
/*==============================================================*/
insert into CONCELHO (CONCELHO_DESIGN) values ('Barcelos')

insert into CONCELHO (CONCELHO_DESIGN) values ('Guimarães')

insert into CONCELHO (CONCELHO_DESIGN) values ('Santo Tirso')


/*==============================================================*/
/* Generate test data for the table "Tipos_Depos".              */
/*==============================================================*/
insert into TIPOS_DEPOS (TIPO_DESIGN) values ('Tanque de Rega')

insert into TIPOS_DEPOS (TIPO_DESIGN) values ('Piscina')


/*==============================================================*/
/* Generate test data for the table "Distrito".                 */
/*==============================================================*/
insert into DISTRITO (DISTRITO_DESIGN) values ('Porto')

insert into DISTRITO (DISTRITO_DESIGN) values ('Braga')


/*==============================================================*/
/* Generate test data for the table "Corporacao".               */
/*==============================================================*/
insert into CORPORACAO (CORPORACAO_DESIGN, LATITUDE_CORP, LONGITUDE_CORP, NUM_HOMENS_DISP, NUM_VEICULOS_DISP) values (
	'Bombeiros Voluntários de Guimarães', True ,41.44669926365472, -8.29843282699585, 160 ,31)


/*==============================================================*/
/* Generate test data for the table "Heli".                     */
/*==============================================================*/
insert into HELI (HELI_DESIGN, HELI_DISPONIBILIDADE) values ('Helicópetro de Resgate', 1)

insert into HELI (HELI_DESIGN, HELI_DISPONIBILIDADE) values ('Helicópetro de Combate Alugado', 1)

insert into HELI (HELI_DESIGN, HELI_DISPONIBILIDADE) values ('Helicópetro de Combate Profissional', 1)


/*==============================================================*/
/* Generate test data for the table "Comandante".               */
/*==============================================================*/
insert into COMANDANTE (USERNAME, PASSWORD, NOME) values ('JSilva', 'cmd01', 'João da Silva')

insert into COMANDANTE (USERNAME, PASSWORD, NOME) values ('MCosta', 'cmd02', 'Marco da Costa')

insert into COMANDANTE (USERNAME, PASSWORD, NOME) values ('teste', 'teste', 'teste')


/*==============================================================*/
/* Generate test data for the table "Voluntariado".             */
/*==============================================================*/
/*
insert into VOLUNTARIADO (COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (0, 2, 'NGE1LGCRD0GTVBQODV2X F4PO4YMH LFT3J JFNPQNM9VU1I5M4BPG1TTK208GCR9EIYJOVS29U7GJR00LX8R4CPM3MW7BLSE47L', 'RFUHTXX6K', 'T 7 GOGGA6T7YVEQD82CC5BET5XSMQ4CGYWBBP0103MMSRUW T', 1)

insert into VOLUNTARIADO (COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (2, 2, '078LSY8J3CGSKC14VG8421XJQ BOYMX911U2FBBYW6MMH HBFIR3B8O3OWFYNQD6BAQBQE 0L LPO3MVGDXYL21EPJSCITM980UU', 'X90G1EDBL', 'CINN 9TMTONAUX2X 15E4FOT3WAVNXMVRIUPJJ7AAFEIPL1VTC', 0)

insert into VOLUNTARIADO (COD_VOLUNTARIO, COD_DISTRITO, NOME_VOLUNTARIO, NUM_TELEFONE, EMAIL, DISPONIBILIDADE) values (1, 0, 'KVLYNROD5U9MP7LAEFI60E3XMU5ATEYEYXVU5J2D4XN8I4K CS1TI10087XQSKV029XIRCUNXIC1XAI853YLS 28RX9XHR8X93BL', ' 2GRU0I1V', 'OQ1APF4OTJ3 SYYP06RAYDXE411J3XCSEEX4P84 FPL9EQ2U3K', 2)
*/

/*==============================================================*/
/* Generate test data for the table "estado_fogo".              */
/*==============================================================*/
insert into ESTADO_FOGO (ESTADO_DESIGN) values ('Não Circunscrito')

insert into ESTADO_FOGO (ESTADO_DESIGN) values ('Circunscrito')

insert into ESTADO_FOGO (ESTADO_DESIGN) values ('Extinto')


/*==============================================================*/
/* Generate test data for the table "Depositos".                */
/*==============================================================*/
insert into DEPOSITOS (COD_TIPO, LATITUDE, LONGITUDE, VOLUME) values (2, 41.44388449101261, -8.302702903747559, 2500000)

insert into DEPOSITOS (COD_TIPO, LATITUDE, LONGITUDE, VOLUME) values (1, 41.36948202530638, -8.300213813781738, 1500000)


/*==============================================================*/
/* Generate test data for the table "Fogo".                     */
/*==============================================================*/
insert into FOGO (COD_COMANDANTE, COD_CONCELHO, COD_RELATORIO, COD_ESTADO, LATITUDE_FOGO, LONGITUDE_FOGO, RAIO_FOGO, RAIO_SEGURANCA, DH_START, DH_CIRCUNSCRITO, DH_FIM, BAIXAS_BOMBEIROS, BAIXAS_CIVIS) values (3, 2, null, 1, 41.44753562970768, -8.28096628189087, 2, 2, '2009-05-23T14:25:10', '2009-05-23T16:15:10','2009-05-23T17:45:10', 0, 1)


/*==============================================================*/
/* Generate test data for the table "HeliFogo".                 */
/*==============================================================*/
insert into HELIFOGO (COD_FOGO, COD_HELI) values (1, 1)


/*==============================================================*/
/* Generate test data for the table "Relatorio".                */
/*==============================================================*/
insert into RELATORIO (COD_FOGO, COMENTARIO) values (1, 'Causa desconhecida. Fogo numa zona civil. Poucos estragos.')


/*==============================================================*/
/* Generate test data for the table "CorpFogo".                 */
/*==============================================================*/
insert into CORPFOGO (COD_FOGO, COD_CORPORACAO, NUM_HOMENS, NUM_VEICULOS) values (1, 1, 60, 25)


