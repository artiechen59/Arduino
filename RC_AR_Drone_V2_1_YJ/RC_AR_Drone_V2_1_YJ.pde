/*

  RC Ar.Drone V2.1
  
  Interface RC radio to AR.Drone WIFI
  
  Put together by Mheeli at rcgroups.com

  Customised WiShield driver required
  
  Please use this at your own risk.

 */



#include <WiShield.h>
#include "user_config.h"



#define WIRELESS_MODE_INFRA	1
#define WIRELESS_MODE_ADHOC	2

// Wireless configuration parameters ----------------------------------------
unsigned char local_ip[] = {192,168,1,4};	// IP address of WiShield
unsigned char gateway_ip[] = {192,168,1,1};	// router or gateway IP address
unsigned char subnet_mask[] = {255,255,255,0};	// subnet mask for the local network
const prog_char ssid[] PROGMEM = {DRONE_NAME};		// max 32 bytes

unsigned char security_type = 0;	// 0 - open; 1 - WEP; 2 - WPA; 3 - WPA2

// WPA/WPA2 passphrase
const prog_char security_passphrase[] PROGMEM = {"12345678"};	// max 64 characters

// WEP 128-bit keys
// sample HEX keys
prog_uchar wep_keys[] PROGMEM = {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,0x00,	// Key 0
				0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x00,	// Key 1
				0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x00,	// Key 2
				0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x00	// Key 3
                                };

// setup the wireless mode
// infrastructure - connect to AP
// adhoc - connect to another WiFi device
//unsigned char wireless_mode = WIRELESS_MODE_INFRA;
unsigned char wireless_mode = WIRELESS_MODE_ADHOC;

unsigned char ssid_len;
unsigned char security_passphrase_len;

//--------End WiFi--------------------------------------------------------


// Staus
#define GROUNDED       1  //drone status - on the ground
#define TAKINGOFF      2  //drone status - taking off
#define HOVERING       3  //drone status - hovering
#define FLYING         4  //drone status - flying
#define LANDING        5  //drone status - landing
#define FLATTRIMING    6  //drone status - flat trimming
#define RESETWATCHDOG  7  // drone status resetting watchdog
#define HOVERRESETWATCHDOG 8  // reset watchdog during long hover

// PINS
#define THROTTLEPIN  5  // Radio CH3
#define ROLLPIN      3  // Radio CH1
#define PITCHPIN     4  // Radio CH2
#define YAWPIN       6  // Radio CH4
#define AUXPIN       7  // Radio CH5


// RX Values

#define ROLLMAX 1901
#define ROLLMIN 1086

#define PITCHMAX 1900
#define PITCHMIN 1086

#define THROTTLEMAX 1902
#define THROTTLEMIN 1086

#define YAWMAX 1903
#define YAWMIN 1087

#define TOGGLEMID 1500

#define RADIO_TIMEOUT  20000

int drone_status=0;
int init_counter=0;
int old_time=0;

int throttle = 0;
int throttle_old = 0;
int throttle_mid;
int throttle_step=0;
float throttle_move=0;

int roll = 0;
int roll_old = 0;
int roll_mid;
int roll_step=0;
float roll_move=0;

int pitch = 0;
int pitch_old = 0;
int pitch_mid;
int pitch_step=0;
float pitch_move=0;

int yaw = 0;
int yaw_old = 0;
int yaw_mid;
int yaw_step=0;
float yaw_move=0;

int aux= 0;
int aux_old= 0;


int seq=1;
int init_drone=1;
int flying_switch = 0;  // 0 = grounded , 1 = flying
char data[100];
char yj_mac[17];
int stick_diff=0;


