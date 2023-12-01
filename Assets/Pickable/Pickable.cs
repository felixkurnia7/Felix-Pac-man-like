using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pickable : MonoBehaviour
{
    [SerializeField]
    public PickableType PickableType;

    public Action<Pickable> OnPicked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (OnPicked != null)
            {
                OnPicked(this);
            }
        }
    }
}
