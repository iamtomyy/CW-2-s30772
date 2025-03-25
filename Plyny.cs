namespace CW2;

public class Plyny : Kontener, IHazardNotifier
{
    private bool isNiebezpieczny { get; set; }

    public Plyny(bool isNiebezpieczny, double maxLadownosc, double wagaWlasna, double wysokosc, double glebokosc)
        : base("L")
    {
        this.isNiebezpieczny = isNiebezpieczny;
        this.MaxLadownosc = maxLadownosc;
        this.WagaWlasna = wagaWlasna;
        this.wysokosc = wysokosc;
        this.glebokosc = glebokosc;
        this.masa = 0;
    }

    public void zaladuj(double waga)
    {
        double maxKG = 0;
        if (isNiebezpieczny)
        {
            maxKG = MaxLadownosc * 0.5;
        }
        else
        {
            maxKG = MaxLadownosc * 0.9;
        }

        if (waga + masa > maxKG)
        {
            wyslijWiadomosc("Przeładowano kontener", numerSeryjny);
            throw new Exception("Przeładowano kontener");
        }

        masa += waga;
    }

    public void rozladuj()
    {
        masa = 0;
    }

    public void wyslijWiadomosc(string wiadomosc, string numerKontenera)
    {
        Console.WriteLine($"[ALERT - {numerKontenera}]: {wiadomosc}");
    }
}