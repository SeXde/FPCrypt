#include <Adafruit_Fingerprint.h>

// pin #2 is IN from sensor (GREEN wire)
// pin #3 is OUT from arduino  (WHITE wire)
// Set up the serial port to use softwareserial..
SoftwareSerial mySerial(2, 3);

Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);

class Fingerprint
{

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
		Serial.print("--- Waiting for valid finger to enroll as #");
		Serial.print(id);
		Serial.println(" ---");

		if (!takeFingerImage())
		{
			return false;
		}

		if (imageTz(1) != FINGERPRINT_OK)
		{
			return false;
		}

		Serial.println("Remove finger");
		delay(2000);

		waitForNoFinger();

		if (!takeFingerImage())
		{
			return false;
		}

		if (imageTz(2) != FINGERPRINT_OK)
		{
			return false;
		}

		Serial.println("--- Creating model ---");

		if (createModel() != FINGERPRINT_OK)
		{
			return false;
		}

		if (storeModel(id) != FINGERPRINT_OK)
		{
			return false;
		}

		return true;
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

	bool takeFingerImage()
	{
		int p = -1;

		while (p != FINGERPRINT_OK)
		{
			p = finger.getImage();

			switch (p)
			{
			case FINGERPRINT_OK:
				Serial.println("Image taken");
				break;

			case FINGERPRINT_NOFINGER:
				Serial.println(".");
				break;

			case FINGERPRINT_PACKETRECIEVEERR:
				Serial.println("Communication error");
				break;

			case FINGERPRINT_IMAGEFAIL:
				Serial.println("Imaging error");
				break;

			default:
				Serial.println("Unknown error");
				break;
			}
		}

		return true;
	}

	int imageTz(int index)
	{
		int p = finger.image2Tz(index);
		switch (p)
		{
		case FINGERPRINT_OK:
			Serial.println("Image converted");
			return FINGERPRINT_OK;

		case FINGERPRINT_IMAGEMESS:
			Serial.println("Image too messy");
			return p;

		case FINGERPRINT_PACKETRECIEVEERR:
			Serial.println("Communication error");
			return p;

		case FINGERPRINT_FEATUREFAIL:
			Serial.println("Could not find fingerprint features");
			return p;

		case FINGERPRINT_INVALIDIMAGE:
			Serial.println("Could not find fingerprint features");
			return p;

		default:
			Serial.println("Unknown error");
			return p;
		}
	}

	int createModel()
	{
		int p = finger.createModel();

		switch (p)
		{
		case FINGERPRINT_OK:
			Serial.println("Prints matched!");
			break;

		case FINGERPRINT_PACKETRECIEVEERR:
			Serial.println("Communication error");
			break;

		case FINGERPRINT_ENROLLMISMATCH:
			Serial.println("Fingerprints did not match");
			break;

		default:
			Serial.println("Unknown error");
			break;
		}

		return p;
	}

	int storeModel(uint8_t id)
	{
		int p = finger.storeModel(id);

		switch (p)
		{
		case FINGERPRINT_OK:
			Serial.println("Stored!");
			return p;

		case FINGERPRINT_PACKETRECIEVEERR:
			Serial.println("Communication error");
			return p;

		case FINGERPRINT_BADLOCATION:
			Serial.println("Could not store in that location");
			return p;

		case FINGERPRINT_FLASHERR:
			Serial.println("Error writing to flash");
			return p;

		default:
			Serial.println("Unknown error");
			return p;
		}
	}
};
