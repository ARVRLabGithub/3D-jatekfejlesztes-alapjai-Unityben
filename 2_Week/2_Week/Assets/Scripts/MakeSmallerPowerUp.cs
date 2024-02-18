using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSmallerPowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            UserCharachterMovement.controller.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            Destroy(this.gameObject);
        }
    }
}
