using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (new Vector3 (0.0f,
                                            0.0f,
                                            Input.GetAxis ("Vertical")*speed*Time.deltaTime));
        transform.Translate (new Vector3 (Input.GetAxis("Horizontal")*speed*Time.deltaTime, 0.0f, 0.0f));
    }
}
