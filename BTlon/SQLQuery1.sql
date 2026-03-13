create table Nguoithue (
ID char(10) not null primary key,
Hoten nvarchar not null,
Gioitinh ntext not null,
Sdt ntext not null,
email ntext not null,
Phuongtien ntext not null,
)

create table Phong(
Sophong char(3) not null primary key,
trangthai ntext not null,
)

create table Hopdong(
ID char(10) not null,
Hoten nvarchar not null,
Sophong char(3) not null,
Ngaybatdau datetime not null default current_timestamp,
Ngayketthuc datetime not null,
Tiencoc int not null,
Tienthue int not null,
foreign key (ID) references Nguoithue(ID),
foreign key (Sophong) references Phong(Sophong),
primary key (ID,Sophong),
)

create table Hoadon(
Sodien int not null,
Sonuoc int not null,
Sophuongtien int,
Ngaytao datetime not null default current_timestamp,
ID char(10) not null,
Hoten nvarchar not null,
Sophong char(3) not null,
foreign key (ID) references Nguoithue(ID),
foreign key (Sophong) references Phong(Sophong),
primary key (ID,Sophong),
)