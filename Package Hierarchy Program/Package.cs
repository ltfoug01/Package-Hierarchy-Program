/* BY: Luke Fougerousse
 * 
 * File: Package.cs
 * An abstract derived class from Parcel. Adds package dimensions and weight.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public abstract class Package : Parcel
{
    private double _length;
    private double _width;
    private double _height;
    private double _weight;

    //Constructor
    //Uses base class origin and destination addresses.
    public Package(Address originAddress, Address destAddress, double length, double width,
        double height, double weight)
        : base(originAddress, destAddress)
    {
        Length = length;
        Width = width;
        Height = height;
        Weight = weight;
    }

    //Constructor Properties
    public double Length
    {
        get { return _length; }

        set
        {
            if (value >= 0)
                _length = value;
            else
                throw new ArgumentOutOfRangeException("Length", value, "Length must be >= 0");
        }
    }

    public double Width
    {
        get { return _width; }

        set
        {
            if (value >= 0)
                _width = value;
            else
                throw new ArgumentOutOfRangeException("Width", value, "Width must be >= 0");
        }
    }

    public double Height
    {
        get { return _width; }

        set
        {
            if (value >= 0)
                _height = value;
            else
                throw new ArgumentOutOfRangeException("Height", value, "Height must be >= 0");
        }
    }

    public double Weight
    {
        get { return _weight; }

        set
        {
            if (value >= 0)
                _length = value;
            else
                throw new ArgumentOutOfRangeException("Weight", value, "Weight must be >= 0");
        }
    }

    //Helper Property.
    protected double TotalDimension
    {
        get { return (Length + Width + Height); }
    }

    //Returns a string with the package's data.
    public override string ToString()
    {
        string result;
        string NL = Environment.NewLine;

        result = $"Package{NL}{base.ToString()}{NL} Length: {Length:N1}{NL} Width: " +
            $"{Width:N1}{NL} Height: {Height:H1}{NL} Weight: {Weight:W1}{NL}";

        return result;
    }
}
