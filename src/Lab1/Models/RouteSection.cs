using Itmo.ObjectOrientedProgramming.Lab1.Simulations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public abstract class RouteSection
{
    public double Length { get; set; }

    protected RouteSection(double length)
    {
        Length = length;
    }

    public abstract SimulationResult Pass(Train train);
}