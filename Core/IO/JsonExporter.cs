using SignalLab.Core.Data;
using System.Text.Json;

namespace SignalLab.Core.IO;

public static class JsonExporter
{
    public static void ExportSignals(string path, List<Vector2> signals)
    {
        var exportData = new { signals };

        var jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(exportData, jsonOptions);
        File.WriteAllText(path, jsonString);
    }
}
