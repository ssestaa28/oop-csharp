using Itmo.ObjectOrientedProgramming.Lab1.Simulations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class RegularMagneticRoute : RouteSection
{
    public RegularMagneticRoute(double length) : base(length) { }

    public override SimulationResult Pass(Train train)
    {
        double time = train.CalculateTravelTime(Length);
        return time >= 0 ? new SimulationResult(true, time) : new SimulationResult(false, 0);
    }
}
