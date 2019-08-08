using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public GameObject dom;
    public GameObject les;
    public GameObject der;

    public GameObject b_prymo;
    public GameObject b_90;
    public GameObject b;

    void Update()
    {
        dom.transform.Rotate(0, 0, 0.3f);
        les.transform.Rotate(0, 0, 0.3f);
        der.transform.Rotate(0, 0, 0.3f);
        b.transform.Rotate(0, 0, 0.3f);
        b_90.transform.Rotate(0, 0, 0.3f);
        b_prymo.transform.Rotate(0, 0, 0.3f);
    }
}
