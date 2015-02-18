using UnityEngine;
using System.Collections;

public class Level_3_Script : MonoBehaviour {
    Transform Circle;
    Transform OuterRing;
	// Use this for initialization
	void Start () {
        Circle = transform.FindChild("Circle");
        OuterRing = transform.FindChild("OuterRing");
	}
	
	// Update is called once per frame
	void Update () {//
        Circle.Rotate(0, 0, 1.5f);
        OuterRing.Rotate(0, 0, -0.5f);
	}
}
//