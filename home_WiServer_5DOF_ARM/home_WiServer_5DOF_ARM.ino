/*
* A simple sketch that uses WiServer to serve a web page !! that kim messed with.
*/


#include <WiServer.h>
#include <string.h>
#include <Stepper.h>
#include <Servo.h> 
 

#define WIRELESS_MODE_INFRA   1
#define WIRELESS_MODE_ADHOC   2

Servo myservo1;  // create servo object to control a servo 
Servo myservo2;  // create servo object to control a servo 
Servo myservo3;  // create servo object to control a servo 
Servo myservo4;  // create servo object to control a servo 
Servo myservo5;  // create servo object to control a servo 

// Wireless configuration parameters ----------------------------------------
unsigned char local_ip[] = { 192,168,2,22};   // IP address of WiShield
unsigned char gateway_ip[] = { 192,168,2,1};   // router or gateway IP address
unsigned char subnet_mask[] = { 255,255,255,0};   // subnet mask for the local network
const prog_char ssid[] PROGMEM = { "default"};      // max 32 bytes
unsigned char security_type = 0;   // 0 - open; 1 - WEP; 2 - WPA; 3 - WPA2

// WPA/WPA2 passphrase
const prog_char security_passphrase[] PROGMEM = { "1234567890"};   // max 64 characters

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
int S1_value;
int S2_value;
int S3_value;
int S4_value;
int S5_value;
int S1_Hlim;
int S1_Llim;
int S2_Hlim;
int S2_Llim;
int S3_Hlim;
int S3_Llim;
int S4_Hlim;
int S4_Llim;
int S5_Hlim;
int S5_Llim;
// End of wireless configuration parameters ----------------------------------------



//=======stepper motor







