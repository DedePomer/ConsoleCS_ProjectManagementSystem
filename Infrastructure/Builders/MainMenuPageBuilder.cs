using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Builders
{
    public class MainMenuPageBuilder
    {
        private List<MenuElement> _element = new List<MenuElement>();
        public MainMenuPageBuilder AddElement(int id, string name, Action<object?> action)
        {
            _element.Add(new MenuElement()
            {
                Id = id,
                Name = name,
                Execute = action,
            });
            return this;
        }
        public List<MenuElement> Build()
        {
            return _element;
        }
    }
}
