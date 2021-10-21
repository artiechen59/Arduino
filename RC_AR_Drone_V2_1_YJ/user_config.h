/*

  RC Drone
  Interface RC radio to AR.Drone WIFI

  User Configuration
  
  By default Yellow Jacket code is in DEBUG mode and WIFI diabled.

 */

//// User Config //////////////////////////////

#define PRINT_DEBUG    1         // En-Disable debug. Must change this to 0 after radio setup
#define WIFI_DISABLE   1         // En-Disable WiFI to test radio. Must change this to 0 after radio setup

#define DRONE_NAME	"drone"  // Name of your drone, case sensitive


#define YAW_RATE        5        // YAW rate. Range 0-6 whole number no decimal
#define THROTTLE_RATE   1500     // Throttle rate. Range 0-20000 whole number no decimal
#define PITCH_ROLL_RATE 3        // Pitch , roll rate. Range 0-5 whole number no decimal ie 0,1,2,3,4 or 5 only

#define ALTITUDE_MAX    5000    // Maximum drone altitude in millimeters. 
                                // Give an integer value between 500 and 5000 to prevent the drone from flying above this limit,
                                // or set it to 10000 to let the drone fly as high as desired

#define FLY_OUTDOOR     "TRUE" // Out door or indoor. "FALSE" = indoor, "TRUE" = outdoor



// Mid stick dead zone. Max value is 400
#define THROTTLEBUFFER  40
#define ROLLBUFFER      20
#define PITCHBUFFER     20
#define YAWBUFFER       30


