using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace visiSteppers
{
    public class Job
    {
        public List<Task> tasks = new List<Task>();
        public Controller controller;
        public Stepper.Direction direction = Stepper.Direction.In;
        public List<Thread> threads = new List<Thread>();

        public Job(Controller controller, Stepper.Direction direction) { 
            this.controller = controller;
            this.direction = direction;
            int load = 0;
            foreach (Stepper s in controller.steppers)
                if (s.enabled)
                    load++;
            foreach (Stepper s in controller.steppers)
            {
                if(s.enabled)
                    tasks.Add(new Task(controller, s, this.direction,load));
            }
        }
        public void startJob()
        {
            foreach (Task t in tasks)
            {
                Thread thread = new Thread(t.startTask);
                this.threads.Add(thread);
                thread.Start();
            }
        }

        public void stopJob() {
            foreach(Task t in tasks)
            {
                t.stopTask();
            }
            foreach(Thread t in threads)
            {
                t.Abort();
            }
        }

    }
}
