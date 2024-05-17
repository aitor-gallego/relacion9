using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;

namespace Ej11;

public partial class MainWindow : Window
{
    private List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
    public int count=0;
    int fil;
    int col;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void DarTamañoGrid()
    {
        
        string columnas = "";
        string filas = "";
        int.TryParse(ComboFil.SelectionBoxItem.ToString(),out fil);
        int.TryParse(ComboCol.SelectionBoxItem.ToString(),out col);
        for (int i = 0; i < fil ; i++)
        {
            filas += "Auto,";
        }
        for (int j = 0; j < col; j++)
        {
            columnas += "Auto,";
        }

        columnas = columnas.Remove(columnas.Length-1, 1);
        filas = filas.Remove(filas.Length-1, 1);
        MainGrid.RowDefinitions = RowDefinitions.Parse(filas);
        MainGrid.ColumnDefinitions = ColumnDefinitions.Parse(columnas);
    }
    private void Matriz()
    {
        DarTamañoGrid();
        count = 0;
        for (int i = 0; i < fil; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Button btn = new Button();
                MainGrid.Children.Add(btn);
                btn.Content = $"{i} | {j}";
                btn.Background = Brushes.Indigo;
                btn.Margin = Thickness.Parse("5");
                btn.CornerRadius = CornerRadius.Parse("25");
                btn.HorizontalContentAlignment = HorizontalAlignment.Center;
                btn.VerticalContentAlignment = VerticalAlignment.Center;
                btn.MinWidth = 40;
                btn.MinHeight = 30;
                btn.FontSize = 10;
                Grid.SetRow(btn,i);
                Grid.SetColumn(btn,j);
                count++;
            }
        }
    }
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Matriz();
    }
}