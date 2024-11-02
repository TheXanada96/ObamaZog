using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondRotation : MonoBehaviour {
    // Velocità di rotazione del diamante
    public float rotationSpeed = 100f;

    void Update() {
        // Ruota il diamante lungo una diagonale
        transform.Rotate(new Vector3(1, 0, 1) * rotationSpeed * Time.deltaTime);
    }
}
