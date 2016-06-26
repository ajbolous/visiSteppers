using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace visiSteppers
{
    public class Controller
    {

        public SerialPort serial;
        public List<Stepper> steppers = new List<Stepper>();
        public bool isBusy = false;
        public Stepper attachStepper(int pin, int duration, int position, bool enabled)
        {
            Stepper s = new Stepper();
            s.id= pin;
            s.position = 0;
            s.enabled = enabled;
            s.controller = this;
            steppers.Add(s);
            
            return s;
        }
        public bool connect(string port, int baud)
        {
            serial = new SerialPort(port, baud);
            serial.Open();
            serial.DataReceived += Serial_DataReceived;
            serial.DiscardInBuffer();
            serial.DiscardOutBuffer();
            return serial.IsOpen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void sendRequest(MoveRequest r)
        {
            while (isBusy) ;
            isBusy = true;
            sendPacket(r.ToPacket());
        }
        public void disconnect()
        {
            this.serial.Close();
            this.serial.Dispose();
            serial = null;
        }
        public void sendPacket(byte[] packet)
        {
            serial.Write(packet, 0, packet.Length);
        }

        private byte[] buff = new byte[6];
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int buffSize = 3;
            while (serial.BytesToRead > 0)
            {
                byte b = (byte)serial.ReadChar();
                for(int i =0;i < buffSize-1; i++)
                    buff[i] = buff[i + 1];
                buff[buffSize - 1] = b;

                if(buff[0] == 'S' && buff[buffSize - 1] == 'E')
                {
                    Stepper s = steppers[buff[1]];
                    s.ackSteps++;
                    isBusy = false;
                }
            }
        }

        public static string[] getPorts()
        {
            return SerialPort.GetPortNames();
        }

    }

}
