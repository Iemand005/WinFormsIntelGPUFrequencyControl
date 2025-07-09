# Intel GPU Frequency tool

A quick demo on how to change GPU clock speeds on Intel GPUs.
This project uses [Intel Level Zero](https://github.com/oneapi-src/level-zero) APIs. Big thanks to Intel for making this open source and available to use!

Should work on Intel Xe, Arc and Battlemage.

Tested on Iris Xe iGPU on 12 and 13th gen mobile CPU. I expect it to work on older units too, depends on what Level Zero supports.

Changing clock speeds should be possible on HD 3000 and up. (Using i915 driver on Linux)
It's also possible to change clock speeds on Intel GMA 900/950 with GMABooster. Other Intel GPUs might also be capable of changing frequencies and overlcocking.

Clock speed overrides get applied immediately and can be fully reset immediately without rebooting or anything.

![afbeelding](https://github.com/user-attachments/assets/efb53ba7-0335-4e31-8cbf-77f2892d7874)


https://github.com/user-attachments/assets/ee91c796-9121-451a-a8d1-dceefa3cc111

