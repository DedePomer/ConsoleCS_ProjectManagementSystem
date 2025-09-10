using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class TaskChangeStatusPage
    {
        public override void FillDictionary()
        {
            var myStatuses = Enum.GetValues(typeof(StatusEnum));
            foreach (StatusEnum status in myStatuses)
            {
                if (status != StatusEnum.None)
                {
                    _elements.Add(new StatusElement()
                    {
                        Name = status.GetDescription(),
                        Status = status,
                    }, RightsEnum.None);
                }              
            }
        }

        private void ChangeStatus()
        {
            string title = $"{_user.Name} Поменяйте статус\n";

            IEnumerable<IElement> showElements = CreateShowList(_elements, _user);

            ShowDisplayElements(showElements, title);

            NavigationLoopService loopService = new NavigationLoopService
                (showElements, GetCountStrokeInTitle());

            int selectedIndex = loopService.GetNumberSelectedElement(false);

            _task.Task.Status  = (showElements.ToList()[selectedIndex] as StatusElement).Status;

            _taskService.ChangeStatusInTask(_task.Task);
        }
    }
}
