using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
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
            while (true) 
            {
                ShowElementsForInputs(_elements, "Заполните поля\n");

                DefaultTask newTask = new DefaultTask();
                newTask.Name = _elements["Название задачи"];
                newTask.Description = _elements["Описание"];
                newTask.Status = StatusEnum.None;
                newTask.User = new DefaultUser()
                {
                    Id = 0
                };


                if (true)
                {

                }
                else
                {

                }
            }
            

        }
    }
}
