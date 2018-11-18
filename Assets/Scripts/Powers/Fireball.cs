using System;
using System.Collections.Generic;
using UnityEngine;


public class Fireball : MonoBehaviour
{
    [SerializeField, Range(0f, 50f)]
    float lifetime;

    [SerializeField, Range(0f, 50f)]
    float moveSpeed;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }
}

