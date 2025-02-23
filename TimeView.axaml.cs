using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace ShowTimeAlwaysOnTop;

public partial class TimeView : Window
{
    private DispatcherTimer timer = new()
    {
        Interval = TimeSpan.FromSeconds(1)
    };
    private string sTime = string.Empty;
    
    public string Time
    {
        get
        {
            return sTime;
        }
        set
        {
            sTime = value;
            UpdateText();
        }
    }
    public TimeView()
    {
        InitializeComponent();
        timer.Tick += Timer_Tick;
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        var now = DateTime.Now;
        var hour = now.Hour.ToString("00");
        var minute = now.Minute.ToString("00");
        sTime = $"{hour}:{minute}";
        UpdateText();
    }

    private void UpdateText()
    {
        TimeText.Text = sTime;
    }
}