using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private int Level = 1;

    public GameObject PlayerStuff;
    public GameObject Player;
    public GameObject Squares;

    private Vector2 PlayerOGPos;
    WeightAddition weightAdditionScript;

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    public GameObject BalloonButt;
    public GameObject WeightButt;
    public GameObject ParachuteButt;
    public GameObject PopBalloon;
    public GameObject DropWeight;

    public GameObject Panel;

    private void Start()
    {
        weightAdditionScript = GameObject.Find("Square").GetComponent<WeightAddition>();
        PlayerOGPos = Player.transform.position;
    }

    private void Update()
    {
        if (Level == 1)
        {
            level1.SetActive(true);
            level2.SetActive(false);
            level3.SetActive(false);

            BalloonButt.SetActive(true);
            WeightButt.SetActive(false);
            ParachuteButt.SetActive(false);
            PopBalloon.SetActive(true);
            DropWeight.SetActive(false);
        }

        if (Level == 2)
        {
            level2.SetActive(true);
            level1.SetActive(false);
            level3.SetActive(false);

            BalloonButt.SetActive(true);
            WeightButt.SetActive(true);
            ParachuteButt.SetActive(false);
            PopBalloon.SetActive(true);
            DropWeight.SetActive(true);
        }

        if (Level == 3)
        {
            level3.SetActive(true);
            level1.SetActive(false);
            level2.SetActive(false);

            BalloonButt.SetActive(true);
            WeightButt.SetActive(false);
            ParachuteButt.SetActive(true);
            PopBalloon.SetActive(false);
            DropWeight.SetActive(false);
        }

        if (Level == 4)
        {
            Panel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerStuff.transform.position = new Vector2(0, 0);
            Squares.transform.position = new Vector2(PlayerStuff.transform.position.x, PlayerStuff.transform.position.y - 0.75f);
            Player.transform.position = PlayerOGPos;
            Level += 1;
            weightAdditionScript.balloonAmount = 0;
            weightAdditionScript.weightAmount = 0;
        }
    }
}
