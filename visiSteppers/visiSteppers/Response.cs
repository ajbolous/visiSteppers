using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visiSteppers
{
    public class Response
    {
        public byte[] packet;
        public Stepper reciever;
        private string message;
        public Response()
        {

        }

        public Response(string msg)
        {
            message = msg;
        }
        public static Response fromPacket(Stepper reciever, byte[] packet)
        {
            Response r = new Response();
            r.packet = packet;
            r.reciever = reciever;
            return r;
        }
    }
}
