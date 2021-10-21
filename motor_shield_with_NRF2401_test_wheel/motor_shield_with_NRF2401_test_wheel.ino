#include <SPI.h>  
#include "RF24.h" 
#include <AFMotor.h>

AF_DCMotor motor1(1, MOTOR12_1KHZ); // create motor #2, 64KHz pwm
AF_DCMotor motor2(2, MOTOR12_1KHZ); // create motor #2, 64KHz pwm
AF_DCMotor motor3(3, MOTOR34_1KHZ); // create motor #2, 64KHz pwm
AF_DCMotor motor4(4, MOTOR34_1KHZ); // create motor #2, 64KHz pwm

RF24 myRadio (48, 49); 


byte addresses[][6] = {"0"}; 

char ReceivedString[100];
int i;
int X_Val=512,Y_Val=512,SW_Val;
char Rcv_X[4],Rcv_Y[4];
int X_Speed,Y_Speed;
double X_factor,Y_factor;

void setup() 
{
  Serial.begin(115200);
  delay(1000);

  myRadio.begin(); 
  myRadio.setChannel(115); 
  myRadio.setPALevel(RF24_PA_LOW);
  myRadio.setDataRate( RF24_250KBPS ) ; 
  myRadio.openReadingPipe(1, addresses[0]);
  myRadio.startListening();

  motor1.setSpeed(200);     // set the speed to 200/255
  motor2.setSpeed(200);     // set the speed to 200/255
  motor3.setSpeed(200);     // set the speed to 200/255
  motor4.setSpeed(200);     // set the speed to 200/255  
}


void loop()  
{



      motor1.run(BACKWARD); 
      delay(2000);
      motor2.run(BACKWARD); 
      delay(2000);
      motor3.run(BACKWARD); 
      delay(2000);
      motor4.run(BACKWARD);
      delay(2000);  
 
 }


