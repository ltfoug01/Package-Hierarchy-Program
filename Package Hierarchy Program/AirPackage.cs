// Luke Fougerousse

// File: AirPackage.cs
// The AirPackage class is an abstract derived class from Package. It is able
// to determine if the package is heavy or large.

// Serializable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public abstract class AirPackage : Package   //derived class.
{
    public const double HEAVY = 75;
    public const double LARGE = 100;

    //Constructor.
    public AirPackage(Address originAddress, Address destAddress, double length, double width,
        double height, double weight)
        : base(originAddress, destAddress, length, width, height, weight)
    {
        //Done in the base class.
    }

    //Boolean method.
    //Air Packge is heavy if it weighs >= 75lbs.
    public bool IsHeavy()
    {
        return (Weight >= HEAVY);
    }

    //Boolean method.
    //Air Package is large if the total dimensions >= 100 inches.
    public bool IsLarge()
    {
        return (TotalDimension >= LARGE);
    }

    //Returns a string with the air package's data - uses the base string.
    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $"Air Package: {base.ToString()}{NL}Heavy: {IsHeavy()}{NL}Large: {IsLarge()}";
    }
}

