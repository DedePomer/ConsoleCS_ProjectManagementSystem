using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class UserCreationService
    {
        private readonly UserCreationRepository _repository;
        public UserCreationService(UserCreationRepository repository)
        {
            _repository = repository;
        }
    }
}
