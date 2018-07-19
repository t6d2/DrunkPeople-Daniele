using System;

namespace Test5
{
    /*
     * Ristrutturare il seguente programma seguendo il paradigma ad oggetti e utilizzando gli opportuni design pattern.
     * 
     * In particolare, il metodo BringDrunkToHome dovrà diventare una classe FACTORY chiamata Pub con un metodo CreateDrunk.
     * Il metodo restituisce un'istanza di IDrunk.
     * L'osteria va realizzata come SINGLETON.
     * 
     * La classe Drunk ha un metodo GoHome(), dentro il quale c'è la logica che sposta la persona ubriaca verso casa.
     * Le coordinate dell'osteria (Pub) sono sempre (20, 0), quelle della casa (20, 20).
     * I due tipi di Drunk (WineDrunk e BeerDrunk) vanno realizzati col pattern TEMPLATE.
     * Questo perché la parte iniziale e finale sono le stesse. Quello che varia è la parte centrale, il modo in cui
     * l'ubriaco fa il suo percorso sgangherato (quindi questa parte sarà implementata nelle due classi derivate).
     * 
     * I parametri bool isDrunk e muchDrunk decidono di quanto si sposta l'ubriaco:
     * - se non è ubriaco, fa dritto dall'osteria a casa;
     * - se è poco ubriaco, riesce a fare parecchi passi nella stessa direzione;
     * - se è molto ubriaco, fa un zig zag molto stretto perché barcolla di più.
     * Questi due parametri devono diventare un insieme di tre piccole classi,
     * accomunate da un'interfaccia IDrunkLevel, da settare in una proprietà della classe Drunk con il pattern STRATEGY.
     * L'interfaccia ha un metodo IsDrunk() che restituisce un bool, e un metodo CalculateMaxSteps().
     * 
     * Il metodo GoHome() dei Drunk funziona quindi così:
     * - chiedo all'IDrunkLevel IsDrunk().
     * - se no, vado dritto a casa perché sono sobrio.
     * - altrimenti, faccio il percorso sgangherato in base al mio tipo (è la parte abstract del metodo TEMPLATE)
     * - alla fine, arrivato all'ultima riga, faccio i passi necessari per arrivare dritto a casa.
     * 
     * LittleDrunkLevel e MuchDrunkLevel restituiscono true nel metodo IsDrunk()
     * NullDrunkLevel è un NullObject: IsDrunk() restituisce false e CalculateMaxSteps() restituisce 0.
     * Implementarlo come SINGLETON.
     * 
     * In ultimo, estrarre la funzionalità di stampa in console della posizione.
     * Deve esserci una classe statica con metodi:
     * - MoveLeft
     * - MoveRight
     * - MoveDown
     * - MoveLeftDown
     * Tutti prendono in input il numero di passi da percorrere,
     * aspettano un numero random di millisecondi (il Thread.Sleep(r.Next(1, 10) * 25))
     * e si muovono della direzione giusta.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Pub.Instance.CreateDrunk(new BeerDrunk(true, false));
        }
    }

    public class Pub
    {
        private Pub() { }
        static Pub()
        {
            Instance = new Pub();
        }
        public static Pub Instance { get; }

        public IDrunk CreateDrunk(Drunk drunk)
        {
            return null;
        }
    }

    public interface IDrunk
    {
        void GoHome();
       
    }

    public interface IDrunkLevel
    {
        bool IsDrunk();
        int CalculateMoreSteps();
        int CalculateLessSteps();
    }

    public class Drunk : IDrunk
    {
        public IDrunkLevel DrunkLevel { get; set; }
        public Drunk(bool isDrunk, bool muchDrunk)
        {
            _IsDrunk = isDrunk;
            _MuchDrunk = muchDrunk;
            if (isDrunk)
            {
                if (muchDrunk)
                    DrunkLevel.CalculateMoreSteps();
                else
                    DrunkLevel.CalculateLessSteps();
            }
        }
        private bool _IsDrunk { get; set; }
        private bool _MuchDrunk { get; set; }

        public void GoHome()
        {

        }
    }

    public class WineDrunk : Drunk
    {
        public WineDrunk(bool isDrunk, bool muchDrunk) : base(isDrunk,muchDrunk)
        {
        }
    }

    public class BeerDrunk : Drunk
    {
        public BeerDrunk(bool isDrunk, bool muchDrunk) : base(isDrunk, muchDrunk)
        {
        }
    }

    public class LittleDrunkLevel : IDrunkLevel
    {

        public bool IsDrunk()
        {
            return true;
        }

        public int CalculateMoreSteps()
        {
            throw new NotImplementedException();
        }

        public int CalculateLessSteps()
        {
            throw new NotImplementedException();
        }
    }

    public class MuchDrunkLevel : IDrunkLevel
    {
        public bool IsDrunk()
        {
            return true;
        }

        public int CalculateMoreSteps()
        {
            throw new NotImplementedException();
        }

        public int CalculateLessSteps()
        {
            throw new NotImplementedException();
        }
    }

    public class NullDrunkLevel : IDrunkLevel
    {

        static NullDrunkLevel()
        {
            Instance = new NullDrunkLevel();
        }
        public static NullDrunkLevel Instance { get; }
        private NullDrunkLevel() { }

        public bool IsDrunk()
        {
            return false;
        }

        public int CalculateMoreSteps()
        {
            return 0;
        }

        public int CalculateLessSteps()
        {
            return 0;
        }
    }
}
