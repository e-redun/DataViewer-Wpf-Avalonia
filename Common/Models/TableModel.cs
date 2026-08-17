namespace Common.Models;

public class TableModel
{
    public string Name { get; set; } = string.Empty;

    public List<RowModel> Rows { get; set; } = new();
}