#define SIZE 6
#define ENABLE 10

char buff[SIZE] = { 100, 100, 100, 100, 100,100 };
int i = 0;
char c;

void setup() {
  Serial.begin(38400);
  for(i = 0;i<13;i++)
    pinMode(i,OUTPUT);
}

void tickStepper(char directionPin, char stepPin, char direction) {
    digitalWrite(ENABLE,HIGH);
    digitalWrite(directionPin,direction);
    digitalWrite(stepPin,HIGH);
    delayMicroseconds(25);
    digitalWrite(stepPin,LOW);
}
char ackBuff[3] = {'S',0,'E'};

void sendAck(char id){
  ackBuff[1] = id;
    Serial.write(ackBuff,3);
}


void loop() {
  if (Serial.available()) {
    c = Serial.read();
    for (i = 0; i < SIZE - 1; i++) 
      buff[i] = buff[i + 1];
    
    buff[SIZE-1] = c;
    if (buff[0] == 'S' && buff[SIZE-1] == 'E') {
      tickStepper(buff[2],buff[3],buff[4]);
      sendAck(buff[1]);
    }
  }
}

