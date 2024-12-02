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
using static Ferry_Ticketing_App.Pages.ucIndividualTrips;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucSearchRoundTrip : UserControl
    {
        private const int DEPCOLLAPSED_HEIGHT = 249;
        private const int DEPEXPANDED_HEIGHT = 673;
        private const int RETCOLLAPSED_HEIGHT = 254;  // Adjust based on your panel's collapsed height
        private const int RETEXPANDED_HEIGHT = 255;
        private const int BUTTON_HEIGHT = 71;
        private const int PADDING = 5;
        private const int BUTTON_PADDING = 35;
        private Timer animationTimer;
        private int currentDepartureHeight;
        private int currentReturnHeight;
        private int targetDepartureHeight;
        private int targetReturnHeight;
        private const int ANIMATION_INTERVAL = 4;  // Faster refresh rate (was 16)
        private const int ANIMATION_STEPS = 5;      // Fewer steps for quicker animation (was using division by 4)
        private const int MIN_STEP_SIZE = 12;
        private bool isAnimating = false;
        public bool IsRoundTrip { get; set; }


        public ucSearchRoundTrip()
        {
            InitializeComponent();
            SetupAnimationTimer();
            SetDoubleBuffered(this);
            InitializePanelStates();

            ucIndividualTrips1.TripSelected += UpdateDepartureSummary;
            ucIndividualTrips2.ReturnTripSelected += UpdateReturnSummary;
            ucDepartureSummary1.pnlDepDropDownSelected.Visible = false;
            ucDepartureSummary1.pnlDepDropDownNoSelected.Visible = true;
            ucReturnSummary1.pnlRetDropdownSelected.Visible = false;
            ucReturnSummary1.pnlRetDropdownNoSelected.Visible = true;
            ucIndividualTrips1.SetSearchRoundTripReference(this);
            ucIndividualTrips2.SetSearchRoundTripReference(this);

            UpdatePanelSizes();
        }

        private void SetDoubleBuffered(Control control)
        {
            if (SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                typeof(Control).GetProperty(
                    "DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);

            aProp.SetValue(control, true, null);

            foreach (Control child in control.Controls)
            {
                SetDoubleBuffered(child);
            }
        }

        private void UpdatePanelSizes()
        {
            SuspendLayout();

            // Position the return summary below departure summary
            ucReturnSummary1.Top = ucDepartureSummary1.Bottom + PADDING;

            // Position the button below return summary
            btnSummaryContinue.Top = ucReturnSummary1.Bottom + PADDING;

            // Calculate total height needed for pnlSummary
            pnlSummary.Height = btnSummaryContinue.Bottom + BUTTON_PADDING;

            if (pnlSummary.Parent != null)
            {
                pnlSummary.Parent.Height = Math.Max(pnlSummary.Bottom + BUTTON_PADDING, pnlSummary.Parent.Height);

                pnlSummary.Parent.Refresh();
            }

            ResumeLayout(true);
        }   

        private void SetupAnimationTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = ANIMATION_INTERVAL;
            animationTimer.Tick += AnimationTimer_Tick;
        }
        private void InitializePanelStates()
        {
            SuspendLayout();
            currentDepartureHeight = DEPCOLLAPSED_HEIGHT;
            currentReturnHeight = RETCOLLAPSED_HEIGHT;
            ucDepartureSummary1.Height = DEPCOLLAPSED_HEIGHT;
            ucReturnSummary1.Height = RETCOLLAPSED_HEIGHT;
            btnSummaryContinue.Height = BUTTON_HEIGHT;

            UpdateControlPositions();
            ResumeLayout(false);
        }
        private void UpdateControlPositions()
        {
            if (!isAnimating) SuspendLayout();

            ucReturnSummary1.Top = ucDepartureSummary1.Bottom + 5;
            btnSummaryContinue.Top = ucReturnSummary1.Bottom + 5;
            pnlSummary.Height = btnSummaryContinue.Bottom + 5;

            if (!isAnimating) ResumeLayout(true);
        }

        private void UpdateDepartureSummary(TripDetails tripDetails)
        {
            if (animationTimer.Enabled)
            {
                animationTimer.Stop();
                // Snap current animation to end state
                FinishCurrentAnimation();
            }
            ucDepartureSummary1.UpdateDepartureDetails(tripDetails);
            targetDepartureHeight = DEPEXPANDED_HEIGHT;
            targetReturnHeight = currentReturnHeight;
            StartAnimation();
        }

        private void UpdateReturnSummary(ReturnTripDetails returnTripDetails)
        {
            if (animationTimer.Enabled)
            {
                animationTimer.Stop();
                // Snap current animation to end state
                FinishCurrentAnimation();
            }
            ucReturnSummary1.UpdateReturnDetails(returnTripDetails);
            targetReturnHeight = RETEXPANDED_HEIGHT;
            targetDepartureHeight = currentDepartureHeight;
            StartAnimation();
        }
        private void FinishCurrentAnimation()
        {
            SuspendLayout();

            // Snap to target positions immediately
            if (ucDepartureSummary1 != null)
                ucDepartureSummary1.Height = targetDepartureHeight;
            if (ucReturnSummary1 != null)
                ucReturnSummary1.Height = targetReturnHeight;

            currentDepartureHeight = targetDepartureHeight;
            currentReturnHeight = targetReturnHeight;

            UpdatePanelSizes();

            ResumeLayout(true);
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            isAnimating = true;
            SuspendLayout();

            bool isDepartureComplete = AnimatePanel(
                ref currentDepartureHeight,
                targetDepartureHeight,
                ucDepartureSummary1
            );

            bool isReturnComplete = AnimatePanel(
                ref currentReturnHeight,
                targetReturnHeight,
                ucReturnSummary1
            );

            UpdatePanelSizes();

            ResumeLayout(true);
            isAnimating = false;

            if (isDepartureComplete && isReturnComplete)
            {
                animationTimer.Stop();
                // Final position adjustment
                FinishCurrentAnimation();
            }
        }

        private bool AnimatePanel(ref int currentHeight, int targetHeight, UserControl panel)
        {
            if (currentHeight == targetHeight) return true;

            // Calculate the step size based on total distance
            int totalDistance = Math.Abs(targetHeight - currentHeight);
            int step = Math.Max(totalDistance / ANIMATION_STEPS, MIN_STEP_SIZE);

            // For very small changes, just snap to position
            if (totalDistance <= MIN_STEP_SIZE * 2)
            {
                currentHeight = targetHeight;
                panel.Height = targetHeight;
                return true;
            }

            // Determine direction and apply step
            if (currentHeight < targetHeight)
            {
                currentHeight = Math.Min(targetHeight, currentHeight + step);
            }
            else
            {
                currentHeight = Math.Max(targetHeight, currentHeight - step);
            }

            try
            {
                panel.Height = currentHeight;
            }
            catch
            {
                currentHeight = targetHeight;
                panel.Height = targetHeight;
                return true;
            }

            return currentHeight == targetHeight;
        }

        private void StartAnimation()
        {
            SuspendLayout();
            if (!animationTimer.Enabled)
            {
                animationTimer.Start();
            }
            ResumeLayout(true);
        }

        public void UpdateItinerary(string fromCode, string fromCity, string toCode, string toCity, int passengers, DateTime departDate, DateTime returnDate)
        {
            foreach (Control ctrl in pnlItineraryPH.Controls)
            {
                if (ctrl is Label label)
                {
                    switch (label.Name)
                    {
                        case "lblFromCode":
                            label.Text = fromCode;
                            break;
                        case "lblToCode":
                            label.Text = toCode;
                            break;
                        case "lblFromCity":
                            label.Text = fromCity;
                            break;
                        case "lblToCity":
                            label.Text = toCity;
                            break;
                        case "lblNoOfPassengers":
                            label.Text = passengers.ToString();
                            break;
                        case "lblDepartureDate":
                            label.Text = departDate.ToString("yyyy-MM-dd");
                            break;
                        case "lblReturnDate":
                            label.Text = returnDate.ToString("yyyy-MM-dd");
                            break;
                    }
                }
            }
        }

        private void btnModifyItinerary_Click(object sender, EventArgs e)
        {
            var findTrips = this.Parent.Controls.OfType<ucFindTrips>().FirstOrDefault();

            if (findTrips != null)
            {
                findTrips.BringToFront();
                findTrips.Visible = true;

                // Update the number of passengers based on the input field (if available)
                int passengers = int.TryParse(findTrips.txtPassengers.Text, out int result) ? result : 1;

                // Update trip details for all instances of ucIndividualTrips
                foreach (var tripControl in this.Parent.Controls.OfType<ucIndividualTrips>())
                {
                    lblNoOfPassengers.Text = passengers.ToString();
                    tripControl.RecalculateTripDetails(DateTime.Now);
                }
            }
        }

        private void btnSummaryContinue_Click(object sender, EventArgs e)
        {
            List<string> placeholderTexts = new List<string> { "No vessel available", "label1", "--:--" };

            if (placeholderTexts.Contains(ucDepartureSummary1.lblDVesselName.Text) ||
                placeholderTexts.Contains(ucReturnSummary1.lblRVesselName.Text))
            {
                MessageBox.Show("Please select both a departure and return trip to proceed.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int numberOfPassengers = int.TryParse(lblNoOfPassengers.Text, out int passengers) ? passengers : 1;

            if (string.IsNullOrEmpty(lblDepartureDate.Text) || string.IsNullOrEmpty(lblReturnDate.Text) ||
                placeholderTexts.Contains(lblDepartureDate.Text) || placeholderTexts.Contains(lblReturnDate.Text))
            {
                MessageBox.Show("Please ensure both departure and return dates are selected.", "Date Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var passengerContactInfo = this.Parent.Controls.OfType<ucPassengerContactInfo>().FirstOrDefault();
            if (passengerContactInfo != null)
            {
                passengerContactInfo.UpdateItinerary2(
                    lblFromCode.Text,
                    lblFromCity.Text,
                    lblToCode.Text,
                    lblToCity.Text,
                    numberOfPassengers,
                    DateTime.Parse(lblDepartureDate.Text),
                    DateTime.Parse(lblReturnDate.Text)
                );

                passengerContactInfo.SetupPassengerDetails(numberOfPassengers);

                // Update passenger numbers in ucPassengerDetails instances within ucPassengerContactInfo
                int passengerIndex = 1;
                foreach (ucPassengerDetails passengerControl in passengerContactInfo.pnlPassengerControlInfo.Controls.OfType<ucPassengerDetails>())
                {
                    // Find lblPassengerNo and set its Text property
                    var lblPassengerNo = passengerControl.Controls.OfType<Label>()
                        .FirstOrDefault(lbl => lbl.Name == "lblPassengerNo");

                    if (lblPassengerNo != null)
                    {
                        lblPassengerNo.Text = passengerIndex.ToString(); // Directly set Text property
                    }

                    passengerIndex++;
                }

                this.Visible = false;
                passengerContactInfo.Visible = true;
                passengerContactInfo.BringToFront();

                this.SendToBack();
            }
        }
    }
}
