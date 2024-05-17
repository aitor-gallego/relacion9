using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Ej8;

public partial class MainWindow : Window
{
private Random _random = new Random();

        private int _dado1;
        private int _dado2;
        private int _suma;
        private bool _resultado;

        public MainWindow()
        {
            InitializeComponent();
            Resetear();
            ActualizarTexto();
        }

        private void BtnTirar_Click(object sender, RoutedEventArgs e)
        {
            TirarDado();
            ActualizarTexto();
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Resetear();
            ActualizarTexto();
        }

        private void TirarDado()
        {
            _dado1 = _random.Next(1, 7);
            _dado2 = _random.Next(1, 7);
            int total = _dado1 + _dado2;

            if (_suma == 0)
            {
                if (total == 7 || total == 11)
                {
                    TxtResultado.Text = "Ganas";
                    _resultado = true;
                    BtnTirar.IsEnabled = false;
                }
                else if (total == 2 || total == 3 || total == 12)
                {
                    TxtResultado.Text = "Pierdes";
                    _resultado = true;
                    BtnTirar.IsEnabled = false;
                }
                else
                {
                    _suma = total;
                    TxtResultado.Text = $"Resultado: {_suma}";
                }
            }
            else
            {
                if (total == _suma)
                {
                    TxtResultado.Text = "Ganas";
                    _resultado = true;
                    BtnTirar.IsEnabled = false;
                }
                else if (total == 7)
                {
                    TxtResultado.Text = "Pierdes";
                    _resultado = true;
                    BtnTirar.IsEnabled = false;
                }
            }
        }

        private void Resetear()
        {
            _suma = 0;
            _dado1 = 0;
            _dado2 = 0;
            _resultado = false;
            TxtResultado.Text = "Tira el dado";
            BtnTirar.IsEnabled = true;
        }

        private void ActualizarTexto()
        {
            TxtDado1.Text = _dado1.ToString();
            TxtDado2.Text = _dado2.ToString();
            TxtTotal.Text = (_dado1 + _dado2).ToString();
            BtnNuevo.IsEnabled = _resultado;
        }
}