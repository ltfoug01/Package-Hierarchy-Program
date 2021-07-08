/* By: Luke Fougerousse

 This class creates the main GUI for Program 3. It provides a
 File menu with About and Exit items, an Insert menu with Address and
 Letter items, and a Report menu with List Addresses and List Parcels
 items. It adds two menu items, Open and Save As, to the File menu.
 In addition, the application must add a new menu, Edit, with a
 single menu item, Address. When selected, present the user with the
 list of addresses and allow the user to choose which one they'd like
 to edit.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace Package_Hierarchy_Program
{
    public partial class ProgramForm : Form
    {
        private UserParcelView upv; // The UserParcelView

        public ProgramForm()
        {
            InitializeComponent();

            upv = new UserParcelView();
        }

        /* --------------------------------------------------------------------------------------------*/
        /* CLICK EVENTS */
        /* --------------------------------------------------------------------------------------------*/

        // Information about the author of the program is displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine; // Newline shorthand

            MessageBox.Show($"Package Hierarchy Program {NL}By: Luke Fougerousse{NL}CIS 200{NL}Fall 2017",
                "About Program 3");
        }

        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // The application is exited
        }

        //List of addresses is displayed in the addressResults Text Box
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built; StringBuilder more efficient than String

            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Addresses:");
            result.Append(NL);
            result.Append(NL);

            foreach (Address a in upv.AddressList)
            {
                result.Append(a.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
            }

            menuReportTxtBox.Text = result.ToString();

            // Put the cursor at start of report
            menuReportTxtBox.Focus();
            menuReportTxtBox.SelectionStart = 0;
            menuReportTxtBox.SelectionLength = 0;
        }

        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm1 letterForm; // The letter dialog box form
            DialogResult result;    // The result of showing form as dialog
            decimal fixedCost;      // The letter's cost

            if (upv.AddressCount < LetterForm1.MIN_ADDRESSES) // Make sure we have enough addresses
            {
                MessageBox.Show("Need " + LetterForm1.MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                return;
            }

            letterForm = new LetterForm1(upv.AddressList); // Send list of addresses
            result = letterForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (decimal.TryParse(letterForm.FixedCostText, out fixedCost))
                {
                    // For this to work, LetterForm's combo boxes need to be in same
                    // order as upv's AddressList
                    upv.AddLetter(upv.AddressAt(letterForm.OriginAddressIndex),
                        upv.AddressAt(letterForm.DestinationAddressIndex),
                        fixedCost);
                }
                else
                {
                    MessageBox.Show("Problem with Letter Validation!", "Validation Error");
                }
            }

            letterForm.Dispose();
        }

        // The list of parcels is displayed in the parcelResultsTxt text box
        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            decimal totalCost = 0;                      // Running total of parcel shipping costs
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Parcels:");
            result.Append(NL);
            result.Append(NL);

            foreach (Parcel p in upv.ParcelList)
            {
                result.Append(p.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
                totalCost += p.CalcCost();
            }

            result.Append(NL);
            result.Append($"Total Cost: {totalCost:C}");

            menuReportTxtBox.Text = result.ToString();

            menuReportTxtBox.Focus();
            menuReportTxtBox.SelectionStart = 0;
            menuReportTxtBox.SelectionLength = 0;
        }

        //The list of addresses is saved to a file using object serialization
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter(); // Object for serializing UPV in binary format
            FileStream output = null;                          // Stream for writing to a file
            DialogResult result;                               // Result of file dialog box
            string fileName;                                   // Name of file to save data

            using (SaveFileDialog fileChooser = new SaveFileDialog()) // Creates the Save File Dialog
            {
                fileChooser.CheckFileExists = false; // let user create file

                // retrieve the result of the dialog box
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; // get specified file name
            }

            // ensure that user clicked "OK"
            if (result == DialogResult.OK)
            {
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // save file via FileStream if user specified valid file
                    try
                    {
                        // open file with write access, Create will overwrite existing file
                        output = new FileStream(fileName, FileMode.Create, FileAccess.Write);

                        formatter.Serialize(output, upv); // Serialize whole UPV object
                    } // end try
                    // handle exception if there is a problem opening the file
                    catch (IOException)
                    {
                        // notify user if file could not be opened
                        MessageBox.Show("I/O Error Writing to File", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // notify user if error occurs in serialization
                    catch (SerializationException)
                    {
                        MessageBox.Show("Serialization Error Writing to File", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // end catch
                    finally
                    {
                        output?.Close(); // close FileStream if not null
                    }
                }
            }
        }

        // The UserParcelView is read in from a file using object deserialization, replacing the existing upv
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter reader = new BinaryFormatter(); // Object for deserializing UPV in binary format
            FileStream input = null;                        // Stream for reading from a file
            DialogResult result;                            // Result of file dialog box
            string fileName;                                // Name of file to save data
            UserParcelView temp;                            // Temporary holder for UPV

            using (OpenFileDialog fileChooser = new OpenFileDialog()) // Create Open Dialog box
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; // get specified name
            }

            // ensure that user clicked "OK"
            if (result == DialogResult.OK)
            {
                // show error if user specified invalid file
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // create FileStream to obtain read access to file
                    try
                    {

                        input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                        // get UPV from file
                        temp = (UserParcelView)reader.Deserialize(input);

                        upv = temp; // Separated in case deserialization failed
                    }

                    // handle exception if there is a problem opening the file
                    catch (IOException)
                    {
                        // notify user if file could not be opened
                        MessageBox.Show("I/O Error Reading From File", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    catch (SerializationException)
                    {
                        MessageBox.Show("Serialization Error Reading From File", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        input?.Close(); // close FileStream if not null
                    }
                }
            }
        }

        //Display addressform dialog box to insert address
        //Under Insert Menu Item
        private void addressToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and store result
            int zip;                                        // The address zip code

            if (result == DialogResult.OK)
            {
                if (int.TryParse(addressForm.Ziptext, out zip))
                {
                    upv.AddAddress(addressForm.AddressName, addressForm.Address1,
                        addressForm.Address2, addressForm.City, addressForm.State,
                        zip);
                }
                else
                {
                    MessageBox.Show("Problem with Address Validation!", "Validation Error");
                }
            }

            addressForm.Dispose(); // Best practice for dialog boxes
        }

        //The address selected from the list has been edited with the new information replacing the existing object's properties
        //Under the Edit Menu Strop Item
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (upv.AddressList.Count > 0) // Only edit if there are addresses!
            {
                ChooseAddressForm chooseAddForm = new ChooseAddressForm(upv.AddressList); // The choose address dialog box form
                DialogResult result = chooseAddForm.ShowDialog();                         // Show form as dialog and store result

                if (result == DialogResult.OK) // Only edit if OK
                {
                    int editIndex; // Index of address to edit
                    editIndex = chooseAddForm.AddressIndex;

                    if (editIndex >= 0) // -1 if didn't select item from combo box
                    {
                        Address editAddress = upv.AddressAt(editIndex); // The address being edited
                        AddressForm addressForm = new AddressForm();    // The address dialog box form

                        // Populate form fields from selected address
                        addressForm.AddressName = editAddress.Name;
                        addressForm.Address1 = editAddress.Address1;
                        addressForm.Address2 = editAddress.Address2;
                        addressForm.City = editAddress.City;
                        addressForm.State = editAddress.State;
                        addressForm.Ziptext = $"{editAddress.Zip:D5}";

                        result = addressForm.ShowDialog(); // Show form as dialog and store result

                        if (result == DialogResult.OK) // Only edit if OK
                        {
                            // Edit address properties using form fields
                            editAddress.Name = addressForm.AddressName;
                            editAddress.Address1 = addressForm.Address1;
                            editAddress.Address2 = addressForm.Address2;
                            editAddress.City = addressForm.City;
                            editAddress.State = addressForm.State;
                            if (int.TryParse(addressForm.Ziptext, out int zip))
                            {
                                editAddress.Zip = zip;
                            }
                            else
                            {
                                MessageBox.Show("Problem with Zip Validation!", "Validation Error");
                            }
                        }
                        addressForm.Dispose();
                    }
                }
                chooseAddForm.Dispose();
            }
            else
                MessageBox.Show("No addresses to edit!", "No Addresses");
        }
    }   
}
