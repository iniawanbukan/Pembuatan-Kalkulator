using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Data;

namespace proj_1;

public partial class MainWindow : Window
{
    private string currentInput = "";
    private string expressionString = "";

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
            if (!string.IsNullOrEmpty(currentInput))
            {
                expressionString += currentInput + " " + btn.Content?.ToString() + " ";
                ExpressionText.Text = expressionString;
                currentInput = "";
                DisplayBox.Text = "0";
            }
            else if (!string.IsNullOrEmpty(expressionString))
            {
                expressionString = expressionString.TrimEnd() + " " + btn.Content?.ToString() + " ";
                ExpressionText.Text = expressionString;
            }
        }
    }

    private void Clear_Click(object? sender, RoutedEventArgs e)
    {
        currentInput = "";
        expressionString = "";
        DisplayBox.Text = "0";
        ExpressionText.Text = ""; // Membersihkan layar ekspresi atas saat tombol C diklik
    }

    private void Equals_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            string fullExpression = expressionString + currentInput;
            if (string.IsNullOrWhiteSpace(fullExpression)) return;

            var result = new DataTable().Compute(fullExpression, null);
            string resStr = result?.ToString() ?? "0";

            ExpressionText.Text = fullExpression + " =";
            DisplayBox.Text = resStr;

            currentInput = resStr;
            expressionString = "";
        }
        catch
        {
            DisplayBox.Text = "Error";
            currentInput = "";
            expressionString = "";
        }
    }
}