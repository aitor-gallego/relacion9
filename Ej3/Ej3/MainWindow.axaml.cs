using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Ej3;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SumarBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        int suma = 0;
        int ini = int.Parse(Inicial.Text);
        int fin = int.Parse(Final.Text);
        while (ini<=fin)
        {
            suma += ini;
            ini++;
        }
        Resultado.Content = suma.ToString();
    }
}