using System;
using System.ComponentModel;
using System.Windows.Forms;

public class MyCustomComponent : Component
{
    public string Message { get; set; } = "Привет, мир!";

    public void ShowMessage()
    {
        MessageBox.Show(Message);
    }
}
