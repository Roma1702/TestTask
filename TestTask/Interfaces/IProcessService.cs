using DataAccessLayer.Interfaces;

namespace TestTask
{
    public interface IProcessService
    {
        Task Process(string[] args);
    }
}
