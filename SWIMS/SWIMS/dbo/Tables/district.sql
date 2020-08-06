﻿CREATE TABLE [dbo].[district] (
    [district_id] INT NOT NULL,
    [contract_id] INT NOT NULL,
    [district_code]       NVARCHAR (50)  NOT NULL,
    [district_desc]     NVARCHAR (50)  NULL,
    [district_address]  NVARCHAR (255) NULL,
    [district_postcode] NVARCHAR (12)  NULL,
    [district_primary]  INT CONSTRAINT [IsPrimaryYesOrNo] DEFAULT ((0)) NULL, 
    CONSTRAINT [PK_district] PRIMARY KEY ([district_id]), 
    CONSTRAINT [FK_district_To_Contract] FOREIGN KEY ([contract_id]) REFERENCES [contract]([contract_id])
);
