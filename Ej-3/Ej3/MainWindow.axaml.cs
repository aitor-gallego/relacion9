using System;
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
        int ini;
        int fin;
        try
        {
            ini = int.Parse(Inicial.Text);
            fin = int.Parse(Final.Text);
        }
        catch (Exception exception)
        {
            Resultado.Content = "Falta algún número";
            return;
        }
        if (ini > 10000 || fin > 10000)
        {
            Resultado.Content = "Números demasiado grandes";
            return;
        }
        while (ini<=fin)
        {
            suma += ini;
            ini++;
        }
        Resultado.Content = suma.ToString();
    }
}