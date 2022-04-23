#include <Adafruit_Fingerprint.h>
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
		Serial.println("Trying to get fingerprint");

		bool found = false;
		while (!found)
		{
			ScanResult scanResult = fingerprintHandler.scanFingerprint();
			if (!scanResult.hasError())
			{
				Serial.print("fingerprint:");
				Serial.print(scanResult.finger->fingerID);

				found = true;
			}
		}

		digitalWrite(10, LOW);
	}
	else if (readedString.startsWith("Register fingerprint:"))
	{

		const int idStartIndex = readedString.indexOf(":");
		const int id = readedString.substring(idStartIndex + 1).toInt();
		Serial.println("Registering...");

		const int status = fingerprintHandler.registerFingerprint(id);

		if (status == FINGERPRINT_OK)
		{
			Serial.println(String("fingerprint:") + id);
		}
		else
		{
			Serial.println(String("error|") + fingerprintHandler.translateErrorMessage(status) + String("|"));
		}

		digitalWrite(10, LOW);
	}
	else if (readedString.startsWith("Delete fingerprint:"))
	{
		const int idStartIndex = readedString.indexOf(":");
		const int id = readedString.substring(idStartIndex + 1).toInt();
		Serial.println(String("Deleting fingerprint: ") + id);

		const int status = fingerprintHandler.deleteFingerprint(id);

		if (status != FINGERPRINT_OK)
		{
			Serial.println("error|unknown error|");
		}
		else
		{
			Serial.println("done");
		}
	}
	else if (readedString.indexOf("Clear") != -1)
	{
		Serial.println("Clearing all fingerprints");
		fingerprintHandler.deleteAllFingerprints();

		Serial.println("done");
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
