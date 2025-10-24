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
