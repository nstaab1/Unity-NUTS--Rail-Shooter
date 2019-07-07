using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{

    [SerializeField] GameObject destroyedVersion;
    [SerializeField] GameObject aliveVersion;
    [SerializeField] GameObject deathFX;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        if(!isDead)
        {
            deathFX.SetActive(true);
            destroyedVersion.SetActive(true);
            aliveVersion.SetActive(false);
        }
    }
}
