//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Card[] test_0;
    public GameObject[] test_1;

    // Start is called before the first frame update
    void Start()
    {
        Test_Zero();
        //Test_One();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    void Test_Zero()
    {

        Deck myDeck = new Deck();

        myDeck.printDeck();
        myDeck.push(0);
        ///*
        myDeck.push(1);
        myDeck.push(2);
        myDeck.push(3);
        myDeck.push(4);
        myDeck.push(5);
        myDeck.push(6);
        myDeck.push(7);
        myDeck.push(8);
        myDeck.push(9);
        myDeck.push(10);
        myDeck.push(11);
        myDeck.push(12);
        myDeck.push(13);
        //*/
        myDeck.push(14);
        myDeck.peek();
        myDeck.totalCards();
        myDeck.printDeck();
        /*
        myDeck.peek();
        myDeck.totalCards();
        myDeck.pop();
        myDeck.peek();
        myDeck.totalCards();
        myDeck.pop();
        myDeck.peek();
        myDeck.totalCards();
        myDeck.printDeck();
        */
        ///*
        myDeck.shuffleDeck();
        myDeck.peek();
        myDeck.totalCards();
        myDeck.printDeck();
        //*/
    }

    public void Test_One()
    {
        test_1 = new GameObject[5];
        Debug.Log(test_1[0]);
        Debug.Log(test_1[0] == null);
    }

}
