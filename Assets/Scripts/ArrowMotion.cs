using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMotion : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed = 10f;
    private string ArrowState = "GainSpeed";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && ArrowState == "GainSpeed")
        {
            Speed += (Time.deltaTime * 2);
            if(Speed >= 10)
            {
                ArrowState = "Release";
            }
        }
        if(ArrowState == "Release")
        {
            MoveArrow();
        }
        Debug.Log(Speed);
        Debug.Log(ArrowState);

    }

    void MoveArrow()
    {
        rb.AddForce(this.transform.forward * Speed);
    }
}
