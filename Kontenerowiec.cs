namespace CW2;

public class Kontenerowiec
{
    public List<Kontener> kontenery = new List<Kontener>();
    public string nazwa;
    public double maxPredkosc {get; set;}
    public int maxKontererow {get; set;}
    public double maxWaga {get; set;}
    
    public void zaladujKontener(Kontener k)
    {
        if (kontenery.Count >= maxKontererow)
        {
            Console.WriteLine("Kontenerowiec zawiera za duzo kontenerow.");
        }

        double sumaWag = kontenery.Sum(k => k.masa + k.WagaWlasna);
        double wagaKontenerowca = sumaWag + k.masa + k.WagaWlasna;

        if (wagaKontenerowca > maxWaga * 1000)
        {
            Console.WriteLine("Waga kontenerowca jest zbyt duża!");
        }
        kontenery.Add(k);
    }
    
    public void zaladujKontenery(List<Kontener> kontenery)
    {
        foreach (var kontener in kontenery)
        {
            zaladujKontener(kontener);
        }
    }
    
    public void usunKontener(string numer)
    {
        kontenery.RemoveAll(k => k.numerSeryjny == numer);
    }
    
    public void zastapKontener(string numerDoZamiany, Kontener nowyKontener)
    {
        int i = kontenery.FindIndex(k => k.numerSeryjny == numerDoZamiany);
        if (i >= 0)
        {
            kontenery[i] = nowyKontener;
        }
    }
    
    public void przeniesKontener(Kontenerowiec inny, string numer)
    {
        var znaleziony = kontenery.FirstOrDefault(k => k.numerSeryjny == numer);
        if (znaleziony == null)
        {
            Console.WriteLine($"Nie znaleziono kontenera o numerze {numer}.");
        }

        inny.zaladujKontener(znaleziony);
        kontenery.Remove(znaleziony);
        Console.WriteLine($"Kontener: {numer} został przeniesiony.");
    }
    
    public void wypiszInfo()
    {
        Console.WriteLine("Informacje o statku:");
        Console.WriteLine($"Nazwa: {nazwa}");
        Console.WriteLine($"Prędkość: {maxPredkosc} węzłów");
        Console.WriteLine($"Kontenery: {kontenery.Count}/{maxKontererow}");
        Console.WriteLine($"Waga: {kontenery.Sum(k => k.masa + k.WagaWlasna)} kg / {maxWaga * 1000} kg");
        Console.WriteLine();
        Console.WriteLine("Informacje o kontenerach:");
        foreach (Kontener kontener in kontenery)
        {
            Console.WriteLine(kontener.ToString());
        }
    }
}