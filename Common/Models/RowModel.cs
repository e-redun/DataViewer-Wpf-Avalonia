namespace Common.Models;

public class RowModel
{
    public List<CellModel> Cells { get; set; } = new();

    public object? GetValue(string columnName)
    {
        return Cells.FirstOrDefault(c => c.ColumnName == columnName)?.Value;
    }
}