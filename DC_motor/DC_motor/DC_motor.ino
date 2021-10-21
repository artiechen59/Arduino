#include <AFMotor.h>

AF_DCMotor motor1(1, MOTOR12_1KHZ); // create motor #2, 64KHz pwm
AF_DCMotor motor2(2, MOTOR12_1KHZ); // create motor #2, 64KHz pwm
AF_DCMotor motor3(3, MOTOR34_1KHZ); // create motor #2, 64KHz pwm
AF_DCMotor motor4(4, MOTOR34_1KHZ); // create motor #2, 64KHz pwm

void setup() {
  Serial.begin(9600);           // set up Serial library at 9600 bps
  Serial.println("Motor test!");
  
  motor1.setSpeed(200);     // set the speed to 200/255
  motor2.setSpeed(200);     // set the speed to 200/255
  motor3.setSpeed(200);     // set the speed to 200/255
  motor4.setSpeed(200);     // set the speed to 200/255  
}

void loop() {
  //Serial.print("tick");
  
  motor1.run(FORWARD);      // turn it on going forward
  motor2.run(FORWARD);      // turn it on going forward
  motor3.run(FORWARD);      // turn it on going forward
  motor4.run(FORWARD);      // turn it on going forward  
  delay(5000);

  //Serial.print("tock");
  motor1.run(BACKWARD);     // the other way
  motor2.run(BACKWARD);     // the other way
  motor3.run(BACKWARD);     // the other way
  motor4.run(BACKWARD);     // the other way  
  delay(5000);
  
  //Serial.print("tack");
  motor1.run(RELEASE);      // stopped
  motor2.run(RELEASE);      // stopped
  motor3.run(RELEASE);      // stopped
  motor4.run(RELEASE);      // stopped  
  delay(2000);
}

