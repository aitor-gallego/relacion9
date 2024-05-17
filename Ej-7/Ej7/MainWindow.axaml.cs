using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace Ej7;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void CambiarColor(){
        byte rojo = (byte)Rojo.Value;
        byte green = (byte)Verde.Value;
        byte azul = (byte)Azul.Value;
        if (rojo==0 && green==0 && azul==0)
            Rectangle.Fill = new SolidColorBrush(Colors.Black);
        
        else if(rojo==255 && green==255 && azul==255)
            Rectangle.Fill = new SolidColorBrush(Colors.White);
        else
            Rectangle.Fill = new SolidColorBrush(Color.FromRgb(rojo,green,azul));
    }

    private void Slider_OnValueChanged(object? sender, RangeBaseValueChangedEventArgs e)
    {
        CambiarColor();
    }
}