void setup() {

  if (PRINT_DEBUG) Serial.begin(38400);

  // Init WIFI
  if (!WIFI_DISABLE) Serial.println("");
  if (!WIFI_DISABLE) Serial.println("");
  if (!WIFI_DISABLE) Serial.println("");
  if (!WIFI_DISABLE) Serial.println("Initiating WiFi...........");
  if (!WIFI_DISABLE) WiFi.init();
  if (!WIFI_DISABLE) Serial.println("Wifi Initiated.......");

  // get the YJ MAC address
  unsigned char *my_mac = zg_get_mac();
  sprintf(yj_mac,"%.2X:%.2X:%.2X:%.2X:%.2X:%.2X",my_mac[0],my_mac[1],my_mac[2],my_mac[3],my_mac[4],my_mac[5]);

  if (PRINT_DEBUG) Serial.print("MAC Address : ");
  if (PRINT_DEBUG) Serial.println(yj_mac);

  
  // define pins
  pinMode(THROTTLEPIN, INPUT);
  pinMode(ROLLPIN, INPUT);
  pinMode(PITCHPIN, INPUT);
  pinMode(YAWPIN, INPUT);
  pinMode(AUXPIN, INPUT);

  // read radio mid stick values
  while (1) {
   read_radio(); 

   if (PRINT_DEBUG) {
   Serial.print ("Aux : ");
   Serial.print (aux);
   Serial.print ("\tThrottle : ");
   Serial.print (throttle);
   Serial.print ("\tYaw : ");
   Serial.print (yaw);
   Serial.print ("\tRoll : ");
   Serial.print (roll);
   Serial.print ("\tPitch : ");
   Serial.print (pitch);
   }
    
   throttle_mid=throttle;
   yaw_mid = yaw;
   roll_mid = roll;
   pitch_mid = pitch;

   // only continue if all sticks are in the middle and take off switch is deactivated
   if (aux > 1500) stick_diff = 1;
   if (throttle > 1500) {
      if ( (throttle - 1500) > 50) stick_diff=1;
   }
   if (yaw > 1500) {
      if ( (yaw - 1500) > 50) stick_diff=1;
   }
   if (roll > 1500) {
      if ( (roll - 1500) > 50) stick_diff=1;
   }
   if (pitch > 1500) {
      if ( (pitch - 1500) > 50) stick_diff=1;
   }
   if (throttle < 1500) {
      if ( (1500 - throttle) > 50) stick_diff=1;
   }
   if (yaw < 1500) {
      if ( (1500 - yaw) > 50) stick_diff=1;
   }
   if (roll < 1500) {
      if ( (1500 - roll) > 50) stick_diff=1;
   }
   if (pitch < 1500) {
      if ( (1500 - pitch) > 50) stick_diff=1;
   }

   if (stick_diff == 0 ) break;
   stick_diff=0;
   
   if (PRINT_DEBUG) Serial.println("\tPlease move stick to middle positionon...");

  }

  // steps for each channel
  yaw_step=YAWMAX-YAWBUFFER-yaw_mid;
  throttle_step=THROTTLEMAX-THROTTLEBUFFER-throttle_mid;
  roll_step=ROLLMAX-ROLLBUFFER-roll_mid;
  pitch_step=PITCHMAX-PITCHBUFFER-pitch_mid;
  
}

