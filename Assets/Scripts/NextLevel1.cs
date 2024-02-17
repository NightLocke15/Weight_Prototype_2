using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel1 : MonoBehaviour
{
    //[SerializeField] private int Level = 1;

    public GameObject PlayerStuffs;
    public GameObject Playere;
    public GameObject Square;

    private Vector2 PlayerOGPosition;
    WeightAddition weightAdditionScripts;

    public GameObject BalloonButt;
    public GameObject WeightButt;
    public GameObject ParachuteButt;
    public GameObject PopBalloon;
    public GameObject DropWeight;

    public GameObject Panel;

    private void Start()
    {
        weightAdditionScripts = GameObject.Find("Square").GetComponent<WeightAddition>();
        PlayerOGPosition = Playere.transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerStuffs.transform.position = new Vector2(0, 0);
            Square.transform.position = new Vector2(PlayerStuffs.transform.position.x, PlayerStuffs.transform.position.y - 0.75f);
            Playere.transform.position = PlayerOGPosition;
            weightAdditionScripts.balloonAmount = 0;
            weightAdditionScripts.weightAmount = 0;
        }
    }
}
