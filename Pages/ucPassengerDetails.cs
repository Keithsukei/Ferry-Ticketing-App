using Ferry_Ticketing_App.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucPassengerDetails : UserControl
    {
        private List<Passenger> passengerList = new List<Passenger>();
        private static int passengerCounter = 1;
        public string InstanceName { get; set; } 

        public ucPassengerDetails()
        {
            InitializeComponent();
            InitializeComboBoxes();

            txtFName.KeyPress += ValidateLettersOnly;
            txtLName.KeyPress += ValidateLettersOnly;
            txtMI.KeyPress += ValidateLettersOnly;
            txtMI.TextChanged += ValidateMiddleInitial;

            // Set initial date range for adult (default type)
            DateTime today = DateTime.Today;
            dtpDateOfBirth.MinDate = DateTime.Today.AddYears(-120);
            dtpDateOfBirth.MaxDate = today.AddYears(-18);
            dtpDateOfBirth.Value = today.AddYears(-20); // Default to 20 years old

            cmbBType.SelectedIndexChanged += cmbBType_SelectedIndexChanged;
        }

        private void ValidateLettersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ValidateMiddleInitial(object sender, EventArgs e)
        {
            if (txtMI.Text.Length > 1)
            {
                txtMI.Text = txtMI.Text.Substring(0, 1);
                txtMI.SelectionStart = 1;
            }
        }

        // Update the passenger number label
        private void UpdatePassengerNumberLabel()
        {
            if (lblPassengerNo != null)
            {
                lblPassengerNo.Text = $"{passengerCounter}";
            }
        }

        // Remove a passenger by ID
        public bool RemovePassenger(int passengerId)
        {
            Passenger passengerToRemove = passengerList.Find(p => p.Id == passengerId);
            if (passengerToRemove != null)
            {
                bool removed = passengerList.Remove(passengerToRemove);
                UpdatePassengerNumberLabel();
                return removed;
            }
            return false;
        }

        private void InitializeComboBoxes()
        {
            // Initialize Gender ComboBox
            cmbBoxGender.Items.Clear();
            cmbBoxGender.Items.AddRange(new string[] {
                "Male",
                "Female",
                "Others"
            });
            cmbBoxGender.SelectedIndex = 0;

            // Initialize Passenger Type ComboBox
            cmbBType.Items.Clear();
            cmbBType.Items.AddRange(new string[] {
                "Adult",
                "Student",
                "Senior Citizen",
                "PWD",
                "Child"
            });
            cmbBType.SelectedIndex = 0;

            // Initialize Nationality ComboBox (Asian Countries)
            cmbBoxNationality.Items.Clear();
            cmbBoxNationality.Items.AddRange(new string[] {
                "Filipino",
                "Chinese",
                "Japanese",
                "Korean",
                "Vietnamese",
                "Thai",
                "Malaysian",
                "Indonesian",
                "Singaporean",
                "Cambodian"
            });
            cmbBoxNationality.SelectedIndex = 0;
        }

        public Passenger GetPassengerDetails()
        {
            if (!ValidateInput())
                return null;

            try
            {
                return new Passenger(
                    passengerCounter++,
                    txtFName.Text.Trim(),
                    txtMI.Text.Trim(),
                    txtLName.Text.Trim(),
                    cmbBoxGender.SelectedItem.ToString(),
                    dtpDateOfBirth.Value,
                    cmbBType.SelectedItem.ToString(),
                    cmbBoxNationality.SelectedItem.ToString()
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please fill in all required fields correctly.\n" + ex.Message,
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        // Reset the passenger counter (useful when starting a new booking session)
        public static void ResetPassengerCounter()
        {
            passengerCounter = 1;
        }

        // Get current passenger count
        public static int GetCurrentPassengerCount()
        {
            return passengerCounter - 1;
        }

        // Method to clear all controls
        public void ClearControls()
        {
            txtFName.Clear();
            txtMI.Clear();
            txtLName.Clear();
            cmbBoxGender.SelectedIndex = 0;
            dtpDateOfBirth.Value = DateTime.Now;
            cmbBType.SelectedIndex = 0;
            cmbBoxNationality.SelectedIndex = 0;
        }

        // Method to set passenger details to controls
        public void SetPassengerDetails(Passenger passenger)
        {
            if (passenger != null)
            {
                txtFName.Text = passenger.FirstName;
                txtMI.Text = passenger.MiddleInitial;
                txtLName.Text = passenger.LastName;
                cmbBoxGender.SelectedItem = passenger.Gender;
                dtpDateOfBirth.Value = passenger.DateOfBirth;
                cmbBType.SelectedItem = passenger.Type;
                cmbBoxNationality.SelectedItem = passenger.Nationality;
            }
        }

        private bool ValidateInput(bool showMessage = true)
        {
            string instancePrefix = !string.IsNullOrEmpty(InstanceName) ? $"in {InstanceName}" : "";

            // Validate First Name
            if (string.IsNullOrWhiteSpace(txtFName.Text))
            {
                if (showMessage)
                {
                    MessageBox.Show($"First Name is required {instancePrefix}.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtFName.Focus();
                }
                return false;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(txtLName.Text))
            {
                if (showMessage) {
                MessageBox.Show($"Last Name is required {instancePrefix}.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    txtLName.Focus();
                }
                return false;
            }

            // Validate Middle Initial length
            if (!string.IsNullOrWhiteSpace(txtMI.Text) && txtMI.Text.Length > 1)
            {
                if (showMessage) {
                MessageBox.Show($"Middle Initial should be a single character {instancePrefix}.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    txtMI.Focus();
                }
                return false;
            }

            // Age validation
            int age = DateTime.Now.Year - dtpDateOfBirth.Value.Year;
            if (DateTime.Now.Month < dtpDateOfBirth.Value.Month || 
                (DateTime.Now.Month == dtpDateOfBirth.Value.Month && DateTime.Now.Day < dtpDateOfBirth.Value.Day))
            {
                age--;
            }

            if (age < 1)
            {
                if (showMessage) {
                MessageBox.Show($"Passenger must be at least 1 year old {instancePrefix}.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    dtpDateOfBirth.Focus();
                }
                return false;
            }
            else if (age > 120)
            {
                if (showMessage) {
                MessageBox.Show($"Please enter a valid date of birth {instancePrefix}.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    dtpDateOfBirth.Focus();
                }
                return false;
            }

            // Check if passenger is already booked
            Passenger tempPassenger = new Passenger(
                0,
                txtFName.Text.Trim(),
                txtMI.Text.Trim(),
                txtLName.Text.Trim(),
                cmbBoxGender.SelectedItem.ToString(),
                dtpDateOfBirth.Value,
                cmbBType.SelectedItem.ToString(),
                cmbBoxNationality.SelectedItem.ToString()
            );

            if (tempPassenger.IsAlreadyBooked())
            {
                if (showMessage)
                {
                    MessageBox.Show(
                        $"This passenger is already booked on another trip {instancePrefix}.",
                        "Duplicate Passenger",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    txtFName.Focus();
                }
                return false;
            }

            return true;
        }

        public bool ValidatePassengerDetails()
        {
            return ValidateInput(false);
        }

        private void cmbBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBType.SelectedItem == null) return;

            string selectedType = cmbBType.SelectedItem.ToString().ToLower();
            DateTime today = DateTime.Today;

            dtpDateOfBirth.MinDate = DateTime.Today.AddYears(-120);
            dtpDateOfBirth.MaxDate = DateTime.Today;

            switch (selectedType)
            {
                case "adult":
                    dtpDateOfBirth.Value = today.AddYears(-20);
                    dtpDateOfBirth.MaxDate = today.AddYears(-18);
                    break;

                case "child":
                    dtpDateOfBirth.Value = today.AddYears(-6);
                    dtpDateOfBirth.MinDate = today.AddYears(-13);
                    break;

                case "senior citizen":
                    dtpDateOfBirth.Value = today.AddYears(-65);
                    dtpDateOfBirth.MaxDate = today.AddYears(-60);
                    break;

                case "student":
                    dtpDateOfBirth.Value = today.AddYears(-18);
                    dtpDateOfBirth.MinDate = today.AddYears(-24);
                    dtpDateOfBirth.MaxDate = today.AddYears(-12);
                    break;

                case "pwd":
                    dtpDateOfBirth.Value = today.AddYears(-30); // Default age
                    break;
            }
        }

        public void ResetControls()
        {
            cmbBType.SelectedIndex = 0;
            cmbBoxGender.SelectedIndex = 0;
            cmbBoxNationality.SelectedIndex = 0;
            txtFName.Clear();
            txtLName.Clear();
            txtMI.Clear();
            dtpDateOfBirth.Value = DateTime.Today.AddYears(-20);
        }
    }
}
