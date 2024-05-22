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
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
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
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE TABLE [Positions] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Positions] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
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
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE TABLE [Workers] (
        [Id] uniqueidentifier NOT NULL,
        [PositionId] uniqueidentifier NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [DateRegister] datetime2 NOT NULL,
        CONSTRAINT [PK_Workers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Workers_Positions_PositionId] FOREIGN KEY ([PositionId]) REFERENCES [Positions] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
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
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE TABLE [Auths] (
        [Id] uniqueidentifier NOT NULL,
        [Login] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [RefreshToken] nvarchar(max) NOT NULL,
        [IsBlocked] bit NOT NULL,
        [WorkerId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Auths] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Auths_Workers_WorkerId] FOREIGN KEY ([WorkerId]) REFERENCES [Workers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE TABLE [Roles] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [WorkerId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Roles_Workers_WorkerId] FOREIGN KEY ([WorkerId]) REFERENCES [Workers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE TABLE [Salarys] (
        [Id] uniqueidentifier NOT NULL,
        [Amount] float NOT NULL,
        [Bonus] float NOT NULL,
        [WorkerId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Salarys] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Salarys_Workers_WorkerId] FOREIGN KEY ([WorkerId]) REFERENCES [Workers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE TABLE [Doctors] (
        [Id] uniqueidentifier NOT NULL,
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
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE TABLE [Floors] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [FloorNumber] int NOT NULL,
        [DepartmentId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Floors] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Floors_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE TABLE [Appointments] (
        [Id] uniqueidentifier NOT NULL,
        [DoctorId] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [AppointmentDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Appointments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Appointments_Doctors_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctors] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
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
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
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
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] ON;
    EXEC(N'INSERT INTO [Hospitals] ([Id], [Location], [Name])
    VALUES (''3fca271d-4f3b-4809-9980-42582a0e4c6d'', N''Абрешим'', N''Обласной болница''),
    (''57f9270b-7183-4c4a-957b-ef4872599501'', N''Гулистон'', N''Гор болница'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Positions]'))
        SET IDENTITY_INSERT [Positions] ON;
    EXEC(N'INSERT INTO [Positions] ([Id], [Name])
    VALUES (''59acaabf-040a-4da1-a1f8-94f791abeee9'', N''Admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Positions]'))
        SET IDENTITY_INSERT [Positions] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'DateOfBirth', N'DateRegister', N'FirstName', N'LastName', N'PhoneNumber', N'PositionId') AND [object_id] = OBJECT_ID(N'[Workers]'))
        SET IDENTITY_INSERT [Workers] ON;
    EXEC(N'INSERT INTO [Workers] ([Id], [Address], [DateOfBirth], [DateRegister], [FirstName], [LastName], [PhoneNumber], [PositionId])
    VALUES (''ddf1c710-c42b-4900-b985-973d96c4f5b8'', N''Panjakent'', ''0001-01-01T00:00:00.0000000'', ''0001-01-01T00:00:00.0000000'', N''Shahzodjon'', N''Jonizoqov'', N''+992927758499'', ''59acaabf-040a-4da1-a1f8-94f791abeee9'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'DateOfBirth', N'DateRegister', N'FirstName', N'LastName', N'PhoneNumber', N'PositionId') AND [object_id] = OBJECT_ID(N'[Workers]'))
        SET IDENTITY_INSERT [Workers] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsBlocked', N'Login', N'Password', N'RefreshToken', N'WorkerId') AND [object_id] = OBJECT_ID(N'[Auths]'))
        SET IDENTITY_INSERT [Auths] ON;
    EXEC(N'INSERT INTO [Auths] ([Id], [IsBlocked], [Login], [Password], [RefreshToken], [WorkerId])
    VALUES (''137b90fd-78d1-4e51-b782-71211a89d6f4'', CAST(0 AS bit), N''SupperAdmin123'', N''!@#123#@!'', N'''', ''ddf1c710-c42b-4900-b985-973d96c4f5b8'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsBlocked', N'Login', N'Password', N'RefreshToken', N'WorkerId') AND [object_id] = OBJECT_ID(N'[Auths]'))
        SET IDENTITY_INSERT [Auths] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'WorkerId') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    EXEC(N'INSERT INTO [Roles] ([Id], [Name], [WorkerId])
    VALUES (''1bddbe1b-bc07-4a6b-8ce7-780829183236'', N''Admin'', ''ddf1c710-c42b-4900-b985-973d96c4f5b8'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'WorkerId') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE INDEX [IX_Appointments_DoctorId] ON [Appointments] ([DoctorId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Auths_WorkerId] ON [Auths] ([WorkerId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE INDEX [IX_Branches_HospitalID] ON [Branches] ([HospitalID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE INDEX [IX_Departments_BranchID] ON [Departments] ([BranchID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE INDEX [IX_Doctors_DepartmentId] ON [Doctors] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE INDEX [IX_Floors_DepartmentId] ON [Floors] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE INDEX [IX_Patients_RoomID] ON [Patients] ([RoomID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Roles_WorkerId] ON [Roles] ([WorkerId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE INDEX [IX_Rooms_FloorId] ON [Rooms] ([FloorId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Salarys_WorkerId] ON [Salarys] ([WorkerId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    CREATE INDEX [IX_Workers_PositionId] ON [Workers] ([PositionId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428053549_AddfirstMigration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240428053549_AddfirstMigration', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    EXEC(N'DELETE FROM [Auths]
    WHERE [Id] = ''137b90fd-78d1-4e51-b782-71211a89d6f4'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    EXEC(N'DELETE FROM [Hospitals]
    WHERE [Id] = ''3fca271d-4f3b-4809-9980-42582a0e4c6d'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    EXEC(N'DELETE FROM [Hospitals]
    WHERE [Id] = ''57f9270b-7183-4c4a-957b-ef4872599501'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    EXEC(N'DELETE FROM [Roles]
    WHERE [Id] = ''1bddbe1b-bc07-4a6b-8ce7-780829183236'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    EXEC(N'DELETE FROM [Workers]
    WHERE [Id] = ''ddf1c710-c42b-4900-b985-973d96c4f5b8'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    EXEC(N'DELETE FROM [Positions]
    WHERE [Id] = ''59acaabf-040a-4da1-a1f8-94f791abeee9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    ALTER TABLE [Appointments] ADD [Email] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    ALTER TABLE [Appointments] ADD [PhoneNumber] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    ALTER TABLE [Appointments] ADD [lastName] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] ON;
    EXEC(N'INSERT INTO [Hospitals] ([Id], [Location], [Name])
    VALUES (''411ef03d-ae2d-49d9-b199-109feb3ed48f'', N''Абрешим'', N''Обласной болница''),
    (''cc240972-dee2-4bcf-a09a-928bd3e49485'', N''Гулистон'', N''Гор болница'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Positions]'))
        SET IDENTITY_INSERT [Positions] ON;
    EXEC(N'INSERT INTO [Positions] ([Id], [Name])
    VALUES (''b65015d7-1718-4370-bb28-e74d3802d6e0'', N''Admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Positions]'))
        SET IDENTITY_INSERT [Positions] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'DateOfBirth', N'DateRegister', N'FirstName', N'LastName', N'PhoneNumber', N'PositionId') AND [object_id] = OBJECT_ID(N'[Workers]'))
        SET IDENTITY_INSERT [Workers] ON;
    EXEC(N'INSERT INTO [Workers] ([Id], [Address], [DateOfBirth], [DateRegister], [FirstName], [LastName], [PhoneNumber], [PositionId])
    VALUES (''4864f4cd-4c2d-4258-ad24-ab363f3e063d'', N''Panjakent'', ''0001-01-01T00:00:00.0000000'', ''0001-01-01T00:00:00.0000000'', N''Shahzodjon'', N''Jonizoqov'', N''+992927758499'', ''b65015d7-1718-4370-bb28-e74d3802d6e0'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'DateOfBirth', N'DateRegister', N'FirstName', N'LastName', N'PhoneNumber', N'PositionId') AND [object_id] = OBJECT_ID(N'[Workers]'))
        SET IDENTITY_INSERT [Workers] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsBlocked', N'Login', N'Password', N'RefreshToken', N'WorkerId') AND [object_id] = OBJECT_ID(N'[Auths]'))
        SET IDENTITY_INSERT [Auths] ON;
    EXEC(N'INSERT INTO [Auths] ([Id], [IsBlocked], [Login], [Password], [RefreshToken], [WorkerId])
    VALUES (''841569fd-0659-4d33-8d66-8fe6cccfcc03'', CAST(0 AS bit), N''SupperAdmin123'', N''!@#123#@!'', N'''', ''4864f4cd-4c2d-4258-ad24-ab363f3e063d'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsBlocked', N'Login', N'Password', N'RefreshToken', N'WorkerId') AND [object_id] = OBJECT_ID(N'[Auths]'))
        SET IDENTITY_INSERT [Auths] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'WorkerId') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    EXEC(N'INSERT INTO [Roles] ([Id], [Name], [WorkerId])
    VALUES (''e157f1c7-87ce-4b0e-87da-d2bc9eefea1c'', N''Admin'', ''4864f4cd-4c2d-4258-ad24-ab363f3e063d'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'WorkerId') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240521171915_AddSecoundMigration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240521171915_AddSecoundMigration', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    EXEC(N'DELETE FROM [Auths]
    WHERE [Id] = ''841569fd-0659-4d33-8d66-8fe6cccfcc03'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    EXEC(N'DELETE FROM [Hospitals]
    WHERE [Id] = ''411ef03d-ae2d-49d9-b199-109feb3ed48f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    EXEC(N'DELETE FROM [Hospitals]
    WHERE [Id] = ''cc240972-dee2-4bcf-a09a-928bd3e49485'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    EXEC(N'DELETE FROM [Roles]
    WHERE [Id] = ''e157f1c7-87ce-4b0e-87da-d2bc9eefea1c'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    EXEC(N'DELETE FROM [Workers]
    WHERE [Id] = ''4864f4cd-4c2d-4258-ad24-ab363f3e063d'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    EXEC(N'DELETE FROM [Positions]
    WHERE [Id] = ''b65015d7-1718-4370-bb28-e74d3802d6e0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    CREATE TABLE [Clients] (
        [Id] uniqueidentifier NOT NULL,
        [Login] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [RefreshToken] nvarchar(max) NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [DateRegister] datetime2 NOT NULL,
        CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] ON;
    EXEC(N'INSERT INTO [Hospitals] ([Id], [Location], [Name])
    VALUES (''3cff9e1f-717a-42be-a061-c13dbfa6d2cf'', N''Гулистон'', N''Гор болница''),
    (''b3740b9b-38dd-417e-9fd0-01ddcc10a6ce'', N''Абрешим'', N''Обласной болница'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Positions]'))
        SET IDENTITY_INSERT [Positions] ON;
    EXEC(N'INSERT INTO [Positions] ([Id], [Name])
    VALUES (''b2bd64c3-e072-4982-b399-a272ce786635'', N''Admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Positions]'))
        SET IDENTITY_INSERT [Positions] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'DateOfBirth', N'DateRegister', N'FirstName', N'LastName', N'PhoneNumber', N'PositionId') AND [object_id] = OBJECT_ID(N'[Workers]'))
        SET IDENTITY_INSERT [Workers] ON;
    EXEC(N'INSERT INTO [Workers] ([Id], [Address], [DateOfBirth], [DateRegister], [FirstName], [LastName], [PhoneNumber], [PositionId])
    VALUES (''6f253175-a69f-4b28-ac5a-597d40803c51'', N''Panjakent'', ''0001-01-01T00:00:00.0000000'', ''0001-01-01T00:00:00.0000000'', N''Shahzodjon'', N''Jonizoqov'', N''+992927758499'', ''b2bd64c3-e072-4982-b399-a272ce786635'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'DateOfBirth', N'DateRegister', N'FirstName', N'LastName', N'PhoneNumber', N'PositionId') AND [object_id] = OBJECT_ID(N'[Workers]'))
        SET IDENTITY_INSERT [Workers] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsBlocked', N'Login', N'Password', N'RefreshToken', N'WorkerId') AND [object_id] = OBJECT_ID(N'[Auths]'))
        SET IDENTITY_INSERT [Auths] ON;
    EXEC(N'INSERT INTO [Auths] ([Id], [IsBlocked], [Login], [Password], [RefreshToken], [WorkerId])
    VALUES (''5bd12d15-4a1c-4f4a-af0e-42ba914dc5b3'', CAST(0 AS bit), N''SupperAdmin123'', N''!@#123#@!'', N'''', ''6f253175-a69f-4b28-ac5a-597d40803c51'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsBlocked', N'Login', N'Password', N'RefreshToken', N'WorkerId') AND [object_id] = OBJECT_ID(N'[Auths]'))
        SET IDENTITY_INSERT [Auths] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'WorkerId') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    EXEC(N'INSERT INTO [Roles] ([Id], [Name], [WorkerId])
    VALUES (''f8b70e5a-bca6-493d-8e6d-d595cb844dd6'', N''Admin'', ''6f253175-a69f-4b28-ac5a-597d40803c51'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'WorkerId') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240522024453_addedClinetMigration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240522024453_addedClinetMigration', N'8.0.0');
END;
GO

COMMIT;
GO

