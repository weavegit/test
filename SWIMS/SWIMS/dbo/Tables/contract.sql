CREATE TABLE [dbo].[contract] (
    [contract_id]            NVARCHAR (50) NOT NULL,
    [contract_desc]          NVARCHAR (50) NULL,
    [contract_canimport]     NVARCHAR (50) NULL,
    [contract_inactive]      BIGINT        CONSTRAINT [InactiveYesOrNo] DEFAULT ((0)) NOT NULL,
    [contract_taskvaluation] SMALLINT      CONSTRAINT [Value1to10] DEFAULT ((0)) NULL,
    [contract_nillrevenue]   INT           CONSTRAINT [value-1000to1000] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_contract] PRIMARY KEY NONCLUSTERED ([contract_id] ASC)
);

