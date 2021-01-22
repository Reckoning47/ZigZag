using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHandler : MonoBehaviour
{
    [SerializeField] int bonusValue = 10;

    GameObject playerInstance;


    private void Start()
    {
        playerInstance = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.AddValue(bonusValue);
        Destroy(gameObject);
    }

    private void Update()
    {
        if((transform.position.x - playerInstance.transform.position.x) <= -1)
        {
            Destroy(gameObject);
        }
    }

}
