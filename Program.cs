using ToDoConsole.Scripts;

ToDoTasksManager toDoTasksManager = new(new ToDoTasksService(new ToDoTasksDisplayer()));

toDoTasksManager.Work();