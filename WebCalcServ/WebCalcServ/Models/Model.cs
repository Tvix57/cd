namespace WebCalcServ.Models;

public class Model
{
    public string? RawString { get; set; }

    public double Result { get; private set; }

    private double _polishStack;
}
