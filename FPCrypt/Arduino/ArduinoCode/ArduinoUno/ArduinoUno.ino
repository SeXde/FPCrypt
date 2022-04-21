#include <Adafruit_Fingerprint.h>
#include "Fingerprint.h"

Fingerprint fingerprintHandler = Fingerprint();

void setup()
{
	Serial.begin(9600);
 pinMode(10, OUTPUT);

	fingerprintHandler.setup();
}

void loop()
{

	String readedString = Serial.readString();
	if (readedString.indexOf("Get fingerprint") != -1)
	{
    digitalWrite(10, HIGH);

    bool found = false;
    while (!found) {
      Adafruit_Fingerprint *adaFP = fingerprintHandler.scanFingerprint();
      if (adaFP != nullptr)
      {
        Serial.print("fingerprint:");
        Serial.print(adaFP->fingerID);

        found = true;
      }
    }

   digitalWrite(10, LOW);
	}
	else if (readedString.indexOf("Show") != -1)
	{
		Serial.print("replay");
	}
	Serial.flush();
}

void registerFingerprint()
{
	Serial.println("Select finger id in the serial");

	uint8_t id = 0;

	while (id <= 0)
	{
		while (!Serial.available())
		{
		} // Wait until serial is available

		id = Serial.parseInt();
	}

	fingerprintHandler.registerFingerprint(id);
}
