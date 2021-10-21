
/* 
 Stepper Motor Control - one revolution
 
 This program drives a unipolar or bipolar stepper motor. 
 The motor is attached to digital pins 8 - 11 of the Arduino.
 
 The motor should revolve one revolution in one direction, then
 one revolution in the other direction.  
 
  
 Created 11 Mar. 2007
 Modified 30 Nov. 2009
 by Tom Igoe
 
 */

#include <Stepper.h>

const int stepsPerRevolution = 20;  // change this to fit the number of steps per revolution
                                     // for your motor

int val=0;

// initialize the stepper library on pins 8 through 11:
Stepper myStepper(stepsPerRevolution, 4,5,6,7);            

void setup() {
  // set the speed at 60 rpm:
  myStepper.setSpeed(600);
  // initialize the serial port:
  Serial.begin(9600);
  
  //go back to home position
  do
  {
    //delay(50);          // wait for sensors to stabilize
    val=analogRead(0);
    myStepper.step(1);
    Serial.println(val);    
  } while (val < 1020);  //limit switch not touched

  
  
  
  
  

}

void loop() {
  // step one revolution  in one direction:
   Serial.println("clockwise");
  myStepper.step(stepsPerRevolution*3);
  delay(500);
  
   // step one revolution in the other direction:
  Serial.println("counterclockwise");
  myStepper.step(-stepsPerRevolution*3);
  delay(500); 
}

