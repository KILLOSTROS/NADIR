using System;
using System.Threading;

namespace HlubinnyProtokol
{
    public class Hrac
    {
        public string Identifikator { get; set; }
        public bool ViZeJeRobot { get; set; }
        public bool ViktorVeri { get; set; }
        public bool MaSvetlici { get; set; }
        public bool GeneratorSpusten { get; set; }
        public DateTime CasStartu { get; set; }
        public int MaxSekundy { get; set; }

        public Hrac(string id, int limitSekund)
        {
            Identifikator = id;
            ViZeJeRobot = false;
            ViktorVeri = false;
            MaSvetlici = true;
            GeneratorSpusten = false;
            CasStartu = DateTime.Now;
            MaxSekundy = limitSekund;
        }

        public void UberCas(int sekundy)
        {
            CasStartu = CasStartu.AddSeconds(-sekundy);
        }

        public void VykresliStatus()
        {
            int zbyva = MaxSekundy - (int)(DateTime.Now - CasStartu).TotalSeconds;
            if (zbyva < 0) zbyva = 0;

            int carky = Math.Max(0, zbyva / 15);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[POSTAVA: {Identifikator} | INTEGRITA: ");
            for (int i = 0; i < carky; i++) Console.Write("#");
            for (int i = carky; i < 16; i++) Console.Write("-");
            Console.WriteLine($" | ZBYVA: {zbyva}s]");
            Console.ResetColor();
            Console.WriteLine(new string('=', 65));
        }

        public bool VyprselCas()
        {
            return (DateTime.Now - CasStartu).TotalSeconds >= MaxSekundy;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Hrac hrac = new Hrac("Subjekt-04", 240);
            int volba = 0;

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
  _   _    _    ____ ___ ____  
 | \ | |  / \  |  _ \_ _|  _ \ 
 |  \| | / _ \ | | | | || |_) |
 | |\  |/ ___ \| |_| | ||  _ < 
 |_| \_/_/   \_\____/___|_| \_\
   STANICE PATHOS-B // HLOUBKA 8 200 M
            ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\a");
            Pis("[VAROVANI: Tlakova prepazka sektoru 07 byla prolomena]");
            Pis("[ZACINA ODPOČET DO IMPLOZE CELÉHO KOMPLEXU]");
            Console.ResetColor();
            Thread.Sleep(2500);

            // 1. cast
            Console.Clear();
            hrac.VykresliStatus();
            Pis("Proberes se na dne servisni komory. Kolem nohou ti proudi ledova cerna voda.");
            Pis("V odrazu rozbite obrazovky vidis misto sve tvare jen zlutou diodu tezke helmy.");
            Pis("Kov kolem tebe stona pod gigantickym tlakem oceanu.");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Pis("Z vysilacky zachrci hlas: 'Halo?! Slysis me?! Tady Viktor z biologickeho useku!'");
            Pis("Viktor: 'Stanice se propada do prikopy! Musime do unikovych modulu, nebo je po nas!'");
            Console.ResetColor();

            Console.WriteLine("\nCo udelas?");
            Console.WriteLine("1 - Otevrit servisni diagnostiku sveho tela");
            Console.WriteLine("2 - Okamzite odpovedet Viktorovi a zahajit evakuaci");
            Console.WriteLine("3 - Ignorovat ho a nejprve zabezpecit mistnost zamkem");

            Console.Write("\nTvoje volba (1-3): ");
            int.TryParse(Console.ReadLine(), out volba);

            if (ZkontrolujKonecCasu(hrac)) return;

            Console.Clear();
            if (volba == 1)
            {
                hrac.ViZeJeRobot = true;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Pis("[DIAGNOSTIKA: Organicky subjekt 04 - STAV: MRTEV (pred 14 dny)]");
                Pis("[PROCESOR: Emulace lidskeho vedomi bezi na 87 % kapacity]");
                Console.ResetColor();
                Pis("Uvnitr citis ledovy chlad. Tvoje telo zemrelo, jsi jen kopie v ocelovem sasi.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Pis("Viktor: 'Proc mlcis?! Haló, potrebuju vedet, ze jsi na zivu!'");
                Console.ResetColor();
            }
            else if (volba == 2)
            {
                hrac.ViktorVeri = true;
                Pis("Zapinas komunikator: 'Tady jsem. Jdu k hlavnimu koridoru.'");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Pis("Viktor: 'Diky bohu! Uz jsem myslel, ze jsem tu zustal uplne sam.'");
                Console.ResetColor();
            }
            else
            {
                Pis("Otocis klicem nouzoveho zamku. Kovove platy se se skripenim zacvaknou.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Pis("Viktor: 'Co to delas?! Slysel jsem zamek! Neodrezavej me!'");
                Console.ResetColor();
            }
            Thread.Sleep(3000);

            // 2. cast
            Console.Clear();
            hrac.VykresliStatus();
            Pis("Vybihas do spojovaci chodby. Cestu do dalsi sekce ale blokuji masivni ocelova vrata.");
            Pis("Konzole hlasi: 'ZADEJTE 4-MISTNY PRISTUPOVY KOD DOHLIZITELE'.");
            Pis("Vedle lezi mrtvy technik s odznakem 'Dr. Vance' a jeho osobni zapisnik.");
            Pis("V zapisniku je text: 'Kdybych zapomnel kod k sektoru B: Je to rok narozeni me dcery (1994).'");

            Console.Write("\nZadej pristupovy kod z terminalu: ");
            string kod = Console.ReadLine();

            if (ZkontrolujKonecCasu(hrac)) return;

            Console.Clear();
            if (kod == "1994")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Pis("[KOD PRIJAT - HYDRAULIKA OTEVIRA PRUCHOD]");
                Console.ResetColor();
                Pis("Dvere se s hlasitym sykotem oteviraji.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Pis("[CHYBNY KOD - SPUSTEN NOUZOVY BYPASS (Zdrzeni 25 sekund)]");
                Console.ResetColor();
                Pis("Musel jsi rucne vypacit prevodovku, coz te stalo drahocenny cas a silu!");
                hrac.UberCas(25);
            }
            Thread.Sleep(3000);

            // 3. cast
            Console.Clear();
            hrac.VykresliStatus();
            Pis("Dostavas se k rozvodi energie pro hangary. Voda uz ti saha po kolena.");
            Pis("Hlavni svetla zhasla. Aby se otevrel vytah ke kapslim, potrebujes stavu.");
            Pis("Na rozvodne desce jsou tri paky a varovny stitek: 'PREPETI ODPALI REAKTOR'.");

            Console.WriteLine("\nCo udelas?");
            Console.WriteLine("1 - Nahodit zalozni baterie (bezpecne, ale pomale)");
            Console.WriteLine("2 - Pretizit jaderny transformator (okamzita stava, ale riziko poškozeni)");
            Console.WriteLine("3 - Nechat generator byt a pokusit se vylomit vytah pacidlem");

            Console.Write("\nTvoje volba (1-3): ");
            int.TryParse(Console.ReadLine(), out volba);

            if (ZkontrolujKonecCasu(hrac)) return;

            Console.Clear();
            if (volba == 1)
            {
                hrac.GeneratorSpusten = true;
                Pis("Pomalu zapinas zalozni clanky. Svetla zablikaji a stabilizuji se na nouzove cervene.");
                Pis("Vytah se rozjel.");
            }
            else if (volba == 2)
            {
                hrac.GeneratorSpusten = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Pis("Jiskry letaji po cele mistnosti! Transformator hvizdi.");
                Console.ResetColor();
                Pis("Energie naskocila okamzite, ale exploze kabelu ti poskodila cast senzoru.");
            }
            else
            {
                Pis("Zkousis pacit dvere sachty hrubou silou tveho mechanickeho tela.");
                Pis("Kov se ohyba, ale ztratil jsi drahocenne sekundy!");
                hrac.UberCas(30);
            }
            Thread.Sleep(3000);

            // 4. cast
            Console.Clear();
            hrac.VykresliStatus();
            Pis("Pred dvermi do hangaru narazis na Viktora. Je bledy, trese se a v ruce ma svetlici.");
            Pis("Mezi vami a unikovou komorou stoji Tvarovac — hruzna masa bio-gelu a lidskych těl.");
            Pis("Tato mutace je slepa, ale reaguje na sebemensi zvuk kroků a teplo.");

            Console.WriteLine("\nCo udelas?");
            Console.WriteLine("1 - Zhasnout oblek a plizit se vodou naprosto potichu");
            Console.WriteLine("2 - Vzit Viktorovi svetlici a odhodit ji do opacne sachty");
            Console.WriteLine("3 - Zapnout nahlas nouzovou vysilacku a odbehnout na druhou stranu");

            Console.Write("\nTvoje volba (1-3): ");
            int.TryParse(Console.ReadLine(), out volba);

            if (ZkontrolujKonecCasu(hrac)) return;

            Console.Clear();
            if (volba == 1)
            {
                Pis("Vypinas vsechny systemy. Jdete krok po kroku ledovou vodou.");
                if (hrac.ViktorVeri)
                {
                    Pis("Viktor te drzi za rameno a prosli jste v tichosti tesne vedle obludy.");
                }
                else
                {
                    Pis("Viktor v panice slapl na plech! Monstrum zarvalo, ale stihli jste vbehnout do vrat.");
                }
            }
            else if (volba == 2)
            {
                hrac.MaSvetlici = false;
                Pis("Skrtas svetlici a hazes ji daleko do vetraci sachty.");
                Pis("Tvarovac zbesile vystartuje za rudym svetlem. Cesta je volna.");
            }
            else
            {
                Pis("Nastavil jsi vysilacku na maximum a odhodil ji do rohu.");
                Pis("Monstrum ji rozdrtilo. Ziskali jste cas, ale ztratili spojeni s povrchem.");
            }
            Thread.Sleep(3000);

            // 5. cast
            Console.Clear();
            hrac.VykresliStatus();
            Pis("Stojite u posledni funkcni zachranne kapsle. Steny kolem praskaji pod tlakem 800 baru.");
            Pis("Displej kapsle blika cervene: 'VAROVANI: TLAKOVY KATAPULT UNESE POUZE 1 OSOBU'.");
            Pis("Viktor si vsimne poskozeneho krytu na tve pazi — vidi draty a titanovy skelet.");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Pis("Viktor: 'Ty... ty nejsi clovek! Ty jsi jenom zatraceny stroj!'");
            Pis("Viktor: 'Ja mam rodinu! Moje dcera na me ceka! Ty necitis nic, nech me odletet!'");
            Console.ResetColor();

            Console.WriteLine("\nCo udelas?");
            Console.WriteLine("1 - Ustoupit, pomoct Viktorovi dovnitr a odpalit ho k hladine");
            Console.WriteLine("2 - Srazit Viktora k zemi, zamknout se v kapsli a odletet sam");
            Console.WriteLine("3 - Pacidlem rozbit odpalovaci mechanismus kapsle");

            Console.Write("\nTvoje volba (1-3): ");
            int.TryParse(Console.ReadLine(), out volba);

            if (ZkontrolujKonecCasu(hrac)) return;

            Console.Clear();

            if (volba == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Pis("=== KONEC 1: ZACHOVANA HUMANITA ===");
                Console.ResetColor();
                Pis("Zaviras za Viktorem hermeticky poklop. Pres sklo vidis jeho sok a slzy vdeku.");
                Pis("Mackas tlacitko KATAPULT. Kapsle se se zableskem vymrstuje k hladine.");
                Pis("Zustavas sam v zaplavene mistnosti na dne sveta.");
                Pis("Steny se rozpadaji a voda se vali dovnitr. Tvoje obvody zhasinaji.");
                Pis("Zemrel jsi jako stroj, ale udelal jsi to nejlidstejsi rozhodnuti.");
            }
            else if (volba == 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Pis("=== KONEC 2: CHLADNY KOV ===");
                Console.ResetColor();
                Pis("Tvoje roboticke paže bez problemu srazi Viktora na zem. Vlezl jsi dovnitr a zamkl.");
                Pis("Katapult te vystreluje do temnoty oceanu. Stoupas stovky metru za vterinu.");
                Pis("Na hladine tvuj modul vylovi zachranna flotila.");
                Pis("Kdyz ale vojaci otevrou poklop a uvidi misto cloveka cizi hardware,");
                Pis("okamzite te oznacuji za bio-hrozbu a tvuj modul putuje rovnou do spalovny.");
            }
            else if (volba == 3)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Pis("=== KONEC 3: KARANTENNI PROTOKOL ===");
                Console.ResetColor();
                Pis("Z cele sily zarazis pacidlo do obvodu kapsle. Draty exploduji jiskrami.");
                Pis("Viktor propada hysterii, ale ty vis, co je v sazce.");
                Pis("Cerny sliz a Tvarovac se nikdy nesmi dostat na povrch k lidem.");
                Pis("Strop se trha a ledovy ocean smete vse do vecne temnoty.");
                Pis("Zabranil jsi infekci sveta za cenu vlastnich existenci.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Pis("=== KONEC 4: VAHANI A PANIKA ===");
                Console.ResetColor();
                Pis("Nezvladl ses v casovem presu rozhodnout a zustal jsi ochromeny stat.");
                Pis("Konstrukce stanice nevydrzela obrovsky napor a cela sekce implodovala.");
            }

            UkonciHru();
        }

        static void Pis(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
            Console.WriteLine();
        }

        static bool ZkontrolujKonecCasu(Hrac hrac)
        {
            if (hrac.VyprselCas())
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\a");
                Pis("=== KONEC 5: CAS VYPRSEL ===");
                Console.ResetColor();
                Pis("Nestihl jsi dobehnout vcas. Tlak 8 200 metru oceanu rozmackal celou stanici.");
                Pis("Kov byl rozdrcen behem zlomku vteriny.");
                UkonciHru();
                return true;
            }
            return false;
        }

        static void UkonciHru()
        {
            Console.WriteLine("\nStiskni libovolnou klavesu pro ukonceni...");
            Console.ReadKey();
        }
    }
}
