using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Templates;

namespace DataViewer.UI.Avalonia.Templates;

public partial class FieldTemplates : ResourceDictionary
{
    internal static readonly FieldTemplates Instance = new FieldTemplates();

    // В Avalonia UI доступ к ресурсам словаря по ключу осуществляется через индексатор или метод TryGetResource.
    // Так как типы ресурсов возвращают object, приводим его к авалониевскому DataTemplate.
    public DataTemplate TestTemplate
    {
        get
        {
            var tmp = (DataTemplate)this["TestTemplate"]!;

            return tmp;
                
        }
    }

    public FieldTemplates()
    {
        // Аналог InitializeComponent() для ресурсов в Avalonia UI
        AvaloniaXamlLoader.Load(this);
    }
}
