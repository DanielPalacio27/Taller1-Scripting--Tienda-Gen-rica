using System.Collections.Generic;

public class Singleton {
  
    private static Singleton instance = null;

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }

    //public Currencies MyCurrencies = new Currencies();
    public int[] mCurrencies;

    public Singleton()
    {

        mCurrencies = new int[3];
        mCurrencies[0] = 5000;
        mCurrencies[1] = 5000;
        mCurrencies[2] = 5000;

    }

}
