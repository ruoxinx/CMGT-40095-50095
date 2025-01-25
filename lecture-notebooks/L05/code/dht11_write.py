import time
import board
import adafruit_dht
import csv

# Sensor data pin is connected to GPIO 4
# sensor = adafruit_dht.DHT22(board.D4)
# Uncomment for DHT11
sensor = adafruit_dht.DHT11(board.D4)

# CSV file to save data
csv_file = "./sensor_data.csv"

# Write the CSV header
with open(csv_file, mode='w', newline='') as file:
    writer = csv.writer(file)
    writer.writerow(["Time", "Temperature (°C)", "Temperature (°F)", "Humidity (%)"])

print(f"Data will be saved to {csv_file}")

while True:
    try:
        # Get the current time
        measurement_time = time.strftime("%Y-%m-%d %H:%M:%S", time.localtime())

        # Read temperature and humidity
        temperature_c = sensor.temperature
        temperature_f = temperature_c * (9 / 5) + 32
        humidity = sensor.humidity

        # Print the values to the console
        print("[{0}] Temp={1:0.1f}ºC, Temp={2:0.1f}ºF, Humidity={3:0.1f}%".format(
            measurement_time, temperature_c, temperature_f, humidity))

        # Save the data to the CSV file
        with open(csv_file, mode='a', newline='') as file:
            writer = csv.writer(file)
            writer.writerow([measurement_time, temperature_c, temperature_f, humidity])

    except RuntimeError as error:
        # Errors happen fairly often, DHT's are hard to read, just keep going
        print(error.args[0])
        time.sleep(2.0)
        continue
    except Exception as error:
        sensor.exit()
        raise error

    time.sleep(3.0)
