

using System.Collections;
using APBD3;

int licznik=0;

KontenerNaPlyn kontener1 = new KontenerNaPlyn(0, 200, 300, 150, 2000, licznik++, true);
KontenerNaGaz kontener2 = new KontenerNaGaz(0, 220, 350, 160, 2500, 2, licznik++);
KontenerChlodniczy kontener3 = new KontenerChlodniczy(0, 180, 280, 130, 1800, -5, licznik++);
KontenerNaPlyn kontener4 = new KontenerNaPlyn(0, 200, 300, 150, 2000, licznik++, true);
KontenerNaGaz kontener5 = new KontenerNaGaz(0, 220, 350, 160, 2500, 2, licznik++);
Product mleko = new Product("Mleko", -3);
kontener3.ZaladujProdukt(mleko);
kontener3.Zaladowanie_Kontenera(800);
List<Kontener> konteneryZZewnatrz = new List<Kontener>();
konteneryZZewnatrz.Add(kontener4);
konteneryZZewnatrz.Add(kontener5);

Kontenerowiec statek = new Kontenerowiec(30, 100, 50000);


statek.DodajKontener(kontener1);
statek.DodajKontener(kontener2);
statek.DodajKontener(kontener3);


statek.RejestrKonenerow.Remove(kontener1);


for (int i = 0; i < statek.RejestrKonenerow.Count; i++)
{
 Console.WriteLine(statek.RejestrKonenerow[i].ToString());
}

for (int i = 0; i < statek.RejestrKonenerow.Count; i++)
{
 if (statek.RejestrKonenerow[i].NumerSeryjny.Equals("Kon-C-2"))
 {
  statek.RejestrKonenerow.Remove(statek.RejestrKonenerow[i]);
  statek.DodajKontener(kontener1);
 }
 
}
Kontenerowiec innyStatek = new Kontenerowiec(35, 80, 60000);
Kontener tmp = statek.RejestrKonenerow[0];
statek.RejestrKonenerow.Remove(statek.RejestrKonenerow[0]);
innyStatek.DodajKontener(tmp);
statek.RejestrKonenerow[0].Oproznienie_Zaladunku();
statek.DodajWiększyZaładunekKontenerow(konteneryZZewnatrz);
Console.Write(statek.ToString());
