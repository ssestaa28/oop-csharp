namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Train
{
    public double Mass { get; set; }

    public double Speed { get; set; }

    public double Acceleration { get; set; }

    public double MaxForce { get; set; }

    public double Precision { get; set; }

    public double MaxAallowedSpeed { get; set; }

    public Train(double mass, double maxForce, double prision)
    {
        Mass = mass;
        MaxForce = maxForce;
        Precision = prision;
        Speed = 0;
        Acceleration = 0;
        MaxAallowedSpeed = double.MaxValue;
    }

    public bool ApplyForce(double force)
    {
        if (force > MaxForce)
        {
            return false;
        }

        Acceleration = force / Mass;
        return true;
    }

    public double CalculateTravelTime(double length)
    {
        double remainingDistance = length;
        double time = 0;

        while (remainingDistance > 0)
        {
            double newSpeed = Speed + (Acceleration * Precision);

            if (newSpeed > MaxAallowedSpeed)
            {
                return -1;
            }

            double traveledDistance = (Speed + newSpeed) / 2 * Precision;

            if (traveledDistance <= 0)
            {
                Console.WriteLine("ошибка:(");
                return -1;
            }

            remainingDistance = remainingDistance - traveledDistance;
            Speed = newSpeed;
            time += Precision;
        }

        return time;
    }

    public void ResetSpeedLimit()
    {
        MaxAallowedSpeed = double.MaxValue;
    }
}
