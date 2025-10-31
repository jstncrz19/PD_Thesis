#include <SPI.h>
#include <LoRa.h>

// LoRa pins
#define NSS   5
#define RST   14
#define DIO0  2

void setup() {
  Serial.begin(115200);
  while (!Serial);

  Serial.println("LoRa Receiver initializing...");

  LoRa.setPins(NSS, RST, DIO0);
  if (!LoRa.begin(433E6)) {
    Serial.println("Starting LoRa failed! Check your connections.");
    while (true);
  }

  LoRa.setSpreadingFactor(7);
  LoRa.setSignalBandwidth(125E3);
  LoRa.setCodingRate4(5);
  LoRa.crc();

  Serial.println("LoRa Receiver ready (433 MHz)");
  Serial.println("------------------------------------");
}

void loop() {
  int packetSize = LoRa.parsePacket();

  if (packetSize) {
    Serial.print("Received packet: ");
    String received = "";
    while (LoRa.available()) {
      received += (char)LoRa.read();
    }
    Serial.println(received);

    // Extract GPS coordinates if needed
    int gpsIndex = received.indexOf("GPS:");
    if (gpsIndex > 0) {
      String gpsData = received.substring(gpsIndex + 4);
      Serial.print("Parsed GPS: ");
      Serial.println(gpsData);
    }

    Serial.print("  |  RSSI: ");
    Serial.println(LoRa.packetRssi());
  }
}
