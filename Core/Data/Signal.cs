namespace SignalLab.Core.Data;

public class Signal
{
    private SignalData _data;
    private List<Vector2> _coordinates;

    public Signal(SignalData data, List<Vector2> coordinates)
    {
        _data = data;
        _coordinates = coordinates;
    }

    public Signal()
    {
        _data = new SignalData();
        _coordinates = new List<Vector2>();
    }

    public List<Vector2> Coordinates => _coordinates;
    public SignalData Data => _data;
}