//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

using System;

public class Deck //: MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    public Card[] deck;
    private Card top;
    private int max;
    private int total;
    public Deck(int size = 100)
    {
        deck = new Card[size];
        top = new Card(-1);
        max = size;
        total = 0;
    }

    public void push(int num)
    {
        Card item = new Card(num);

        if (top.CardNumber >= max - 1)
        {
            Debug.Log("Deck Overflow");
            return;
        }
        else if ((item.CardNumber > 13) || (item.CardNumber < 1))
        {
            Debug.Log("Card number " + item.CardNumber + " not acceptable.");
            return;
        }
        else
        {

            total++;
            //Debug.Log("total : " + total);

            deck[++top.CardNumber] = item;
        }
    }

    public Card pop()
    {
        if (top.CardNumber <= -1)
        {
            Debug.Log("Deck Underflow");
            return new Card(-1);
        }
        else
        {
            Debug.Log("Popped card is : " + deck[top.CardNumber].CardNumber);

            total--;
            //Debug.Log("total : " + total);

            return deck[top.CardNumber--];
        }
    }

    public int peek()
    {
        if (top.CardNumber <= -1 || top == null)
        {
            Debug.Log("Deck Underflow");
            return -1;
        }
        else
        {
            Debug.Log("The topmost card of deck is : " + deck[top.CardNumber].CardNumber); // {0}
            return deck[top.CardNumber].CardNumber;
        }
    }

    public void printDeck()
    {
        if (top.CardNumber <= -1 || top == null)
        {
            Debug.Log("Deck is Empty");
            return;
        }
        else
        {
            for (int i = 0; i <= top.CardNumber; i++)
            {
                Debug.Log("Card number " + i + " : " + deck[i].CardNumber);
            }
        }

    }

    public int totalCards()
    {
        //Debug.Log("total : " + total);
        return total;
    }

    public void shuffleDeck()
    {
        System.Random rand = new System.Random();
        ///*
        for (int i = total - 1; i >= 1; i--) // deck.Length - 1
        {
            int j = rand.Next(i + 1);
            var tmp = deck[j];
            deck[j] = deck[i];
            deck[i] = tmp;
        }
        //*/
        /*
        for (int i = 0; i < deck.Length - 1; i++)
        {
            int j = rand.Next(i, deck.Length);
            var tmp = deck[i];
            deck[i] = deck[j];
            deck[j] = tmp;
        }
        */
    }
}
