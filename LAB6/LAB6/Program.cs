using System.Formats.Asn1;
using System.Reflection.Metadata;
using System.Security;

internal class Programm
{
    private static void Main(string[] args)
    {
        Cat barsik = new("Барсик");
        barsik.meow();
        barsik.meow(3);
    }
}