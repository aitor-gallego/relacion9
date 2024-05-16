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
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    for (int k = 0; k < 60; k++)
                    {
                        LblReloj.Content = $"{h:D2}:{m:D2}:{s:D2}";
                        await Task.Delay(1000);
                        s++;
                    }
                    m++;
                }
                h++;
            }
    }

    private void BtnEmpezar_OnClick(object? sender, RoutedEventArgs e)
    {
            _status = true;
            BtnReiniciar.IsEnabled = true;
            BtnParar.IsEnabled = true;
            Reloj();   
    }

    private void BtnParar_OnClick(object? sender, RoutedEventArgs e)
    {
        _status = false;
    }

    private async void BtnSalir_OnClick(object? sender, RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Confirmar para salir de la aplicación", "¿Estás Seguro/a?",
            ButtonEnum.YesNo);
        if (await box.ShowWindowAsync() == ButtonResult.Yes)
            Close();
    }

    private void BtnReiniciar_OnClick(object? sender, RoutedEventArgs e)
    {
        _status = false;
        BtnParar.IsEnabled = false;
        LblReloj.Content = $"{0:D2}:{0:D2}:{0:D2}";
    }
}