using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    public RemoveManager manager;

    public void Interact()
    {
        if (manager.removing)
        {
            RemoveObject();
        }
    }

    public void RemoveObject()
    {

    }
}
