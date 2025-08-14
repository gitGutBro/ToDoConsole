namespace ToDoConsole.Scripts;

internal class ToDoTask
{
    private static int _idSequence = 0;

    public ToDoTask(string name, string description)
    {
        Name = string.IsNullOrEmpty(name) == false ? name : throw new Exception("Имя не должно быть пустым или значения null!");
        Description = (description.Length > Constants.MaxDescriptionSymbols ?
            throw new("Превышено количество символов в описании!") : description)
            ?? string.Empty;
        IsCompleted = false;

        Id = Interlocked.Increment(ref _idSequence);
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; set; }
}