using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visiSteppers
{
    [Serializable()]
    public class Stepper
    {
        public Controller controller;
        private StepperGui gui;
        public enum Direction { Out = 1, In = 2 };
        public int id;
        public int directionPin;
        public int stepPin;

        public decimal stepSize = 5;
        public decimal stepSpeed = 1;
        public int stepDelay = 1;

        public double absPosition = 0;
        public double levelPosition = 0;
        public double testPosition = 0;
        public double position = 0;

        public double originalPosition = 0;

        public int targetSteps = 0;
        public int ackSteps = 0;

        public Direction direction = 0;
        public bool enabled = false;
        public bool active = false;

        public StepperGui getGui()
        {
            if (gui == null)
            {
                gui = new StepperGui();
                gui.set(this);
            }
            return this.gui;
        }
        public void setProcessing(bool status)
        {
            active = status;
            this.gui.setProcessing(status);
        }

        public void moveIn()
        {
            MoveRequest r = new MoveRequest(this, Direction.In);
            gui.setQueued();
            this.targetSteps = 1;
            this.ackSteps = 0;
            gui.setProcessing(true);
            controller.sendRequest(r);
            while (this.ackSteps < this.targetSteps) ;
            calculatePosition(1);
            this.originalPosition = this.position;
            gui.setProcessing(false);
        }
        public void moveOut()
        {
            MoveRequest r = new MoveRequest(this, Direction.Out);
            gui.setQueued();
            this.targetSteps = 1;
            this.ackSteps = 0;
            gui.setProcessing(true);
            controller.sendRequest(r);
            while (this.ackSteps < this.targetSteps) ;
            calculatePosition(1);
            this.originalPosition = this.position;
            gui.setProcessing(false);
        }
        public void calculatePosition(int sent)
        {
            if (this.direction == Direction.In)
                this.position = this.originalPosition + ackSteps * Config.getConfig().tickSize;

            if (this.direction == Direction.Out)
                this.position = this.originalPosition - ackSteps * Config.getConfig().tickSize;


            gui.updatePosition(sent);
        }

    }
}