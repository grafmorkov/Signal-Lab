using SignalLab.Core.Data;

namespace SignalLab.Core.Modulation;

public interface ISignalModulation
{
    Signal Modulate(SignalData signalData, TransiverProperties properties);
}