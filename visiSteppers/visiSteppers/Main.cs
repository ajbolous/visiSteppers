using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visiSteppers
{
    public partial class Main : Form
    {
        Controller control = new Controller();
        public Main()
        {
            InitializeComponent();
            cmbMode.SelectedIndex = 0;
            
            foreach(string port in Controller.getPorts())
                cmbPorts.Items.Add(port);

            for (int i = 0; i < 6; i++)
            {
                Stepper s = control.attachStepper(i, 2, 1, true);
                s.direction = Stepper.Direction.In;
                s.directionPin = Config.getConfig().directionPins[i];
                s.stepPin = Config.getConfig().stepPins[i];

                s.stepSize = (decimal)Config.getConfig().stepSizes[i];
                s.stepSpeed = (decimal)Config.getConfig().stepSpeeds[i];
                s.stepDelay = Config.getConfig().stepDelay[i];

                s.directionPin = Config.getConfig().directionPins[i];
                s.directionPin = Config.getConfig().directionPins[i];

                s.absPosition = Config.getConfig().absolutePositions[i];
                s.levelPosition = Config.getConfig().levelPositions[i];
                s.position = Config.getConfig().currentPositions[i];
                s.testPosition = Config.getConfig().testPositions[i];
                s.originalPosition = Config.getConfig().currentPositions[i];

                flowLayoutPanel1.Controls.Add(s.getGui());
                s.getGui().Show();
            }
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
            control.connect((string)cmbPorts.SelectedItem, 9600);
            flowLayoutPanel1.Enabled = true;
        }

   
        private void btnEnableAll_Click(object sender, EventArgs e)
        {
            foreach(Stepper s in control.steppers) {
                s.enabled = true;
                s.getGui().updateAll();
            }
        }

        private void btnDisableAll_Click(object sender, EventArgs e)
        {
            foreach (Stepper s in control.steppers)
            {
                s.enabled = false;
                s.getGui().updateAll();
            }
        }

        private void btnSetAll_Click(object sender, EventArgs e)
        {
            foreach (Stepper s in control.steppers)
            {
                s.stepSize = numStepSize.Value;
                s.stepSpeed = numStepSpeed.Value;
                s.getGui().updateAll();
            }
        }

        private void notifyAll()
        {
            foreach (Stepper s in control.steppers)
            {
                s.getGui().updateAll();
            }
        }
        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.getConfig().testMode = (cmbMode.SelectedItem.ToString() == "Test");
            notifyAll();
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            control.connect(cmbPorts.SelectedItem.ToString(), 38400);
            grpControls.Enabled = true;
            flowLayoutPanel1.Enabled = true;

        }
        public Job job;
        private void btnStepIn_Click(object sender, EventArgs e)
        {
            if(job!=null)
                job.stopJob();
            job = new Job(this.control, Stepper.Direction.In);
            job.startJob();
        }
   
  
        private void button6_Click(object sender, EventArgs e)
        {
            if (job != null)
                job.stopJob();
            job = new Job(this.control, Stepper.Direction.Out);
            job.startJob();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(job!=null)
                job.stopJob();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.saveConfig(control);
        }

        private void btnAbsAll_Click(object sender, EventArgs e)
        {
            foreach (Stepper s in control.steppers)
            {
                s.position = 0;
                s.absPosition = 0;
                s.originalPosition = 0;
                s.testPosition = 0;
                s.levelPosition = 0;
                s.getGui().updateAll();
            }
        }

        private void btnLevelAll_Click(object sender, EventArgs e)
        {
            foreach (Stepper s in control.steppers)
            {
                s.levelPosition = s.testPosition + s.levelPosition + s.position;
                s.position = 0;
                s.originalPosition = 0;     
                s.testPosition = 0;

                s.getGui().updateAll();
            }
        }

        private void btnSetTestAll_Click(object sender, EventArgs e)
        {
            foreach (Stepper s in control.steppers)
            {
                s.testPosition = s.testPosition + s.position;
                s.position = 0;
                s.originalPosition = 0;

                s.getGui().updateAll();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach(Stepper s in control.steppers)
            {
                double stepSize = s.position + s.testPosition + s.levelPosition;
                if (stepSize <= 0)
                    return;
                s.stepSize = (decimal)stepSize;
                s.stepSpeed = (decimal)stepSize / 5;
                s.getGui().updateAll();
            }
            job = new Job(this.control, Stepper.Direction.Out);
            job.startJob();
        }
    }
}
