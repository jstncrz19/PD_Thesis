import serial
import pynmea2
from SX127x.LoRa import LoRa
from SX127x.board_config_ada import BOARD
import time
import RPi.GPIO as GPIO
from SX127x.constants import MODE, BW, CODING_RATE, GAIN

# ---------------- GPS Setup ---------------- #
gps_serial = serial.Serial("/dev/serial0", baudrate=9600, timeout=1)

def get_gps_data():
    """Read GPS data and return as string (lat, lon) if valid."""
    try:
        line = gps_serial.readline().decode('ascii', errors='replace').strip()
        if not line.startswith('$GPGGA'):
            return "No GPS fix"

        msg = pynmea2.parse(line)
        # Validate that fix quality is valid (1 = GPS fix, 2 = DGPS fix)
        if getattr(msg, "gps_qual", 0) in (1, 2) and msg.lat and msg.lon:
            lat = f"{msg.latitude:.6f}"
            lon = f"{msg.longitude:.6f}"
            return f"{lat},{lon}"
        else:
            return "No GPS fix"
    except Exception as e:
        # print("GPS read error:", e)
        return "No GPS fix"


# ------------------ LoRa Transmitter Class ------------------ #
class LoRaSender(LoRa):
    def __init__(self, verbose=False):
        super(LoRaSender, self).__init__(verbose)
        self.tx_counter = 0

    def on_tx_done(self):
        print("Transmission done.")
        self.set_mode(MODE.STDBY)

    def start(self):
        print("Starting LoRa sender loop...")
        try:
            while True:
                gps_data = get_gps_data()
                msg = f"Hello LoRa {self.tx_counter} | GPS: {gps_data}"
                self.tx_counter += 1

                print(f"Sending: {msg}")
                self.write_payload(list(map(ord, msg)))
                self.set_mode(MODE.TX)
                time.sleep(5)
        except KeyboardInterrupt:
            print("\nInterrupted. Cleaning up...")
            self.set_mode(MODE.SLEEP)
            BOARD.teardown()
            print("GPIO cleanup complete.")
            exit(0)

# ------------------ Main Program ------------------ #
if __name__ == "__main__":
    BOARD.setup()
    lora = LoRaSender(verbose=False)
    lora.set_mode(MODE.STDBY)
    lora.set_pa_config(pa_select=1)
    lora.set_bw(BW.BW125)
    lora.set_coding_rate(CODING_RATE.CR4_5)
    lora.set_spreading_factor(7)
    lora.set_rx_crc(True)
    lora.set_freq(433.0)
    lora.set_pa_config(pa_select=1, max_power=0x04, output_power=14)
    lora.set_lna_gain(GAIN.G1)

    print("LoRa init complete. Transmitting messages with GPS every 5 seconds...\n")
    lora.start()

