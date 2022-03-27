using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSwing : MonoBehaviour
{
    public Transform ninjaStar;
    public Bounds curBounds;
    private Quaternion startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = ninjaStar.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion a = startPos;
        a.x += -1 * (-1f * Mathf.Sin(Time.time * 2.0f));
        ninjaStar.rotation = a;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Destroy(this);
        }
    }
}
