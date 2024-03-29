﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField] float fallDelay = 1f;
    GameObject playerInstance;
    Renderer _renderer;

    float value = 0f;
    int shaderProperty;
    bool tileFalling = false;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        shaderProperty = Shader.PropertyToID("_cutoff");
        playerInstance = GameObject.Find("Player");
    }

    void Update()
    {
        
        if(tileFalling)
        {
            _renderer.material.SetFloat(shaderProperty, value);
            value += .02f;
        }
        if ((transform.position.x - playerInstance.transform.position.x) <= -1)
        {
            FallDown();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("FallDown", fallDelay);
    }

    private void FallDown()
    {
        var rb = GetComponent<Rigidbody>();
        tileFalling = true;
        rb.isKinematic = false;
        rb.useGravity = true;

        //Destroy(PlatformSpawner.instance.bonusPrefab.gameObject, 2f);

        Destroy(gameObject, 2f);
    }
}
