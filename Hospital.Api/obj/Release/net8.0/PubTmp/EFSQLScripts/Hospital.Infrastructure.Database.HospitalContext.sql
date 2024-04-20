IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE TABLE [Appointments] (
        [Id] uniqueidentifier NOT NULL,
        [DoctorId] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [AppointmentDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Appointments] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE TABLE [Floors] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [FloorNumber] int NOT NULL,
        CONSTRAINT [PK_Floors] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE TABLE [Hospitals] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Location] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Hospitals] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE TABLE [Users] (
        [Id] uniqueidentifier NOT NULL,
        [WorkerId] uniqueidentifier NOT NULL,
        [Login] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [RefreshToken] nvarchar(max) NOT NULL,
        [Role] nvarchar(max) NOT NULL,
        [IsBlocked] bit NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [DateRegister] datetime2 NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE TABLE [Workers] (
        [Id] uniqueidentifier NOT NULL,
        [SelaryId] uniqueidentifier NOT NULL,
        [AuthId] uniqueidentifier NOT NULL,
        [Role] nvarchar(max) NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [DateRegister] datetime2 NOT NULL,
        CONSTRAINT [PK_Workers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE TABLE [Rooms] (
        [Id] uniqueidentifier NOT NULL,
        [RoomNumber] int NOT NULL,
        [Status] int NOT NULL,
        [FloorId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Rooms] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Rooms_Floors_FloorId] FOREIGN KEY ([FloorId]) REFERENCES [Floors] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE TABLE [Branches] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Location] nvarchar(max) NOT NULL,
        [HospitalID] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Branches] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Branches_Hospitals_HospitalID] FOREIGN KEY ([HospitalID]) REFERENCES [Hospitals] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE TABLE [Patients] (
        [Id] uniqueidentifier NOT NULL,
        [Disease] nvarchar(max) NOT NULL,
        [State] int NOT NULL,
        [RoomID] uniqueidentifier NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [DateRegister] datetime2 NOT NULL,
        CONSTRAINT [PK_Patients] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Patients_Rooms_RoomID] FOREIGN KEY ([RoomID]) REFERENCES [Rooms] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE TABLE [Departments] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [BranchID] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Departments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Departments_Branches_BranchID] FOREIGN KEY ([BranchID]) REFERENCES [Branches] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE TABLE [DepartmentPatients] (
        [DepartmentId] uniqueidentifier NOT NULL,
        [PatientId] uniqueidentifier NOT NULL,
        [Id] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_DepartmentPatients] PRIMARY KEY ([DepartmentId], [PatientId]),
        CONSTRAINT [FK_DepartmentPatients_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_DepartmentPatients_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE TABLE [Doctors] (
        [Id] uniqueidentifier NOT NULL,
        [AuthId] uniqueidentifier NOT NULL,
        [Positions] nvarchar(max) NOT NULL,
        [DepartmentId] uniqueidentifier NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [DateRegister] datetime2 NOT NULL,
        CONSTRAINT [PK_Doctors] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Doctors_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE TABLE [DoctorPatients] (
        [DoctorId] uniqueidentifier NOT NULL,
        [PatientId] uniqueidentifier NOT NULL,
        [Id] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_DoctorPatients] PRIMARY KEY ([DoctorId], [PatientId]),
        CONSTRAINT [FK_DoctorPatients_Doctors_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctors] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_DoctorPatients_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] ON;
    EXEC(N'INSERT INTO [Hospitals] ([Id], [Location], [Name])
    VALUES (''8b841ba0-d826-4975-8706-ffd025988376'', N''Гулистон'', N''Гор болница''),
    (''b75af299-9a19-44f4-88bb-7dc3c4b1fc6c'', N''Абрешим'', N''Обласной болница'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE INDEX [IX_Branches_HospitalID] ON [Branches] ([HospitalID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE INDEX [IX_DepartmentPatients_PatientId] ON [DepartmentPatients] ([PatientId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE INDEX [IX_Departments_BranchID] ON [Departments] ([BranchID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE INDEX [IX_DoctorPatients_PatientId] ON [DoctorPatients] ([PatientId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE INDEX [IX_Doctors_DepartmentId] ON [Doctors] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE INDEX [IX_Patients_RoomID] ON [Patients] ([RoomID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    CREATE INDEX [IX_Rooms_FloorId] ON [Rooms] ([FloorId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240414010150_CreatedMigrate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240414010150_CreatedMigrate', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240417161450_AddConfigurationToAppointment'
)
BEGIN
    EXEC(N'DELETE FROM [Hospitals]
    WHERE [Id] = ''8b841ba0-d826-4975-8706-ffd025988376'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240417161450_AddConfigurationToAppointment'
)
BEGIN
    EXEC(N'DELETE FROM [Hospitals]
    WHERE [Id] = ''b75af299-9a19-44f4-88bb-7dc3c4b1fc6c'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240417161450_AddConfigurationToAppointment'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] ON;
    EXEC(N'INSERT INTO [Hospitals] ([Id], [Location], [Name])
    VALUES (''2012c297-e02b-4983-b5fb-d52802db1946'', N''Абрешим'', N''Обласной болница''),
    (''ae0c39b4-ae27-47cf-ad3b-f1afe61d3e5a'', N''Гулистон'', N''Гор болница'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240417161450_AddConfigurationToAppointment'
)
BEGIN
    CREATE INDEX [IX_Appointments_DoctorId] ON [Appointments] ([DoctorId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240417161450_AddConfigurationToAppointment'
)
BEGIN
    ALTER TABLE [Appointments] ADD CONSTRAINT [FK_Appointments_Doctors_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctors] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240417161450_AddConfigurationToAppointment'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240417161450_AddConfigurationToAppointment', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240418104151_CreateDbContextForSalary'
)
BEGIN
    EXEC(N'DELETE FROM [Hospitals]
    WHERE [Id] = ''2012c297-e02b-4983-b5fb-d52802db1946'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240418104151_CreateDbContextForSalary'
)
BEGIN
    EXEC(N'DELETE FROM [Hospitals]
    WHERE [Id] = ''ae0c39b4-ae27-47cf-ad3b-f1afe61d3e5a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240418104151_CreateDbContextForSalary'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'WorkerId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Users] DROP COLUMN [WorkerId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240418104151_CreateDbContextForSalary'
)
BEGIN
    EXEC sp_rename N'[Workers].[SelaryId]', N'UserId', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240418104151_CreateDbContextForSalary'
)
BEGIN
    EXEC sp_rename N'[Workers].[AuthId]', N'SalaryId', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240418104151_CreateDbContextForSalary'
)
BEGIN
    CREATE TABLE [Salarys] (
        [Id] uniqueidentifier NOT NULL,
        [Amount] float NOT NULL,
        [Bonus] float NOT NULL,
        CONSTRAINT [PK_Salarys] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240418104151_CreateDbContextForSalary'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] ON;
    EXEC(N'INSERT INTO [Hospitals] ([Id], [Location], [Name])
    VALUES (''27f1362a-2d95-4946-a428-bfe6a855d8da'', N''Абрешим'', N''Обласной болница''),
    (''fb38d341-fee1-4df9-9410-ca1d3163f7bc'', N''Гулистон'', N''Гор болница'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240418104151_CreateDbContextForSalary'
)
BEGIN
    CREATE INDEX [IX_Workers_SalaryId] ON [Workers] ([SalaryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240418104151_CreateDbContextForSalary'
)
BEGIN
    CREATE INDEX [IX_Workers_UserId] ON [Workers] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240418104151_CreateDbContextForSalary'
)
BEGIN
    ALTER TABLE [Workers] ADD CONSTRAINT [FK_Workers_Salarys_SalaryId] FOREIGN KEY ([SalaryId]) REFERENCES [Salarys] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240418104151_CreateDbContextForSalary'
)
BEGIN
    ALTER TABLE [Workers] ADD CONSTRAINT [FK_Workers_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240418104151_CreateDbContextForSalary'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240418104151_CreateDbContextForSalary', N'8.0.0');
END;
GO

COMMIT;
GO

