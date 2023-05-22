create database children_creativity

create table user_roles
(
	user_role_id int identity(1,1) not null,
	user_role_name varchar(50) not null,
	primary key (user_role_id)
);

create table users 
(
	[user_id] int identity(1,1) not null,
	user_firstname varchar(50) not null,
	user_surname varchar(50) not null,
	user_password varchar(20) not null,
	fk_user_role_id int not null,
	primary key ([user_id]),
	foreign key (fk_user_role_id) references user_roles (user_role_id)
);

create table producers 
(
	producer_id int identity(1,1) not null,
	producer_name varchar(50) not null,
	primary key (producer_id)
);

create table delivery_points 
(
	delivery_point_id int identity(1,1) not null,
	delivery_point_name varchar(50) not null,
	primary key (delivery_point_id)
);

create table products 
(
	product_id int identity(1,1) not null,
	product_name varchar(50) not null,
	product_desc varchar(50) not null,
	product_price float not null,
	product_discount float null,
	product_count int not null default 0,
	product_photo varbinary(MAX) null,
	fk_producer_id int not null,
	primary key (product_id),
	foreign key (fk_producer_id) references producers (producer_id)
);

create table orders 
(
	order_id int identity(1,1) not null,
	order_date date null,
	order_delivery_date date null,
	order_code int null,
	order_status varchar(50) null,
	fk_delivery_point_id int null,
	fk_user_id int null,
	primary key (order_id),
	foreign key (fk_delivery_point_id) references delivery_points (delivery_point_id),
	foreign key (fk_user_id) references users ([user_id])
);

create table order_bins 
(
	order_bin_id int identity(1,1) not null,
	fk_order_id int not null,
	fk_product_id int not null,
	order_bin_count int not null default 1,
	primary key (order_bin_id),
	foreign key (fk_order_id) references orders (order_id),
	foreign key (fk_product_id) references products (product_id)
);