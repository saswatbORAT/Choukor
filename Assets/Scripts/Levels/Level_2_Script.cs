using UnityEngine;
using System.Collections;

public class Level_2_Script : MonoBehaviour {
    Transform innerRing;
    Transform outerRing;
	// Use this for initialization
	void Start () {
        innerRing = transform.FindChild("InnerRing");
        outerRing = transform.FindChild("OuterRing");
	}
	
	// Update is called once per frame
	void Update () {
        if (innerRing != null)
        {
            innerRing.Rotate(0, 0, 1f);////
        }
        if (outerRing != null)
        {
            outerRing.Rotate(0, 0, -0.5f);////
        }
	}
}
