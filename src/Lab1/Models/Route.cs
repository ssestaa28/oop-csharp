using Itmo.ObjectOrientedProgramming.Lab1.Simulations;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Route
{
    private readonly Collection<RouteSection> _sections;

    public Route(Collection<RouteSection> sections)
    {
        _sections = sections;
    }

    public SimulationResult Start(Train train)
    {
        double totalTime = 0;

        foreach (RouteSection section in _sections)
        {
            SimulationResult result = section.Pass(train);
            if (!result.IsSuccess)
            {
                Console.WriteLine("Маршрут не пройден на секции: " + section.GetType().Name);
                return new SimulationResult(false, totalTime);
            }

            totalTime += result.Time;
            Console.WriteLine($"Секция {section.GetType().Name} пройдена за {result.Time} секунд, текушая скорость: {train.Speed} метров в секунду");
        }

        return new SimulationResult(true, totalTime);
    }
}
