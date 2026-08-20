using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Common.Models;

namespace DataViewer.UI.Avalonia.Extensions;

public static class DataGridExtensions
{
    public static readonly AttachedProperty<ObservableCollection<RowModel>?> DynamicRowsProperty =
        AvaloniaProperty.RegisterAttached<DataGrid, ObservableCollection<RowModel>?>(
            "DynamicRows",
            ownerType: typeof(DataGridExtensions),
            defaultValue: null);

    static DataGridExtensions()
    {
        DynamicRowsProperty.Changed.AddClassHandler<DataGrid>(OnDynamicRowsChanged);
    }

    public static void SetDynamicRows(AvaloniaObject element, ObservableCollection<RowModel>? value)
        => element.SetValue(DynamicRowsProperty, value);

    public static ObservableCollection<RowModel>? GetDynamicRows(AvaloniaObject element)
        => element.GetValue(DynamicRowsProperty);

    private static void OnDynamicRowsChanged(DataGrid dataGrid, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.OldValue is INotifyCollectionChanged oldCollection)
        {
            oldCollection.CollectionChanged -= (s, args) => RebuildColumns(dataGrid);
        }

        if (e.NewValue is ObservableCollection<RowModel> newCollection)
        {
            dataGrid.AutoGenerateColumns = false;

            RebuildColumns(dataGrid);

            newCollection.CollectionChanged += (s, args) => RebuildColumns(dataGrid);
        }
    }

    private static void RebuildColumns(DataGrid dataGrid)
    {
        dataGrid.Columns.Clear();

        var rows = GetDynamicRows(dataGrid);

        if (rows == null || rows.Count == 0)
        {
            return;
        }

        var firstRow = rows.FirstOrDefault();
        if (firstRow == null || firstRow.Fields == null)
        {
            return;
        }

        for (int i = 0; i < firstRow.Fields.Count; i++)
        {
            var cell = firstRow.Fields[i];

            var column = new DataGridTextColumn
            {
                Header = cell.ColumnName,
                Binding = new Binding($"Fields[{i}].Value")
            };

            dataGrid.Columns.Add(column);
        }
    }
}