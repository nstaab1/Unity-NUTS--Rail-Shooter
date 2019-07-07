using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    [SerializeField] float propellerSpeed = -250f;
    // Start is called before the first frame update
    bool isAlive = true;

    AudioSource propellerNoise;

    void Start()
    {
        propellerNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            gameObject.transform.Rotate(Vector3.back, propellerSpeed);
        }
        
    }

    void StopPropeller() // Called by string reference in Collision Handler
    {
        isAlive = false;
        propellerNoise.Stop();
    }
}
