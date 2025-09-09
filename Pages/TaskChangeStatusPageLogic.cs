using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class TaskChangeStatusPage
    {
        public override void FillDictionary()
        {
            foreach (StatusEnum status in Enum.GetValues(typeof(StatusEnum)))
            {
                _elements.Add(status.GetDescription());
            }
        }

        private void ChangeStatus()
        {
            ShowDisplayElements(_elements);

            NavigationLoopService loopService = new NavigationLoopService
                (_elements, GetCountStrokeInTitle());

            _task.Status  = (StatusEnum)loopService.GetNumberSelectedElement(false);

            _taskService.ChangeStatusInTask(_task);
        }
    }
}
