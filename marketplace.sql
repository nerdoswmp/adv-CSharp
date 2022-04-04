CREATE TABLE tbl_Address(
	id_address INT IDENTITY(1,1) PRIMARY KEY,
	street VARCHAR(100),
	city VARCHAR(58),
	state VARCHAR(50),
	country VARCHAR(50),
	posteCode VARCHAR(50)
);

CREATE TABLE tbl_Person (
	 id_person INT IDENTITY(1,1) PRIMARY KEY,
	 name VARCHAR(40) NOT NULL,
	 age VARCHAR(3) NOT NULL,
	 document VARCHAR(20) NOT NULL,
	 email VARCHAR(256) NOT NULL,
	 phone VARCHAR(20) NOT NULL,
	 login VARCHAR(50)NOT NULL,
	 fk_address INT NOT NULL
	 CONSTRAINT fk_id_address FOREIGN KEY (fk_address) REFERENCES tbl_Address (id_address)
);

CREATE TABLE tbl_Owner(
	pk_owner INT PRIMARY KEY,
	CONSTRAINT fk_id_person FOREIGN KEY (pk_owner) REFERENCES tbl_Person (id_person)
);

CREATE TABLE tbl_Client(
	pk_client INT PRIMARY KEY,
	CONSTRAINT fk_pk_person FOREIGN KEY (pk_client) REFERENCES tbl_Person (id_person)
);

CREATE TABLE tbl_Product(
	id_product int IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50),
	unitPrice FLOAT,
	barCode VARCHAR(50),
);

CREATE TABLE tbl_Store(
	id_store int IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50),
	CNPJ VARCHAR(20),
	fk_owner INT NOT NULL
	CONSTRAINT fk_id_owner FOREIGN KEY (fk_owner) REFERENCES tbl_Owner (pk_owner)
);

CREATE TABLE tbl_Stocks(
	id_Stocks INT IDENTITY(1,1) PRIMARY KEY,
	quantity INT NOT NULL,
	fk_product int NOT NULL,
	fk_store int NOT NULL
	CONSTRAINT fk_id_product FOREIGN KEY (fk_product) REFERENCES tbl_Product (id_product),
	CONSTRAINT fk_id_store FOREIGN KEY (fk_store) REFERENCES tbl_Store (id_store)
);

CREATE TABLE tbl_WishList(
	id_wishList INT IDENTITY(1,1) PRIMARY KEY,
	fk_product INT NOT NULL,
	fk_client INT NOT NULL
	CONSTRAINT fk_pk_product FOREIGN KEY (fk_product) REFERENCES tbl_Product (id_product),
	CONSTRAINT fk_id_client FOREIGN KEY (fk_client) REFERENCES tbl_Client (pk_client)
);

CREATE TABLE tbl_Purchase(
	id_purchase INT IDENTITY(1,1) PRIMARY KEY,
	payment VARCHAR(50),
	datePurchase DATE,
	numberConfirmation VARCHAR(50),
	numberNf VARCHAR(50),
	fk_store INT NOT NULL,
	fk_product INT NOT NULL,
	fk_client INT NOT NULL
	CONSTRAINT fk_pk_store FOREIGN KEY (fk_store) REFERENCES tbl_Store (id_store),
	CONSTRAINT fk_pkk_product FOREIGN KEY (fk_product) REFERENCES tbl_Product (id_product),
	CONSTRAINT fk_pk_client FOREIGN KEY (fk_client) REFERENCES tbl_Client (pk_client)
);