void loop() {
  
  // Run WiFi
  if (!WIFI_DISABLE) WiFi.run();

  //init drone
  if (init_drone == 1) initialise_drone();

  // read radio values
  
  read_radio();
  
  if (PRINT_DEBUG) {

   Serial.print("Aux:");
   Serial.print(aux);
   Serial.print("  ");

   Serial.print("Yaw:");
   Serial.print(yaw);
   Serial.print("  ");
   Serial.print("Yaw Move : ");
   Serial.print(yaw_move);
   Serial.print("  ");

   Serial.print("Throttle:");
   Serial.print(throttle);
   Serial.print("  ");
   Serial.print("Throttle Move : ");
   Serial.print(throttle_move);
   Serial.print("  ");

   Serial.print("Roll:");
   Serial.print(roll);
   Serial.print("  ");
   Serial.print("Roll Move : ");
   Serial.print(roll_move);
   Serial.print("  ");

   Serial.print("Pitch:");
   Serial.print(pitch);
   Serial.print("  ");
   Serial.print("Pitch Move : ");
   Serial.print(pitch_move);
   Serial.print("  ");

   Serial.print ("Drone Status : ");
   Serial.print (drone_status);
   Serial.print ("   ");

  }

  switch(drone_status){
   
   case GROUNDED:    // drone is on the ground
    if (PRINT_DEBUG) Serial.println ("Grounded");
    
    // keep sending keep alive and landing command
//    sprintf(data,"AT*PCMD=%d,0,0,0,0,0\rAT*REF=%d,290717696\r",seq++,seq++);
    sprintf(data,"AT*PCMD=%d,0,0,0,0,0\rAT*REF=%d,290717696\r",1,1);

    // if flying switch goes high then take off
    if (flying_switch == 1) {  //reset watchdog, flat trim, take off and hover
        drone_status = RESETWATCHDOG;
        old_time=0;
     } 
   break;

   case RESETWATCHDOG:    // reset watchdog
    if (PRINT_DEBUG) Serial.println ("Resetting watchdog");
    
//    sprintf(data,"AT*COMWDG=%d\r",seq++);
    sprintf(data,"AT*COMWDG=%d\r",1);
    
    // give WiFi some time to send the command
    if (old_time == 0) old_time = millis();
    if (millis() - old_time > 400 && zg_get_tx_status() == 0){  // make sure the watch dog command is sent
      drone_status = FLATTRIMING;
      seq=1;
      old_time=0;
    }
    if (flying_switch == 0) drone_status = GROUNDED;
   break;


   case FLATTRIMING:    // flat trim
    if (PRINT_DEBUG) Serial.println ("Flat triming");
    sprintf(data,"AT*FTRIM=%d,\rAT*LED=%d,2,1073741824,1\r",seq++,seq++);
    
    // give WiFi some time to send the flat trim command
    if (old_time == 0) old_time = millis();
    if (millis() - old_time > 200 && zg_get_tx_status() == 0){
      drone_status = TAKINGOFF;
      old_time=0;
    }

    if (flying_switch == 0) drone_status = GROUNDED;
   break;

   case TAKINGOFF:    // taking off
    if (PRINT_DEBUG) Serial.println ("Taking off");
    sprintf(data,"AT*PCMD=%d,0,%ld,%ld,%ld,%ld\rAT*REF=%d,290718208\r",seq++,roll_move,pitch_move,throttle_move,yaw_move,seq++);
//    sprintf(data,"AT*PCMD=%d,0,%ld,%ld,%ld,%ld\rAT*REF=%d,290718208\r",1,roll_move,pitch_move,throttle_move,yaw_move,1);
    
    // give WiFi some time to send the flat trim command
    if (old_time == 0) old_time = millis();
    if (millis() - old_time > 300 && zg_get_tx_status() == 0) drone_status = HOVERING;
    if (flying_switch == 0) drone_status = GROUNDED;
   break;

   case HOVERING:
     if (PRINT_DEBUG) Serial.println ("Hovering");
     sprintf(data,"AT*PCMD=%d,0,%ld,%ld,%ld,%ld\r",seq++,roll_move,pitch_move,throttle_move,yaw_move);
     if (flying_switch == 0) drone_status = GROUNDED;
     if (roll_move != 0 || pitch_move != 0 )drone_status=FLYING;
   break;

   case FLYING:
     if (PRINT_DEBUG) Serial.println ("Flying");
     sprintf(data,"AT*PCMD=%d,1,%ld,%ld,%ld,%ld\r",seq++,roll_move,pitch_move,throttle_move,yaw_move);
//     sprintf(data,"AT*PCMD=%d,1,%ld,%ld,%ld,%ld\r",1,roll_move,pitch_move,throttle_move,yaw_move);
     if (roll_move == 0 && pitch_move == 0) drone_status=HOVERING;
     if (flying_switch == 0) drone_status = GROUNDED;
    break; 

  }

}

void read_radio() {
  
      // Read Receiver
      // Tested with ASSAN X8R7

      // save previous values just in case we cannot read radio signal
      roll_old=roll;
      pitch_old=pitch;
      throttle_old=throttle;
      yaw_old=yaw;
      aux_old=aux;

      roll = pulseIn(ROLLPIN, HIGH, RADIO_TIMEOUT);
      pitch = pulseIn(PITCHPIN, HIGH, RADIO_TIMEOUT);
      throttle = pulseIn(THROTTLEPIN, HIGH, RADIO_TIMEOUT);
      yaw = pulseIn(YAWPIN, HIGH, RADIO_TIMEOUT);
      aux = pulseIn(AUXPIN, HIGH, RADIO_TIMEOUT);

      // if could not read radio , then sent command to hover drone
        if (roll == 0 || pitch == 0 || throttle == 0 || yaw == 0) drone_status = HOVERING;
//      if (roll == 0) roll = roll_old;
//      if (pitch == 0) pitch = pitch_old;
//      if (throttle == 0) throttle = throttle_old;
//      if (yaw == 0) yaw = yaw_old;
//      if (aux == 0) aux = aux_old;


      // check ground and flying switch
     if (aux > TOGGLEMID && aux < 2500 ) flying_switch=1;    // flying
     if ( aux < TOGGLEMID) flying_switch=0; //  grounded
     
    // YAW movement
    // YAW Middle
    if ( yaw < (yaw_mid+YAWBUFFER) && yaw > (yaw_mid-YAWBUFFER) ) yaw_move=0;

    // YAW right
    if ( yaw > (yaw_mid+YAWBUFFER) ) yaw_move = float(yaw-YAWBUFFER-yaw_mid) / float(yaw_step);

    // YAW left
    if ( yaw < (yaw_mid-YAWBUFFER) ) yaw_move = (float(yaw_mid-YAWBUFFER-yaw) / float(yaw_step)) * float(-1);

    // throttle movement
    // throttle Middle
    if ( throttle < (throttle_mid+THROTTLEBUFFER) && throttle > (throttle-THROTTLEBUFFER) ) throttle_move=0;

    // throttle up
    if ( throttle > (throttle_mid+THROTTLEBUFFER)) throttle_move = float(throttle-THROTTLEBUFFER-throttle_mid) / float(throttle_step);

    // throttle down
    if ( throttle < (throttle_mid-THROTTLEBUFFER)) throttle_move = (float(throttle_mid-THROTTLEBUFFER-throttle) / float(throttle_step)) * float(-1);


    // roll movement
    // roll Middle
    if ( roll < (roll_mid+ROLLBUFFER) && roll > (roll_mid-ROLLBUFFER) ) roll_move=0;

    // roll right 
    if ( roll > (roll_mid+ROLLBUFFER)) roll_move = float(roll-ROLLBUFFER-roll_mid) / float(roll_step);

    // roll left
    if ( roll < (roll_mid-ROLLBUFFER)) roll_move = (float(roll_mid-ROLLBUFFER-roll) / float(roll_step)) * float(-1);

   // pitch movement
   // pitch Middle
   if ( pitch < (pitch_mid+PITCHBUFFER) && pitch > (pitch_mid-PITCHBUFFER) ) pitch_move=0;

    // pitch up
    if ( pitch > (pitch_mid+PITCHBUFFER)) pitch_move = float(pitch-PITCHBUFFER-pitch_mid) / float(pitch_step);

    // pitch down
    if ( pitch < (pitch_mid-PITCHBUFFER)) pitch_move = (float(pitch_mid-ROLLBUFFER-pitch) / float(pitch_step)) * float(-1);

}

