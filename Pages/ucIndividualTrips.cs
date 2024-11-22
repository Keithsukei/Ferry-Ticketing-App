using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucIndividualTrips : UserControl
    {
        private DateTime currentDateStart;
        private List<Button> dateButtons;

        public ucIndividualTrips()
        {
            InitializeComponent();
            dateButtons = new List<Button>
            {
                btnDate1, btnDate2, btnDate3, btnDate4, btnDate5,
                btnDate6, btnDate7, btnDate8, btnDate9, btnDate10
            };
            

            // Hook up navigation button events
            btnLeft.Click += (s, e) => UpdateDates(-10);
            btnRight.Click += (s, e) => UpdateDates(10);
        }
        private void HighlightDate(DateTime dateToHighlight)
        {
            foreach (var button in dateButtons)
            {
                if (button.Tag is DateTime buttonDate && buttonDate.Date == dateToHighlight.Date) // Match only the date part
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.Black; // Set a border color
                    button.BackColor = Color.LightBlue;                 // Optional: highlight background
                    button.ForeColor = Color.Black;                    // Optional: change text color
                }
                else
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
                }
            }
        }

        public void SetStartDate(DateTime startDate)
        {
            currentDateStart = startDate;

            int dayOffset = 0;
            foreach (Control control in pnlDateSliderButtons.Controls)
            {
                if (control is Button button)
                {
                    DateTime date = currentDateStart.AddDays(dayOffset);
                    button.Text = date.ToString("dd\nMMM");
                    button.Tag = date;
                    dayOffset++;
                }
            }
        }
        public void InitializeWithDate(DateTime startDate)
        {
            currentDateStart = startDate; // Set the starting date
            HighlightDate(startDate);
            UpdateDateButtons();
        }
        private void UpdateDateButtons()
        {
            for (int i = 0; i < dateButtons.Count; i++)
            {
                DateTime date = currentDateStart.AddDays(i);
                dateButtons[i].Text = $"{date.Day}\n{date:ddd}\n{date:MMM}";
                dateButtons[i].Tag = date;

                dateButtons[i].Click -= DateButton_Click; // Avoid duplicate event handlers
                dateButtons[i].Click += DateButton_Click;
            }

            HighlightDate(currentDateStart);
        }

        private void UpdateDates(int offset)
        {
            currentDateStart = currentDateStart.AddDays(offset);
            UpdateDateButtons();
        }

        private void DateButton_Click(object sender, EventArgs e)
        {
            if (sender is Button selectedButton && selectedButton.Tag is DateTime selectedDate)
            {
                HighlightDate(selectedDate);
            }
        }

    }
}
