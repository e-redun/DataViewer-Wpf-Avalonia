using Common.Models;

namespace Common.Services;

public interface IDataService
{
    // Получить список имен всех доступных баз данных
    List<string> GetDatabases();

    // Получить список всех таблиц для конкретной базы данных
    List<string> GetTables(string? databaseName);

    // Получить данные конкретной таблицы
    TableModel GetTableContent(string? databaseName, string? tableName);
}