-- * to 1 relation :(
create table employees(
	EmployeeId int identity(1,1) primary key,
	EmployeeName varchar not null,
	ProjectId int,
	DepartmentId int,
	constraint fk_emp_ProjectId foreign key (ProjectId) references Projects(ProjectId),
	constraint fk_emp_DepartmentId foreign key (DepartmentId) references Departments(DepartmentId)
);

create table Departments(
	DepartmentId int identity(1,1)  primary key,
	name varchar not null,
	ManagerId int,
	ProjectId int,
	EmployeeId int
);
-- 1 - 1 relation
create table Managers(
	ManagerId int primary key,
	ManagerName varchar,
	constraint fk_man_ManagerId foreign key (ManagerId) references Departments(DepartmentId)
);

-- no relation from this side.
create table Projects(
	ProjectId int primary key identity(1,1) ,
	projectName varchar,
	DepartmentId int,
	constraint fk_pro_DepartmentId foreign key (DepartmentId) references Departments(DepartmentId)
);


-- many to many 
CREATE TABLE DepartmentEmployee (
    DepartmentId int,
    EmployeeId int,
    ProjectId int,
    PRIMARY KEY (DepartmentId, EmployeeId), 
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
    FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId)
);




exec dropAll