CREATE DATABASE CHURCHDB

USE CHURCHDB

GO



CREATE TABLE dbo.Members(
    CodMember INT IDENTITY(1,1) NOT NULL ,
    MemberName VARCHAR(300)  NULL,
    Email VARCHAR(50)  NULL,
    Phone VARCHAR(50)  NULL,
    BirthDate DATE  NULL,
    IsBaptized BIT  NULL,
    Nationality VARCHAR(300)  NULL,
    DateOfRegister DATE  NULL,
    CONSTRAINT PK_Members PRIMARY KEY CLUSTERED (codMember)        
)

CREATE TABLE dbo.Address(
    IdAddress INT IDENTITY(1,1) NOT NULL,
    CodMember INT  NOT NULL,
    Street VARCHAR(300)  NULL,
    AddressNumber VARCHAR(50) NULL,
    Complement VARCHAR(300)  NULL,
    Neighborhood VARCHAR(300)  NULL,
    City VARCHAR(300)  NULL,
    State VARCHAR(300)  NULL,
    Postcode VARCHAR(50)  NULL,
    Country VARCHAR(300)  NULL,    
    CONSTRAINT PK_Address PRIMARY KEY CLUSTERED (IdAddress),
    CONSTRAINT FK_AddressMembers FOREIGN KEY (CodMember)
    REFERENCES dbo.Members (CodMember)
    
) 

