CREATE TABLE organization (
    id UNIQUEIDENTIFIER  PRIMARY KEY,
    name TEXT NOT NULL,
    image VARBINARY(MAX) ,
    created_at TIMESTAMP  ,
   
);
