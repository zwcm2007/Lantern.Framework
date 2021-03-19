namespace Lantern.Data
{
    public enum DbProviderType : byte
    {
        Unknown = 0,
        SqlServer = 1,
        MySql,
        Oracle,
        OracleDataAccess,
        OracleManagedDataAccess,
        SQLite,
        ODBC,
        OleDb,
        Firebird,
        PostgreSql,
        DB2,
        Informix,
        SqlServerCe
    }
}