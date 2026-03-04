using System;
using System.Collections.ObjectModel;

namespace todo_activity;

public partial class MainPage : ContentPage
{
    private ObservableCollection<ToDoClass> todoItems = new ObservableCollection<ToDoClass>();
    private ToDoClass? selectedItem;

    public MainPage()
    {
        InitializeComponent();
        todoLV.ItemsSource = todoItems;
    }

    private void AddToDoItem(object sender, EventArgs e)
    {
        var newTask = new ToDoClass
        {
            Id = todoItems.Count + 1,
            Title = TitleEntry.Text,
            Detail = DetailsEditor.Text
        };
        todoItems.Add(newTask);

        TitleEntry.Text = "";
        DetailsEditor.Text = "";
    }

    private void EditToDoItem(object sender, EventArgs e)
    {
        if (selectedItem != null)
        {
            selectedItem.Title = TitleEntry.Text;
            selectedItem.Detail = DetailsEditor.Text;

            AddBtn.IsVisible = true;
            EditBtn.IsVisible = false;
            CancelBtn.IsVisible = false;

            TitleEntry.Text = "";
            DetailsEditor.Text = "";
        }
    }

    private void CancelEdit(object sender, EventArgs e)
    {
        AddBtn.IsVisible = true;
        EditBtn.IsVisible = false;
        CancelBtn.IsVisible = false;

        TitleEntry.Text = "";
        DetailsEditor.Text = "";
    }

    private void DeleteToDoItem(object sender, EventArgs e)
    {
        var button = sender as Button;
        int id = int.Parse(button.ClassId);
        var itemToRemove = todoItems.FirstOrDefault(t => t.Id == id);
        if (itemToRemove != null)
        {
            todoItems.Remove(itemToRemove);
        }
    }

    private void todoLV_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        selectedItem = e.Item as ToDoClass;
        if (selectedItem != null)
        {
            TitleEntry.Text = selectedItem.Title;
            DetailsEditor.Text = selectedItem.Detail;

            AddBtn.IsVisible = false;
            EditBtn.IsVisible = true;
            CancelBtn.IsVisible = true;
        }
    }
}
