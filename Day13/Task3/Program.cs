// Класс с событием изменения имени
class MyInfo
{
    private string _name = "marta";
    
    // Делегат для события
    public delegate void NameChangedHandler(string oldName, string newName);
    
    // Событие изменения имени
    public event NameChangedHandler NameChanged;

    public string Name
    {
        get => _name;
        set
        {
            if(_name != value)
            {
                string oldName = _name;
                _name = value;
                NameChanged?.Invoke(oldName, _name); // Вызов события
            }
        }
    }
}

class Program
{
    static void Main()
    {
        MyInfo info = new MyInfo();
        
        // Подписка на событие
        info.NameChanged += (oldName, newName) => 
        {
            Console.WriteLine($"Имя изменено: {oldName} -> {newName}");
        };

        // Изменяем имя (вызовет событие)
        info.Name = "Marta";
        
        // Повторное изменение (не вызовет событие - имя совпадает)
        info.Name = "Marta";
        
        // Новое изменение (вызовет событие)
        info.Name = "Anna";
    }
}