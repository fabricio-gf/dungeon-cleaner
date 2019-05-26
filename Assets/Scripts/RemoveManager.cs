using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveManager : MonoBehaviour
{
    public bool removing = false;

    public void ToggleRemove()
    {
        removing = !removing;
    }
}
