using System;
using SignalLab.Core.Modulation;
using SignalLab.Core.Data;
using SignalLab.Core.Logging;
using SignalLab.Core.IO;

namespace SignalLab.Core.CLI.Commands;

public static class GenerateSignalCommand
{
    public static void GenerateSignal()
    {
        ILogger consoleLogger = new ConsoleLogger();
        ILogger fileLogger = new FileLogger();
        
        SignalData data = new SignalData();
        
        data.Amplitude = ReadValue("Enter the signal amplitude: ", 2.0);
        data.Frequency = ReadValue("Enter the signal frequency: ", 44100.0);
        data.Phase = ReadValue("Enter the initial signal phase: ", 0.0);
        data.Time = ReadValue("Enter the signal duration (in seconds): ", 1.0);

        int modType = ReadValue("Select modulation type (0 - FM, 1 - AM): ", 0);

        Console.WriteLine("Enter transceiver settings:");
        double kf = ReadValue("Enter frequency sensitivity (kf): ", 100.0);
        double sampleRate = ReadValue("Enter sampling rate: ", 44100.0);
        double minTimeStep = ReadValue("Enter minimum time step (affects accuracy and performance): ", 0.01);

        string information = ReadValue("Enter the information (text) you want to convert into a signal: ", "");

        ISignalModulation modulator = modType switch
        {
            0 => new FrequencyModulation(),
            1 => new AmplitudeModulation(),
            _ => new FrequencyModulation()
        };
        if (modType != 0 && modType != 1)
        {
            consoleLogger.Log($"Invalid modulation type entered. Default type applied: {nameof(FrequencyModulation)}", LogType.Warning);
        }

        TransceiverProperties properties = new TransceiverProperties(kf, sampleRate, information, minTimeStep);
        Signal signal = modulator.Modulate(data, properties);
        
        foreach (var vector in signal.Coordinates)
        {
            fileLogger.Log($"{signal.Coordinates.IndexOf(vector)}. Vector: {vector.X:F3}, {vector.Y:F3}");
        }

        consoleLogger.Log("Success! The signal has been modulated successfully.");

        string choice = ReadValue("Do you want to write all the signal data to the .json? (Y,n): ", "n");
        if (choice.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            string path = ReadValue("Enter the path to a JSON file: ", "signals.json");
            JsonExporter.ExportSignals(path, signal.Coordinates);
        }
    }

    private static T ReadValue<T>(string prompt, T defaultValue)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        Console.WriteLine();

        if (typeof(T) == typeof(int))
        {
            if (int.TryParse(input, out int intResult))
                return (T)(object)intResult;
            return defaultValue;
        }

        if (typeof(T) == typeof(double))
        {
            if (double.TryParse(input, System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture, out double doubleResult))
                return (T)(object)doubleResult;
            return defaultValue;
        }

        if (typeof(T) == typeof(string))
        {
            return (T)(object)(input ?? (string)(object)defaultValue);
        }

        if (typeof(T) == typeof(bool))
        {
            if (bool.TryParse(input, out bool boolResult))
                return (T)(object)boolResult;
            return defaultValue;
        }
        
        return defaultValue;
    }

}
