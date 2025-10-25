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

```csharp
using SignalLab.Core.Modulation;
using SignalLab.Core.Data;
using SignalLab.Core.Logging;

namespace SignalLab.Core.CLI.Commands;

public static class GenerateSignalCommand
{
    public static void GenerateSignal()
    {
        ConsoleLogger logger = new ConsoleLogger();
        SignalData data = new SignalData();

        Console.Write("Enter the signal amplitude: ");
        data.Amplitude = double.Parse(Console.ReadLine() ?? "1", System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine();

        Console.Write("Enter the signal frequency: ");
        data.Frequency = double.Parse(Console.ReadLine() ?? "44100", System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine();

        Console.Write("Enter the initial signal phase: ");
        data.Phase = double.Parse(Console.ReadLine() ?? "0", System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine();

        Console.Write("Enter the signal duration (in seconds): ");
        data.Time = double.Parse(Console.ReadLine() ?? "0.1", System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine();

        Console.WriteLine("Select modulation type:\n0 - FM (Frequency Modulation)\n1 - AM (Amplitude Modulation)");
        int modType = int.Parse(Console.ReadLine() ?? "0", System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine();

        Console.WriteLine("Enter transceiver settings:");

        Console.Write("Enter frequency sensitivity (kf): ");
        double kf = double.Parse(Console.ReadLine() ?? "100", System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine();

        Console.Write("Enter sampling rate: ");
        double sampleRate = double.Parse(Console.ReadLine() ?? "44100", System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine();

        Console.Write("Enter minimum time step (NOTE: affects simulation accuracy and performance): ");
        double minTimeStep = double.Parse(Console.ReadLine() ?? "0.01", System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine();

        Console.Write("Enter the information (text) you want to convert into a signal: ");
        string information = Console.ReadLine() ?? string.Empty;
        Console.WriteLine();

        ISignalModulation modulator;
        if (modType == 0)
        {
            modulator = new FrequencyModulation();
        }
        else if (modType == 1)
        {
            modulator = new AmplitudeModulation();
        }
        else
        {
            modulator = new FrequencyModulation();
            logger.Log($"Invalid modulation type entered.\nDefault type applied: {nameof(FrequencyModulation)}", LogType.Warning);
        }

        TransiverProperties properties = new TransiverProperties(kf, sampleRate, information, minTimeStep);
        Signal signal = modulator.Modulate(data, properties);

        logger.Log("Success! The signal has been modulated successfully.");

        foreach (var vector in signal.Coordinates)
        {
            Console.WriteLine($"{signal.Coordinates.IndexOf(vector)}. Vector: {vector.X:F3}, {vector.Y:F3}");
        }
    }
}
```
## Future Plans

WAV Converter — export generated signals to .wav format

JSON Configuration — save and load modulation parameters

Digital Modulation Support — add BPSK, QPSK, FSK, and others

GUI Tool — optional graphical interface for visualization and testing

## License
This project is licensed under the **GNU General Public License v3.0 (GPL-3.0)**.
