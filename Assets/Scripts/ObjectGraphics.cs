using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGraphics : MonoBehaviour
{
    WeightAdjustments weightAdjustmentsScript;

    public GameObject Balloon1;
    public GameObject Balloon2;
    public GameObject Balloon3;
    public GameObject Balloon4;
    public GameObject Weight;
    public GameObject Parachute;
    public GameObject BigBalloon;

    private void Awake()
    {
        weightAdjustmentsScript = GameObject.Find("Player").GetComponent<WeightAdjustments>();
    }

    private void Update()
    {
        if (weightAdjustmentsScript.parachute.itemAmount == 0)
        {
            Parachute.SetActive(false);
        }
        else if (weightAdjustmentsScript.parachute.itemAmount >= 1)
        {
            weightAdjustmentsScript.parachute.itemAmount = 1;

            Parachute.SetActive(true);
            Balloon1.SetActive(false);
            Balloon2.SetActive(false);
            Balloon3.SetActive(false);
            Balloon4.SetActive(false);
            Weight.SetActive(false);
        }

        if (weightAdjustmentsScript.balloon.itemAmount == 0)
        {
            Balloon1.SetActive(false);
            Balloon2.SetActive(false);
            Balloon3.SetActive(false);
            Balloon4.SetActive(false);
        }
        else if (weightAdjustmentsScript.balloon.itemAmount == 1)
        {
            Balloon1.SetActive(true);
            Balloon2.SetActive(false);
            Balloon3.SetActive(false);
            Balloon4.SetActive(false);
        }
        else if (weightAdjustmentsScript.balloon.itemAmount == 2)
        {
            Balloon1.SetActive(false);
            Balloon2.SetActive(true);
            Balloon3.SetActive(false);
            Balloon4.SetActive(false);
        }
        else if (weightAdjustmentsScript.balloon.itemAmount == 3)
        {
            Balloon1.SetActive(false);
            Balloon2.SetActive(false);
            Balloon3.SetActive(true);
            Balloon4.SetActive(false);
        }
        else if (weightAdjustmentsScript.balloon.itemAmount >= 4)
        {
            Balloon1.SetActive(false);
            Balloon2.SetActive(false);
            Balloon3.SetActive(false);
            Balloon4.SetActive(true);
        }

        if (weightAdjustmentsScript.weight.itemAmount >= 1)
        {
            Weight.SetActive(true);
        }
        else if (weightAdjustmentsScript.weight.itemAmount == 0)
        {
            Weight.SetActive(false);
        }

        if (weightAdjustmentsScript.bigballoon.itemAmount == 1)
        {
            BigBalloon.SetActive(true);
        }
        else if (weightAdjustmentsScript.bigballoon.itemAmount == 0)
        {
            BigBalloon.SetActive(false);
        }
    }
}
