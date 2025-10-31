from SX127x.LoRa import LoRa
from SX127x.board_config_ada import BOARD
import time
import RPi.GPIO as GPIO
from SX127x.constants import MODE, BW, CODING_RATE, GAIN


# ------------------ LoRa Transmitter Class ------------------ #
class LoRaSender(LoRa):
    def __init__(self, verbose=False):
        super(LoRaSender, self).__init__(verbose)
        self.tx_counter = 0

    def on_tx_done(self):
        """Callback when a packet is sent."""
        print("Transmission done.")
        self.set_mode(MODE.STDBY)

    def start(self):
        """Main transmit loop."""
        print("Starting LoRa sender loop...")
        try:
            while True:
                msg = f"Hello LoRa {self.tx_counter}"
                self.tx_counter += 1

                print(f"Sending: {msg}")
                self.write_payload(list(map(ord, msg)))
                self.set_mode(MODE.TX)

                time.sleep(5)  # Delay between messages
        except KeyboardInterrupt:
            print("\nInterrupted. Cleaning up...")
            self.set_mode(MODE.SLEEP)
            BOARD.teardown()
            print("GPIO cleanup complete.")
            exit(0)


# ------------------ Main Program ------------------ #
if __name__ == "__main__":
    print("Initializing LoRa...")
    BOARD.setup()
    print("(Safe setup complete.)")

    lora = LoRaSender(verbose=False)
    lora.set_mode(MODE.STDBY)
    lora.set_pa_config(pa_select=1)
    lora.set_bw(BW.BW125)
    lora.set_coding_rate(CODING_RATE.CR4_5)
    lora.set_spreading_factor(7)
    lora.set_rx_crc(True)
    lora.set_freq(433.0)  # Change this if using 868/915 MHz LoRa module

    # Set PA (power amplifier) configuration for TX power
    # pa_select=1 -> PA_BOOST pin (for SX1276/77/78 modules)
    # max_power=0x04 -> internal max power config
    # output_power=14 -> transmit power in dBm (range 2-17 typical)
    lora.set_pa_config(pa_select=1, max_power=0x04, output_power=14)

    # Optional: Adjust LNA gain for reception (not critical for sender)
    lora.set_lna_gain(GAIN.G1)

    print("LoRa init complete.")
    print("Transmitting messages every 5 seconds...\n")

    print("DIO0:", GPIO.input(BOARD.DIO0))

    lora.start()
