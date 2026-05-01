-- SQLite init script for GestionEmpleados
CREATE TABLE IF NOT EXISTS Empleados (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT NOT NULL,
    Apellidos TEXT NOT NULL,
    Departamento TEXT NOT NULL,
    Salario REAL NOT NULL,
    FechaIngreso TEXT NOT NULL,
    Activo INTEGER NOT NULL
);


