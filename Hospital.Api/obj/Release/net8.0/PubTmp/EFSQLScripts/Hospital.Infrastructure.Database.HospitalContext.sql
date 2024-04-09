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
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE TABLE [Appointments] (
        [Id] uniqueidentifier NOT NULL,
        [DoctorId] uniqueidentifier NOT NULL,
        [AppointmentDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Appointments] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240405032901_createDb'
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
    WHERE [MigrationId] = N'20240405032901_createDb'
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
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE TABLE [Users] (
        [Id] uniqueidentifier NOT NULL,
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
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE TABLE [Workers] (
        [Id] uniqueidentifier NOT NULL,
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
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE TABLE [Rooms] (
        [Id] uniqueidentifier NOT NULL,
        [RoomNumber] int NOT NULL,
        [FloorId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Rooms] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Rooms_Floors_FloorId] FOREIGN KEY ([FloorId]) REFERENCES [Floors] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE TABLE [Branches] (
        [Id] uniqueidentifier NOT NULL,
        [Location] nvarchar(max) NOT NULL,
        [HospitalID] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Branches] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Branches_Hospitals_HospitalID] FOREIGN KEY ([HospitalID]) REFERENCES [Hospitals] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240405032901_createDb'
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
    WHERE [MigrationId] = N'20240405032901_createDb'
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
    WHERE [MigrationId] = N'20240405032901_createDb'
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
    WHERE [MigrationId] = N'20240405032901_createDb'
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
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE TABLE [DoctorPatients] (
        [DoctorID] uniqueidentifier NOT NULL,
        [PatientId] uniqueidentifier NOT NULL,
        [Id] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_DoctorPatients] PRIMARY KEY ([DoctorID], [PatientId]),
        CONSTRAINT [FK_DoctorPatients_Doctors_DoctorID] FOREIGN KEY ([DoctorID]) REFERENCES [Doctors] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_DoctorPatients_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] ON;
    EXEC(N'INSERT INTO [Hospitals] ([Id], [Location], [Name])
    VALUES (''635b969d-7944-42ad-9d73-3607af481fbd'', N''Абрешим'', N''Обласной болница''),
    (''7e8ccf20-a556-4814-a40a-79068fa3f49b'', N''Гулистон'', N''Гор болница'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Hospitals]'))
        SET IDENTITY_INSERT [Hospitals] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE INDEX [IX_Branches_HospitalID] ON [Branches] ([HospitalID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE INDEX [IX_DepartmentPatients_PatientId] ON [DepartmentPatients] ([PatientId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE INDEX [IX_Departments_BranchID] ON [Departments] ([BranchID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE INDEX [IX_DoctorPatients_PatientId] ON [DoctorPatients] ([PatientId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE INDEX [IX_Doctors_DepartmentId] ON [Doctors] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE INDEX [IX_Patients_RoomID] ON [Patients] ([RoomID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    CREATE INDEX [IX_Rooms_FloorId] ON [Rooms] ([FloorId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240405032901_createDb'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240405032901_createDb', N'8.0.0');
END;
GO

COMMIT;
GO

