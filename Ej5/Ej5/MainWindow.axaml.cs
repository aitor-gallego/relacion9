using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace Ej5;

public partial class MainWindow : Window
{
    private bool _status = false;
    private int h = 0;
    private int m = 0;
    private int s = 0;
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Reloj()
    {
        while (_status)
        {
            LblReloj.Content = $"{h:D2}:{m:D2}:{s:D2}";
            await Task.Delay(1000);

            s++;
            if (s == 60)
            {
                s = 0;
                m++;
                if (m == 60)
                {
                    m = 0;
                    h++;
                    if (h == 24)
                    {
                        h = 0;
                    }
                }
            }
        }
    }

    private void BtnEmpezar_OnClick(object? sender, RoutedEventArgs e)
    {
        _status = true;
        BtnEmpezar.IsEnabled = false;
        BtnParar.IsEnabled = true;
        BtnReiniciar.IsEnabled = true;
        Reloj();
    }

    private void BtnParar_OnClick(object? sender, RoutedEventArgs e)
    {
        _status = false;
        BtnEmpezar.IsEnabled = true;
        BtnParar.IsEnabled = false;
        BtnReiniciar.IsEnabled = true;
    }

    private void BtnReiniciar_OnClick(object? sender, RoutedEventArgs e)
    {
        _status = false;
        BtnEmpezar.IsEnabled = true;
        BtnParar.IsEnabled = false;
        BtnReiniciar.IsEnabled = true;
        
        h = 0;
        m = 0;
        s = 0;
        LblReloj.Content = $"{h:D2}:{m:D2}:{s:D2}";
    }
    
    private async void BtnSalir_OnClick(object? sender, RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Confirmar para salir de la aplicación", "¿Estás Seguro/a?",
            ButtonEnum.YesNo);
        if (await box.ShowWindowAsync() == ButtonResult.Yes)
            Close();
    }
}