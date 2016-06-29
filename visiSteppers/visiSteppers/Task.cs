using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace visiSteppers
{   public  class Task
    {
        public Stepper stepper;
        public Stepper.Direction direction;
        public Controller controller; 
        public int loadFactor = 1;
        private bool killTask = false;
        public Task(Controller c, Stepper stepper, Stepper.Direction direction, int loadFactor)
        {
            this.stepper = stepper;
            this.direction = direction;
            this.controller = c;
            this.stepper.direction = direction;
            this.loadFactor = loadFactor;
        }
        public void startTask()
        {
            killTask = false;
            stepper.ackSteps = 0;

            stepper.targetSteps = (int)(stepper.stepSize / (decimal)Config.getConfig().tickSize);
            int stepSpeed = (int)(1000/(stepper.targetSteps/(stepper.stepSize/stepper.stepSpeed)));
            stepper.calculatePosition(0);

            Thread.Sleep(stepper.stepDelay);

            MoveRequest r = new MoveRequest(stepper, direction);
            int sentSteps = 0;
            int i = 0;
            while (!killTask && sentSteps < stepper.targetSteps)
            {
                Thread.Sleep(stepSpeed);
                controller.sendRequest(r);
                sentSteps++;
                if ((i++)%loadFactor == 0)
                    stepper.calculatePosition(sentSteps);
            }
            while (!killTask && stepper.ackSteps < stepper.targetSteps)
                stepper.calculatePosition(sentSteps);

            stepper.calculatePosition(sentSteps);
            stepper.originalPosition = stepper.position;
        }

        public void stopTask()
        {
            killTask = true;
        }
    }
}
