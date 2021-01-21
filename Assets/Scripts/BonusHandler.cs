using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHandler : MonoBehaviour
{
    [SerializeField] int bonusValue = 10;
    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.AddValue(bonusValue);
        Destroy(gameObject);
    }
}
