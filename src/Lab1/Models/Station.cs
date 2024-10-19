using Itmo.ObjectOrientedProgramming.Lab1.Simulations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Station : RouteSection
{
    private readonly double _maxSpeed;

    public Station(double length, double maxSpeed) : base(length)
    {
        _maxSpeed = maxSpeed;
    }

    public override SimulationResult Pass(Train train)
    {
        if (train.Speed > _maxSpeed)
        {
            return new SimulationResult(false, 0);
        }

        train.MaxAallowedSpeed = _maxSpeed;

        double time = train.CalculateTravelTime(Length);
        train.ResetSpeedLimit();

        return time >= 0 ? new SimulationResult(true, time) : new SimulationResult(false, 0);
    }
}
