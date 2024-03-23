namespace APBD3;

public class KontenerChlodniczy: Kontener,IHazardNotifier
{
    protected Product Produkt;
    protected int temperaturaWKontenerze;

    public KontenerChlodniczy(double masaLadunku, double wysokosc, double masaKontenera, 
        double glebokosc, double maksymalnaLadownosc, int temperaturaWKontenerze, int numer) : 
        base(masaLadunku, wysokosc, masaKontenera, glebokosc, maksymalnaLadownosc)
    {
        this.temperaturaWKontenerze = temperaturaWKontenerze;
        Ustaw_Numer(numer);
    }

    public void NotifyDanger(string numerSeryjny)
    {
        Console.WriteLine($"[ALERT] Za niska temperatura w kontenerze o numerze:{numerSeryjny} ");
    }

    public void UstawTemperature(int nowaTemp)
    {
        this.temperaturaWKontenerze = nowaTemp;
    }

    public void ZaladujProdukt(Product product)
    {
        if (temperaturaWKontenerze>product.Temperatura)
        {
            NotifyDanger(this.NumerSeryjny);
            return;
        }
        
        this.Produkt = product;
        
    }
    public void Ustaw_Numer(int numer)
    {
        NumerSeryjny +=  "-C-" + numer;
    }
    public override string ToString()
    {
        return $"Kontener chłodniczy: Numer seryjny: {NumerSeryjny}, Masa ładunku: {MasaLadunku}, Wysokość: {Wysokosc}, Temperatura w kontenerze: " +
               $"{temperaturaWKontenerze}, Maksymalna ładowność: {MaksymalnaLadownosc}, Ładunek: {Produkt.Nazwa}";
    }

    public override void Oproznienie_Zaladunku()
    {
        Produkt = new Product("", 1000000);
        MasaLadunku = 0;

    }
}