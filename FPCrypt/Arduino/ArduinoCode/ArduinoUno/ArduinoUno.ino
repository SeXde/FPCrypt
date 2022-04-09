void setup()
{
  Serial.begin(9600);
}

void loop()
{
  String readedString = Serial.readString();
  if (readedString.indexOf("Get fingerprint") != -1) {
    Serial.print("fingerprint:klk");
  } else if (readedString.indexOf("Show") != -1) {
    Serial.print("replay");
  }
  Serial.flush();
}