INSERT INTO tbl_Address (street,city,state,country,posteCode)
VALUES
  ('P.O. Box 143, 2405 Duis Street','Shimla','Vlaams-Brabant','Algeria','6508'),
  ('Ap #759-4447 Nunc St.','San Francisco','Bauchi','Christmas Island','855682'),
  ('P.O. Box 752, 2698 Tempor Ave','Turriff','North Island','Vanuatu','0274'),
  ('Ap #644-1118 Non, Avenue','Vads�','Northumberland','Swaziland','F4 2YP'),
  ('566-8264 Sed, Road','Musina','Mazowieckie','Nicaragua','61-445'),
  ('P.O. Box 295, 4469 A, St.','Los Lagos','Los R�os','Pitcairn Islands','765853'),
  ('2060 Ipsum. Road','Picton','South Island','Cocos (Keeling) Islands','0537'),
  ('217-9137 Sodales Road','Link�ping','�sterg�tlands l�n','Gambia','06047'),
  ('519-9057 Odio. Avenue','Kessel','Antwerpen','Christmas Island','6715'),
  ('P.O. Box 511, 255 Pharetra Street','Zwettl-Nieder�sterreich','Lower Austria','Latvia','4612');

INSERT INTO tbl_Person (name,age,document,email,phone,login,fk_address)
VALUES
  ('Shea Mccoy','15','374.608.340-07','sheamccoy7377@google.com','(53) 45954-6474','Xena',1),
  ('Quon Ayers','08','439.044.081-11','quonayers7368@hotmail.com','(14) 07653-1239','Arsenio',2),
  ('Logan Barrera','61','376.894.637-17','loganbarrera@hotmail.com','(24) 87451-2019','Hyatt',3),
  ('Kessie Ware','25','183.036.866-61','kessieware@google.com','(73) 84153-7896','India',4),
  ('Jameson Crawford','86','558.521.444-80','jamesoncrawford@google.com','(11) 88288-5007','Jolie',5),
  ('Britanney Zimmerman','75','481.669.397-85','britanneyzimmerman2947@google.com','(22) 72598-7295','Joseph',6),
  ('Shaine Hoover','06','178.493.696-79','shainehoover@google.com','(49) 13825-5210','Suki',7),
  ('Xanthus Mcfarland','35','621.248.395-33','xanthusmcfarland@google.com','(75) 94936-2421','Kiayada',8),
  ('Quin Fulton','71','828.379.156-30','quinfulton@hotmail.com','(14) 27795-6880','Gage',9),
  ('Eric Dillon','14','124.284.146-36','ericdillon@google.com','(62) 90474-1337','Fritz',10);

INSERT INTO tbl_Owner VALUES (1);
INSERT INTO tbl_Owner VALUES (2);
INSERT INTO tbl_Owner VALUES (3);
INSERT INTO tbl_Owner VALUES (4);
INSERT INTO tbl_Owner VALUES (5);
INSERT INTO tbl_Client VALUES (6);
INSERT INTO tbl_Client VALUES (7);
INSERT INTO tbl_Client VALUES (8);
INSERT INTO tbl_Client VALUES (9);
INSERT INTO tbl_Client VALUES (10);

INSERT INTO tbl_Store (name,CNPJ,fk_owner)
VALUES
  ('Aliquam PC','48.228.859/0001-28',1),
  ('Sit Corporation','44.716.523/0001-72',2),
  ('Neque Vitae Limited','23.358.595/0001-49',3),
  ('Magna Ltd','87.428.378/0001-48',4),
  ('Nullam Vitae Company','75.357.535/0001-46',5);

INSERT INTO tbl_Product (name,unitPrice,barCode)
VALUES
  ('babbling',127,'6506362767888'),
  ('from',89,'6683753872735'),
  ('office.',135,'7303373674875'),
  ('than you',116,'1749553804723'),
  ('or',31,'2422378568219'),
  ('your',107,'9366393741119'),
  ('believe',143,'4975299388572'),
  ('these flowers',147,'0546034430246'),
  ('leaving?',63,'3489449421134'),
  ('black.',45,'4192241121192'),
  ('a filthy,',102,'8535238048248'),
  ('Oongratulations! Step',155,'7849091317626'),
  ('We throw',81,'1923245531802'),
  ('idea',151,'5169183420845'),
  ('with',93,'4007513974790'),
  ('last too',34,'1199640258165'),
  ('have. I',131,'9762354092472'),
  ('able',139,'3630677410501'),
  ('Listen,',63,'2025149415977'),
  ('Now',135,'1156155854924'),
  ('Are',143,'6498059335658'),
  ('Barry...',157,'3148931693411'),
  ('a little',7,'9120464472663'),
  ('Another',147,'3906615196829'),
  ('Bee',99,'4765776405735');

