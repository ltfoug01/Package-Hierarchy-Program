//BY: Luke Fougerousse

/* File: Parcel.cs
 * Parcel is the abstract base class for the Parcel class hierarchy.
 * Calculates the cost of the Parcel.
 * Displays the origin, destination, and cost.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[Serializable]
public class Letter : Parcel
{
    private decimal _fixedCost;

    //Constructor derives originAddress and DestAddress from Parcel.
    public Letter(Address originAddress, Address destAddress, decimal fixedCost)
            : base(originAddress, destAddress)
    {
        FixedCost = fixedCost;
    }

    //Fixed Cost Property.
    private decimal FixedCost
    {
        get { return _fixedCost; }

        set
        {
            if (value >= 0)
                _fixedCost = value;
            else
                throw new ArgumentOutOfRangeException("FixedCost", value, "Fixed Cost must" +
                    "be >= 0");
        }
    }

    //CalcCost Method.
    public override decimal CalcCost()
    {
        return FixedCost;
    }

    //Retruns a string with the Letter's data.
    public override String ToString()
    {
        string NL = Environment.NewLine;

        return $"Letter:{NL}{NL}{base.ToString()}";
    }
}
