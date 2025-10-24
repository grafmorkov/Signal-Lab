namespace SignalLab.Core.Data;

public interface ISignalDataProvider
{
    double Amplitude { get; }
    double Frequency { get; }
    double Phase { get; }
    double Time { get; }
}

public class SignalData : ISignalDataProvider
{
    private double _amplitude;
    private double _frequency;
    private double _phase;
    private double _time;

    public double Amplitude
    {
        get => _amplitude;
        set
        {
            _amplitude = value;
            CheckValue(0.0, 1000.0, _amplitude);
        }
    }

    public double Frequency
    {
        get => _frequency;
        set
        {
            _frequency = value;
            CheckValue(-1.0, 100000.0, _frequency);
        }
    }

    public double Phase
    {
        get => _phase;
        set
        {
            _phase = value;
            while (_phase >= 2 * Math.PI)
                _phase -= 2 * Math.PI;
            while (_phase < 0)
                _phase += 2 * Math.PI;
        }
    }

    public double Time
    {
        get => _time;
        set
        {
            _time = value;
            CheckValue(0.0, 60.0, _time);
        }
    }

    private void CheckValue(double minValue, double maxValue, double value)
    {
        if (value < minValue || value > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"{value}, выходит за рамки допустимых значений!");
        }
    }
}