#include <SPI.h>  
#include "RF24.h"

RF24 myRadio (9, 10);
byte addresses[][6] = {"0"};


char SentString1[100] = "forward";
char SentString2[100] = "backward";
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
}

void loop()
{

  myRadio.write(SentString1, sizeof(SentString1)); 
  delay(1000);

  myRadio.write(SentString2, sizeof(SentString2)); 
  delay(1000);
}
