using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collision detected");
    }
}
