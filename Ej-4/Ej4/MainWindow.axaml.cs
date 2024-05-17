using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Ej4;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private string Encriptar(string encriptar, int desp){
        string str = "";
        char caracter;
        for (int i = 0; i < encriptar.Length; i++)
        {
            caracter = encriptar[i];
            if (char.IsLower(caracter))
                caracter = (char)('a' + (caracter - 'a' + desp) % 27);
            else
                caracter = (char)('A' + (caracter - 'A' + desp) % 27);

            str += caracter;
        }
        return str;
    }
    
    private void EncriptarBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Frase.Text == null || Desplazamiento.Value == null) return;
        var desp = (int)Desplazamiento.Value;
        var frase = Frase.Text;
        var encriptada = string.Empty;
        encriptada = Encriptar(frase, desp);
        
        OriginalLbl.Content = frase;
        EncriptadaLbl.Content = encriptada;
        DesencriptadaLbl.Content = frase;
    }
}