#include "Fingerprint.h"

Fingerprint fingerprintHandler = Fingerprint();

void setup()
{
	Serial.begin(9600);

	fingerprintHandler.setup();
}

void loop()
{
	String readedString = Serial.readString();
	if (readedString.indexOf("Get fingerprint") != -1)
	{
		Serial.print("fingerprint:klk");
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
