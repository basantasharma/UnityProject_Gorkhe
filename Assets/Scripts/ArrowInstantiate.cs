using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowInstantiate : MonoBehaviour
{
    public GameObject ArrowPrefab;
  
    public GameObject SpanArea;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
           GameObject ArrowObject = Instantiate(ArrowPrefab);
            ArrowObject.transform.position = SpanArea.transform.position + SpanArea.transform.forward;
            ArrowObject.transform.forward = SpanArea.transform.forward;


        }
    }
}
