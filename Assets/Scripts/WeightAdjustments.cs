using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeightAdjustments : MonoBehaviour
{
    public Item balloon;
    public Item bigballoon;
    public Item weight;
    public Item parachute;

    public float speed = 3;

    public float balloonSpeed = 1;
    public float bigballoonSpeed = 0;
    public float weightSpeed = 1;
    public float parachuteSpeed = 1;
    public TextMeshProUGUI weightNumber;

    public GameObject poppedBalloon;

    ObjectGraphics objectGraphicsScript;

    private void Awake()
    {
        objectGraphicsScript = GetComponent<ObjectGraphics>();

        balloon = new Item(1, "Balloon", 0, 1.3f, 0.2f);        
        bigballoon = new Item(1, "Big Balloon", 0, 3.9f, 0.2f);
        weight = new Item(3, "Weight", 0, -0.6f, 2f);
        parachute = new Item(4, "Parachute", 0, 0, 0.3f);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 
            (weight.itemAmount * weight.itemWeight) + (balloon.itemAmount * balloon.itemWeight) + (bigballoon.itemAmount * bigballoon.itemWeight)), 
            (bigballoonSpeed + balloonSpeed) * weightSpeed * parachuteSpeed * speed * Time.deltaTime);
        Debug.Log(transform.position);

        if (transform.position.y == 0)
        {
            poppedBalloon.SetActive(false);
        }
    }

    public void BalloonButt()
    {
        balloon.itemAmount += 1;
        balloonSpeed = balloon.itemSpeed;
    }

    public void BigBalloonButt()
    {
        bigballoon.itemAmount += 1;
        bigballoonSpeed = bigballoon.itemSpeed;
    }

    public void WeightButt()
    {
        weight.itemAmount += 1;
        weightSpeed = weight.itemSpeed;
        weightNumber.text = "" + weight.itemAmount;
    }

    public void ParachuteButt()
    {
        parachute.itemAmount += 1;
        parachuteSpeed = parachute.itemSpeed;
    }

    public void PopBalloon()
    {
        balloon.itemAmount = 0;
        balloonSpeed = 1;

        if (transform.position.y > 0)
        {
            poppedBalloon.SetActive(true);
        }
    }
    public void PopBigBalloon()
    {
        bigballoon.itemAmount = 0;
        bigballoonSpeed = 0;

        if (transform.position.y > 0)
        {
            poppedBalloon.SetActive(true);
        }
    }

    public void RemoveWeight()
    {
        weight.itemAmount = 0;
        weightSpeed = 1;
    }

    public void RemoveParachute()
    {
        parachute.itemAmount = 0;
        parachuteSpeed = 1;
    }
}

public class Item
{
    public int ID;
    public string Name;
    public float itemAmount;
    public float itemWeight;
    public float itemSpeed;

    public Item(int _ID, string _Name, float _itemAmount, float _itemWeight, float _itemSpeed)
    {
        ID = _ID;
        Name = _Name;
        itemAmount = _itemAmount;
        itemWeight = _itemWeight;
        itemSpeed = _itemSpeed;
    }
}
