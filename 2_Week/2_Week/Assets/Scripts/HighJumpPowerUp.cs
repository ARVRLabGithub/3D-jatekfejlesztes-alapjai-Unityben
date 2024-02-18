using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpPowerUp : MonoBehaviour
{
    public float multiplier = 2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            UserCharachterMovement.jumpHeight *= multiplier;
            Destroy(this.gameObject);
        }
    }
}
