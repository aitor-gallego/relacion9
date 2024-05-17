using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Styling;
using Avalonia.Threading;
using Avalonia.VisualTree;

namespace Ej6;

public partial class MainWindow : Window
{
    private DispatcherTimer _timer;
    private int[] _estadistica = new int[6];
    string[] _imagenes = Directory.GetFiles("../../../Assets/");

    private int _numTiradas = 0;
    
    public MainWindow()
    {
        InitializeComponent();
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(500); // Adjust the interval as needed
        _timer.Tick += (sender, args) => TirarDado();
    }
    
    private void TirarDado()
    {
        Random rnd = new();
        var numDado = rnd.Next(6);
                
        ImgDado.Source = new Bitmap(_imagenes[numDado]);
        _estadistica[numDado] += 1;
        _numTiradas += 1;
        
        //actualizar
        ActualizarNTiradas();
        ActualizarEstadistica();
    }
    
    private void RegistroMensaje(string msg)
    {
        var lbl = new Label() { Content = msg, HorizontalAlignment = HorizontalAlignment.Center, Foreground = Brushes.Black };
        RegistroCnv.Children.Add(lbl);
    }

    private void ActualizarNTiradas()
    {
        LblNumTiradas.Content = _numTiradas;
    }

    private void ActualizarEstadistica()
    {
        try
        {
            LblTiradas1.Content = _estadistica[0];
            LblPorcentaje1.Content = $"{(_estadistica[0] * 100 / _numTiradas):F2}%";
        
            LblTiradas2.Content = _estadistica[1];
            LblPorcentaje2.Content = $"{(_estadistica[1] * 100 / _numTiradas):F2}%";
        
            LblTiradas3.Content = _estadistica[2];
            LblPorcentaje3.Content = $"{(_estadistica[2] * 100 / _numTiradas):F2}%";
        
            LblTiradas4.Content = _estadistica[3];
            LblPorcentaje4.Content = $"{(_estadistica[3] * 100 / _numTiradas):F2}%";
        
            LblTiradas5.Content = _estadistica[4];
            LblPorcentaje5.Content = $"{(_estadistica[4] * 100 / _numTiradas):F2}%";
        
            LblTiradas6.Content = _estadistica[5];
            LblPorcentaje6.Content = $"{(_estadistica[5] * 100 / _numTiradas):F2}%";
        }
        catch (Exception e)
        {
            LblTiradas1.Content = 0;
            LblPorcentaje1.Content = "0,00%";
            LblTiradas2.Content = 0;
            LblPorcentaje2.Content = "0,00%";
            LblTiradas3.Content = 0;
            LblPorcentaje3.Content = "0,00%";
            LblTiradas4.Content = 0;
            LblPorcentaje4.Content = "0,00%";
            LblTiradas5.Content = 0;
            LblPorcentaje5.Content = "0,00%";
            LblTiradas6.Content = 0;
            LblPorcentaje6.Content = "0,00%";
        }
    }

    private void BtnTirar_OnClick(object? sender, RoutedEventArgs e)
    {
        RegistroMensaje("Se ha tirado el dado");
        TirarDado();
    }

    private void BtnAuto_OnClick(object? sender, RoutedEventArgs e)
    {
        RegistroMensaje("El dado está en automático");
        if (BtnAuto.IsChecked == true)
        {
            _timer.Start();
            BtnReset.IsEnabled = false;
        }
        else
        {
            _timer.Stop();
            BtnReset.IsEnabled = true;
        }
    }

    private void BtnReset_OnClick(object? sender, RoutedEventArgs e)
    {
        RegistroMensaje("El dado se ha reseteado");
        ImgDado.Source =  new Bitmap(_imagenes[6]);
        for (int i = 0; i < _estadistica.Length-1; i++)
            _estadistica[i] = 0;
        _numTiradas = 0;
        ActualizarEstadistica();
        ActualizarNTiradas();
    }
}