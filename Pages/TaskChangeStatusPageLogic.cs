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
            foreach (StatusEnum status in Enum.GetValues(typeof(StatusEnum)))
            {
                _elements.Add(new MenuElement()
                {
                    Name = status.GetDescription(),
                },RightsEnum.None);
            }
        }

        private void ChangeStatus()
        {
            IEnumerable<IElement> showElements = CreateShowList(_elements, _user);

            ShowDisplayElements(showElements);

            NavigationLoopService loopService = new NavigationLoopService
                (showElements, GetCountStrokeInTitle());

            _task.Status  = (StatusEnum)loopService.GetNumberSelectedElement(false);

            _taskService.ChangeStatusInTask(_task);
        }
    }
}
