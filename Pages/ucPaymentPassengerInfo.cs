using Ferry_Ticketing_App.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ferry_Ticketing_App.GetAllInfoForTicket.DepartureTicketInfo;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucPaymentPassengerInfo : UserControl
    {
        private static int passengerCounter = 1;

        public ucPaymentPassengerInfo()
        {
            InitializeComponent();
        }

        public PassengerDetails GetPassengerInfo()
        {
            return new PassengerDetails
            {
                FirstName = GetLabelText(this, "lblPIFName"),
                MiddleInitial = GetLabelText(this, "lblPIMiddleInitial"),
                LastName = GetLabelText(this, "lblPILName"),
                Gender = GetLabelText(this, "lblPIGender"),
                Birthdate = GetLabelText(this, "lblPIBirthdate")
            };
        }

        private string GetLabelText(Control parentControl, string labelName)
        {
            var label = parentControl.Controls.Find(labelName, true).FirstOrDefault() as Label;
            return label?.Text ?? string.Empty;
        }
    }
}
