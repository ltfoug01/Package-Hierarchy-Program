using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Package_Hierarchy_Program
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProgramForm());                      //Show Form when debugging

            //Address objects.
            Address A1 = new Address("Luke Fougerousse", "1051 Wood Dr.", "New Albany", "IN", 47150);
            Address A2 = new Address("Jon Snow", "100 Wall Blvd.", "North City", "WI", 62510);
            Address A3 = new Address("Bran Stark", "506 Winterfell St.", "Kings Landing", "CA", 91560);
            Address A4 = new Address("Sansa Stark", "915 North Dr.", "Louisville", "KY", 40208);

            //Letter objects.
            Letter L1 = new Letter(A1, A2, 20.00m);
            Letter L2 = new Letter(A3, A4, 10.00m);
            Letter L3 = new Letter(A4, A1, 5.00m);

            //List of parcel objects
            List<Parcel> parcels = new List<Parcel>();
            parcels.Add(L1);
            parcels.Add(L2);
            parcels.Add(L3);

            //Displays the Data.
            Console.WriteLine("---List of Parcels---");
            

            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("---------------------");
            }
        }
    }
}
