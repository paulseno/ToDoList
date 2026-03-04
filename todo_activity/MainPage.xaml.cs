namespace todo_activity;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class ToDoClass: INotifyPropertyChanged
{
    public ToDoClass()
    {
    }
    private int _id;
    private string _title;
    private string _detail;
    
    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    public string Detail
    {
        get => _detail;
        set
        {
            _detail = value;
            OnPropertyChanged(nameof(Detail));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}