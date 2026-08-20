using DataViewer.UI.Wpf.Templates;
using System.Windows;
using System.Windows.Controls;

namespace DataViewer.UI.Wpf.Helpers
{
    internal class FieldTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return FieldTemplates.Instance.TestTemplate;
        }
    }
}