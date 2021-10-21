
#include <WiShield.h>
#include <Wire.h>
#include <PString.h>

#define WIRELESS_MODE_INFRA	1
#define WIRELESS_MODE_ADHOC	2



//AF_DCMotor motor1(1, MOTOR12_1KHZ); // create motor #2, 64KHz pwm
//AF_DCMotor motor2(2, MOTOR12_1KHZ); // create motor #2, 64KHz pwm
//AF_DCMotor motor3(3, MOTOR34_1KHZ); // create motor #2, 64KHz pwm
//AF_DCMotor motor4(4, MOTOR34_1KHZ); // create motor #2, 64KHz pwm

/*
// office Wireless configuration parameters ----------------------------------------
  unsigned char local_ip[] = { 192,168,11,11};   // IP address of WiShield
  unsigned char gateway_ip[] = { 192,168,11,1};   // router or gateway IP address
  unsigned char subnet_mask[] = { 255,255,255,0};   // subnet mask for the local network
  const prog_char ssid[] PROGMEM = { "TERKHH"};      // max 32 bytes
  unsigned char security_type = 1;   // 0 - open; 1 - WEP; 2 - WPA; 3 - WPA2

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
 */
 
  // home Wireless configuration parameters ----------------------------------------
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
char buffer[20],buffer1[20];
PString str(buffer1, sizeof(buffer1));
//---------------------------------------------------------------------------
byte x = 0;
int first_run=0;

void setup()
{

	WiFi.init();
        Wire.begin(); // join i2c bus (address optional for master)
        Serial.begin(9600);
        
        
        
        //str = "Yin"; // assignment
        //str += " Yang"; // concatenation

        
        
 
}

void loop()
{

  
      if(buffer[0] == 'F' || buffer[0] == 'B' || buffer[0] == 'R' || buffer[0] == 'L' || buffer[0] == 'S' || buffer[0] == 'O' || buffer[0] == 'C')
      {
        Wire.beginTransmission(4); // transmit to device #4
        Wire.write(buffer);        // sends five bytes
          
        Wire.endTransmission();    // stop transmitting

       
        //delay(500);
        
        //Serial.println(buffer);
        
        
      }
  /*
  
      if (buffer[0] == 'D') 
      { // Control specific pin
        //Serial.print("Drive ");
        if (buffer[1] == 'F') 
        {

           
          
          
          Wire.beginTransmission(4); // transmit to device #4
          Wire.write("forward");        // sends five bytes
          
          Wire.endTransmission();    // stop transmitting

       
          delay(500);
    
          
          
        } else if (buffer[1] == 'B') 
        {
          Wire.beginTransmission(4); // transmit to device #4
          Wire.write("backward");        // sends five bytes
                      
          Wire.endTransmission();    // stop transmitting

          
          delay(500);
         
        }
        
      }
      else if (buffer[0] == 'T') 
      { // Control specific pin
        //Serial.print("TURN ");
        if (buffer[1] == 'R') 
        {
          Wire.beginTransmission(4); // transmit to device #4
          Wire.write("right");        // sends five bytes
          Wire.write(x);              // sends one byte  
          Wire.endTransmission();    // stop transmitting

          x++;
          delay(500);
        }
        else if (buffer[1] == 'L') 
        {
          Wire.beginTransmission(4); // transmit to device #4
          Wire.write("left");        // sends five bytes
          Wire.write(x);              // sends one byte  
          Wire.endTransmission();    // stop transmitting

          x++;
          delay(500);
        }
      }
      else if (buffer[0] == 'S') 
      {  
          Wire.beginTransmission(4); // transmit to device #4
          Wire.write("stop");        // sends five bytes
          Wire.write(x);              // sends one byte  
          Wire.endTransmission();    // stop transmitting

          x++;
          delay(500);
         
    
        
      }      
*/       
      //buffer[20]=NULL;
      memset(buffer, 0x00, sizeof(buffer)); // Empty buffer
      
      WiFi.run();
  
}









