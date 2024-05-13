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

