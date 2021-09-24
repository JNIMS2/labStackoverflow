create database stackoverflowlab;
use stackoverflowlab;

create table questions(
id int not null auto_increment,
username varchar (20)not null,
title varchar (30) not null,
detail varchar(200),
posted datetime default current_timestamp on update current_timestamp,
category varchar(20),
tags varchar(80),
status int(1),
primary key (id)
);
#question id #foreign key to questions. 
create table answers(
id int not null auto_increment,
username varchar(20) not null,
detail varchar (300),
questionId int (100),
posted datetime default current_timestamp on update current_timestamp,
upvotes int (255),
primary key (id),
foreign key (questionId) references questions(id)

);
#have to figure out how to do datetime(insert) i think it is automatic
insert into questions(username, title, detail, category, status) 
values('jbone1', 'why won''t my computer turn on?', 'I am not sure what happened. It just won''t turn on after the storm.', 'BASIC', 0);

insert into questions(username, title, detail, category, status) 
values('tomboy531', 'Add a class?', 'How do I add a class in my MVC?', 'MVC', 0);

insert into questions(username, title, detail, category, status) 
values('goaway75', 'Home Controller MVC', 'Someone told me you are not supposed to change the Index function in your home controller. is that true?', 'MVC', 0);

insert into questions(username, title, detail, category, status) 
values('peterparker38', 'Buttons?', 'Where the flip do I add buttons, like at the top to go to my diff pages. not buttons. But, you know the titles u click', 'FRONTEND', 0);


insert into answers(username, detail, questionid) values('ddude53', 'TBH man,, it sounds like u may have had a powersurge that fried your system', 1);
insert into answers(username, detail, questionid) values('ddude53', 'Hey man, you need to right click Models. Then click ''Add''. Add new class. ', 2);
insert into answers(username, detail, questionid) values('jrdudekin34', 'You def do NOT want to change the name of the Index. But, you can put ur Landing page functions in it.',3 );
insert into answers(username, detail, questionid) values('BestinClass01', 'You can find it in your Views. Go to layout under shared views. It is everything that says nav-item. you can change the names or add your own',4 );



