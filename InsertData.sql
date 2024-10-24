insert into Profiles
values ('Johnson', '12345678912', 'js1234@gmail.com', 'Male', '123 California, USA', '12/1/1999', null);
insert into Profiles
values ('Johnson2', '12345678913', 'js1235@gmail.com', 'Female', '124 California, USA', '12/1/2000', null);
insert into Profiles
values ('Johnson3', '12345678914', 'js1236@gmail.com', 'Male', '125 California, USA', '12/1/2001', null);
insert into Profiles
values ('Johnson4', '12345678915', 'js1237@gmail.com', 'Female', '126 California, USA', '12/1/2002', null);

insert into Accounts
values ('json1', '12345', 1, 1);
insert into Accounts
values ('json2', '12346', 1, 2);
insert into Accounts
values ('json3', '12347', 1, 3);
insert into Accounts
values ('json4', '12348', 1, 4);

insert into FoodCategories values ('Pizza');
insert into FoodCategories values ('Pasta');
insert into FoodCategories values ('Tacos');
insert into FoodCategories values ('Steak');
insert into FoodCategories values ('Chicken');

insert into Foods 
values ('Seafood Pizza', 100000, 1, 1, null);
insert into Foods 
values ('Cheese Pizza', 110000, 1, 1, null);
insert into Foods 
values ('Seafood Pasta', 120000, 2, 1, null);
insert into Foods 
values ('Cheese Pasta', 130000, 2, 1, null);
insert into Foods 
values ('Seafood Tacos', 50000, 3, 1, null);
insert into Foods 
values ('Cheese Tacos', 60000, 3, 1, null);
insert into Foods 
values ('Medium Rare Steak', 180000, 4, 1, null);
insert into Foods 
values ('Rare Steak', 180000, 4, 1, null);
insert into Foods 
values ('BBQ Chicken', 90000, 5, 1, null);
insert into Foods 
values ('Cheese Chicken', 100000, 5, 1, null);

insert into Combos 
values ('Combo1', 200000, 1, null);
insert into Combos 
values ('Combo2', 400000, 1, null);
insert into Combos 
values ('Combo3', 600000, 1, null);
insert into Combos 
values ('Combo4', 800000, 1, null);
insert into Combos 
values ('Combo5', 1000000, 1, null);

insert into ComboDetails
values (1, 1, 1);
insert into ComboDetails
values (3, 1, 1);
insert into ComboDetails
values (2, 2, 2);
insert into ComboDetails
values (4, 2, 2);
insert into ComboDetails
values (5, 3, 3);
insert into ComboDetails
values (7, 3, 3);
insert into ComboDetails
values (6, 4, 4);
insert into ComboDetails
values (8, 4, 4);
insert into ComboDetails
values (1, 5, 5);
insert into ComboDetails
values (8, 5, 5);

insert into Orders
values (1, 0);
insert into Orders
values (2, 1);
insert into Orders
values (3, 2);
insert into Orders
values (4, 3);

insert into OrderDetails
values (1, 1, 1, 1, 1);
insert into OrderDetails
values (1, 2, 2, 2, 2);
insert into OrderDetails
values (2, 3, 3, 3, 3);
insert into OrderDetails
values (3, 4, 4, 4, 4);

update Foods 
set Description = '/images/pizza1.jpg'
where id = 1;
update Foods 
set Description = '/images/pizza2.jpg'
where id = 2;
update Foods 
set Description = '/images/pasta1.jpg'
where id = 3;
update Foods 
set Description = '/images/pasta2.jpg'
where id = 4;
update Foods 
set Description = '/images/tacos1.jpg'
where id = 5;
update Foods 
set Description = '/images/tacos2.jpg'
where id = 6;
update Foods 
set Description = '/images/beef1.jpg'
where id = 7;
update Foods 
set Description = '/images/beef1.jpg'
where id = 8;
update Foods 
set Description = '/images/chicken1.jpg'
where id = 9;
update Foods 
set Description = '/images/chicken2.jpg'
where id = 10;
