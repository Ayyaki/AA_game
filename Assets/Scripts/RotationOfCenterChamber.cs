using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfCenterChamber : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SpawnLevelObjects.instance.rotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, SpawnLevelObjects.instance.rotationSpeed*Time.deltaTime);
    }
}
