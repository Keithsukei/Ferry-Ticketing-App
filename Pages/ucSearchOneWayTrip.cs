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
    public partial class ucSearchOneWayTrip : UserControl
    {
        private const int DEPCOLLAPSED_HEIGHT = 249;
        private const int DEPEXPANDED_HEIGHT = 673;
        private const int BUTTON_HEIGHT = 71;
        private const int PADDING = 5;
        private const int BUTTON_PADDING = 35;
        private Timer animationTimer;
        private int currentDepartureHeight;
        private int targetDepartureHeight;
        private const int ANIMATION_INTERVAL = 4;
        private const int ANIMATION_STEPS = 5;
        private const int MIN_STEP_SIZE = 12;
        private bool isAnimating = false;

        public ucSearchOneWayTrip()
        {
            InitializeComponent();
            SetupAnimationTimer();
            SetDoubleBuffered(this);
            InitializePanelStates();

            ucIndividualTrips1.TripSelected += UpdateDepartureSummary;
            ucDepartureSummary1.pnlDepDropDownSelected.Visible = false;
            ucDepartureSummary1.pnlDepDropDownNoSelected.Visible = true;
            ucIndividualTrips1.SetSearchOneWayTripReference(this);

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
            btnSummaryContinue.Top = ucDepartureSummary1.Bottom + PADDING;
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
            ucDepartureSummary1.Height = DEPCOLLAPSED_HEIGHT;
            btnSummaryContinue.Height = BUTTON_HEIGHT;

            UpdateControlPositions();
            ResumeLayout(false);
        }
        private void UpdateControlPositions()
        {
            if (!isAnimating) SuspendLayout();

            btnSummaryContinue.Top = ucDepartureSummary1.Bottom + 5;
            pnlSummary.Height = btnSummaryContinue.Bottom + 5;

            if (!isAnimating) ResumeLayout(true);
        }

        private void UpdateDepartureSummary(ucIndividualTrips.TripDetails tripDetails)
        {
            if (animationTimer.Enabled)
            {
                animationTimer.Stop();
                FinishCurrentAnimation();
            }

            ucDepartureSummary1.UpdateDepartureDetails(tripDetails);
            ucDepartureSummary1.pnlDepDropDownSelected.Visible = true;
            ucDepartureSummary1.pnlDepDropDownNoSelected.Visible = false;

            targetDepartureHeight = DEPEXPANDED_HEIGHT;
            StartAnimation();

            lblDepartureDate.Text = tripDetails.DepartureDate.ToString("yyyy-MM-dd");
        }

        private void FinishCurrentAnimation()
        {
            SuspendLayout();

            if (ucDepartureSummary1 != null)
                ucDepartureSummary1.Height = targetDepartureHeight;

            currentDepartureHeight = targetDepartureHeight;

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

            UpdatePanelSizes();

            ResumeLayout(true);
            isAnimating = false;

            if (isDepartureComplete)
            {
                animationTimer.Stop();
                FinishCurrentAnimation();
            }
        }

        private bool AnimatePanel(ref int currentHeight, int targetHeight, UserControl panel)
        {
            if (currentHeight == targetHeight) return true;

            int totalDistance = Math.Abs(targetHeight - currentHeight);
            int step = Math.Max(totalDistance / ANIMATION_STEPS, MIN_STEP_SIZE);

            if (totalDistance <= MIN_STEP_SIZE * 2)
            {
                currentHeight = targetHeight;
                panel.Height = targetHeight;
                return true;
            }

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



        public void UpdateItinerary(string fromCode, string fromCity, string toCode, string toCity, int passengers, DateTime departDate)
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
                        case "lblArrivalDate":
                            label.Text = departDate.AddDays(1).ToString("yyyy-MM-dd");
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
                ucDepartureSummary1.pnlDepDropDownSelected.Visible = false;
                ucDepartureSummary1.pnlDepDropDownNoSelected.Visible = true;
                currentDepartureHeight = DEPCOLLAPSED_HEIGHT;
                ucDepartureSummary1.Height = DEPCOLLAPSED_HEIGHT;
                pnlSummary.Height = DEPCOLLAPSED_HEIGHT + BUTTON_HEIGHT + PADDING;
                UpdatePanelSizes();

                findTrips.BringToFront();
                findTrips.Visible = true;
                this.Visible = false;
            }
        }

        private void btnSummaryContinue_Click(object sender, EventArgs e)
        {
            List<string> placeholderTexts = new List<string> { "No vessel available", "label1", "--:--" };

            if (placeholderTexts.Contains(ucDepartureSummary1.lblDVesselName.Text))
            {
                MessageBox.Show("Please select a departure trip to proceed.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int numberOfPassengers = int.TryParse(lblNoOfPassengers.Text, out int passengers) ? passengers : 1;

            if (string.IsNullOrEmpty(lblDepartureDate.Text) || placeholderTexts.Contains(lblDepartureDate.Text))
            {
                MessageBox.Show("Please ensure departure date is selected.", "Date Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    DateTime.Parse(lblArrivalDate.Text),
                    false
                );

                passengerContactInfo.SetupPassengerDetails(numberOfPassengers);

                int passengerIndex = 1;
                foreach (ucPassengerDetails passengerControl in passengerContactInfo.pnlPassengerControlInfo.Controls.OfType<ucPassengerDetails>())
                {
                    var lblPassengerNo = passengerControl.Controls.OfType<Label>()
                        .FirstOrDefault(lbl => lbl.Name == "lblPassengerNo");

                    if (lblPassengerNo != null)
                    {
                        lblPassengerNo.Text = passengerIndex.ToString();
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
