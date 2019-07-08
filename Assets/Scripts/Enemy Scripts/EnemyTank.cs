using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{

    [SerializeField] GameObject destroyedVersion;
    [SerializeField] GameObject damagedFX;
    [SerializeField] GameObject deathFX;
    [SerializeField] int hitPoints = 10;

    bool isDying = false;

    int scorePerhit = 1;
    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        // TODO: How to instaniate our detroyed version when its needed? And should it generate its own Box Collider?
    }

    private void AddNonTriggerBoxCollider()
    {
        gameObject.AddComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        if(hitPoints <= 5)
        {
            System.Random rand = new System.Random();
            int randNum = rand.Next(-1, 2);
            Instantiate(damagedFX, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 3, gameObject.transform.localPosition.z + randNum), Quaternion.identity);
        }
        if (hitPoints <= 0)
        {
            scoreBoard.ScoreHit(scorePerhit);
            //deathFX.SetActive(true);
            Instantiate(deathFX, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z), gameObject.transform.rotation);
            Instantiate(destroyedVersion, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z), gameObject.transform.rotation);
            //destroyedVersion.SetActive(true);
            Destroy(gameObject);
        }    
    }
}
