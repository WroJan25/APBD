namespace APBD3;

public class KontenerNaGaz: Kontener,IHazardNotifier
{
    protected double Cisnienie;

    public KontenerNaGaz(double masaLadunku, double wysokosc, double masaKontenera, 
        double glebokosc, double maksymalnaLadownosc,double cisnienie,int numer) :
        base(masaLadunku, wysokosc, masaKontenera, glebokosc, maksymalnaLadownosc)
    {
        this.Cisnienie = cisnienie;
        Ustaw_Numer(numer);
    }
    public void Ustaw_Numer(int numer)
    {
        this.NumerSeryjny = base.NumerSeryjny + "-G-" + numer;
    }

    public override void Oproznienie_Zaladunku()
    {
        this.MasaLadunku = MasaLadunku * 0.05;
    }
    public override void Zaladowanie_Kontenera(double masaLadunku)
    {
        if (masaLadunku + this.MasaLadunku > MaksymalnaLadownosc)
        {
            NotifyDanger(NumerSeryjny);
            throw new OverfillException("Przekroczono maksymalną ładowność kontenera.");
            
        }
        this.MasaLadunku += masaLadunku;
    }
    public void NotifyDanger(string numerSeryjny)
    {
        Console.WriteLine($"[ALERT] Niebezpieczna sytuacja w kontenerze o numerze:{numerSeryjny} ");
    }
    public override string ToString()
    {
        return $"Kontener na gaz: Numer seryjny: {NumerSeryjny}, Masa ładunku: {MasaLadunku}, Wysokość: {Wysokosc}, " +
               $"Cisnienie: {Cisnienie}, Maksymalna ładowność: {MaksymalnaLadownosc}";
    }
}