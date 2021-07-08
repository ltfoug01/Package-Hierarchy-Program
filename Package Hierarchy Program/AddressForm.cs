/*
 * By: Luke Fougerousse
 * File: AddressForm.cs
 * 
 * This class creates the Address dialog box form GUI. It performs validation
 * and provides String properties for each field. This solution uses one
 * event handler for all required text textboxes Validating events and one
 * event handler for all controls Validated events.
 * 
 */

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
    public partial class AddressForm : Form
    {
        public const String DEFAULT_STATE = "KY"; // Default state for addresses

        public AddressForm()
        {
            InitializeComponent();

            List<string> states = new List<string> {"CA", "IN", "KY", "MD", "ME",
                                   "NC", "OH", "SC", "TN", "TX"}; // A list of possible states

            //Add states to comboBox
            foreach (string state in states)
                stateComboBox.Items.Add(state);
        }

        /* --------------------------------------------------------------------------------------------*/
        /* ADDRESS FORM PROPERTIES */
        /* --------------------------------------------------------------------------------------------*/

        internal string AddressName
        {
            get
            {
                return nameTxt.Text;  //the text of a form's name field is returned
            }

            set
            {
                nameTxt.Text = value; //the text of form's field is set to specififed value
            }
        }

        internal string Address1
        {
            get
            {
                return address1Txt.Text; //the text of the forms address1 field is returned.
            }

            set
            {
                address1Txt.Text = value; //the text of form's address1 is set to specified value.
            }
        }

        internal string Address2
        {
            get
            {
                return address2Txt.Text; //the text of the form's address2 field is retruned.
            }

            set
            {
                address2Txt.Text = value; //the text of form's address2 is set to specified value.
            }
        }

        internal string City
        {
            get
            {
                return cityTxt.Text; //the text of form's city field is returned
            }

            set
            {
                cityTxt.Text = value; //the text of form's city is set to specified value.
            }
        }

        internal string Ziptext
        {
            get
            {
                return zipTxt.Text;
            }

            set
            {
                zipTxt.Text = value;
            }
        }

        internal string State
        {
            get
            {
                if (stateComboBox.SelectedIndex != -1) //-1 = no item selected
                    return stateComboBox.SelectedItem.ToString();
                else
                    return "";
            }

            // Precondition:  value must be in stateCbo Items
            // Postcondition: The text of form's State field is set to specified value
            set
            {
                stateComboBox.SelectedItem = value;
            }
        }

        /* --------------------------------------------------------------------------------------------*/
        /* VALIDATION SECTION */
        /* --------------------------------------------------------------------------------------------*/

        //if no state is selected, focus remains & error provider highlights the field
        private void stateComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (stateComboBox.SelectedIndex == -1) // Didn't select anything from cbo
            {
                e.Cancel = true;
                errorProvider.SetError(stateComboBox, "Must select a state!");
            }
        }

        //if zipcode text is validated, focus remains & error provider hgihlights the field
        private void zipTxt_Validating(object sender, CancelEventArgs e)
        {
            int zip; // Zip code of address

            if (!int.TryParse(zipTxt.Text, out zip)      // Parse failed?
                || (zip < 0) || (zip > Address.MAX_ZIP)) // Invalid, so cancel and highlight field
            {
                e.Cancel = true;
                zipTxt.SelectAll();
                errorProvider.SetError(zipTxt, "Invalid zip code! Enter 5 digit zip code.");
            }
        }

        // If zipcode text is invalid, focus remains and error provider highlights the field
        private void RequiredTextFields_Validating(object sender, CancelEventArgs e)
        {
            // Downcast to sender as TextBox, so make sure you obey precondition!
            TextBox textbox = sender as TextBox; // Cast sender as TextBox
                                                 // Should always be a TextBox

            if (string.IsNullOrWhiteSpace(textbox.Text)) // Empty field
            {
                e.Cancel = true;

                const int SUFFIX = 3; // Chars in "txt" suffix in control names
                string name;          // Will hold field name based on control name
                name = textbox.Name.Substring(0, textbox.Name.Length - SUFFIX); // Remove suffix
                errorProvider.SetError(textbox, $"Must enter a value for {name}!");
            }
        }

        private void AllFields_Validated(object sender, EventArgs e)
        {
            // Downcast to sender as Control, so make sure you obey precondition!
            Control control = sender as Control; // Cast sender as Control
                                                 // Should always be a Control
            errorProvider.SetError(control, "");
        }

        // Precondition: User clicked on cancelBtn
        // Postcondition: The form closes and sends Cancel result
        private void cancelBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)           // left-click?
                this.DialogResult = DialogResult.Cancel;
        }

        // Precondition:  User clicked on okBtn
        // Postcondition: If invalid field on dialog, keep form open and give first invalid
        //                field the focus. Else return OK and close form.
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }
    }
}
