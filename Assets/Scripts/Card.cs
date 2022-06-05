//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Card //: MonoBehaviour
{
    private int cardNumber;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    public Card (int cardNumber = 0)
    {
        this.cardNumber = cardNumber;
    }

    public int CardNumber
    {
        get { return cardNumber; }
        set { cardNumber = value; }
    }

}
