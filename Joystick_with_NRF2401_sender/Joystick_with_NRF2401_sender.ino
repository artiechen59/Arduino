#include <SPI.h>  
#include "RF24.h"

// Arduino pin numbers, joystick
const int SW_pin = 2; // digital pin connected to switch output
const int X_pin = 0; // analog pin connected to X output
const int Y_pin = 1; // analog pin connected to Y output
int X_Val,Y_Val,SW_Val;

RF24 myRadio (9, 10);
byte addresses[][6] = {"0"};



char SentString1[100] = "forward";
char SentString2[100] = "backward";
String sentstr;
void setup()
{
  Serial.begin(115200);
  delay(1000);
  myRadio.begin();  
  myRadio.setChannel(115); 
  myRadio.setPALevel(RF24_PA_MAX);
  myRadio.setDataRate( RF24_250KBPS ) ; 
  myRadio.openWritingPipe( addresses[0]);
  delay(1000);

  pinMode(SW_pin, INPUT);
  digitalWrite(SW_pin, HIGH);
  
}

void loop()
{
  //String tmp = "cat";
  //char tab2[1024];




  SW_Val=digitalRead(SW_pin);
  X_Val=analogRead(X_pin);
  Y_Val=analogRead(Y_pin);

 
  //================ sending data
  
  strcpy(SentString1, "x=");
  sentstr=String(X_Val);
  strcat(SentString1, sentstr.c_str());
  
  myRadio.write(SentString1, sizeof(SentString1)); 
  delay(50);
  //------------------------------------
  strcpy(SentString1, "y=");
  sentstr=String(Y_Val);
  strcat(SentString1, sentstr.c_str());
  
  myRadio.write(SentString1, sizeof(SentString1)); 
  delay(50);
  //------------------------------------
  strcpy(SentString1, "b=");
  sentstr=String(SW_Val);
  strcat(SentString1, sentstr.c_str());
  
  myRadio.write(SentString1, sizeof(SentString1));   
  delay(50);
}
