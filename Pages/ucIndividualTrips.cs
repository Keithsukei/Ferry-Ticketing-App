using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            Console.WriteLine($"Initializing slider with date: {startDate}");
            currentDateStart = startDate.Date; // Ensure only the date part is used
            UpdateDateButtons(); // Refresh the slider buttons with the new start date

            // Automatically highlight the initial date
            var selectedButton = dateButtons.FirstOrDefault(btn =>
                btn.Tag is DateTime date && date.Date == currentDateStart.Date);
            if (selectedButton != null)
            {
                HighlightSelectedDate(selectedButton);
            }
            else
            {
                Console.WriteLine("No matching button found for the selected date.");
            }
        }
        private void UpdateDateButtons()
        {
            for (int i = 0; i < dateButtons.Count; i++)
            {
                DateTime date = currentDateStart.AddDays(i);
                dateButtons[i].Text = $"{date.Day}\n{date:ddd}\n{date:MMM}";
                dateButtons[i].Tag = date;
            }
        }

        private void UpdateDates(int offset)
        {
            currentDateStart = currentDateStart.AddDays(offset);
            UpdateDateButtons();
        }

        private void DateButton_Click(object sender, EventArgs e)
        {
            var selectedButton = sender as Button;
            if (selectedButton != null)
            {
                // Get the date from the button's Tag
                DateTime selectedDate = (DateTime)selectedButton.Tag;

                // Highlight the selected date button
                HighlightSelectedDate(selectedButton);

                // Perform any additional actions with the selected date
                MessageBox.Show($"Selected Date: {selectedDate.ToShortDateString()}");
            }
        }

        private void HighlightSelectedDate(Button selectedButton)
        {
            foreach (var btn in dateButtons)
            {
                btn.BackColor = SystemColors.Control; // Reset button background color
                btn.ForeColor = Color.Black;         // Reset text color
            }

            selectedButton.BackColor = Color.LightBlue; // Highlight selected button background
            selectedButton.ForeColor = Color.White;    // Change text color for better visibility
        }
    }
}
