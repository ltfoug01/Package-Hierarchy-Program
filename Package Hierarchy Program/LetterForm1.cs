// By: Luke Fougerousse

// File: LetterForm.cs
// This class creates the Letter dialog box form GUI. It performs validation
// and provides properties properties for each field.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Package_Hierarchy_Program
{
    public partial class LetterForm1 : Form
    {
        public const int MIN_ADDRESSES = 2; // Minimum number of addresses needed

        private List<Address> addressList;  // List of addresses used to fill combo boxes

        // Precondition:  addresses.Count >= MIN_ADDRESSES
        // Postcondition: The form's GUI is prepared for display.
        public LetterForm1(List<Address> addresses)
        {
            InitializeComponent();
            addressList = addresses;
        }

        /* --------------------------------------------------------------------------------------------*/
        /* LETTER FORM PROPERTIES */
        /* --------------------------------------------------------------------------------------------*/

        internal int OriginAddressIndex
        {
            // The index of the selected origin address returned
            get
            {
                return originAddCbo.SelectedIndex;
            }

            // The specified index is selected in originAddCbo
            set
            {
                if ((value >= -1) && (value < addressList.Count))
                    originAddCbo.SelectedIndex = value;
                else
                    throw new ArgumentOutOfRangeException("OriginAddressIndex", value,
                        "Index must be valid");
            }
        }

        internal int DestinationAddressIndex
        {
            // The index of the selected origin address returned
            get
            {
                return destAddCbo.SelectedIndex;
            }

            // The specified index is selected in destination combo box
            set
            {
                if ((value >= -1) && (value < addressList.Count))
                    destAddCbo.SelectedIndex = value;
                else
                    throw new ArgumentOutOfRangeException("DestinationAddressIndex", value,
                        "Index must be valid");
            }
        }

        internal string FixedCostText
        {
            // Precondition:  None
            // Postcondition: The text of form's fixed cost field is returned
            get
            {
                return fixedCostTxt.Text;
            }
            // Precondition:  None
            // Postcondition: The text of form's fixed cost field is set to specified value
            set
            {
                fixedCostTxt.Text = value;
            }
        }

        // Precondition:  addressList.Count >= MIN_ADDRESSES
        // Postcondition: The list of addresses is used to populate the
        //                origin and destination address combo boxes
        private void LetterForm1_Load(object sender, EventArgs e)
        {
            if (addressList.Count < MIN_ADDRESSES) // Violated precondition!
            {
                MessageBox.Show("Need " + MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                this.DialogResult = DialogResult.Abort; // Dismiss immediately
            }
            else
            {
                foreach (Address a in addressList)
                {
                    originAddCbo.Items.Add(a.Name);
                    destAddCbo.Items.Add(a.Name);
                }
            }
        }

        /* --------------------------------------------------------------------------------------------*/
        /* VALIDATION SECTION */
        /* --------------------------------------------------------------------------------------------*/

        private void fixedCostTxt_Validating(object sender, CancelEventArgs e)
        {
            decimal fixedCost; // Cost of a letter
            bool valid = true; // Is the text valid?

            if (!decimal.TryParse(fixedCostTxt.Text, out fixedCost)) // Parse failed?
                valid = false;
            else if (fixedCost < 0)
                valid = false;

            if (!valid) // Invalid, so cancel and highlight field
            {
                e.Cancel = true;
                fixedCostTxt.SelectAll();
                errorProvider1.SetError(fixedCostTxt, "Invalid cost! Enter an amount.");
            }
        }

        private void addressCbo_Validating(object sender, CancelEventArgs e)
        {
            // Downcast to sender as ComboBox, so make sure you obey precondition!
            ComboBox cbo = sender as ComboBox; // Cast sender as combo box

            if (cbo.SelectedIndex == -1) // -1 means no item selected
            {
                e.Cancel = true;
                errorProvider1.SetError(cbo, "Must select an address");
            }
            else if (originAddCbo.SelectedIndex != -1 && destAddCbo.SelectedIndex == originAddCbo.SelectedIndex)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbo, "Must select different addresses");
            }
        }

        private void AllFields_Validated(object sender, EventArgs e)
        {
            // Downcast to sender as Control, so make sure you obey precondition!
            Control control = sender as Control; // Cast sender as Control
                                                 // Should always be a Control
            errorProvider1.SetError(control, "");
        }

        private void cancelBtn_MouseDown(object sender, MouseEventArgs e)
        {
            // This handler uses MouseDown instead of Click event because
            // Click won't be allowed if other field's validation fails

            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }
    }
}
