Console.WriteLine("Hello, World!");
Console.WriteLine(GetAVG([1.0,2.0,3.0,4.0,5.0]));
Console.WriteLine(GetMax([1,2,3,4,5]));
static double GetAVG(double[] tab)
{
    int[] liczby = { 10, 20, 30, 40, 50 };
    double srednia = ObliczSrednia(liczby);
    int maksimum = ZnajdzMaksimum(liczby);

    Console.WriteLine("Średnia wynosi: " + srednia);
    Console.WriteLine("Maksimum wynosi: " + maksimum);
    double sum = 0;
    foreach (var VARIABLE in tab)
    {
        sum += VARIABLE;
    }
    return sum / tab.Length;

 

}
static int GetMax(int[] arr)
{
    int max = 0;

    foreach (var liczba in arr)
    {
        if (max<liczba)
        {
            max = liczba;
        }   
    }

    return max;
}

static double ObliczSrednia(int[] tablica)
{
    if (tablica.Length == 0)
    {
        return 0; // Jeśli tablica jest pusta, zwracamy średnią jako 0
    }

    int suma = 0;
    foreach (int liczba in tablica)
    {
        suma += liczba;
    }

    return (double)suma / tablica.Length;
}
static int ZnajdzMaksimum(int[] tab)
{
    if (tab.Length == 0)
    {
        throw new ArgumentException("Tablica nie może być pusta.");
    }

    int maksimum = tab[0];
    foreach (int liczba in tab)
    {
        if (liczba > maksimum)
        {
            maksimum = liczba;
        }
    }

    return maksimum;
}