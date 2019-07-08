using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{

    [SerializeField] GameObject destroyedVersion;
    [SerializeField] GameObject deathFX;

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
            scoreBoard.ScoreHit(scorePerhit);
            deathFX.SetActive(true);
            Instantiate(deathFX, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z), gameObject.transform.rotation);
            Instantiate(destroyedVersion, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z), gameObject.transform.rotation);
            //destroyedVersion.SetActive(true);
            Destroy(gameObject);
    }
}
