using System;

namespace APBD3
{
    // Wyjątek rzucany przy przekroczeniu maksymalnej ładowności kontenera


    public class Kontener
    {
        public double MasaLadunku { get; protected set; }
        public double Wysokosc { get; protected set; }
        public double MasaKontenera { get; protected set; }
        public double Glebokosc { get; protected set; }
        public string NumerSeryjny { get; protected set; }
        public double MaksymalnaLadownosc { get; protected set; }

        protected Kontener(double masaLadunku, double wysokosc, double masaKontenera,
            double glebokosc, double maksymalnaLadownosc)
        {
            MasaLadunku = masaLadunku;
            Wysokosc = wysokosc;
            MasaKontenera = masaKontenera;
            Glebokosc = glebokosc;
            NumerSeryjny = "KON";
            MaksymalnaLadownosc = maksymalnaLadownosc;
        }

        public virtual void Oproznienie_Zaladunku()
        {
            MasaLadunku = 0;
        }

        public virtual void Zaladowanie_Kontenera(double nowaMasa)
        {
            if (MasaLadunku + nowaMasa > MaksymalnaLadownosc)
                throw new OverfillException("Przekroczono maksymalną ładowność kontenera.");
            else
                MasaLadunku += nowaMasa;
        }

        public override string ToString()
        {
            return $"Kontener: Numer seryjny: {NumerSeryjny}, Masa ładunku: " +
                   $"{MasaLadunku}, Wysokość: {Wysokosc}, Maksymalna ładowność: {MaksymalnaLadownosc}";
        }
    }
}