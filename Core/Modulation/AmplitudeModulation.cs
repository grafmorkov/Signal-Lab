using SignalLab.Core.Data;
using SignalLab.Core.Utils;
using SignalLab.Core.Logging;

namespace SignalLab.Core.Modulation;
public class AmplitudeModulation : ISignalModulation
{
    public Signal Modulate(SignalData signalData, TransiverProperties properties)
    {
        ConsoleLogger logger =  new ConsoleLogger();
        try
        {
            // S(t)=[1+m(t)]⋅sin(2πfct); m(t) - information
            List<Vector2> resultCoordinates = new List<Vector2>();
                
            string binaryInf = BinaryConverter.ConvertToBinary(properties.Information);
            List<int> infBits = DecoderToInt.DecodeString(binaryInf);
                
            if (infBits.Count == 0)
                infBits.Add(0);
                
            int index = 0;

            for (double time = 0.0; time < signalData.Time; time += properties.MinTimeStep)
            {
                int bit = infBits[index % infBits.Count];
                double m = bit;
                double amplitude = signalData.Amplitude * (1 + m); // [1+m(t)] * base
                double s = amplitude * Math.Sin(2 * Math.PI * signalData.Frequency * time + signalData.Phase);
                var vector2 = new Vector2(s, time);
                resultCoordinates.Add(vector2);
                index++;
            }

            Signal resultSignal = new Signal(signalData, resultCoordinates);
            return resultSignal;
        }
        catch (Exception e)
        {
            logger.Log(e.Message, LogType.Error);
            throw;
        }
    }
}