using System;
using System.Drawing;
using System.Windows.Forms;

namespace visiSteppers
{
    public partial class StepperGui : UserControl
    {
        Stepper stepper;
        public StepperGui()
        {
            InitializeComponent();
        }

        public void set(Stepper s)
        {
            stepper = s;
        }
     
        public void updateAll()
        {
            numStep.Value = stepper.stepSize;
            numSpeed.Value = stepper.stepSpeed;
            numDelay.Value = stepper.stepDelay;

            txtTag.Text = stepper.id.ToString();
            chkEnabled.Checked = stepper.enabled;
            grpSettings.Enabled = stepper.enabled;
            txtTag.BackColor = (stepper.active ? Color.Red : this.BackColor);

            numStep.Enabled = !Config.getConfig().testMode;
            numSpeed.Enabled = !Config.getConfig().testMode;
            numDelay.Enabled = !Config.getConfig().testMode;

            btnUp.Enabled = !Config.getConfig().testMode;
            btnDown.Enabled = !Config.getConfig().testMode;

            updatePosition(0);
        }

        public void setProcessing(bool status)
        {
            if (status == stepper.active)
                return;

            stepper.active = status;
            this.Invoke((MethodInvoker)delegate
            {
                txtTag.BackColor = (status == true ? Color.Red : this.BackColor);
            });
        }
        public void setQueued()
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtTag.BackColor = Color.DeepSkyBlue;
            });
        }
        public void updatePosition(int sent)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if(stepper.targetSteps != 0)
                    this.progressBar1.Value = (int)(100*(double)stepper.ackSteps / stepper.targetSteps);
             //   this.progressBar1.Visible = (stepper.ackSteps != stepper.targetSteps);
                stepsCounter.Text = stepper.ackSteps + "/" + sent + "/" + stepper.targetSteps + " [Step]";
                lblAbsPos.Text = "Absolute: " + (stepper.absPosition > 0 ? "+" : "")+ Math.Round(stepper.absPosition, 2).ToString() + " [mm]";
                lblLevelPos.Text = "Leveling: " +(stepper.levelPosition>0 ? "+" : "") + Math.Round(stepper.levelPosition, 2).ToString() + " [mm]";
                lblTestPos.Text = "Test start: " + (stepper.testPosition > 0 ? "+" : "")  + Math.Round(stepper.testPosition, 2).ToString() + " [mm]";
                lblCurrentPosition.Text = "Position: " + (stepper.position > 0 ? "+" : "")  + Math.Round(stepper.position, 2).ToString() + " [mm]";

                lblAbsPos.ForeColor =(stepper.absPosition >= 0 ? Color.SeaGreen : Color.DarkRed);
                lblLevelPos.ForeColor = (stepper.levelPosition >= 0 ? Color.SeaGreen : Color.DarkRed);
                lblTestPos.ForeColor = (stepper.testPosition >= 0 ? Color.SeaGreen : Color.DarkRed);
                lblCurrentPosition.ForeColor = (stepper.position >= 0 ? Color.SeaGreen : Color.DarkRed);

                double totalPos = stepper.absPosition + stepper.levelPosition + stepper.testPosition + stepper.position;
                lblTotal.Text = "Total: " + (totalPos > 0 ? "+" : "") + Math.Round(totalPos,2).ToString();
                lblTotal.ForeColor = (totalPos > 0 ? Color.SeaGreen : Color.DarkRed);
            });
        }
        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            stepper.enabled = chkEnabled.Checked;
            grpSettings.Enabled = stepper.enabled;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            stepper.moveOut();


        }
        private void numDuration_ValueChanged(object sender, EventArgs e)
        {
            stepper.stepSize = numStep.Value;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            stepper.moveIn();
        }

        private void StepperGui_Load(object sender, EventArgs e)
        {
            updateAll();
        }

        private void numSpeed_ValueChanged(object sender, EventArgs e)
        {
            stepper.stepSpeed = numSpeed.Value;
        }

        private void numDelay_ValueChanged(object sender, EventArgs e)
        {
            stepper.stepDelay = (int)numDelay.Value;
        }
    }
}
