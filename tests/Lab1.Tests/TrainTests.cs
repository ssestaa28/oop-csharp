using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Simulations;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab1.Tests;

public class TrainTests
{
    [Fact]
    public void PowerRouteAcceleratingPermissibleOnRoute()
    {
        var train = new Train(1000, 500, 0.1);
        var sections = new Collection<RouteSection>
        {
            new PowerMagneticRoute(100, 300),
            new RegularMagneticRoute(200),
        };

        var route = new Route(sections);

        SimulationResult result = route.Start(train);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void PowerRouteAcceleratingMoreSpeedOfRoute()
    {
        var train = new Train(1000, 500, 0.1);
        var sections = new Collection<RouteSection>
        {
            new PowerMagneticRoute(600, 100),
            new RegularMagneticRoute(200),
        };
        var route = new Route(sections);

        SimulationResult result = route.Start(train);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void PowerRouteAcceleratingPermissibleOnRouteAndStation()
    {
        var train = new Train(1000, 500, 0.1);
        var sections = new Collection<RouteSection>
        {
            new PowerMagneticRoute(100, 600),
            new RegularMagneticRoute(200),
            new Station(50, 150),
        };
        var route = new Route(sections);

        SimulationResult result = route.Start(train);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void PowerRouteExceedsMaxSpeed_AtStation()
    {
        var train = new Train(1000, 500, 0.1);
        var sections = new Collection<RouteSection>
        {
            new PowerMagneticRoute(600, 100),
            new Station(50, 300),
            new RegularMagneticRoute(200),
        };
        var route = new Route(sections);

        SimulationResult result = route.Start(train);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void PowerRouteExceedsRoureSpeed_LessPermissibleStationSpeed()
    {
        var train = new Train(1000, 500, 0.1);
        var sections = new Collection<RouteSection>
        {
            new PowerMagneticRoute(600, 100),
            new Station(50, 100),
            new RegularMagneticRoute(200),
        };
        var route = new Route(sections);

        SimulationResult result = route.Start(train);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void PowerRouteExceedsStationSpeed_BrakeBeforeStation()
    {
        var train = new Train(1000, 500, 0.1);
        var sections = new Collection<RouteSection>
        {
            new PowerMagneticRoute(100, 600),
            new RegularMagneticRoute(200),
            new PowerMagneticRoute(100, -300),
            new Station(50, 300),
            new RegularMagneticRoute(200),
            new PowerMagneticRoute(100, 600),
            new RegularMagneticRoute(200),
            new PowerMagneticRoute(100, -600),
        };
        var route = new Route(sections);

        SimulationResult result = route.Start(train);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void RegularRouteOnly()
    {
        var train = new Train(1000, 500, 0.1);
        var sections = new Collection<RouteSection>
        {
            new RegularMagneticRoute(200),
        };
        var route = new Route(sections);

        SimulationResult result = route.Start(train);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void PowerRouteApplyForceAndReverseForce()
    {
        var train = new Train(1000, 500, 0.1);
        var sections = new Collection<RouteSection>
        {
            new PowerMagneticRoute(600, 100),
            new PowerMagneticRoute(-600, 100),
        };
        var route = new Route(sections);

        SimulationResult result = route.Start(train);

        Assert.False(result.IsSuccess);
    }
}
