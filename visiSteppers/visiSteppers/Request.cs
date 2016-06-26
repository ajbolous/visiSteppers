using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visiSteppers
{

    public class MoveRequest : Request
    {
        public Stepper stepper;
        public Stepper.Direction direction;
        public MoveRequest(Stepper stepper, Stepper.Direction direction)
        {
            this.stepper = stepper;
            this.direction = direction;
        }
        public override byte[] ToPacket()
        {
            return Request.encodePacket(stepper.id,stepper.directionPin, stepper.stepPin, (int)direction);
        }
    }

    public abstract class Request
    {
        public delegate void RequestFinishedHandler(Response r);
        public event RequestFinishedHandler RequestFinished;

        public delegate void RequestSentHandler();
        public event RequestSentHandler RequestSent;

        public static byte[] encodePacket(int b1, int b2, int b3, int b4)
        {
            return new byte[] { (byte)'S', (byte)b1, (byte)b2, (byte)b3,(byte)b4, (byte)'E' };
        }
        public abstract byte[] ToPacket();
    }
}
