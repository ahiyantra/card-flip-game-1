using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] cardPrefab;

    public GameObject[] deckPrefab;

    public int pileSize = 0;

    public Transform deckParent;

    public Vector3 cardPosition;
    /*
    public float addXpos = 29.0f;

    public float removeXpos = -29.0f;

    public Vector3 altPosition;

    public float speed;

    public float distance;
    */
    public float newYpos;

    public Deck myDeck;

    GameObject currentCard;

    public int topCardNumber;

    public int total = 0;

    public Scene scene;
    /*
    public bool addAnim = false;

    public bool removeAnim = false;

    public int addable = 0;
    public int removable = 0;
    */
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        //Debug.Log(scene.name);

        if (scene.name == "MainScene")
        {
            deckPrefab = new GameObject[100];
            cardPosition = deckParent.position;
            newYpos = 0f;
            myDeck = new Deck();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.name == "MainScene")
        {
            total = myDeck.totalCards();
        }
        
        /*
        if (myDeck.peek() > 0 && addAnim == true)
        {
            addAnimCard();
        }
        if (myDeck.peek() > 0 && removeAnim == true)
        {
            removeAnimCard();
        }
        */
    }

    public void StartNow()
    {
        SceneManager.LoadScene(1);
    }

    public void AddCard(int canum = 14) //int caNum = 0
    {
        //addAnim = true;

        //removeAnim = false;

        if (canum == 14)
        {
            AudioSource audioData = GameObject.Find("Move").GetComponent<AudioSource>();
            audioData.Play(0);
        }

        int[] pack = new int[total];

        for (int i = 0; i < total; i++)
        {
            pack[i] = myDeck.deck[i].CardNumber;
        }

        int[] set = new int[13];

        for (int i = 0; i < 13; i++)
        {
            set[i] = i + 1;
        }
        /*
        if (pack.Length >= 13)
        {
            Debug.Log("cloning complete");
            return;
        }
        */
        int cardNumber;

        if (canum==14)
        {

            bool check = false;
            /*
            cardNumber = UnityEngine.Random.Range(1, 13);

            for (int i = 0; i < total; i++)
            {
                check = Array.Exists(pack, x => x == cardNumber);
            }
            
            Debug.Log("repeated : " + check);
            */
            do
            {
                cardNumber = UnityEngine.Random.Range(1, 14);

                //for (int i = 0; i < total; i++)
                //{
                check = Array.Exists(pack, x => x == cardNumber);
                //}

                if (check)
                {
                    Debug.Log("skipping : " + cardNumber);
                }

                bool cloned = false;

                if (pack.Length >= 13)
                {
                    //Array.Sort(pack);
                    //if (pack.Length >= 13) // pack == set
                    //{
                    cloned = true;
                    //}
                }

                if (cloned == false)
                {
                    Debug.Log("cloning in progress");
                }
                else
                {
                    Debug.Log("cloning complete");
                    return;
                }
            }
            while (check);
        }
        else
        {
            cardNumber = canum;
        }

        myDeck.push(cardNumber);

        newYpos += 0.2f;

        cardPosition = new Vector3(cardPosition.x, newYpos, cardPosition.z);

        //altPosition = new Vector3(addXpos, newYpos, cardPosition.z); // for animation

        deckPrefab[pileSize] = GameObject.Instantiate(cardPrefab[cardNumber-1], cardPosition, Quaternion.identity, deckParent); // altPosition

        deckPrefab[pileSize].transform.Rotate(new Vector3(0f, 0f, 180f));

        //deckPrefab[pileSize] = currentCard;

        pileSize++;

        //currentCard.name = cardNumber.ToString();

        //currentCard.gameObject.GetComponentInChildren<TextMesh>().text = cardNumber.ToString();
        //currentCard.GetComponentInChildren<TextMesh>().text = cardNumber.ToString();
        /*
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == cardNumber.ToString())
            {
                gameObj.GetComponentInChildren<TextMesh>().text = cardNumber.ToString();
            }
        }
        */
    }

    public void RemoveCard(bool withsound = true)
    {
        //addAnim = false;

        //removeAnim = true;
        if (withsound)
        {
            AudioSource audioData = GameObject.Find("Move").GetComponent<AudioSource>();
            audioData.Play(0);
        }

        //altPosition = new Vector3(removeXpos, newYpos, cardPosition.z); // for animation

        //removable = myDeck.peek();

        myDeck.pop();
        
        if (newYpos >= 0.2f)
        {
            newYpos -= 0.2f;
        }
        
        ///*

        if (pileSize > 0)
        {
            Debug.Log("Destroying " + deckPrefab[pileSize-1].name);
            Destroy(deckPrefab[pileSize-1]);

            deckPrefab[pileSize-1] = null;
            pileSize--;
        }
        //*/
        //if (pileSize > 0)
        //{
        //currentCard = deckPrefab[pileSize-1];
        //}

    }

    public void Reveal()
    {
        topCardNumber = myDeck.peek();

        AudioSource audioData = GameObject.Find("Move").GetComponent<AudioSource>();
        audioData.Play(0);

        if (total > 0)
        {
            deckPrefab[total - 1].transform.Rotate(new Vector3(0f, 0f, 180f)); // pileSize
        }
    }

    public void Shuffle()
    {
        AudioSource audioData = GameObject.Find("Shuffle").GetComponent<AudioSource>();
        audioData.Play(0);

        //Debug.Log("deck length : " + myDeck.totalCards());
        ///*
        myDeck.shuffleDeck();
        //*/
        ///*
        int all = GameObject.FindGameObjectsWithTag("Card").Length;

        foreach (var b in GameObject.FindGameObjectsWithTag("Card"))
        {
            //Destroy(b);
            RemoveCard(false);
        }

        //addXpos = 0.0f;

        for (int i = 0; i < all; i++)
        {
            AddCard(myDeck.deck[i].CardNumber);
        }

        //addXpos = 29.0f;

        //*/
        /*
        total = GameObject.FindGameObjectsWithTag("Card").Length;
        pileSize = GameObject.FindGameObjectsWithTag("Card").Length;
        newYpos = 0.1f;
        */
        //deckPrefab = temp;
    }

    public void EndNow()
    {
        SceneManager.LoadScene(0);
    }
    /*
    public void addAnimCard()
    {
        int holder = myDeck.peek(); // for animation

        Debug.Log("from " + GameObject.Find("Card_" + holder + "(Clone)").transform.position + " to " + cardPosition);

        distance = Vector3.Distance(cardPosition, GameObject.Find("Card_"+holder+"(Clone)").transform.position); // for animation

        if (distance > 0.0f) // for animation
        {
            Vector3 dir = cardPosition - GameObject.Find("Card_" + holder + "(Clone)").transform.position; // for animation

            dir.Normalize(); // for animation

            GameObject.Find("Card_" + holder + "(Clone)").transform.position += dir * speed * Time.deltaTime; // for animation
        }
    }

    public void removeAnimCard()
    {
        int holder = removable; // for animation

        Debug.Log("from " + GameObject.Find("Card_" + holder + "(Clone)").transform.position + " to " + altPosition);

        distance = Vector3.Distance(altPosition, deckPrefab[pileSize - 1].transform.position); // for animation

        if (distance > 0.0f) // for animation
        {
            Vector3 dir = altPosition - deckPrefab[pileSize - 1].transform.position; // for animation

            dir.Normalize(); // for animation

            deckPrefab[pileSize - 1].transform.position += dir * speed * Time.deltaTime; // for animation
        }
    }
    */
}
