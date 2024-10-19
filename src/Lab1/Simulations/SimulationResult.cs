namespace Itmo.ObjectOrientedProgramming.Lab1.Simulations;

public class SimulationResult
{
    public bool IsSuccess { get; set; }

    public double Time { get; set; }

    public SimulationResult(bool isSuccess, double time)
    {
        IsSuccess = isSuccess;
        Time = time;
    }
}
