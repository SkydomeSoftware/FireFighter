using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool destroyAfter;
    public int qestID;
    public bool isPickable;
    public bool isPicked;
    public Vector3 pickedObjectDestination;
    public Vector3 picketObjectRotation;
    public float rotationSpeed;
    public void FixedUpdate()
    {
      
        if(isequiped()&&isPicked)
        { 
            GoToPlayer(); 
        }
           
    }

    public void GoToPlayer()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, pickedObjectDestination, 4f * Time.deltaTime);
        Quaternion quaternion = Quaternion.Euler(picketObjectRotation);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, quaternion, Time.deltaTime * 12f);
       
       
    }
    public void PickUp()
    {
        
        if (qestID != 0)
        {
            if(Quests.Instance.IsAllMissionComplete(qestID))
            {
                Quests.Instance.DoneQuest(qestID);
                if (destroyAfter)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    isPicked = true;
                    this.transform.SetParent(Player.Instance.transform.GetChild(0));
                    this.gameObject.layer = LayerMask.NameToLayer("item");
                    foreach (Transform child in this.transform)
                    {
                        child.gameObject.layer = LayerMask.NameToLayer("item");
                    }
                }
            }
        }
       
    }
    void Rotate(Vector3 direction)
    {
        transform.Rotate(direction * rotationSpeed);
    }

    public bool isequiped()
    {
        if (transform.parent.name == "FirstPersonCharacter" & transform.localPosition != pickedObjectDestination & transform.localRotation != Quaternion.LookRotation(Player.Instance.transform.eulerAngles))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
