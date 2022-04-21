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
		digitalWrite(10, HIGH);

		const int idStartIndex = readedString.indexOf(":");
		const int id = readedString.substring(idStartIndex).toInt();

		const int status = fingerprintHandler.registerFingerprint(id);

		if (status == FINGERPRINT_OK)
		{
			Serial.println(String("fingerprint:") + status);
		}
		else
		{
			Serial.println(String("error:") + fingerprintHandler.translateErrorMessage(status));
		}

		digitalWrite(10, LOW);
	}
	else if (readedString.startsWith("Delete fingerprint:"))
	{
		const int idStartIndex = readedString.indexOf(":");
		const int id = readedString.substring(idStartIndex).toInt();

		const int status = fingerprintHandler.deleteFingerprint(id);

		if (status != FINGERPRINT_OK)
		{
			Serial.println("error");
		}
		else
		{
			Serial.println("done");
		}
	}
	else if (readedString.equals("Clear"))
	{
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
