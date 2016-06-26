using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visiSteppers
{
    public partial class RequestGui : UserControl
    {
        public RequestGui()
        {
            InitializeComponent();
        }

        public RequestGui(Request request)
        {
            InitializeComponent();
            if (request.GetType() == typeof(MoveRequest))
            {
                MoveRequest r = (MoveRequest)request;
                lblMotor.Text = r.stepper.id.ToString() + "," + r.direction ;
                this.Width = 10 + (int)r.stepper.stepSize;
                r.RequestSent += R_RequestSent;
                r.RequestFinished += R_RequestFinished;
            }
        }
        private void R_RequestFinished(Response r)
        {
            this.BackColor = Color.Gray;
        }

        private void R_RequestSent()
        {
            Invoke((MethodInvoker)delegate
            {
                this.BackColor = Color.Chartreuse;
            });
        }
    }
}
