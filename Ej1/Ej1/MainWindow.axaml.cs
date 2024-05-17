using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

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
    private async void BtnSalir_OnClick(object? sender, RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Confirmar para salir de la aplicación", "¿Estás Seguro/a?",
            ButtonEnum.YesNo);
        if (await box.ShowWindowAsync() == ButtonResult.Yes)
            Close();
    }
}