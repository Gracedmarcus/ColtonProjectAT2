using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Markers : MonoBehaviour
{
    public GameObject marker1, marker2, marker3;
    public GameObject table, toilet, bed;
    private Vector3 offset = new Vector3(0,1,0);
    // Start is called before the first frame update
    void Start()
    {
        marker1.transform.position = table.transform.position + offset;
        marker2.transform.position = toilet.transform.position + offset;
        marker3.transform.position = bed.transform.position + offset;
    }
    void Update()
    {
        marker1.transform.LookAt(Camera.main.transform);
        marker2.transform.LookAt(Camera.main.transform);
        marker3.transform.LookAt(Camera.main.transform);
    }
}
