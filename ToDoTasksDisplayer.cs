using static ToDoConsole.Utils;

internal class ToDoTasksDisplayer
{
    public void ShowAll(IEnumerable<ToDoTask> tasks, bool waitKey = false) =>
        Show(tasks, waitKey);

    public void ShowActive(IEnumerable<ToDoTask> tasks) =>
        ShowByCondition(tasks, task => task.IsCompleted == false, true);

    public void ShowCompleted(IEnumerable<ToDoTask> tasks) =>
        ShowByCondition(tasks, task => task.IsCompleted, true);

    private void ShowByCondition(IEnumerable<ToDoTask> tasks, Predicate<ToDoTask> condition, bool waitKey = false)
    {
        if (tasks.Any() == false)
        {
            Print("Задач нет.");
            return;
        }

        List<ToDoTask> filteredTasks = tasks.ToList().FindAll(condition);

        if (filteredTasks.Count == 0)
            Print("Задачи не найдены!");
        else
            Show(filteredTasks, waitKey);
    }

    private void Show(IEnumerable<ToDoTask> tasks, bool waitKey = false)
    {
        if (tasks.Any() == false)
        {
            Print("Задач нет.");
            return;
        }

        foreach (ToDoTask task in tasks)
        {
            Console.WriteLine($"Номер: {task.Id}\n" +
                              $"Название: {task.Name}\n" +
                              $"Описание: {task.Description}");

            if (task.IsCompleted == false)
                Console.WriteLine("Статус: Активно");
            else
                Console.WriteLine("Статус: Завершено");
        }

        if (waitKey)
            Console.ReadKey();
    }
}