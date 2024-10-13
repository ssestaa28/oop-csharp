using Itmo.ObjectOrientedProgramming.Lab1.Simulations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class PowerMagneticRoute : RouteSection
{
    private readonly double _force;

    public PowerMagneticRoute(double force, double length) : base(length)
    {
        _force = force;
    }

    public override SimulationResult Pass(Train train)
    {
        if (!train.ApplyForce(_force))
        {
            return new SimulationResult(false, 0);
        }

        double time = train.CalculateTravelTime(Length);
        return time >= 0 ? new SimulationResult(true, time) : new SimulationResult(false, time);
    }
}