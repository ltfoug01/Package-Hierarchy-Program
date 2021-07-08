/*  Luke Fougerousse
 *  
 *  File: Parcel.cs
 *  Parcel serves as the abstract base class of the Parcel hierachy.
 *  Now IComparable, ascending by cost.
 *  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public abstract class Parcel
{
    //Constructor with Address objects.
    public Parcel(Address originAddress, Address destAddress)
    {
        OriginAddress = originAddress;
        DestinationAddress = destAddress;
    }

    public Address OriginAddress
    {
        get;
        set;
    }

    public Address DestinationAddress
    {
        get;
        set;
    }

    //CalcCost method, no parameters
    public abstract decimal CalcCost();

    //Returns the values in the specified string format.
    public override String ToString()
    {
        string NL = Environment.NewLine;

        return $"Origin Address:{NL}{OriginAddress}{NL}{NL}Destination Address:{NL}{DestinationAddress}" +
            $"{NL}{NL}Cost: {CalcCost():C}";
    }
}

