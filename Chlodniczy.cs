namespace CW2;

public class Chlodniczy : Kontener
{
    public string produkt {get; set;}
    public double temperatura {get; set;}

    public static Dictionary<string, double> dictionary = new Dictionary<string, double>()
    {
        { "Banany", 13.3 },
        { "Czekolady", 18 },
        { "Ryby", 2 },
        { "Mięsa", -15 },
        { "Lody", -18 },
        { "Pizze", -30 },
        { "Sery", 7.2 },
        { "Kiełbaski", 5 },
        { "Masła", 20.5 },
        { "Jaja", 19 }
    };

    public Chlodniczy(string produkt, double temperatura, double maxLadownosc, double wagaWlasna, double wysokosc, double glebokosc) : base("C")
    {
        this.produkt = produkt;
        this.temperatura = temperatura;
        this.MaxLadownosc = maxLadownosc;
        this.WagaWlasna = wagaWlasna;
        this.wysokosc = wysokosc;
        this.glebokosc = glebokosc;
        
        if (!dictionary.ContainsKey(produkt))
        {
            throw new Exception("Nieznany produtk");
        }

        double minTemp = dictionary[produkt];
        if (temperatura < minTemp)
        {
            throw new Exception("Temperatura kontenera jest zbyt niska!");
        }
    }
    public void zaladuj(double waga, string produkt)
    {
        if (produkt.ToLower() != this.produkt)
            throw new Exception($"Ten kontener może przechowywać tylko: {this.produkt}");

        if (waga + masa > MaxLadownosc)
            throw new Exception($"Za dużo ładunku – maksymalna pojemność to {MaxLadownosc} kg");

        masa += waga;
    }

    public void rozladuj()
    {
        masa = 0;
    }
}