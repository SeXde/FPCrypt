#include <Adafruit_Fingerprint.h>

// pin #2 is IN from sensor (GREEN wire)
// pin #3 is OUT from arduino  (WHITE wire)
// Set up the serial port to use softwareserial..
SoftwareSerial mySerial(2, 3);

#define MAX_FINGER_TRIES 10000

struct ScanResult
{
	Adafruit_Fingerprint *finger = nullptr;
	int errorCode = FINGERPRINT_OK;

	ScanResult(Adafruit_Fingerprint *inFinger)
		: finger(inFinger), errorCode(FINGERPRINT_OK) {}

	ScanResult(int inError)
		: finger(nullptr), errorCode(inError) {}

	bool hasError()
	{
		return finger == nullptr;
	}
};

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
			Serial.println("error:Did not find fingerprint sensor :(");
			while (1)
			{
				delay(1);
			}
		}

		// printParams();
	}

	/** Returns the error string if any */
	int registerFingerprint(uint8_t id)
	{
		int status = -1;

		finger.LEDcontrol(FINGERPRINT_LED_GRADUAL_ON, 0, FINGERPRINT_LED_BLUE);

		status = takeFingerImage();
		if (status != FINGERPRINT_OK)
		{
			return status;
		}

		status = imageTz(1);
		if (status != FINGERPRINT_OK)
		{
			return status;
		}

		Serial.println("Remove the finger");

		waitForNoFinger();

		Serial.println("Put the finger again");

		status = takeFingerImage();
		if (status != FINGERPRINT_OK)
		{
			return status;
		}

		status = imageTz(2);
		if (status != FINGERPRINT_OK)
		{
			return status;
		}

		Serial.println("Creating finger model");

		status = createModel();
		if (status != FINGERPRINT_OK)
		{
			return status;
		}

		status = storeModel(id);
		if (status != FINGERPRINT_OK)
		{
			return status;
		}

		finger.LEDcontrol(FINGERPRINT_LED_GRADUAL_OFF, 0, FINGERPRINT_LED_BLUE);

		return status;
	}

	ScanResult scanFingerprint()
	{
		finger.LEDcontrol(FINGERPRINT_LED_GRADUAL_ON, 0, FINGERPRINT_LED_BLUE);

		int status = -1;

		status = takeFingerImage();
		if (status != FINGERPRINT_OK)
		{
			return ScanResult(status);
		}

		status = imageTz(1);
		if (status != FINGERPRINT_OK)
		{
			return ScanResult(status);
		}

		status = searchFinger();
		if (status != FINGERPRINT_OK)
		{
			return ScanResult(status);
		}

		finger.LEDcontrol(FINGERPRINT_LED_GRADUAL_OFF, 0, FINGERPRINT_LED_BLUE);

		return ScanResult(&finger);
	}

	void waitForNoFinger()
	{
		int p = FINGERPRINT_OK;
		while (p != FINGERPRINT_NOFINGER)
		{
			p = finger.getImage();
		}
	}

	int deleteFingerprint(uint8_t id)
	{
		return finger.deleteModel(id);
	}

	void deleteAllFingerprints()
	{
		finger.emptyDatabase();
	}

	String translateErrorMessage(int fingerprintErrorCode)
	{
		switch (fingerprintErrorCode)
		{
		case FINGERPRINT_PACKETRECIEVEERR:
			return "Communication error";

		case FINGERPRINT_NOTFOUND:
			return "Did not find a match";

		case FINGERPRINT_BADLOCATION:
			return "Could not store in that location";

		case FINGERPRINT_FLASHERR:
			return "Error writing to flash";

		case FINGERPRINT_ENROLLMISMATCH:
			return "Fingerprints did not match";

		case FINGERPRINT_IMAGEMESS:
			return "Image too messy";

		case FINGERPRINT_FEATUREFAIL:
			return "Could not find fingerprint features";

		case FINGERPRINT_INVALIDIMAGE:
			return "Could not find fingerprint features";

		case FINGERPRINT_NOFINGER:
			return "No finger detected";

		case FINGERPRINT_IMAGEFAIL:
			return "Imaging error";

		default:
			return "Unknown error";
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

			if (p != FINGERPRINT_NOFINGER)
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
};
