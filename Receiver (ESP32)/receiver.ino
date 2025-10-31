#include <SPI.h>
#include <LoRa.h>

// -------------------- Pin Definitions --------------------
// Adjust these to match your wiring between ESP32 and SX1278
#define NSS   5    // LoRa chip select (CS)
#define RST   14   // LoRa reset
#define DIO0  2    // LoRa DIO0 (used for RX done)

void setup() {
  Serial.begin(115200);
  while (!Serial);

  Serial.println();
  Serial.println("LoRa Receiver initializing...");

  // Initialize LoRa transceiver
  LoRa.setPins(NSS, RST, DIO0);

  if (!LoRa.begin(433E6)) {
    Serial.println("Starting LoRa failed! Check your connections.");
    while (true);
  }

  // Match the Raspberry Pi sender’s radio configuration
  LoRa.setSpreadingFactor(7);      // SF7
  LoRa.setSignalBandwidth(125E3);  // 125 kHz
  LoRa.setCodingRate4(5);          // 4/5
  LoRa.crc();                      // Enable CRC check

  Serial.println("LoRa Receiver ready (433 MHz)");
  Serial.println("------------------------------------");
}

void loop() {
  // Try to parse a LoRa packet
  int packetSize = LoRa.parsePacket();

  if (packetSize) {
    Serial.print("Received packet: ");

    // Read packet
    while (LoRa.available()) {
      Serial.print((char)LoRa.read());
    }

    // Print RSSI (signal strength)
    Serial.print("  |  RSSI: ");
    Serial.println(LoRa.packetRssi());
  }
}
