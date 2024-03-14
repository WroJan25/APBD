Console.WriteLine("Hello, World!");
Console.WriteLine(GetAVG([1.0,2.0,3.0,4.0,5.0]));
Console.WriteLine(GetMax([1,2,3,4,5]));
static double GetAVG(double[] tab)
{
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