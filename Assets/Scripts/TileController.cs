using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    Renderer _renderer;

    float value = 0f;
    int shaderProperty;
    bool tileFalling = false;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        shaderProperty = Shader.PropertyToID("_cutoff");
    }

    void Update()
    {
        
        if(tileFalling)
        {
            _renderer.material.SetFloat(shaderProperty, value);
            value += .01f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("FallDown", .5f);
    }

    private void FallDown()
    {
        var rb = GetComponent<Rigidbody>();
        tileFalling = true;
        rb.isKinematic = false;
        rb.useGravity = true;

        Destroy(gameObject, 2f);
    }
}
