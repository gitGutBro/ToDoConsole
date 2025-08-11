using static ToDoConsole.Scripts.Utils;

namespace ToDoConsole.Scripts;

internal class ToDoTasksManager(ToDoTasksService toDoTasksService)
{
    private readonly ToDoTasksService _toDoTasksService = toDoTasksService;

    public void Work()
    {
        bool isWorking = true;

        while (isWorking)
        {
            const string AddTaskCommand = "1";
            const string RemoveTaskCommand = "2";
            const string ShowAllTasksCommand = "3";
            const string ShowActiveTasksCommand = "4";
            const string ShowCompletedTasksCommand = "5";
            const string ChangeTaskStateCommand = "6";
            const string ExitCommand = "7";

            string userInput = GetInput($"{AddTaskCommand} - Добавить задачу\n" +
                                        $"{RemoveTaskCommand} - Удалить задачу\n" +
                                        $"{ShowAllTasksCommand} - Показать все задачи\n" +
                                        $"{ShowActiveTasksCommand} - Показать активные задачи\n" +
                                        $"{ShowCompletedTasksCommand} - Показать завершённые задачи\n" +
                                        $"{ChangeTaskStateCommand} - Поменять статус задачи\n" +
                                        $"{ExitCommand} - Выход\n" +
                                        "\nВведите номер команды: ");
            Console.Clear();

            switch (userInput)
            {
                case AddTaskCommand:
                    _toDoTasksService.TryAdd();
                    break;

                case RemoveTaskCommand:
                    _toDoTasksService.Remove();
                    break;

                case ChangeTaskStateCommand:
                    _toDoTasksService.ChangeState();
                    break;

                case ShowAllTasksCommand:
                    _toDoTasksService.ShowAll();
                    break;

                case ShowActiveTasksCommand:
                    _toDoTasksService.ShowActive();
                    break;

                case ShowCompletedTasksCommand:
                    _toDoTasksService.ShowCompleted();
                    break;

                case ExitCommand:
                    isWorking = false;
                    break;

                default:
                    Print("Неизвестная команда. Пожалуйста, попробуйте снова.");
                    break;
            }

            Console.Clear();
        }
    }
}