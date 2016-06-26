#define MOVE 2
#define READ 3
#define ALL 4

class Stepper {
  public:
    int pin;
    void moveUp(int duration) {

    }
    void moveDown(int duration) {

    }
};

class StepperController {
  public:
    char buff[5] = { 0 };
    void wait() {
      char c = Serial.read();
      int i = 0;
      for (i = 0; i < 4; i++) {
        buff[i + 1] = buff[i];
      }
      buff[0] = c;
      if (buff[0] == 200 && buff[4] == 200)
        resolve(buff);
    }

    void resolve(char* data) {
      switch (data[1]) {
        case SET: definePin(data[2], data[3]); break;
        case MOVE: moveStepper(data[2], data[3]); break;
        case READ: readPin(data[2]); break;
      }
    }

    void readPin(char pin) {
      Serial.println("reading pin");
    }
    void definePin(char pin, char ptype) {
      pinMode(pin, ptype);
      Serial.println("Defining pin");
    }

    void moveStepper(char pin, char duration) {

    }
};
