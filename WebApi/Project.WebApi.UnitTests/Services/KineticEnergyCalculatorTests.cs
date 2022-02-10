using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Project.WebApi.Services;
using Shouldly;
using System;

namespace Project.WebApi.UnitTests.Services;

public class KineticEnergyCalculatorTests
{
    private KineticEnergyCalculator _calculator;

    [SetUp]
    public void Setup()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddTransient(sp => new Mock<ILogger<KineticEnergyCalculator>>().Object);
        services.AddTransient<KineticEnergyCalculator>();

        var serviceProvider = services.BuildServiceProvider();

        _calculator = serviceProvider.GetService<KineticEnergyCalculator>();
    }

    [Test]
    public void Calculate_ShouldCalculateCorrectly_WhenCorrectDataPassed()
    {
        // arrange
        var mass = 15;
        var velocity = 13;

        // act
        var kineticEnergy = _calculator.Calculate(mass, velocity);

        // assert
        kineticEnergy.ShouldBe(1267.5);
    }

    [Test]
    public void Calculate_ShouldThrowException_WhenMassIsZero()
    {
        // arrange
        var mass = 0;
        var velocity = 13;

        try
        {
            // act
            _calculator.Calculate(mass, velocity);

        }
        catch (Exception)
        {
            // assert
            Assert.Pass();
        }

        Assert.Fail();
    }


    [Test]
    public void Calculate_ShouldThrowException_WhenVelocityIsZero()
    {
        // arrange
        var mass = 15;
        var velocity = 0;

        try
        {
            // act
            _calculator.Calculate(mass, velocity);

        }
        catch (Exception)
        {
            // assert
            Assert.Pass();
        }

        Assert.Fail();
    }
}