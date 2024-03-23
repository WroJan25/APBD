using System.Collections;

namespace APBD3;

public class Kontenerowiec
{
    public List<Kontener> RejestrKonenerow = new List<Kontener>();
    public double Predkosc;
    public int MaksLiczbaKontenrow;
    public double MaksMasaZaladunku;

    public Kontenerowiec(double predkosc, int maksLiczbaKontenrow, double maksMasaZaladunku)
    {
        Predkosc = predkosc;
        MaksLiczbaKontenrow = maksLiczbaKontenrow;
        MaksMasaZaladunku = maksMasaZaladunku;
    }

    public void DodajKontener(Kontener kontener)
    {
        double suma = 0;
        for (int i = 0; i < RejestrKonenerow.Count; i++)
        {
            suma += RejestrKonenerow[i].MasaKontenera+RejestrKonenerow[i].MasaLadunku;

        }
        if (RejestrKonenerow.Count+1>MaksLiczbaKontenrow)
        {
            Console.WriteLine("Nie można zaokrętować kolejnego kontenera, więcej się już nie zmieści");
        }
        else if (suma+kontener.MasaKontenera+kontener.MasaLadunku>MaksMasaZaladunku*1000)
        {
            Console.WriteLine("Nie można zaokrętować tego kontenera, przekroczona zostałaby maksymalna masa załadunku");
        }
        else
        {
            RejestrKonenerow.Add(kontener);
        }
    }

    public void DodajWiększyZaładunekKontenerow(List<Kontener> zaladunek)
    {
        for (int i = 0; i < zaladunek.Count; i++)
        {
            DodajKontener(zaladunek[i]);
            
        }
        
    }
    public override string ToString()
    {
 
        string konteneryInfo = string.Join(Environment.NewLine, RejestrKonenerow);
        return $"Kontenerowiec: Prędkość: {Predkosc}, Maksymalna liczba kontenerów: {MaksLiczbaKontenrow}, Maksymalna masa załadunku: {MaksMasaZaladunku}, Zaladunek:{Environment.NewLine}{konteneryInfo}";
    }
    
}