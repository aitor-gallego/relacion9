using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Ej4;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void EncriptarBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var frase = Frase.Text;
        var encriptada = string.Empty;
        var desp = Desplazamiento.Value;
        foreach (var c in frase)
        {
            var nc = (int)c + desp;
            encriptada += (char)nc;
        }

        OriginalLbl.Content = frase;
        EncriptadaLbl.Content = encriptada;
        DesencriptadaLbl.Content = frase;
    }
}