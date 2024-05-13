using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
namespace Ej9;

public partial class MainWindow : Window
{
    private const double PaddleSpeed = 10.0;
    private const double BallSpeed = 7.0;
    private const double InitialBallDirectionX = 1.0;
    private const double InitialBallDirectionY = 1.0;
    
    private double dirX = InitialBallDirectionX;
    private double dirY = InitialBallDirectionY;

    public MainWindow()
    {
        InitializeComponent();
        KeyDown += OnKeyDown;
        Activated += OnActivated;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        jugador = this.FindControl<Rectangle>("jugador");
        pelota = this.FindControl<Ellipse>("pelota");
    }

    private async void OnActivated(object sender, EventArgs e)
    {
        await GameLoop();
    }

    private async Task GameLoop()
    {
        while (true)
        {
            MovimientoPelota();
            Colisiones();
            await Task.Delay(TimeSpan.FromMilliseconds(20));
        }
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Left:
                MovimientoJugador(-PaddleSpeed);
                break;
            case Key.Right:
                MovimientoJugador(PaddleSpeed);
                break;
        }
    }

    private void MovimientoJugador(double deltaX)
    {
        double newLeft = Canvas.GetLeft(jugador) + deltaX;
        if (newLeft >= 0 && newLeft + jugador.Width <= this.Width)
        {
            Canvas.SetLeft(jugador, newLeft);
        }
    }

    private void MovimientoPelota()
    {
        double ballLeft = Canvas.GetLeft(pelota);
        double ballTop = Canvas.GetTop(pelota);

        ballLeft += dirX * BallSpeed;
        ballTop += dirY * BallSpeed;

        Canvas.SetLeft(pelota, ballLeft);
        Canvas.SetTop(pelota, ballTop);
    }

    private void Colisiones()
    {
        double ballLeft = Canvas.GetLeft(pelota);
        double ballTop = Canvas.GetTop(pelota);

        if (ballLeft <= 0 || ballLeft + pelota.Width >= this.Width)
        {
            dirX *= -1;
        }

        if (ballTop <= 0 || ballTop + pelota.Height >= this.Height)
        {
            dirY *= -1;
        }

        if (ballTop + pelota.Height >= Height - jugador.Height &&
            ballLeft + pelota.Width >= Canvas.GetLeft(jugador) &&
            ballLeft <= Canvas.GetLeft(jugador) + jugador.Width)
        {
            dirY *= -1;
        }
    }
}