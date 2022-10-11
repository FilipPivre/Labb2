using Labb2;

bool run = true;
int användarensVal;
var Vitvaror = new List<Products> { new Products("Mikrovågsugn", "Philips", false, 1), new Products("Ugn", "Smeg", true, 2), new Products("Brödrost", "KitchenAid", true, 3) };
while (run)
{
    Menu();
    Int32.TryParse(Console.ReadLine(), out användarensVal);


    switch (användarensVal)
    {
        case 1:
            AnvändKöksapparat();
            Console.ReadKey();
            break;
        case 2:
            läggtill();
            break;
        case 3:
            SkrivUtKöksapparater();
            Console.ReadKey();
            break;

        case 4:
            Tabort();
            Uppdateralista();
            break;
        case 5:
            run = false;
            break;
    }

}


void Menu()
{
    Console.WriteLine("======KÖKET======\n" +
        "1. Använd köksapparat\n" +
        "2. Lägg till köksapparat\n" +
        "3. Lista köksapparater\n" +
        "4. Ta bort köksapparat\n" +
        "5. Avsluta");
    Console.Write("Ange val:\n>");
}
void AnvändKöksapparat()
{

    int köksVal;

    Console.WriteLine("Välj köksapparat:");
    foreach (var item in Vitvaror)
    {
        Console.WriteLine($"{item.Id}. {item.Type}");
    }
    Console.Write("Ange val:\n>");
    Int32.TryParse(Console.ReadLine(), out köksVal);

    var valet = Vitvaror.Where(x => x.Id == köksVal).FirstOrDefault();
    if (valet == null)
    {
        Console.WriteLine("Fel val");
        AnvändKöksapparat();
    }
    else
    {
        if (valet.IsFunctioning)
        {

            Console.WriteLine($"Använder {valet.Type}");
        }
        else
        {
            Console.WriteLine($"{valet.Type} är trasig.");
        }

    }

}


void läggtill()
{
    string type, brand;
    bool isfunctioning = true;
    int id = Vitvaror.Count + 1;
    Console.WriteLine("Lägg till köksapparat:");
    Console.Write("Typ: \n>");
    type = Console.ReadLine();
    Console.Write("Märke: \n>");
    brand = Console.ReadLine();
Label:
    Console.Write("Fungerar produkten j/n:\n>");
    string isfunktion = Console.ReadLine().ToLower();
    if (isfunktion == "n")
    {
        isfunctioning = false;
        var NyVitvara = new Products(type, brand, isfunctioning, id);
        Vitvaror.Add(NyVitvara);
    }
    else if (isfunktion == "j")
    {
        var NyVitvara = new Products(type, brand, isfunctioning, id);
        Vitvaror.Add(NyVitvara);
    }
    else
    {
        goto Label;
    }
    Console.WriteLine("Tillagd!");

}
void SkrivUtKöksapparater()
{
        Console.WriteLine(
       "-------KÖKSAPPARATER-------\n" +
       "***************************");
    foreach (var köksapparat in Vitvaror)
    {      
        Console.WriteLine($"" +
            $"Typ: {köksapparat.Type}\n" +
            $"Märke: {köksapparat.Brand}");

        if (köksapparat.IsFunctioning == true)
        {
            Console.WriteLine("Fungerar: Ja");
        }
        else if (köksapparat.IsFunctioning == false)
        {
            Console.WriteLine("Fungerar: Nej");
        }
        else
        {
            Console.WriteLine("Finns ingen köksapparat");
        }
        Console.WriteLine($"-----------------------------------");
    }
}
void Tabort()
{
    int tabort = 0;
    if (Vitvaror.Count == 0)
    {
        Console.WriteLine("Finns inget att ta bort.");
    }
    else
    {
        Console.WriteLine("Vilken köksapparat vill du ta bort?");

        foreach (var item in Vitvaror)
        {
            Console.WriteLine($"{item.Id}. {item.Type}");
        }
        Console.Write("Ange val\n>");
        Int32.TryParse(Console.ReadLine(), out tabort);

        var valet = Vitvaror.Where(x => x.Id == tabort).FirstOrDefault();
        Vitvaror = Vitvaror.Where(x => x.Id != tabort).ToList();
        if (valet == null)
        {
            Console.WriteLine("-Fel, använd en av siffrorna som är ovanstående. Tryck ENTER för att forstätta");
            Console.ReadKey();
            Tabort();
        }
        else
        {
            Console.WriteLine($"{valet.Type} har tagits bort.");

        }
    }

}
void Uppdateralista()
{
    int id = 1;
    foreach (var item in Vitvaror)
    {
        item.Id = id;
        id++;
    }
}

