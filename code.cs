// Made by Evgeny Vovk 2024 all rights reserved
// RP2040 Touchpads
// Jan 12, 2024


#include "pico/stdlib.h"
#include "hardware/i2c.h"

#define TOUCHPAD_I2C_ADDR 0x5A

int main() {
    stdio_init_all();

    // Initialize I2C
    i2c_init(i2c0, 100 * 1000);  // 100 kHz
    gpio_set_function(0, GPIO_FUNC_I2C); // Set GPIO0 as I2C SDA
    gpio_set_function(1, GPIO_FUNC_I2C); // Set GPIO1 as I2C SCL
    gpio_pull_up(0);  // Enable pull-up on SDA
    gpio_pull_up(1);  // Enable pull-up on SCL

    sleep_ms(100);  // Give some time for the I2C peripheral to settle

    while (1) {
        // Read touchpad data
        uint8_t data[2];
        i2c_read_blocking(i2c0, TOUCHPAD_I2C_ADDR, data, 2, false);

        // Process touchpad data (example: print raw values)
        printf("Touchpad Data: %u %u\n", data[0], data[1]);

        sleep_ms(100);  // Add a delay to control the update frequency
    }

    return 0;
}
