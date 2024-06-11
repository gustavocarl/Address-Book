CREATE DATABASE ADDRESS_BOOK

use ADDRESS_BOOK

CREATE TABLE TELEPHONE
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TYPE NVARCHAR(50),
    DDD NVARCHAR(5),
    TELEPHONENUMBER NVARCHAR(20)
);

CREATE TABLE CONTACT
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    FIRSTNAME NVARCHAR(50),
    LASTNAME NVARCHAR(50),
    EMAIL NVARCHAR(100),
    TELEPHONEID INT,
    FOREIGN KEY (TELEPHONEID) REFERENCES TELEPHONE(ID)
);