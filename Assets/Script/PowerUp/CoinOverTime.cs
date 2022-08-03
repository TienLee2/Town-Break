using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinOverTime : MonoBehaviour
{
    public bool mot, hai, ba, bon, nam = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("one", 60f);
        Invoke("one", 180f);
        Invoke("one", 250f);
        Invoke("two", 300f);
        Invoke("two", 400f);
        Invoke("two", 500f);
        Invoke("two", 600f);
        Invoke("two", 700f);
        Invoke("three", 800f);
        Invoke("three", 900f);
        Invoke("three", 1000f);
        Invoke("three", 1200f);
        Invoke("four", 1600f);
        Invoke("four", 1800f);
        Invoke("four", 2000f);
    }
    
    void Update()
    {
        if (SumScore.Score > 1000 && mot == false)
        {
            one();
            mot = true;
        }
        if (SumScore.Score > 2000 && hai == false)
        {
            one();
            hai = true;
        }
        if (SumScore.Score > 3500 && ba == false)
        {
            one();
            ba = true;
        }
        if (SumScore.Score > 5000 && bon == false)
        {
            two();
            bon = true;
        }
    }
    
    void one()
    {
        Wallet.SetAmount(Wallet.GetAmount() + 1);
        Achievement.SetRuby(Achievement.GetRuby() + 1f);
    }

    void two()
    {
        Wallet.SetAmount(Wallet.GetAmount() + 2);
        Achievement.SetRuby(Achievement.GetRuby() + 2f);
    }

    void three()
    {
        Wallet.SetAmount(Wallet.GetAmount() + 3);
        Achievement.SetRuby(Achievement.GetRuby() + 3f);
    }
    void four()
    {
        Wallet.SetAmount(Wallet.GetAmount() + 4);
        Achievement.SetRuby(Achievement.GetRuby() + 4f);
    }
}
