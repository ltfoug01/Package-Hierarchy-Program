/*  CIS 200
 *  Luke Fougerousse
 *  
 *  File: Address.cs
 *  This class stores a typical US address consisting of name,
 *  two address lines, city, state, and 5 digit zip code.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class Address
{
    public const int MIN_ZIP = 0;     //Min zip value.
    public const int MAX_ZIP = 99999; //Max zip value.

    private string _name;       // Address name
    private string _address1;   // 1st line
    private string _address2;   // 2nd line, optional
    private string _city;
    private string _state;
    private int _zip;


    //Constructor 
    public Address(String name, String address1, String address2,
                   String city, String state, int zip)
    {
        Name = name;
        Address1 = address1;
        Address2 = address2;
        City = city;
        State = state;
        Zip = zip;
    }


    // Overloaded Constructor 
    // Calls the previous constructor sending an empty string for address2.
    public Address(String name, String address1, String city, String state, int zip) :
         this(name, address1, string.Empty, city, state, zip)
    {
        // No body needed
        // Calls previous constructor sending empty string for Address2
    }


    //Start of the Constructor Properties.
    public String Name
    {
        get { return _name; }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException("Name", value, "Name must" +
                        "not be empty");
            else
                _name = value.Trim();
        }
    }

    public String Address1
    {
        get { return _address1; }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException("Address1", value, "Address1 must " +
                        "not be empty");
            else
                _address1 = value.Trim();
        }
    }

    public String Address2
    {
        get { return _address2; }

        set
        {
            _address2 = value.Trim();
        }
    }

    public String City
    {
        get { return _city; }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException("City", value, "City must " +
                    "not be empty");
            else
                _city = value.Trim();
        }
    }

    public String State
    {
        get { return _state; }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException("State", value, "State must " +
                        "not be empty");
            else
                _state = value.Trim();
        }
    }

    public int Zip
    {
        get { return _zip; }

        set
        {
            if ((value >= MIN_ZIP) && (value <= MAX_ZIP))
                _zip = value;
            else
                throw new ArgumentOutOfRangeException("Zip", value, "Zip must be U.S." +
                    "digit zip code");
        }
    }//End of Constructor Properties.


    //Returns the data fields as a formatted string.
    public override string ToString()
    {
        string NL = Environment.NewLine;
        string result;

        result = $"{Name}{NL}{Address1}{NL}";

        if (!String.IsNullOrWhiteSpace(Address2))
            result += $"{Address2}{NL}";          //Displays address 2 if provided

        result += $"{City}, {State} {Zip:D5}";

        return result;
    }
}
