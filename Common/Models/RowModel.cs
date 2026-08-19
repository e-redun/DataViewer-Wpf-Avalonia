namespace Common.Models;

public class RowModel
{
    public List<FieldModel> Fields { get; set; } = new();

    public object? GetValue(string columnName)
    {
        return Fields.FirstOrDefault(c => c.ColumnName == columnName)?.Value;
    }
}