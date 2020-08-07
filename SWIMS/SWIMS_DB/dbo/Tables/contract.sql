CREATE TABLE [dbo].[contract] (
    [contract_id]            INT           NOT NULL,
    [contract_code]          NVARCHAR (50) NOT NULL,
    [contract_desc]          NVARCHAR (255) NULL,
    [contract_canimport]     TINYINT NULL,
    [contract_inactive]      TINYINT        CONSTRAINT [InactiveYesOrNo] DEFAULT ((0)) NOT NULL,
    [contract_taskvaluation] TINYINT      CONSTRAINT [Value1to10] DEFAULT ((0)) NULL,
    [contract_nillrevenue]   INT           CONSTRAINT [value-1000to1000] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_contract] PRIMARY KEY NONCLUSTERED ([contract_id] ASC)
);

