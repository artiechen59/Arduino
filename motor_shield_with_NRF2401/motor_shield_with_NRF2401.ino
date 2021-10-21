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
int X_Val=512,Y_Val=512,SW_Val=0;
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

}


void loop()  
{


  //Serial.println(X_Val);
  
  if ( myRadio.available()) 
  {
    while (myRadio.available())
    {
      myRadio.read( ReceivedString, sizeof(ReceivedString) );
      
      
    }
    if (ReceivedString[0]=='x')
    {
      for (i=2;i< sizeof(ReceivedString);i++)
      {
        Rcv_X[i-2]=ReceivedString[i];
      }
      X_Val=atoi(Rcv_X);
      
    }
    else if (ReceivedString[0]=='y')
    {
      for (i=2;i< sizeof(ReceivedString);i++)
      {
        Rcv_Y[i-2]=ReceivedString[i];
      }      
      Y_Val=atoi(Rcv_Y);
      
    }
    else if (ReceivedString[0]=='b')
    {
      SW_Val= atoi(ReceivedString[2]);     
      
    }
    else
    {
      
    }
  }

  Serial.println(X_Speed);
  Serial.println(Y_Speed);
  Serial.println(SW_Val);
  
    //========== calculating speed ============
    if ( abs(X_Val-512.0) > 10 )  
    {
      X_factor=abs(X_Val-512.0)/512.0;
    }
    else
    {
      X_factor=0;   //for dead zone
    }
    if ( abs(Y_Val-512.0) > 10 )  
    {
      Y_factor=abs(Y_Val-512.0)/512.0;
    }
    else
    {
      Y_factor=0;   //for dead zone
    }
    X_Speed=X_factor*255;        
    Y_Speed=Y_factor*255;    
    
    if((502< Y_Val)&&( Y_Val < 522) && (502 < X_Val ) && (X_Val < 522) )  //neutral
    {
      motor1.setSpeed(0);
      motor2.setSpeed(0);
      motor3.setSpeed(0);
      motor4.setSpeed(0);      
      motor1.run(BRAKE); 
      motor2.run(BRAKE); 
      motor3.run(BRAKE); 
      motor4.run(BRAKE);      
    }
    else if(( Y_Val > 522) && (502 < X_Val ) && (X_Val < 522) )  //postive Y axis
    {
      motor1.setSpeed(Y_Speed);
      motor2.setSpeed(Y_Speed);
      motor3.setSpeed(Y_Speed);
      motor4.setSpeed(Y_Speed);      
      motor1.run(FORWARD); 
      motor2.run(FORWARD); 
      motor3.run(FORWARD); 
      motor4.run(FORWARD);      
    }
    else if (( Y_Val < 502) && (502 < X_Val ) && (X_Val < 522) )  //negtive Y axis
    {
      motor1.setSpeed(Y_Speed);
      motor2.setSpeed(Y_Speed);
      motor3.setSpeed(Y_Speed);
      motor4.setSpeed(Y_Speed);        
      motor1.run(BACKWARD); 
      motor2.run(BACKWARD); 
      motor3.run(BACKWARD); 
      motor4.run(BACKWARD);
    }
    else if (( X_Val > 522) )  //postive X axis, rotate clockwise
     {
      motor1.setSpeed(X_Speed);
      motor2.setSpeed(X_Speed);
      motor3.setSpeed(X_Speed);
      motor4.setSpeed(X_Speed);        
      motor1.run(BACKWARD); 
      motor2.run(BACKWARD); 
      motor3.run(FORWARD); 
      motor4.run(FORWARD);
    }   
    else if (( X_Val < 502) )  //negative X axis, rotate counter-clockwise
     {
      motor1.setSpeed(X_Speed);
      motor2.setSpeed(X_Speed);
      motor3.setSpeed(X_Speed);
      motor4.setSpeed(X_Speed);        
      motor1.run(FORWARD); 
      motor2.run(FORWARD); 
      motor3.run(BACKWARD); 
      motor4.run(BACKWARD);
    }       

   
    //delay(100);
 

/*
  if (strcmp(ReceivedString,"release")==0)
  {  
    //Serial.print("tack");
    motor1.run(RELEASE);      // stopped
    motor2.run(RELEASE);      // stopped
    motor3.run(RELEASE);      // stopped
    motor4.run(RELEASE);      // stopped  
    //delay(2000);
  }
 */

}
