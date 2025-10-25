namespace SignalLab.Core.Data;

public class TransceiverProperties
{
    public double Kf { get; private set; }
    public double SampleRate { get; private set; }
    public string Information { get;private set; }
    public double MinTimeStep { get; private set; }
    public double DeltaTime => 1.0 / SampleRate;

    public TransceiverProperties(double kf, double sampleRate, string information, double minTimeStep)
    { 
        Kf = kf;
        SampleRate = sampleRate;
        Information = information;
        MinTimeStep = minTimeStep;
    }
    public TransceiverProperties()
    {
        Kf = 100;
        SampleRate = 44100;
        Information = string.Empty;
        MinTimeStep = 0.01;
    }
}