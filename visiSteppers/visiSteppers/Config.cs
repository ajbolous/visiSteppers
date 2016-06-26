using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visiSteppers
{
    [Serializable()]
    public class Config
    {
        public bool testMode = false;
        public double tickSize = 0.02;
        public int[] stepPins = { 2, 3, 4, 5, 6, 7 };
        public int[] directionPins = { 8, 9, 10, 11, 12, 13 };
        public double[] stepSizes = { 1, 1, 1, 1, 1, 1 };
        public double[] stepSpeeds = { 1, 1, 1, 1, 1, 1 };
        public int[] stepDelay = { 0, 0, 0, 0, 0, 0 };
        public double[] absolutePositions = { 0, 0, 0, 0, 0, 0 };
        public double[] levelPositions = { 0, 0, 0, 0, 0, 0 };
        public double[] currentPositions = { 0, 0, 0, 0, 0, 0 };
        public double[] testPositions = { 0, 0, 0, 0, 0, 0 };
        private static Config instance = null;
        private Config()
        {

        }

        public static Config getConfig()
        {
            if (instance == null)
            {
                instance = loadConfig();
                if (instance == null)
                    instance = new  Config();
            }
            return instance;
        }
        public static Config loadConfig()
        {

            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Config));
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"Config.xml");
                Config conf = (Config)reader.Deserialize(file);
                file.Close();
                return conf;
            }
            catch { return null; }
        }
        public static void saveConfig(Controller control)
        {
            foreach(Stepper s in control.steppers)
            {
                instance.currentPositions[s.id] = s.originalPosition;
                instance.absolutePositions[s.id] = s.absPosition;
                instance.levelPositions[s.id] = s.levelPosition;
                instance.testPositions[s.id] = s.testPosition;

                instance.stepSizes[s.id] = (double)s.stepSize;
                instance.stepSpeeds[s.id] = (double)s.stepSpeed;
                instance.stepDelay[s.id] = s.stepDelay;

                instance.stepPins[s.id] = s.stepPin;
                instance.directionPins[s.id] = s.directionPin;
            }
            System.Xml.Serialization.XmlSerializer writer =
              new System.Xml.Serialization.XmlSerializer(typeof(Config));

            var path = "Config.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, instance);
            file.Close();
        }
    }
}
