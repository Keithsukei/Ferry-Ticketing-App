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

        public ucPassengerDetails()
        {
            InitializeComponent();
            InitializeComboBoxes();
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
                Passenger passenger = new Passenger(
                    passengerCounter++,
                    txtFName.Text.Trim(),
                    txtMI.Text.Trim(),
                    txtLName.Text.Trim(),
                    cmbBoxGender.SelectedItem.ToString(),
                    dtpDateOfBirth.Value,
                    cmbBType.SelectedItem.ToString(),
                    cmbBoxNationality.SelectedItem.ToString()
                );

                return passenger;
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

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text))
            {
                MessageBox.Show("First and Last Name are required.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            // Age validation
            int age = DateTime.Now.Year - dtpDateOfBirth.Value.Year;
            if (dtpDateOfBirth.Value > DateTime.Now || age > 120)
            {
                MessageBox.Show("Please enter a valid date of birth.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
