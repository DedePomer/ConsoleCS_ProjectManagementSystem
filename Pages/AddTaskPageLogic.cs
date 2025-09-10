using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class AddTaskPage
    {
        public override void FillDictionary()
        {
            _inputElements.Add(TASK_NAME_VIEW_TEXT, "");
            _inputElements.Add(TASK_DESCRIPTION_VIEW_TEXT, "");
        }


        private void CreateNewTask()
        {

            ShowElementsForInputs(_inputElements, "Заполните поля\n");

            TaskElement newTaskElement = new TaskElement();
            newTaskElement.Task = new DefaultTask();
            newTaskElement.Task.User = new DefaultUser();
            newTaskElement.Task.Name = _inputElements[TASK_NAME_VIEW_TEXT];
            newTaskElement.Task.Description = _inputElements[TASK_DESCRIPTION_VIEW_TEXT];
            newTaskElement.Task.Status = StatusEnum.None;
            _navigation.Open(new AssignTaskPage(_user, _navigation, _userService, _taskService, _roleService, newTaskElement), true);
        }
    }
}
