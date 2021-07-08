// By: Luke Fougerousse

// File: ChooseAddressForm.cs
// Creates the Choose Address to Edit dialog box form GUI. It
// provides a get property to retrieve the index of the selected Letter
// from a list of addresses.

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
    public partial class ChooseAddressForm : Form
    {
        private List<Address> addressList; // Variable: List of addresses used to fill combo boxes

        //The form's GUI is prepared for display.
        public ChooseAddressForm(List<Address> addresses)
        {
            InitializeComponent();
            addressList = addresses;
        }

        public int AddressIndex
        {
            //The index of the selected origin address returned
            get
            {
                return addListComboBox.SelectedIndex;
            }

            // Precondition:  -1 <= value < addressList.Count
            // Postcondition: The specified index is selected in originAddCbo
            set
            {
                if ((value >= -1) && (value < addressList.Count))
                    addListComboBox.SelectedIndex = value;
                else
                    throw new ArgumentOutOfRangeException("AddressIndex", value,
                        "Index must be valid");
            }
        }

        private void ChooseAddressForm_Load(object sender, EventArgs e)
        {
            foreach (Address a in addressList)
            {
                addListComboBox.Items.Add(a.Name);
            }

            addListComboBox.SelectedIndex = 0; //selects first name in list
        }

        private void cancelBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /* --------------------------------------------------------------------------------------------*/
        /* VALIDATION SECTION */
        /* --------------------------------------------------------------------------------------------*/

        private void addListComboBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(addListComboBox, "");
        }

        private void addListComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (addListComboBox.SelectedIndex == -1) //if selected
            {
                e.Cancel = true;
                errorProvider1.SetError(addListComboBox, "Must select an address");
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            // The easy way
            // Raise validating event for all enabled controls on form
            // If all pass, ValidateChildren() will be true
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }
    }
}
