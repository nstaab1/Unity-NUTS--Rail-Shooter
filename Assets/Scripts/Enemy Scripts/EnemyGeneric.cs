using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneric : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
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
            dying = true;
            Instantiate(deathFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
