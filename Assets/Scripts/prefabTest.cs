using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabTest : MonoBehaviour
{
    GameObject tank;
    void Start()
    {
        tank = Managers.Resource.Instantiate("Tank");

        Destroy(tank, 3.0f);
    }
}
