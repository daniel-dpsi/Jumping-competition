public class Skakalnica
{
    
    private static List<Skok> skoki = new List<Skok>();
    private static List<int> zmag = new List<int>();

    static void Main()
    {
        int zap_st = 0, skakalci = 0;

        var datum = DateTime.Now;
        Console.WriteLine(datum);

       
        vnos_podatkov();
        izpis_podatkov();
        zmaga();

    }

    static void vnos_podatkov()
    {
        Random random = new Random();

        int zap_st = 0, skakalci = 0;

        Console.WriteLine("Number of competitors: ");
        skakalci = (int.Parse(Console.ReadLine()));

        //loop ki pridobi vse potrebne podatke za stevilo tekmovalcev (-> skakalci)
        for (int i = 0; i < skakalci; i++)
        {
            zap_st += 1;

            Console.Write($"Competitor nr {zap_st}. - ");
            var ime = Console.ReadLine();

            //program sam doloci vrednost po nakljucju v rangu st. 170 do 225
            int daljava = random.Next(10, 25);

            //posredujem vnosene podatke v list skoki in zmag
            zmag.Add(daljava);
            skoki.Add(new Skok { Zap_st = zap_st, Ime = ime, Daljava = daljava });
        }
    }


    static void izpis_podatkov()
    {
       Console.Clear();
        //izpis vseh podatkov tekmovalcev
        foreach (var a in skoki)
        {
            Console.WriteLine("-------------");
            Console.WriteLine($"{a.Zap_st}.");
            Console.WriteLine($"{a.Ime}");
            Console.WriteLine($"{a.Daljava}");
            Console.WriteLine("-------------");
        }

    }

    static void zmaga()
    {
        //uporaba LINQ-a za preverjanje najdaljse dolzine (najvisja vrednost)
        int zmagovalec = zmag.AsQueryable().Max();
        Console.Write($"max length: {zmagovalec} meters\n");

        foreach (var b in skoki)
        {
            //metoda ki poveze daljavo zmagovalca z ostalimi podatki zmagovalca in jih izpise
            if (b.Daljava == zmagovalec)
            {
                Console.Write($"\nThe winner is competitor {b.Zap_st}. ");
                Console.Write($"{b.Ime} ");
                Console.Write($"With a {b.Daljava}m");
                Console.Write("\n");
            }
        }

    }

    struct Skok
    {
        public int Zap_st { get; set; }
        public string Ime { get; set; }
        public int Daljava { get; set; }
    }
}
