-- create schema Training;

use Training;

create table Agenda (ID int primary key not null, Nume nchar(100) not null, Prenume nchar(100) not null, Telefon nchar(12) not null unique);

insert into Agenda values (1, 'Popescu', 'Ion', '0721234567'), (2, 'Georgescu', 'George', '0723456789'), (3, 'Stefanescu', 'Stefan', '0724567890'), (4, 'Cristescu', 'Cristina', '0720567891'), (5, 'Radulescu', 'Radu', '0744123456'), (6, 'Adamescu', 'Adriana', '0742345678'), (7, 'Avramescu', 'Avram', '0743678901'), (8, 'Achim', 'Petre', '0744543876'), (9, 'Ionescu', 'Valentina', '0721098765'), (10, 'Gheorghe', 'Anton', '0721321654');