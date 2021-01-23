using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHandler : MonoBehaviour
{
    [SerializeField] int bonusValue = 10;

    GameObject playerInstance;
    UIManager uiManager;

    private void Start()
    {
        playerInstance = GameObject.Find("Player");
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        uiManager.AddValue(bonusValue);
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
