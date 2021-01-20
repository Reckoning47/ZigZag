using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public BallController target;

    Vector3 offset;
    [SerializeField] float lerpRate = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        if (!target.GetGameOver())
        {
            
        }
    }
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position - offset;

        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
