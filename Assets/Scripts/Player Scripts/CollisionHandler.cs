using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;
    // Start is called before the first frame update
    [SerializeField] GameObject propellerGameObject;
    [SerializeField] GameObject deathFX;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel() // Called by string reference
    {
        SceneManager.LoadScene(1);
    }

    private void StartDeathSequence()
    {
        deathFX.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        print("Player Dying");
        SendMessage("DisableControls");
        propellerGameObject.SendMessage("StopPropeller");
        deathFX.SetActive(true);
        gameObject.SetActive(false);

    }
}
