using System;
using System.Globalization;
using System.IO;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml.Converters;
using Avalonia.Media;

namespace ShowTimeAlwaysOnTop;

public partial class MainWindow : Window
{
    private readonly TimeView Tv = new();
    private int X, Y;
    private bool TimeShown = false;
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void TbSize_OnValueChanged(object? sender, RangeBaseValueChangedEventArgs e)
    {
        Tv.FontSize = TbSize.Value;
    }

    private void TbOpacity_OnValueChanged(object? sender, RangeBaseValueChangedEventArgs e)
    {
        Tv.Opacity = TbOpacity.Value / 100D;
    }

    private void BtnHide_OnClick(object? sender, RoutedEventArgs e)
    {
        Tv.Hide();
        TimeShown = false;
    }

    private void BtnShow_OnClick(object? sender, RoutedEventArgs e)
    {
        Tv.Show();
        TimeShown = true;
    }

    private void DragArea_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var point = e.GetCurrentPoint(sender as Control);
        X = (int)point.Position.X - Tv.Position.X;
        Y = (int)point.Position.Y - Tv.Position.Y;
    }

    private void DragArea_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        var point = e.GetCurrentPoint(sender as Control);
        if (point.Properties.IsLeftButtonPressed)
        {
            Tv.Position = new PixelPoint((int)point.Position.X - X, (int)point.Position.Y - Y);
        }
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        if (!File.Exists("config.txt")) return;
        string[] lines = File.ReadAllLines("config.txt");
        foreach (string line in lines)
        {
            if (line.Contains('='))
            {
                string key = line[..line.IndexOf('=')];
                string value = line[(line.IndexOf('=') + 1)..];
                switch (key)
                {
                    case "TimeX":
                        Tv.Position = new PixelPoint(int.Parse(value, CultureInfo.InvariantCulture), Tv.Position.Y);
                        break;
                    case "TimeY":
                        Tv.Position = new PixelPoint(Tv.Position.X, int.Parse(value, CultureInfo.InvariantCulture));
                        break;
                    case "TimeFont":
                        Tv.FontFamily = value;
                        break;
                    case "TimeColorR":
                    {
                        var nullableColor = (Color?)ColorToBrushConverter.ConvertBack(Tv.Foreground, typeof(Color));
                        if (nullableColor is null) continue;
                        var color = (Color)nullableColor;
                        color = new Color(color.A, byte.Parse(value), color.G, color.B);
                        var brush = ColorToBrushConverter.Convert(color, typeof(IBrush));
                        if (brush is not null) Tv.Foreground = (IBrush)brush;
                        break;
                    }
                    case "TimeColorG":
                    {
                        var nullableColor = (Color?)ColorToBrushConverter.ConvertBack(Tv.Foreground, typeof(Color));
                        if (nullableColor is null) continue;
                        var color = (Color)nullableColor;
                        color = new Color(color.A, color.R, byte.Parse(value), color.B);
                        var brush = ColorToBrushConverter.Convert(color, typeof(IBrush));
                        if (brush is not null) Tv.Foreground = (IBrush)brush;
                        break;
                    }
                    case "TimeColorB":
                    {
                        var nullableColor = (Color?)ColorToBrushConverter.ConvertBack(Tv.Foreground, typeof(Color));
                        if (nullableColor is null) continue;
                        var color = (Color)nullableColor;
                        color = new Color(color.A, color.R, color.G, byte.Parse(value));
                        var brush = ColorToBrushConverter.Convert(color, typeof(IBrush));
                        if (brush is not null) Tv.Foreground = (IBrush)brush;
                        break;
                    }
                    case "TimeShown":
                        if (bool.Parse(value))
                        {
                            Tv.Show();
                            TimeShown = true;
                        }
                        else
                        {
                            Tv.Hide();
                            TimeShown = false;
                        }
                        break;
                    case "Transparency":
                        TbOpacity.Value = double.Parse(value);
                        Tv.Opacity = TbOpacity.Value / 100D;
                        break;
                    case "Size":
                        TbSize.Value = double.Parse(value);
                        Tv.FontSize = TbSize.Value;
                        break;
                    case "X":
                        Position = new PixelPoint(int.Parse(value), Position.Y);
                        break;
                    case "Y":
                        Position = new PixelPoint(Position.X, int.Parse(value));
                        break;
                }
            }
        }
    }

    private void Window_OnClosing(object? sender, WindowClosingEventArgs e)
    {
        StringBuilder settings = new();
        var tvForeground = (Color?)ColorToBrushConverter.ConvertBack(Tv.Foreground, typeof(Color));
        settings.Append("TimeX=").AppendLine(Tv.Position.X.ToString());
        settings.Append("TimeY=").AppendLine(Tv.Position.Y.ToString());
        settings.Append("TimeFont=").AppendLine(Tv.FontFamily.Name);
        if (tvForeground is not null)
        {
            settings.Append("TimeColorR=").AppendLine(tvForeground?.R.ToString());
            settings.Append("TimeColorG=").AppendLine(tvForeground?.G.ToString());
            settings.Append("TimeColorB=").AppendLine(tvForeground?.B.ToString());
        }
        settings.Append("TimeShown=").AppendLine(TimeShown.ToString());
        settings.Append("Transparency=").AppendLine(TbOpacity.Value.ToString(CultureInfo.InvariantCulture));
        settings.Append("Size=").AppendLine(TbSize.Value.ToString(CultureInfo.InvariantCulture));
        settings.Append("X=").AppendLine(Position.X.ToString());
        settings.Append("Y=").AppendLine(Position.Y.ToString());
        File.WriteAllText("config.txt", settings.ToString());
        Environment.Exit(0);
    }
}