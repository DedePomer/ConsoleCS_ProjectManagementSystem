using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class AddTaskPage
    {
        public override void FillDictionary()
        {
            _elements.Add("Название задачи", "");
            _elements.Add("Описание", "");
        }

        private void CreateNewTask()
        {
            ShowElementsForInputs(_elements, "Заполните поля\n");

            TaskElement newTask = new TaskElement();
            newTask.Name = _elements["Название задачи"];
            newTask.Description = _elements["Описание"];


            if (!_userCreationService.UserAuthentication(newUser.Name, newUser.Password))
            {
                _userCreationService.CreateUser(newUser);
                break;
            }
            else
            {
                ShowException("Такой пользователь существует");
            }

        }
    }
}