void initialise_drone() {

 if (PRINT_DEBUG) Serial.println("Initialising");
 
 if (init_counter < 7) {
    if (zg_get_tx_status() == 0) sprintf(data,"Dummy to init network");
 }
  
 switch (init_counter){
  
  case 7:  // Pair Drone to YJ
    if (zg_get_tx_status() == 0) sprintf(data,"AT*CONFIG=%d,\"network:owner_mac\",\"%s\"\r",1,yj_mac);
  break;

  case 20:  // Set yaw rate
    if (zg_get_tx_status() == 0) sprintf(data,"AT*CONFIG=%d,\"control:control_yaw\",\"%d\"\r",seq++,YAW_RATE);
  break;

  case 21:  // Set throttle rate
    if (zg_get_tx_status() == 0) sprintf(data,"AT*CONFIG=%d,\"control:control_vz_max\",\"%d\"\r",seq++,THROTTLE_RATE);
  break;

  case 22:  // Set pitch, roll rate
    if (zg_get_tx_status() == 0) sprintf(data,"AT*CONFIG=%d,\"control:euler_angle_max\",\"0.%d\"\r",seq++,PITCH_ROLL_RATE);
  break;

  case 23:  // Set max altitude
    if (zg_get_tx_status() == 0) sprintf(data,"AT*CONFIG=%d,\"control::altitude_max\",\"%d\"\r",seq++,ALTITUDE_MAX);
  break;

  case 24:  // Set outdoor indoor
    if (zg_get_tx_status() == 0) sprintf(data,"AT*CONFIG=%d,\"control::outdoor\",\"%s\"\r",seq++,FLY_OUTDOOR);
  break;

  case 25:  // Drone is ready , play LEDs
    if (zg_get_tx_status() == 0) sprintf(data,"AT*LED=%d,2,1073741824,5\r",seq++);
  break;

  case 27:  // Drone is ready , play LEDs
    if (zg_get_tx_status() == 0) sprintf(data,"AT*LED=%d,4,1073741824,120\r",seq++);
  break;

  case 28:  // Drone is ready , play LEDs
    if (zg_get_tx_status() == 0) sprintf(data,"AT*LED=%d,4,1073741824,120\r",seq++);
  break;


  case 30:  // set drone ready for flying
    init_drone=0;
    drone_status=GROUNDED;
  break;

 } 

 // send keep alive command to give drone a chance to process pairing command
// if (init_counter > 7  and init_counter < 20) {
//    if (zg_get_tx_status() == 0) sprintf(data,"AT*PCMD=%d,0,0,0,0,0\rAT*REF=%d,290717696\r",seq++,seq++);
//    if (zg_get_tx_status() == 0) sprintf(data,"AT*PCMD=%d,0,0,0,0,0\rAT*REF=%d,290717696\r",1,1);
// }


  if (zg_get_tx_status() == 0) init_counter++;

}