INSERT INTO tbl_WishList (fk_client,fk_product)
VALUES
  (6,7),
  (6,13),
  (6,9),
  (6,8),
  (6,4),
  (7,7),
  (7,12),
  (7,3),
  (7,19),
  (7,8),
  (8,8),
  (8,23),
  (8,16),
  (8,14),
  (8,19),
  (9,7),
  (9,7),
  (9,25),
  (9,18),
  (9,22),
  (10,1),
  (10,14),
  (10,4),
  (10,25),
  (10,13);

INSERT INTO tbl_Stocks (quantity,fk_store,fk_product)
VALUES
  (104,2,2),
  (42,2,3),
  (172,2,4),
  (11,2,5),
  (51,2,6),
  (70,3,7),
  (10,3,8),
  (141,3,9),
  (105,3,10),
  (125,3,11),
  (166,4,12),
  (137,4,13),
  (168,4,14),
  (148,4,15),
  (198,4,16),
  (63,5,17),
  (156,5,18),
  (194,5,19),
  (56,5,20),
  (114,5,21),
  (63,1,22),
  (156,1,23),
  (194,1,24),
  (56,1,25),
  (114,1,1);

INSERT INTO tbl_Stocks (quantity,fk_store,fk_product)
VALUES
  (263,3,2),
  (30,1,1),
  (231,4,16),
  (43,1,7),
  (33,3,24),
  (43,3,7),
  (167,3,3),
  (225,5,1),
  (289,3,2),
  (226,2,15),
  (176,3,4),
  (76,3,7),
  (15,2,17),
  (13,3,7),
  (125,4,21);

INSERT INTO tbl_Purchase (payment,datePurchase,numberConfirmation,numberNf,fk_store,fk_product,fk_client)
VALUES
  ('credito','Dec 26, 2021','416443','2157502485482',2,2,6),
  ('debito','Dec 26, 2021','126683','1624732480264',3,9,6),
  ('credito','Feb 16, 2023','668416','0122316614577',3,8,6),
  ('debito','Mar 27, 2022','587443','7291468685738',1,1,6),
  ('debito','Jan 7, 2023','161819','2269724571457',4,12,6),
  ('dinheiro','Jun 8, 2021','657254','8293894652801',5,21,7),
  ('dinheiro','Nov 16, 2021','717232','4661185771585',5,21,7),
  ('debito','Apr 6, 2022','588836','2287126568696',2,2,7),
  ('debito','Jun 6, 2021','382977','7874155423825',1,22,8),
  ('debito','Dec 10, 2021','308237','9558874564062',1,25,9),
  ('debito','Feb 5, 2022','156226','2667577021276',5,21,9),
  ('credito','Mar 27, 2022','826017','5860588937302',2,2,9),
  ('credito','Jul 22, 2021','784080','9255340451371',2,6,9),
  ('dinheiro','Sep 9, 2021','886521','1657424607772',5,19,10),
  ('dinheiro','Jul 31, 2022','074593','2277632772584',4,16,10),
  ('debito','Jul 26, 2021','650013','1737828776251',4,13,10),
  ('credito','Sep 6, 2021','478681','5447362630874',5,17,10),
  ('debito','Jul 26, 2022','203244','1355265487068',4,14,10);

select * from tbl_Person inner join tbl_Owner on tbl_Person.id_person = tbl_Owner.pk_owner
select * from tbl_Address
select * from tbl_Person
select * from tbl_Owner
select * from tbl_Store
select * from tbl_Product
select * from tbl_Client
select * from tbl_Stocks
select * from tbl_WishList
select * from tbl_Purchase

delete from tbl_Purchase
delete from tbl_Stocks
delete from tbl_Client
delete from tbl_WishList
delete from tbl_Product
delete from tbl_Store
delete from tbl_Owner
delete from tbl_Person
delete from tbl_Address

