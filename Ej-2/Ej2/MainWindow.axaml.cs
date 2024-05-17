using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Ej2;

public partial class MainWindow : Window
{
    private int _num;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Generar_OnClick(object? sender, RoutedEventArgs e)
    {
        Random rnd = new();
        _num = rnd.Next(1, 100);
        Acertar.Foreground = Brushes.White;
        Acertar.Watermark = "Adivinar el número";
        Acertar.Text = "";
    }

    private void Probar_OnClick(object? sender, RoutedEventArgs e)
    {
        if (_num == 0)
            Acertar.Watermark = "Genera un número";
        else if (Acertar.Text == string.Empty)
            Acertar.Watermark = "Prueba un número";
        else if (int.Parse(Acertar.Text) > _num)
            Acertar.Watermark = "Te has pasado";
        else if(int.Parse(Acertar.Text) < _num)
            Acertar.Watermark = "Te has quedado corto";
        else
        {
            Acertar.Watermark = "Número adivinado";
            Acertar.Foreground = Brushes.LightSeaGreen;
        }
    }

    private void Visibilidad_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Visibilidad.IsChecked == true)
            Numero.Text = _num.ToString();
        else
            Numero.Text = "?";
    }
}