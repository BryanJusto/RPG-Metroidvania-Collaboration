using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableManager : MonoBehaviour
{
    public PickupType pickupType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch(pickupType)
            {
                case PickupType.fireAbility:
                    Debug.Log("Fire ability aqcuired");
                    collision.gameObject.GetComponent<playerControl>().fireEnabled = true;
                    collision.gameObject.GetComponent<playerControl>().iceEnabled = false;
                    Destroy(gameObject);
                    break;
                case PickupType.upgradePoint:
                    Debug.Log("Upgrade Point");
                    Destroy(gameObject);
                    break;
                case PickupType.iceAbility:
                    Debug.Log("Ice ability aqcuired");
                    collision.gameObject.GetComponent<playerControl>().iceEnabled = true;
                    collision.gameObject.GetComponent<playerControl>().fireEnabled = false;
                    Destroy(gameObject);
                    break;
                case PickupType.healthPickup:
                    Debug.Log("health up");
                    collision.gameObject.GetComponent<playerControl>().UI.GetComponent<UIManager>().updateHealth(collision.gameObject.GetComponent<playerControl>().health + 1);
                    Destroy(gameObject);
                    break;
            }
        }
    }

    public enum PickupType
    {
        upgradePoint,
        fireAbility,
        iceAbility,
        bossToken,
        healthPickup,
        swordUpgrade
    }
}
