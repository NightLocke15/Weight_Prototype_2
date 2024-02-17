using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightAddition : MonoBehaviour
{
    private Vector2 OGposition;
    [SerializeField] private float balloonWeight = 2;

    [SerializeField] private float weightWeight = -1;
    [SerializeField] private float weightSpeed = 2;

    public bool parachute;
    [SerializeField] private float parachuteSpeed = 1f;

    public int balloonAmount;
    public int weightAmount;


    public GameObject Player;
    public GameObject Top;
    public GameObject Balloon1;
    public GameObject Balloon2;
    public GameObject Balloon3;
    public GameObject Balloon4;
    public GameObject Weight;
    public GameObject Parachute;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, (weightAmount*weightWeight) + (balloonAmount*balloonWeight) - 0.75f), parachuteSpeed * weightSpeed * Time.deltaTime);

        Top.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + 0.75f);

        if (transform.position.x != Player.transform.position.x)
        {
            transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - 0.75f);
        }

        if (parachute)
        {
            Parachute.SetActive(true);
            Balloon1.SetActive(false);
            Balloon2.SetActive(false);
            Balloon3.SetActive(false);
            Balloon4.SetActive(false);
            Weight.SetActive(false);

            if (Player.transform.position.x > 2)
            {
                parachuteSpeed = 0.5f;
                PopBalloon();                
            }
        }
        else
        {
            parachuteSpeed = 1f;
            Parachute.SetActive(false);
        }

        if (balloonAmount == 0)
        {
            Balloon1.SetActive(false);
            Balloon2.SetActive(false);
            Balloon3.SetActive(false);
            Balloon4.SetActive(false);
        }
        else if (balloonAmount == 1)
        {
            Balloon1.SetActive(true);
            Balloon2.SetActive(false);
            Balloon3.SetActive(false);
            Balloon4.SetActive(false);
        }
        else if (balloonAmount == 2)
        {
            Balloon1.SetActive(false);
            Balloon2.SetActive(true);
            Balloon3.SetActive(false);
            Balloon4.SetActive(false);
        }
        else if (balloonAmount == 3)
        {
            Balloon1.SetActive(false);
            Balloon2.SetActive(false);
            Balloon3.SetActive(true);
            Balloon4.SetActive(false);
        }
        else if (balloonAmount >= 4)
        {
            Balloon1.SetActive(false);
            Balloon2.SetActive(false);
            Balloon3.SetActive(false);
            Balloon4.SetActive(true);
        }

        if (weightAmount >= 1)
        {
            Weight.SetActive(true);
        }
        else if (weightAmount == 0)
        {
            Weight.SetActive(false);
        }
    }

    public void BalloonButt()
    {
        balloonAmount += 1;
    }

    public void WeightButt()
    {
        weightAmount += 1;
    }

    public void ParachuteButt()
    {
        parachute = true;
    }

    public void PopBalloon()
    {
        balloonAmount = 0;
    }

    public void RemoveWeight()
    {
        weightAmount = 0;
    }

    public void RemoveParachute()
    {
        parachute = false;
    }

}
