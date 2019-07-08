using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneric : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
    [SerializeField] int hitPoints = 10;
    bool dying = false;

    int scorePerhit = 1;


    ScoreBoard scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddNonTriggerBoxCollider()
    {
        gameObject.AddComponent<BoxCollider>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (!dying)
        {
            scoreBoard.ScoreHit(scorePerhit);
            hitPoints--;
            if(hitPoints <=0)
            {
                dying = true;
                Instantiate(deathFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
    }
}
