using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Data;

namespace proj_1;

public partial class MainWindow : Window
{
    private string currentInput = "";

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Number_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn)
        {
            currentInput += btn.Content?.ToString();
            DisplayBox.Text = currentInput;
        }
    }

    private void Operator_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn)
        {
            currentInput += " " + btn.Content?.ToString() + " ";
            DisplayBox.Text = currentInput;
        }
    }

    private void Clear_Click(object? sender, RoutedEventArgs e)
    {
        currentInput = "";
        DisplayBox.Text = "0";
    }

    private void Equals_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            var result = new DataTable().Compute(currentInput, null);
            DisplayBox.Text = result?.ToString() ?? "0";
            currentInput = DisplayBox.Text ?? "";
        }
        catch
        {
            DisplayBox.Text = "Error";
            currentInput = "";
        }
    }
}