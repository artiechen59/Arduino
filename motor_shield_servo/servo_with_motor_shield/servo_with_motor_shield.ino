// Adafruit Motor shield library
// copyright Adafruit Industries LLC, 2009
// this code is public domain, enjoy!

#include <AFMotor.h>
#include <Servo.h> 


Servo servo1;


void setup() {
  Serial.begin(9600);           // set up Serial library at 9600 bps
  Serial.println("Motor party!");
  
  // turn on servo
  servo1.attach(10);  //servo 1 connector
   

}

int i;

// Test the DC motor, stepper and servo ALL AT ONCE!
void loop() {

  for (i=0; i<255; i++) {
    servo1.write(i);
    delay(10);
 }
 
  for (i=255; i!=0; i--) {
    servo1.write(i);
    delay(10);
 }
 

}
