create table Departments(
    DepartmentId int identity(1,1)  primary key,
    name varchar(255) not null
);

-- no relation from this side.
create table Projects(
    ProjectId int primary key identity(1,1) ,
    projectName varchar(255),
    DepartmentId int,
    constraint fk_pro_DepartmentId foreign key (DepartmentId) references Departments(DepartmentId)
);

-- * to 1 relation :(
create table employees(
    EmployeeId int identity(1,1) primary key,
    EmployeeName varchar(255) not null,
    ProjectId int,
    DepartmentId int,
    constraint fk_emp_ProjectId foreign key (ProjectId) references Projects(ProjectId),
    constraint fk_emp_DepartmentId foreign key (DepartmentId) references Departments(DepartmentId)
);

-- 1 - 1 relation
create table Managers(
    ManagerId int primary key,
    ManagerName varchar(255),
    constraint fk_man_ManagerId foreign key (ManagerId) references Departments(DepartmentId)
);

-- many to many 
CREATE TABLE DepartmentEmployee (
    DepartmentId int,
    EmployeeId int,
    ProjectId int,
    PRIMARY KEY (DepartmentId, EmployeeId, ProjectId), 
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
    FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId)
);