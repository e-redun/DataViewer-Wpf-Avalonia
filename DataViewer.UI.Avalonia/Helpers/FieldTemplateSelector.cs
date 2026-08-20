using Avalonia.Controls;
using Avalonia.Controls.Templates;
using DataViewer.UI.Avalonia.Templates;

namespace DataViewer.UI.Avalonia.Helpers
{
    internal class FieldTemplateSelector : IDataTemplate
    {
        public Control? Build(object? param)
        {
            // Получаем шаблон из нашего синглтона ресурсов и создаем его визуальное дерево
            var template = FieldTemplates.Instance.TestTemplate;
            return template?.Build(param);
        }

        // Метод Match определяет, применим ли этот селектор к переданному объекту данных.
        // Если возвращает true, Avalonia вызовет метод Build.
        public bool Match(object? data)
        {
            // Здесь можно сделать проверку типа, как в WPF (например, data is CellModel)
            return true;
        }
    }
}