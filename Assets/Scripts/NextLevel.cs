using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private int Level = 1;

    public GameObject PlayerStuff;
    public GameObject Player;

    private Vector2 PlayerOGPos;
    WeightAdjustments weightAdjustmentsScript;

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    public GameObject BalloonButt;
    public GameObject BigBalloonButt;
    public GameObject WeightButt;
    public GameObject ParachuteButt;
    public GameObject PopBalloon;
    public GameObject PopBigBalloon;
    public GameObject DropWeight;
    public GameObject DropParachute;

    private float timer = 0;
    private bool platform = true;

    public GameObject Panel;

    private void Start()
    {
        weightAdjustmentsScript = GameObject.Find("Player").GetComponent<WeightAdjustments>();
        PlayerOGPos = Player.transform.position;

        ParachuteButt.SetActive(false);
        DropParachute.SetActive(false);
    }

    private void Update()
    {
        if (Level == 1)
        {
            level1.SetActive(true);
            level2.SetActive(false);
            level3.SetActive(false);
        }

        if (Level == 2)
        {
            level2.SetActive(true);
            level1.SetActive(false);
            level3.SetActive(false);
        }

        if (Level == 3)
        {
            level3.SetActive(true);
            level1.SetActive(false);
            level2.SetActive(false);

            WeightButt.SetActive(false);
            DropWeight.SetActive(false);
            ParachuteButt.SetActive(true);
            DropParachute.SetActive(true);
            BigBalloonButt.SetActive(false);
            PopBigBalloon.SetActive(false);
            BalloonButt.SetActive(false);
            PopBalloon.SetActive(false);

            if (platform)
            {
                Player.transform.position = new Vector2(0, 9);
                timer += Time.deltaTime;
            }
            else
            {

            }

            if (timer >= 0.5f)
            {
                platform = false;
            }
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
            Player.transform.position = PlayerOGPos;
            Level += 1;
            weightAdjustmentsScript.balloon.itemAmount = 0;
            weightAdjustmentsScript.bigballoon.itemAmount = 0;
            weightAdjustmentsScript.weight.itemAmount = 0;
            weightAdjustmentsScript.parachute.itemAmount = 0;
            weightAdjustmentsScript.balloonSpeed = 1;
            weightAdjustmentsScript.bigballoonSpeed = 0;
            weightAdjustmentsScript.weightSpeed = 1;
            weightAdjustmentsScript.parachuteSpeed = 1;
            weightAdjustmentsScript.weightMoveSpeed = 1;
            weightAdjustmentsScript.parachuteMoveSpeed = 1;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
