using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class Player : MonoBehaviour
{

 

    public static Player Instance { get; private set; }

    Ray ray;
    RaycastHit hit;
    
 

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void FixedUpdate()
    {
        CheckMouseRay();
    }
    public void CheckMouseRay()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.transform.tag == "Item" && hit.distance < 3)
                {
                    if (Quests.Instance.time <0.1f)
                    Quests.Instance.WriteOnScreen(0.1f,$"Press right button to pick {hit.transform.name}");
                    if (Input.GetMouseButtonDown(0))
                    {
                        PickUp(hit.transform);
                    }
                }
                else if(hit.transform.tag == "Fire" && hit.distance<3)
                {
                    Quests.Instance.WriteOnScreen(0.1f, $"Press left button to put out the fire {hit.transform.name}");
                    if (Input.GetMouseButton(0))
                    {
                        Fire.Instance.extinguish();
                    }
                }
            }
        }
    }
    public void PickUp(Transform pickedObject)
    {
        pickedObject.GetComponent<PickableObject>().PickUp();
    }
   
}
