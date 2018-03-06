DROP TABLE Guests;
CREATE TABLE Guests (
       GuestID		INT(5) AUTO_INCREMENT,
       FirstName	VARCHAR(25) NULL,
       LastName		VARCHAR(30) NULL,
       Email		VARCHAR(20) NULL,
       PRIMARY KEY (GuestID)
);
