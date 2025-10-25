using SignalLab.Core.Data;
using SignalLab.Core.Utils;
using SignalLab.Core.Logging;

namespace SignalLab.Core.Modulation;

public class FrequencyModulation : ISignalModulation
{
    public Signal Modulate(SignalData signalData, TransceiverProperties properties)
    {
        try
        {
            // S(ti)=A⋅sin(ϕ(ti))
            List<Vector2> resultCoordinates = new List<Vector2>();
            List<double> phases = new List<double>();

            Vector2 firstVector = new Vector2(0.0, signalData.Amplitude);
            double startPhase = signalData.Phase;

            resultCoordinates.Add(firstVector);
            phases.Add(startPhase);

            string binaryInf = BinaryConverter.ConvertToBinary(properties.Information);
            List<int> infBits = DecoderToInt.DecodeString(binaryInf);

            if (infBits.Count == 0)
                infBits.Add(0);

            int index = 0;
            double phase = startPhase;

            for (double time = 0.0; time < signalData.Time; time += properties.MinTimeStep)
            {
                int bit = infBits[index % infBits.Count];
                phase = GetCurrentPhase(phase, signalData.Frequency, bit, properties.Kf, properties.DeltaTime);
                double s = signalData.Amplitude * Math.Sin(phase);
                var vector2 = new Vector2(s, time);
                resultCoordinates.Add(vector2);
                index++;
            }

            Signal resultSignal = new Signal(signalData, resultCoordinates);
            return resultSignal;
        }
        catch (Exception e)
        {
            ConsoleLogger logger = new ConsoleLogger();
            logger.Log(e.Message, LogType.Error);
            throw;
        }
    }
    private double GetCurrentPhase(double previousPhase, double carrierFrequency, int bitValue, double kf,
        double deltaTime)
    {
        // ϕ(ti)=ϕ(ti−1)+2πfc⋅Δt+kf⋅m(ti)⋅Δt
        return previousPhase + 2 * Math.PI * carrierFrequency * deltaTime + kf * bitValue * deltaTime;
    }
}