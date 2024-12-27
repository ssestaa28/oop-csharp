using Itmo.ObjectOrientedProgramming.Lab5.Application.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.ConsoleApp;

public class ApplicationRunner : IApplicationRunner
{
    private readonly IInputHandler _inputHandler;
    private readonly IAtmAppService _atmAppService;
    private readonly IAdminAppService _adminAppService;

    public ApplicationRunner(
        IInputHandler inputHandler,
        IAtmAppService atmAppService,
        IAdminAppService adminAppService)
    {
        _inputHandler = inputHandler;
        _atmAppService = atmAppService;
        _adminAppService = adminAppService;
    }

    public void Run()
    {
        while (true)
        {
            string mode = _inputHandler.GetUserInput("Выберите режим работы (1 – Пользователь, 2 – Администратор, 0 – Выход):");
            switch (mode)
            {
                case "1":
                    _atmAppService.ExecuteAtmOperations();
                    break;
                case "2":
                    _adminAppService.ExecuteAdminOperations();
                    break;
                case "0":
                    Console.WriteLine("Завершение работы");
                    return;
                default:
                    Console.WriteLine("Чет не то ввел, уточни пароль у бати!");
                    break;
            }
        }
    }
}
