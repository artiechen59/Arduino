/*
* A simple sketch that uses WiServer to serve a web page !! that kim messed with.
*/


#include <WiServer.h>
#include <string.h>

#define WIRELESS_MODE_INFRA   1
#define WIRELESS_MODE_ADHOC   2

#define ledPin1 5
#define ledPin2 6
#define ledPin3 7

// Wireless configuration parameters ----------------------------------------
unsigned char local_ip[] = { 192,168,2,22};   // IP address of WiShield
unsigned char gateway_ip[] = { 192,168,2,1};   // router or gateway IP address
unsigned char subnet_mask[] = { 255,255,255,0};   // subnet mask for the local network
const prog_char ssid[] PROGMEM = { "default"};      // max 32 bytes
unsigned char security_type = 0;   // 0 - open; 1 - WEP; 2 - WPA; 3 - WPA2

// WPA/WPA2 passphrase
const prog_char security_passphrase[] PROGMEM = { "12345678"};   // max 64 characters

// WEP 64-bit keys
// sample HEX keys
prog_uchar wep_keys[] PROGMEM = { 
  0x12, 0x34, 0x56, 0x78, 0x90, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,   // Key 0
  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,   // Key 1
  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,   // Key 2
  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00   // Key 3
};

// setup the wireless mode
// infrastructure - connect to AP
// adhoc - connect to another WiFi device
unsigned char wireless_mode = WIRELESS_MODE_INFRA;

unsigned char ssid_len;
unsigned char security_passphrase_len;

// End of wireless configuration parameters ----------------------------------------

boolean states[3]; //holds led states
char stateCounter; //used as a temporary variable
char tmpStrCat[64]; //used in processing the web page
char stateBuff[4]; //used in text processing around boolToString()
char numAsCharBuff[2];
char ledChange;

void boolToString (boolean test, char returnBuffer[4])
{
  returnBuffer[0] = '\0';
  if (test)
  {
    strcat(returnBuffer, "On");
  }
  else
  {
    strcat(returnBuffer, "Off");
  }
}

void printStates()
{
        for (stateCounter = 0 ; stateCounter < 3; stateCounter++)
        {
            boolToString(states[stateCounter], stateBuff);
           
            Serial.print("State of ");
            Serial.print(stateCounter);
            Serial.print(": ");
            Serial.println(stateBuff);
        } 
}

void writeStates()
{
        //set led states
        digitalWrite(ledPin1, states[0]);
        digitalWrite(ledPin2, states[1]);
        digitalWrite(ledPin3, states[2]);
}

// This is our page serving function that generates web pages
boolean sendPage(char* URL) {
  
  //Serial.println("Page printing begun");
  //Serial.println(URL);
  
 

  WiServer.print("<html><head><title>Artie's Robot</title></head>");
  WiServer.print("<body>Controlling the robot <form method=GET><input type=submit name=DIR value=UP>");
  WiServer.print("</form><form method=GET><input type=submit name=DIR value=LEFT>");
  WiServer.print("<input type=submit name=DIR value=RIGHT></form>");
  WiServer.print("<form method=GET><input type=submit name=DIR value=DOWN></form>");
  WiServer.print("<form method=GET><input type=submit name=DIR value=STOP></form>");
  WiServer.print("<hr>");
  
  if (URL[1] == '?' && URL[2] == 'D' && URL[3] == 'I' && URL[4] == 'R') //url has a leading /
  {
    //clearSenderArray();
    // Serial.println(URL[6]);
    switch(URL[6]) 
    {
      case 'U':
                Serial.println("UP");
                WiServer.print("<p>UP</p>");
                break;
      case 'L':
                Serial.println("LEFT");
                WiServer.print("<p>LEFT</p>");               
                break;
      case 'R':
                Serial.println("RIGHT");
                WiServer.print("<p>RIGHT</p>");                
                break;
      case 'D':
                Serial.println("DOWN");
                WiServer.print("<p>DOWN</p>");               
                break;
      case 'S':
                Serial.println("STOP");
                WiServer.print("<p>STOP</p>");                
                break;
    }
 
    
  } 
  
  WiServer.print("</body>");
  WiServer.print("</html> ");
 
  return true;
}

void setup() {
  // Initialize WiServer and have it use the sendMyPage function to serve pages
  pinMode(ledPin1, OUTPUT);
  pinMode(ledPin2, OUTPUT);
  pinMode(ledPin3, OUTPUT);

  Serial.begin(9600);
  WiServer.init(sendPage);
  states[0] = false;
  states[1] = false;
  states[2] = false;
}

void loop(){
  // Run WiServer
  WiServer.server_task();

  delay(10);
}
