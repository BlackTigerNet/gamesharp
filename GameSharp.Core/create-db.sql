drop table if exists game;

create table game(id char(36) NOT NULL, name varchar(256), description varchar(2048), publisher varchar(256), publishDate DATE, PRIMARY KEY (id));

insert into game (id, name, description, publisher, publishDate) values ('7dd8a335-4232-408c-a038-5129768e6de8', 'Uncharted 4', 'Several years after his last adventure, retired fortune hunter, 
                Nathan Drake, is forced back into the world of thieves.', 'Naughty Dog', now());
insert into game (id, name, description, publisher, publishDate) values ('73d75eef-05ca-41cf-b82e-631e0a3cea44', 'Rise of the Tomb Raider', 'In Rise of the Tomb Raider, Lara Croft becomes more than a
                 survivor as she embarks on her first Tomb Raiding expedition to the most treacherous and remote regions of Siberia.', 'Crystal Dynamics', now());