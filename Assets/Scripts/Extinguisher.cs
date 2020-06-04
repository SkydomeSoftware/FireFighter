using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Extinguisher : MonoBehaviour
{
    public ParticleSystem foam;

    private void Update()
    {
        if(Input.GetButton("Fire1") && transform.GetComponentInParent<PickableObject>().isPicked == true)
        {
            UseItem();
        }
        else
        {
            foam.enableEmission = false;
        }
    }

    public void UseItem()
    {
        foam.enableEmission = true;
        foam.transform.gameObject.layer = LayerMask.NameToLayer("Default");
    }
}