/*1*/
select * from tbl_Purchase where fk_store = 2;
/*2*/
select * from tbl_Purchase where fk_product = 25;
/*3*/
select * from tbl_Purchase where fk_client = 18;
/*4*/
select * from tbl_Purchase inner join tbl_client on tbl_Client.pk_client=tbl_Purchase.fk_client inner join tbl_Person on tbl_Person.id_person=tbl_client.pk_client where tbl_Person.document = '124.284.146-36'
/*5*/
select * from tbl_Purchase inner join tbl_store on  tbl_store.id_store=tbl_Purchase.fk_store where tbl_store.fk_owner = 10
/*6*/
select * from tbl_stocks where fk_product = 6
/*7*/
select tbl_person.name as Name, tbl_product.name as Product from tbl_wishlist inner join tbl_product on tbl_product.id_product=tbl_wishlist.fk_product inner join tbl_client on tbl_client.pk_client = tbl_wishlist.fk_client inner join tbl_Person on tbl_Person.id_person=tbl_client.pk_client where tbl_product.name = 'leaving?'
/*8*/

select * from tbl_Stocks

select * from tbl_Person

update tbl_Purchase
set payment = 'credito'
from tbl_purchase inner join tbl_client on tbl_Client.pk_client = tbl_Purchase.fk_client 
inner join tbl_Person on tbl_Person.id_person = tbl_Client.pk_client
inner join tbl_Address on tbl_Address.id_address = tbl_Person.fk_address
where tbl_Person.age between 18 and 25

select * from tbl_Purchase inner join tbl_client on tbl_Client.pk_client = tbl_Purchase.fk_client 
inner join tbl_Person on tbl_Person.id_person = tbl_Client.pk_client
inner join tbl_Address on tbl_Address.id_address = tbl_Person.fk_address
where tbl_Person.age between 18 and 25

select * from tbl_Purchase inner join tbl_Store on tbl_store.id_store = tbl_Purchase.fk_store 
inner join tbl_Owner on tbl_owner.pk_owner = tbl_Store.fk_owner
inner join tbl_Person on tbl_Person.id_person = tbl_owner.pk_owner
inner join tbl_Address on tbl_Address.id_address = tbl_Person.fk_address
where tbl_Address.city = 'San Francisco'

select * from tbl_Purchase inner join tbl_client on tbl_Client.pk_client = tbl_Purchase.fk_client 
inner join tbl_Person on tbl_Person.id_person = tbl_Client.pk_client
inner join tbl_Address on tbl_Address.id_address = tbl_Person.fk_address
where tbl_Address.city = 'Los Lagos'

select tbl_Product.name as Nome, quantity as Quantidade, country as Pa�s from tbl_Stocks inner join tbl_Store on tbl_Stocks.fk_store = tbl_Store.id_store
inner join tbl_product on tbl_Product.id_product = tbl_Stocks.fk_product
inner join tbl_Owner on tbl_owner.pk_owner = tbl_store.fk_owner 
inner join tbl_Person on tbl_person.id_person = tbl_owner.pk_owner 
inner join tbl_Address on tbl_Address.id_address = tbl_Person.fk_address
where tbl_product.name = 'from'
order by tbl_Address.country

select tbl_Address.country as Pa�s, count(pk_client) as "QTD. Clientes" from tbl_Client
inner join tbl_Person on tbl_person.id_person = tbl_client.pk_client 
inner join tbl_Address on tbl_Address.id_address = tbl_Person.fk_address
group by tbl_Address.country


select tbl_Address.country as Pa�s, count(id_store) as "QTD. Lojas" from tbl_Store inner join tbl_Owner on tbl_owner.pk_owner = tbl_store.fk_owner 
inner join tbl_Person on tbl_person.id_person = tbl_owner.pk_owner 
inner join tbl_Address on tbl_Address.id_address = tbl_Person.fk_address
group by tbl_Address.country



