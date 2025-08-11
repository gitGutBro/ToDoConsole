using static ToDoConsole.Scripts.Utils;

namespace ToDoConsole.Scripts;

internal class ToDoTasksService(ToDoTasksDisplayer tasksDisplayer)
{
    private readonly List<ToDoTask> _tasks = [];
    private readonly ToDoTasksDisplayer _tasksDisplayer = tasksDisplayer;

    public bool TryAdd()
    {
        string name = GetInput("Введите название задачи: ");

        if (string.IsNullOrEmpty(name))
        {
            Print("Имя не должно быть пустым или значения null!");
            return false;
        }

        string description = GetInput("Введите описание задачи: ");

        if (description.Length > Constants.MaxDescriptionSymbols)
        {
            Print("Превышено количество символов в описании!");
            return false;
        }

        ToDoTask newToDoTask = new(name, description);

        _tasks.Add(newToDoTask);
        Print("\nЗадача успешно добавлена!");
        return true;
    }

    public void Remove()
    {
        ToDoTask? taskToRemove = TryPrepareTask();

        if (taskToRemove is null)
            return;

        _tasks.Remove(taskToRemove);
        Print("Задача успешно удалена!");
    }

    public void ChangeState()
    {
        ToDoTask? taskToChangeState = TryPrepareTask();

        if (taskToChangeState is null)
            return;

        taskToChangeState.IsCompleted = !taskToChangeState.IsCompleted;
        Print("Статус задачи обновлён!");
    }

    public void ShowAll() =>
        _tasksDisplayer.ShowAll(_tasks);

    public void ShowActive() =>
        _tasksDisplayer.ShowActive(_tasks);

    public void ShowCompleted() =>
        _tasksDisplayer.ShowCompleted(_tasks);

    private ToDoTask? TryPrepareTask()
    {
        int id = int.MinValue;

        if (TryValidateUserInputId(ref id) == false)
            return null;

        ToDoTask? taskToPrepare = TryGetById(id);

        return taskToPrepare;
    }

    private ToDoTask? TryGetById(int id)
    {
        ToDoTask? task = _tasks.FirstOrDefault(task => task.Id == id);

        if (task is null)
        {
            Print($"\nЗадача с Id {id} не найдена.");
            return null;
        }

        return task;
    }

    private bool TryValidateUserInputId(ref int id)
    {
        if (_tasks.Count is 0)
        {
            Print("Задач нет.");
            return false;
        }

        const string ExitCommand = "-1";

        Console.WriteLine($"{ExitCommand} - Выйти\n");
        _tasksDisplayer.ShowAll(_tasks);

        string userInput = GetInput("\nВведите номер команды: ");

        if (userInput is ExitCommand)
            return false;

        if (int.TryParse(userInput, out id) == false)
        {
            Print("Неверный формат id. Введите число.");
            return false;
        }

        return true;
    }
}