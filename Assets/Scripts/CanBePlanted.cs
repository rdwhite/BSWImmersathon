using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PlantedEventHandler(object sender);

[RequireComponent(typeof(Rigidbody))]
public class CanBePlanted : MonoBehaviour
{
    public bool isPlanted = false;
    private Rigidbody body;

    public event PlantedEventHandler HasBeenPlanted;
    public event PlantedEventHandler HasBeenUnPlanted;

    void Start()
    {
        this.body = GetComponent<Rigidbody>();
    }

    void setIsPlanted(bool planted)
    {
        this.isPlanted = planted;
        if (planted)
        {
            this.HasBeenPlanted(this);
        } else
        {
            this.HasBeenUnPlanted(this);
        }
    }

    void Update()
    {
        if (isPlanted)
        {
            body.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            body.constraints = RigidbodyConstraints.None;
        }
    }
}
