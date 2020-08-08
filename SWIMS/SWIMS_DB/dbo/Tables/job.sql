CREATE TABLE [dbo].[job] (
    [job_id]         UNIQUEIDENTIFIER            NOT NULL,
    [application_id] NVARCHAR (50)  NULL,
    [contract_id]    INT            NOT NULL,
    [district_id]    INT            NOT NULL,
    [masterjob_id]   INT            NULL,
    [job_address]    NVARCHAR (255) NULL,
    CONSTRAINT [PK_job] PRIMARY KEY NONCLUSTERED ([job_id] ASC),
    CONSTRAINT [FK_job_To_Contract] FOREIGN KEY ([contract_id]) REFERENCES [dbo].[contract] ([contract_id]),
    CONSTRAINT [FK_job_To_District] FOREIGN KEY ([district_id]) REFERENCES [dbo].[district] ([district_id])
);

