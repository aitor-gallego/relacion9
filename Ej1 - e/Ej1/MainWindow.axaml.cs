using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Ej1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Calcular_OnClick(object? sender, RoutedEventArgs e)
    {
        if (tbNumero.Text != null)
        {
            int num = int.Parse(tbNumero.Text);
            int acum = 0;
            for (int i = 1; i <= num; i++)
                acum += i;
            tbResultado.Text = acum.ToString();  
        }    
    }

    private void Close_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}