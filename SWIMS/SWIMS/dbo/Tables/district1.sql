CREATE TABLE [dbo].[district1] (
    [district_id]       NVARCHAR (50)  NOT NULL,
    [contract_id]       NVARCHAR (50)  NOT NULL,
    [district_desc]     NVARCHAR (50)  NULL,
    [district_address]  NVARCHAR (255) NULL,
    [district_postcode] NVARCHAR (12)  NULL,
    [district_primary]  INT            CONSTRAINT [IsPrimaryYesOrNo] DEFAULT ((0)) NULL,
    CONSTRAINT [bbbbb] PRIMARY KEY NONCLUSTERED ([district_id] ASC, [contract_id] ASC)
);

