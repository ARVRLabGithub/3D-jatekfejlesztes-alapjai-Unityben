using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float multiplier = 2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            UserCharachterMovement.Speed *= multiplier;
            Destroy(this.gameObject);
        }
    }
}
