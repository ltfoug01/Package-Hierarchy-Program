using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class GroundPackage : Package
{
    private int _zoneDistance;

    //Constructor.
    public GroundPackage(Address originAddress, Address destAddress, double length, double width,
        double height, double weight)
        : base(originAddress, destAddress, length, width, height, weight)
    {
        //Done in the base class.
    }

    //Constructor read only property.
    public int ZoneDistance
    {
        /*Returns zone distance (Differnce btw zip codes)
         * Positive difference btw the 1st digit of origin 
         * address zip and 1st digit of destination addrees zip
         */
        get
        {
            const int FIRST_DIGIT_FACTOR = 10000; //Denominator to extract last digit.
            int distance;

            distance = Math.Abs((OriginAddress.Zip / FIRST_DIGIT_FACTOR) - (DestinationAddress.Zip /
            FIRST_DIGIT_FACTOR));

            return distance;
        }
    }

    //Overrided Method to calculate package cost based on dimensions.
    public override decimal CalcCost()
    {
        double cost;
        const double MULTIPLIER_1 = 0.20;
        const double MULTIPLIER_2 = 0.05;

        cost = MULTIPLIER_1 * TotalDimension + MULTIPLIER_2 * ((ZoneDistance + 1) * Weight);

        return (decimal)(cost);
    }

    //Returns a string with the Ground Package's data - uses the base string.
    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $" Ground {base.ToString()}{NL} Zone Distance: {ZoneDistance:D}";
    }
}
