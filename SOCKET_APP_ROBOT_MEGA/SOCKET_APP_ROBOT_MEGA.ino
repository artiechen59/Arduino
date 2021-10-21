
#include <Wire.h>
#include <AFMotor.h>

AF_DCMotor motor1(1, MOTOR12_1KHZ); // create motor #2, 64KHz pwm
AF_DCMotor motor2(2, MOTOR12_1KHZ); // create motor #2, 64KHz pwm
AF_DCMotor motor3(3, MOTOR34_1KHZ); // create motor #2, 64KHz pwm
AF_DCMotor motor4(4, MOTOR34_1KHZ); // create motor #2, 64KHz pwm

char command[20];


void setup()
{
  Wire.begin(4);                // join i2c bus with address #4
  Wire.onReceive(receiveEvent); // register event
  Serial.begin(9600);           // start serial for output
  
  motor1.setSpeed(255); 
  motor2.setSpeed(255);
  motor3.setSpeed(255);
  motor4.setSpeed(255);  
  
  
  
}

void loop()
{
  delay(100);
}

// function that executes whenever data is received from master
// this function is registered as an event, see setup()
void receiveEvent(int howMany)
{
  int i=0,servo_speed=0,motor_speed=0,cmd_length;
  char Servo_Speed[3];
  while(0 < Wire.available()) // loop through all but the last
  {
    char c = Wire.read(); // receive byte as a character
    command[i]=c;
    i++;
    //Serial.print(buffer);
  }
  
  //Serial.println("\n");
  Serial.println(command);
  
  if( command[0] == 'F')
  {
      motor1.run(ALLFORWARD);
  }
  else if ( command[0] == 'B')
  {
     motor1.run(ALLBACKWARD);
                   
  }  
  else if ( command[0] == 'R')
  {
     motor1.run(RIGHT);
                   
  }
  else if ( command[0] == 'L')
  {
     motor1.run(LEFT);
                   
  } 
  else if ( command[0] == 'S')
  {
     motor1.run(RELEASE);
     motor2.run(RELEASE);
     motor3.run(RELEASE);
     motor4.run(RELEASE);     
  }  
  else if ( command[0] == 'O') //Servo
  {
    cmd_length=strlen(command);
    for(i=0;i<cmd_length;i++)
      Servo_Speed[i]=command[i+2];
    servo_speed=atoi(Servo_Speed);      
    Serial.println(servo_speed);
  } 
   else if ( command[0] == 'C') //other commands
  {
    
  }  
}
