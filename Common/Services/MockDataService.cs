using Common.Models;

namespace Common.Services;

public class MockDataService : IDataService
{
    public List<string> GetDatabases()
    {
        return new List<string> { "Company.db", "Warehouse.db" };
    }

    public List<string> GetTables(string databaseName)
    {
        if (databaseName == "Company.db")
        {
            return new List<string> { "Employees", "Departments" };
        }
        if (databaseName == "Warehouse.db")
        {
            return new List<string> { "Products" };
        }
        return new List<string>();
    }

    public TableModel GetTableContent(string databaseName, string tableName)
    {
        var table = new TableModel { Name = tableName };

        if (databaseName == "Company.db" && tableName == "Employees")
        {
            // Имитируем аватарку: просто массив из 4 байт для теста
            byte[] fakePhotoBytes = new byte[] { 1, 2, 3, 4 };

            table.Rows.Add(CreateRow(new() { ("Id", 1), ("Name", "Иван Иванов"), ("Age", 30), ("IsManager", true), ("Photo", fakePhotoBytes) }));
            table.Rows.Add(CreateRow(new() { ("Id", 2), ("Name", "Петр Петров"), ("Age", 25), ("IsManager", false), ("Photo", fakePhotoBytes) }));
        }
        else if (databaseName == "Company.db" && tableName == "Departments")
        {
            table.Rows.Add(CreateRow(new() { ("Id", 101), ("Title", "IT Отдел"), ("Budget", 500000) }));
            table.Rows.Add(CreateRow(new() { ("Id", 102), ("Title", "Бухгалтерия"), ("Budget", 150000) }));
        }
        else if (databaseName == "Warehouse.db" && tableName == "Products")
        {
            table.Rows.Add(CreateRow(new() { ("Sku", "A-001"), ("Title", "Ноутбук"), ("Price", 75000.50) }));
            table.Rows.Add(CreateRow(new() { ("Sku", "B-002"), ("Title", "Мышь"), ("Price", 1500.00) }));
        }

        return table;
    }

    // Удобный метод-помощник для быстрой сборки универсальной строки из кортежей (Tuple)
    private RowModel CreateRow(List<(string Name, object? Value)> fields)
    {
        var row = new RowModel();
        foreach (var field in fields)
        {
            row.Cells.Add(new CellModel { ColumnName = field.Name, Value = field.Value });
        }
        return row;
    }
}