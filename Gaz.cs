namespace CW2;

public class Gaz : Kontener, IHazardNotifier
{
    public double Cisnienie { get; set; }

    public Gaz(double cisnienie, double maxLadownosc, double wagaWlasna, double wysokosc, double glebokosc)
        : base("G")
    {
        this.Cisnienie = cisnienie;
        this.MaxLadownosc = maxLadownosc;
        this.WagaWlasna = wagaWlasna;
        this.wysokosc = wysokosc;
        this.glebokosc = glebokosc;
        this.masa = 0;
    }

    public void zaladuj(double waga)
    {
        if (waga + masa > MaxLadownosc)
        {
            wyslijWiadomosc("Przekroczono max ładowność", numerSeryjny);
            throw new Exception($"Przekroczono max ładowność kontenera {numerSeryjny}");
        }

        masa += waga;
    }

    public void rozladuj()
    {
        masa = masa * 0.05;
    }

    public void wyslijWiadomosc(string wiadomosc, string numerKontenera)
    {
        Console.WriteLine($"[GAZ ALERT - {numerKontenera}]: {wiadomosc}");
    }
}