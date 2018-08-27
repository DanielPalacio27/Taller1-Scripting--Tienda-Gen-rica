using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Currencies
{
    private float currency1;
    private byte currency2;
    private int currency3;

    public float Currency1 { get { return currency1; } set { currency1 = value; } }
    public byte Currency2 { get { return currency2; } set { currency2 = value; } }
    public int Currency3 { get { return currency3; } set { currency3 = value; } }

    public Currencies()
    {
        Currency1 = 0f;
        Currency2 = 0;
        Currency3 = 0;
    }

    public Currencies(float _currency1)
    {
        Currency1 = _currency1;
    }
    public Currencies(byte _currency2)
    {
        Currency2 = _currency2;
    }
    public Currencies(int _currency3)
    {
        Currency3 = _currency3;
    }

    public Currencies(float _currency1, byte _currency2)
    {
        Currency1 = _currency1;
        Currency2 = _currency2;
    }
    public Currencies(byte _currency2, int _currency3)
    {
        Currency2 = _currency2;
        Currency3 = _currency3;
    }
    public Currencies(float _currency1, int _currency3)
    {
        Currency1 = _currency1;
        Currency3 = _currency3;
    }

    public Currencies(float _currency1, byte _currency2, int _currency3)
    {
        Currency1 = _currency1;
        Currency2 = _currency2;
        Currency3 = _currency3;
    }
}