// This is our page serving function that generates web pages
boolean sendPage(char* URL) {
  
  //Serial.println("Page printing begun");
  //Serial.println(URL);
  
   if (strcmp(URL, "/") == 0) 
   {

    WiServer.print("<html><font size=7>");
    //WiServer.print("<body>Controlling the robot ");    
    WiServer.print("<p>S1</p><a href=?S1I10>+10</a>&nbsp;&nbsp;<a href=?S1I2>+2</a>&nbsp;&nbsp;<a href=?S1D10>-10</a>&nbsp;&nbsp;<a href=?S1D2>-2</a>");  
    WiServer.print("<p>S2</p><a href=?S2I10>+10</a>&nbsp;&nbsp;<a href=?S2I2>+2</a>&nbsp;&nbsp;<a href=?S2D10>-10</a>&nbsp;&nbsp;<a href=?S2D2>-2</a>");
    WiServer.print("<p>S3</p><a href=?S3I10>+10</a>&nbsp;&nbsp;<a href=?S3I2>+2</a>&nbsp;&nbsp;<a href=?S3D10>-10</a>&nbsp;&nbsp;<a href=?S3D2>-2</a>");
    WiServer.print("<p>S4</p><a href=?S4I10>+10</a>&nbsp;&nbsp;<a href=?S4I2>+2</a>&nbsp;&nbsp;<a href=?S4D10>-10</a>&nbsp;&nbsp;<a href=?S4D2>-2</a>");
    WiServer.print("<p>S5</p><a href=?S5I10>+10</a>&nbsp;&nbsp;<a href=?S5I2>+2</a>&nbsp;&nbsp;<a href=?S5D10>-10</a>&nbsp;&nbsp;<a href=?S5D2>-2</a>");
    WiServer.print("<p></p><a href=?F>F</a><a href=?L>L</a><a href=?R>R</a><a href=?B>B</a></font>");
 


   }
   else
   {
  
     switch(URL[3])
     {
       case '1':
             switch(URL[4])
             {
                case 'I':
                     switch(URL[5])
                     {
                         case '1':
                             S1_value=S1_value+10;
                             
                             break;
                         case '2':
                             S1_value=S1_value+2;
                             break;                
                     }
                     if ( S1_value >= S1_Hlim ) S1_value=S1_Hlim;     
                     break; 
               case 'D':
                     switch(URL[5])
                     {
                         case '1':
                             S1_value=S1_value-10;
                             break;
                         case '2':
                             S1_value=S1_value-2;
                             break;                        
                     }
                     if ( S1_value <= S1_Llim ) S1_value=S1_Llim;      
                     break;                      
             }
             break;
       case '2':
             switch(URL[4])
             {
                case 'I':
                     switch(URL[5])
                     {
                         case '1':
                             S2_value=S2_value+10;
                             break;
                         case '2':
                             S2_value=S2_value+2;
                             break;                             
                     }
                     if ( S2_value >= S2_Hlim ) S2_value=S2_Hlim;  
                     break; 
               case 'D':
                     switch(URL[5])
                     {
                         case '1':
                             S2_value=S2_value-10;
                             break;
                         case '2':
                             S2_value=S2_value-2;
                             break;                             
                     }
                     if ( S2_value <= S2_Llim ) S2_value=S2_Llim;  
                     break;                      
             }
             break;   
          case '3':
             switch(URL[4])
             {
                case 'I':
                     switch(URL[5])
                     {
                         case '1':
                             S3_value=S3_value+10;
                             break;
                         case '2':
                             S3_value=S3_value+2;
                             break;                             
                     }
                     if ( S3_value >= S3_Hlim ) S3_value=S3_Hlim; 
                     break; 
               case 'D':
                     switch(URL[5])
                     {
                         case '1':
                             S3_value=S3_value-10;
                             break;
                         case '2':
                             S3_value=S3_value-2;
                             break;                             
                     }
                     if ( S3_value <= S3_Llim ) S3_value=S3_Llim; 
                     break;                      
             }
             break;     
       case '4':
             switch(URL[4])
             {
                case 'I':
                     switch(URL[5])
                     {
                         case '1':
                             S4_value=S4_value+10;
                             break;
                         case '2':
                             S4_value=S4_value+2;
                             break;                             
                     }
                     if ( S4_value >= S4_Hlim ) S4_value=S4_Hlim; 
                     break; 
               case 'D':
                     switch(URL[5])
                     {
                         case '1':
                             S4_value=S4_value-10;
                             break;
                         case '2':
                             S4_value=S4_value-2;
                             break;                             
                     }
                     if ( S4_value <= S4_Llim ) S4_value=S4_Llim; 
                     break;                      
             }
             break;             
       case '5':
             switch(URL[4])
             {
                case 'I':
                     switch(URL[5])
                     {
                         case '1':
                             S5_value=S5_value+10;
                             break;
                         case '2':
                             S5_value=S5_value+2;
                             break;                             
                     }
                     if ( S5_value >= S5_Hlim ) S5_value=S5_Hlim; 
                     break; 
               case 'D':
                     switch(URL[5])
                     {
                         case '1':
                             S5_value=S5_value-10;
                             break;
                         case '2':
                             S5_value=S5_value-2;
                             break;                             
                     }
                     if ( S5_value <= S5_Llim ) S5_value=S5_Llim;
                     break;                      
             }
             break;             
     }

    Serial.println(S1_value);   
    Serial.println(S2_value);   
    Serial.println(S3_value);   
    Serial.println(S4_value);   
    Serial.println(S5_value);       
  
   }
  //WiServer.print("</body>");
  WiServer.print("</html> ");
 
  return true;
}

void setup() {
  // Initialize WiServer and have it use the sendMyPage function to serve pages
  int i;

  Serial.begin(115200);
  WiServer.init(sendPage);

  myservo1.attach(0);  // attaches the servo on pin 0 to the servo object 
  myservo2.attach(1);  // attaches the servo on pin 1 to the servo object 
  myservo3.attach(3);  // attaches the servo on pin 3 to the servo object 
  myservo4.attach(4);  // attaches the servo on pin 4 to the servo object  
  myservo5.attach(5);  // attaches the servo on pin 5 to the servo object 


   delay(500);
  /*
  //go back to home position
  do
  {
    //delay(50);          // wait for sensors to stabilize
    val=analogRead(0);
    myStepper.step(-1);
    Serial.println(val);    
  } while (val < 1020);  //limit switch not touched
  */
 S1_Hlim=140;
 S1_Llim=0;  
 S2_Hlim=179;
 S2_Llim=0; 
 S3_Hlim=179;
 S3_Llim=50; 
 S4_Hlim=179;
 S4_Llim=0; 
 S5_Hlim=179;
 S5_Llim=20;  
 
 
 //go to home position
 myservo5.write(100);
 delay(200);
 myservo3.write(179);
 delay(200);
 
  
}

void loop(){
  // Run WiServer
  WiServer.server_task();

  delay(10);
}
