namespace APBD3;

public class  KontenerNaPlyn : Kontener,IHazardNotifier
{
    protected readonly Boolean czyNiebezpieczny;
  

    public KontenerNaPlyn(double masaLadunku, double wysokosc, double masaKontenera, 
        double glebokosc, double maksymalnaLadownosc,int numer,Boolean czyNiebezpieczny) : 
        base(masaLadunku, wysokosc, masaKontenera, glebokosc, maksymalnaLadownosc)
    {
        this.czyNiebezpieczny = czyNiebezpieczny;
        this.Ustaw_Numer(numer);
    }
    public void Ustaw_Numer(int numer)
    {
       NumerSeryjny += "-L-" + numer;
    }
    
    public override void Zaladowanie_Kontenera(double masaLadunku)
    {
        if (masaLadunku > MaksymalnaLadownosc)
            throw new OverfillException("Przekroczono maksymalną ładowność kontenera.");

        if (czyNiebezpieczny)
        {
            if (masaLadunku > MaksymalnaLadownosc * 0.5)
            {
             NotifyDanger(NumerSeryjny);
            throw new OverfillException("Przekroczono maksymalną ładowność dla niebezpiecznego ładunku.");
            }
        }
        else
        {
            if (masaLadunku > MaksymalnaLadownosc * 0.9)
            {
                NotifyDanger(NumerSeryjny);
                throw new OverfillException("Przekroczono maksymalną ładowność kontenera.");
            }
        }

        this.MasaLadunku = masaLadunku;
    }
    
    public void NotifyDanger(string numerSeryjny)
    {
        Console.WriteLine($"[ALERT] Niebezpieczna sytuacja w kontenerze o numerze:{numerSeryjny} ");
    }
    public override string ToString()
    {
        return $"Kontener na płyny: Numer seryjny: {NumerSeryjny}, Masa ładunku: " +
               $"{MasaLadunku}, Wysokość: {Wysokosc}, Maksymalna ładowność: {MaksymalnaLadownosc}";
    }
}