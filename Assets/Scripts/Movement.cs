using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    WeightAdjustments weightAdjustmentsscript;

    private void Awake()
    {
        weightAdjustmentsscript = GameObject.Find("Player").GetComponent<WeightAdjustments>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * weightAdjustmentsscript.weightMoveSpeed * weightAdjustmentsscript.parachuteMoveSpeed * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * weightAdjustmentsscript.weightMoveSpeed * weightAdjustmentsscript.parachuteMoveSpeed * speed * Time.deltaTime);
        }
    }
}
