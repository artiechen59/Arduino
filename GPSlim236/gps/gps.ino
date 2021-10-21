/* GPS */
//#include "NewSoftSerial.h"
#include <SoftwareSerial.h>
#include "TinyGPS.h"
SoftwareSerial gpsNSS(9, 0);
TinyGPS gps;

void setup()
{
    /* Serial output */
    Serial.begin(38400);
    Serial.println("Waiting for GPS");

    /* Start GPS */
    gpsNSS.begin(38400);    
}

void loop()
{  
    while (gpsNSS.available()) {
        if (gps.encode(gpsNSS.read())) {
            float lat, lon, alt;
            unsigned long age;
            gps.f_get_position(&lat, &lon, &age);
            alt = gps.f_altitude();
            
            /* Display new GPS data when we get it */
            Serial.print("Lat: ");
            Serial.println(lat, 5);
            Serial.print("Lon: ");
            Serial.println(lon, 5);
            Serial.print("Alt: ");
            Serial.print(alt, 1);
            Serial.println("m");
        }
    } 
}
