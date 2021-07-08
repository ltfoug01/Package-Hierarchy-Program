// By: Luke Fougerousse

// File: TwoDayAirPackage.cs
// The TwoDayAirPackage class is a concrete derived class from AirPackage. It adds
// a delivery type.

// Serializable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class TwoDayAirPackage : AirPackage
{
    public enum Delivery { Early, Saver } //Delivery Types.

    //Constructor.
    public TwoDayAirPackage(Address originAddress, Address destAddress, double length, double width,
        double height, double weight, Delivery delType)
        : base(originAddress, destAddress, length, width, height, weight)
    {
        DeliveryType = delType;
    }

    //Delivery Type Property.
    public Delivery DeliveryType
    {
        get;
        set;
    }

    //Returns the cost of the two day air package.
    //Adds a 10% discount if the package is a Saver type.
    public override decimal CalcCost()
    {
        const double MULITIPLIER = 0.25;
        const decimal DISCOUNT_FACTOR = 0.10m;

        decimal cost;

        cost = (decimal)(MULITIPLIER * (TotalDimension) + MULITIPLIER * Weight);

        if (DeliveryType == Delivery.Saver)
            cost += (1 - DISCOUNT_FACTOR);

        return cost;
    }

    //Returns the two day air package data.
    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $"TwoDay{base.ToString()}{NL}Delivery Type: {DeliveryType}";
    }
}
