#include <Adafruit_Fingerprint.h>

// pin #2 is IN from sensor (GREEN wire)
// pin #3 is OUT from arduino  (WHITE wire)
// Set up the serial port to use softwareserial..
SoftwareSerial mySerial(2, 3);

#define MAX_FINGER_TRIES 10000

class Fingerprint
{
	Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);

public:
	void setup()
	{
		Serial.println("Starting up Fingerprint Sensor");
		// set the data rate for the sensor serial port
		finger.begin(57600);

		if (finger.verifyPassword())
		{
			Serial.println("Found fingerprint sensor!");
		}
		else
		{
			Serial.println("Did not find fingerprint sensor :(");
			while (1)
			{
				delay(1);
			}
		}

		printParams();
	}

	bool registerFingerprint(uint8_t id)
	{
		int status = -1;

		status = takeFingerImage();
		if (status != FINGERPRINT_OK)
		{
			printError(status);
			return false;
		}

		status = imageTz(1);
		if (status != FINGERPRINT_OK)
		{
			printError(status);
			return false;
		}

		Serial.println("Remove finger");
		delay(3000);

		waitForNoFinger();

		Serial.println("Put the finger again");
		delay(3000);

		status = takeFingerImage();
		if (status != FINGERPRINT_OK)
		{
			printError(status);
			return false;
		}

		status = imageTz(2);
		if (status != FINGERPRINT_OK)
		{
			printError(status);
			return false;
		}

		Serial.println("--- Creating model ---");

		status = createModel();
		if (status != FINGERPRINT_OK)
		{
			printError(status);
			return false;
		}

		status = storeModel(id);
		if (status != FINGERPRINT_OK)
		{
			printError(status);
			return false;
		}

		return true;
	}

	Adafruit_Fingerprint *scanFingerprint()
	{
		int status = -1;

		status = takeFingerImage();
		if (status != FINGERPRINT_OK)
		{
			printError(status);
			return nullptr;
		}

		status = imageTz(1);
		if (status != FINGERPRINT_OK)
		{
			printError(status);
			return nullptr;
		}

		status = searchFinger();
		if (status != FINGERPRINT_OK)
		{
			printError(status);
			return nullptr;
		}

		return &finger;
	}

	void waitForNoFinger()
	{
		int p = FINGERPRINT_OK;
		while (p != FINGERPRINT_NOFINGER)
		{
			p = finger.getImage();
		}
	}

private:
	void printParams()
	{
		Serial.println(F("Reading sensor parameters"));
		finger.getParameters();
		Serial.print(F("Status: 0x"));
		Serial.println(finger.status_reg, HEX);
		Serial.print(F("Sys ID: 0x"));
		Serial.println(finger.system_id, HEX);
		Serial.print(F("Capacity: "));
		Serial.println(finger.capacity);
		Serial.print(F("Security level: "));
		Serial.println(finger.security_level);
		Serial.print(F("Device address: "));
		Serial.println(finger.device_addr, HEX);
		Serial.print(F("Packet len: "));
		Serial.println(finger.packet_len);
		Serial.print(F("Baud rate: "));
		Serial.println(finger.baud_rate);
	}

	uint8_t waitForSerialNumber()
	{
		uint8_t num = 0;

		while (num == 0)
		{
			while (!Serial.available())
			{
			} // Wait until serial is available

			num = Serial.parseInt();
		}

		return num;
	}

	int takeFingerImage()
	{
		int p = -1;
		int tries = 0;

		while (p != FINGERPRINT_OK)
		{
			p = finger.getImage();

			if (p == FINGERPRINT_NOFINGER)
			{
				Serial.println(".");
			}
			else
			{
				tries++;

				if (tries > MAX_FINGER_TRIES)
				{
					return FINGERPRINT_NOFINGER;
				}
			}
		}

		return FINGERPRINT_OK;
	}

	int imageTz(int index)
	{
		return finger.image2Tz(index);
	}

	int createModel()
	{
		return finger.createModel();
	}

	int storeModel(uint8_t id)
	{
		return finger.storeModel(id);
	}

	int searchFinger()
	{
		return finger.fingerSearch();
	}

	void printError(int fingerprintErrorCode)
	{
		switch (fingerprintErrorCode)
		{
		case FINGERPRINT_PACKETRECIEVEERR:
			Serial.println("Communication error");
			break;

		case FINGERPRINT_NOTFOUND:
			Serial.println("Did not find a match");
			break;

		case FINGERPRINT_BADLOCATION:
			Serial.println("Could not store in that location");
			break;

		case FINGERPRINT_FLASHERR:
			Serial.println("Error writing to flash");
			break;

		case FINGERPRINT_ENROLLMISMATCH:
			Serial.println("Fingerprints did not match");
			break;

		case FINGERPRINT_IMAGEMESS:
			Serial.println("Image too messy");
			break;

		case FINGERPRINT_FEATUREFAIL:
			Serial.println("Could not find fingerprint features");
			break;

		case FINGERPRINT_INVALIDIMAGE:
			Serial.println("Could not find fingerprint features");
			break;

		case FINGERPRINT_NOFINGER:
			Serial.println("No finger detected");
			break;

		case FINGERPRINT_IMAGEFAIL:
			Serial.println("Imaging error");
			break;

		default:
			Serial.println("Unknown error");
			break;
		}
	}
};
