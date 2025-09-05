using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Builders
{
    public class MainMenuPageBuilder
    {
        private MenuElement _element = new MenuElement();
        public MainMenuPageBuilder AddElement(int id, string name, Action<object?> action)
        {
            _element.Id = id;
            _element.Name = name;
            _element.Execute += action;
            return this;
        }
        public MenuElement Build()
        {
            return new MenuElement()
            { 
                Id = _element.Id,
                Name = _element.Name,
                Execute = _element.Execute,          
            };
        }
    }
}
