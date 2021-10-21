#include <LiquidCrystal.h>
#include <LCDKeypad.h>

LCDKeypad lcd;

//Key message
char msgs[5][15] = {"Right Key OK ", 
                    "Up Key OK    ", 
                    "Down Key OK  ", 
                    "Left Key OK  ", 
                    "Select Key OK" };
int  adc_key_val[5] ={30, 150, 360, 535, 760 };
int NUM_KEYS = 5;
int adc_key_in;
int key=-1;
int oldkey=-1;

void setup()
{
  
  lcd.begin(16, 2);
  lcd.clear();
  lcd.print("KEYPAD testing... pressing");
  lcd.setCursor(0,1);
  lcd.print("   The Number");
  
 
}

void loop()
{


	adc_key_in = analogRead(0);    // read the value from the sensor  
  key = get_key(adc_key_in);		        // convert into key press
	
	if (key != oldkey)				    // if keypress is detected
	{
    delay(50);		// wait for debounce time
		adc_key_in = analogRead(0);    // read the value from the sensor  
    key = get_key(adc_key_in);		        // convert into key press
    if (key != oldkey)				
    {			
      oldkey = key;
      if (key >=0){
      lcd.setCursor(0,1);
  			lcd.print(msgs[key]);
      }
    }
  }
  

}

// Convert ADC value to key number
int get_key(unsigned int input)
{
	int k;
    
	for (k = 0; k < NUM_KEYS; k++)
	{
		if (input < adc_key_val[k])
		{
           
    return k;
        }
	}
    
    if (k >= NUM_KEYS)
        k = -1;     // No valid key pressed
    
    return k;
}



