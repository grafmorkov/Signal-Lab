# Signal Lab

**Signal Lab** is an open-source core library for signal modulation and generation written in C#.
It provides basic tools for creating, manipulating, and visualizing different types of signals, including AM and FM.

The project aims to serve as a simple and extensible foundation for research, education, and signal-processing applications.

## Features
  1. Signal generation with adjustable parameters (amplitude, frequency, phase)
  2. Amplitude Modulation (AM) and Frequency Modulation (FM) support
  3. Lightweight and dependency-free core
  4. Designed for extension and integration with custom modules

## Mathematical background

**Amplitude Modulation (AM):**
S(ti​)=A⋅(1+ka​⋅m(ti​))⋅sin(2πfc​ti​)

**Frequency Modulation (FM):**
S(ti​)=A⋅sin(φ(ti​))
where
φ(ti​)=φ(ti−1​)+2πfc​⋅Δt+kf​⋅m(ti​)⋅Δt

## Example usage

```bash
Welcome to the SignalLab Core!
0 - Generate a signal
1 - Exit
0
Enter the signal amplitude: 2 

Enter the signal frequency: 192

Enter the initial signal phase: 0

Enter the signal duration (in seconds): 10

Select modulation type (0 - FM, 1 - AM): 0

Enter transceiver settings:
Enter frequency sensitivity (kf): 10

Enter sampling rate: 192

Enter minimum time step (affects accuracy and performance): 0.1

Enter the information (text) you want to convert into a signal: Demo

[INFO][14:03:36]: Success! The signal has been modulated successfully.
Do you want to write all the signal data to the .json? (Y,n): Y

Enter the path to a JSON file: /home/watt/signals.json


Process finished with exit code 0.
```
## Future Plans

WAV Converter — export generated signals to .wav format

Digital Modulation Support — add BPSK, QPSK, FSK, and others

GUI Tool — optional graphical interface for visualization and testing

## License
This project is licensed under the **GNU General Public License v3.0 (GPL-3.0)**.
