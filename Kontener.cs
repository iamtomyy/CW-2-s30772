namespace CW2;

public class Kontener
{
    private static int licznik { get; set;}
    public double masa {get; set;}
    public double wysokosc {get; set;}
    public double WagaWlasna {get; set;}
    public double glebokosc {get; set;}
    public string numerSeryjny {get; set;}
    public double MaxLadownosc {get; set;}

    public Kontener(string typKontenera)
    {
        numerSeryjny = $"KON-{typKontenera}-{licznik++}";
    }
}