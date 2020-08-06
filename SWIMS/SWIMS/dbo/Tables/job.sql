CREATE TABLE [dbo].[job] (
    [job_id]         UNIQUEIDENTIFIER NOT NULL,
    [application_id] NVARCHAR (50)    NULL,
    [contract_id]    NVARCHAR (50)    NOT NULL,
    [district_id]    NVARCHAR (50)    NULL,
    [masterjob_id]   INT              NULL,
    [job_address]    NVARCHAR (255)   NULL,
    CONSTRAINT [PK_job] PRIMARY KEY NONCLUSTERED ([job_id] ASC)
);

