using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Common.Models;

namespace DataViewer.UI.Wpf.Extensions;

public static class DataGridExtensions
{
    public static readonly DependencyProperty DynamicRowsProperty =
        DependencyProperty.RegisterAttached(
            "DynamicRows",
            typeof(ObservableCollection<RowModel>),
            typeof(DataGridExtensions),
            new PropertyMetadata(null, OnDynamicRowsChanged));

    public static void SetDynamicRows(DependencyObject element, ObservableCollection<RowModel> value)
        => element.SetValue(DynamicRowsProperty, value);

    public static ObservableCollection<RowModel> GetDynamicRows(DependencyObject element)
        => (ObservableCollection<RowModel>)element.GetValue(DynamicRowsProperty);

    private static void OnDynamicRowsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not DataGrid dataGrid) return;

        // Отписываемся от старой коллекции, если она была
        if (e.OldValue is INotifyCollectionChanged oldCollection)
        {
            oldCollection.CollectionChanged -= (s, args) => RebuildColumns(dataGrid);
        }

        // Подписываемся на новую коллекцию
        if (e.NewValue is ObservableCollection<RowModel> newCollection)
        {
            // Отключаем стандартную автогенерацию колонок WPF
            dataGrid.AutoGenerateColumns = false;

            // Перестраиваем колонки сразу при присвоении
            RebuildColumns(dataGrid);

            // И следим за изменениями (например, когда прилетит новый список строк)
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

        // Берем самую первую строку для выявления структуры колонок
        var firstRow = rows.FirstOrDefault();
        if (firstRow == null)
        {
            return;
        }

        // Генерируем колонки на основе CellModel
        for (int i = 0; i < firstRow.Fields.Count; i++)
        {
            var cell = firstRow.Fields[i];

            var column = new DataGridTextColumn
            {
                Header = cell.ColumnName,
                // Используем индекс ячейки для жесткой привязки
                Binding = new Binding($"Fields[{i}].Value")
            };

            dataGrid.Columns.Add(column);
        }
    }
}
