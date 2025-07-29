using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfCenterChamber : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnLevelObjects.instance.isClockwise)
        {
            transform.Rotate(0, 0, -SpawnLevelObjects.instance.rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, SpawnLevelObjects.instance.rotationSpeed * Time.deltaTime);
        }
    }
}
