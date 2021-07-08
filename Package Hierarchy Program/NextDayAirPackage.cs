// By: Luke Fougerousse

// File: NextDayAirPackage.cs
// The NextDayAirPackage class is a concrete derived class from AirPackage. It adds
// an express fee.

// Serializable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class NextDayAirPackage : AirPackage
{
    private decimal _expressFee;

    //Constructor.
    //Adds an express fee - uses base class constructor.
    public NextDayAirPackage(Address originAddress, Address destAddress, double length, double width,
        double height, double weight, decimal expressFee)
        : base(originAddress, destAddress, length, width, height, weight)
    {
        ExpressFee = expressFee;
    }

    //ExpressFee property.
    public decimal ExpressFee
    {
        get { return _expressFee; }

        private set //Helper set property.
        {
            if (value >= 0)
                _expressFee = value;
            else
                throw new ArgumentOutOfRangeException("ExpressFee", value, "ExpressFee must" +
                    "be >= 0");
        }
    }

    //Returns the next day air package cost.
    public override decimal CalcCost()
    {
        const double HEAVY = 0.25;
        const double LARGE = 0.25;
        const double MULTIPLIER1 = 0.40;
        const double MULTIPLIER2 = 0.30;

        decimal cost;

        cost = (decimal)(MULTIPLIER1 * (TotalDimension) + MULTIPLIER2 * (Weight)) + ExpressFee;

        //Adds additional charge if package is heavy or large.
        if (IsHeavy())
            cost += (decimal)(HEAVY * Weight);
        if (IsLarge())
            cost += (decimal)(LARGE + TotalDimension);

        return cost;
    }

    //Returns the next day air package's data with the base string format.
    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $"NextDay{base.ToString()}{NL}Express Fee: {ExpressFee:C}";
    }
}
