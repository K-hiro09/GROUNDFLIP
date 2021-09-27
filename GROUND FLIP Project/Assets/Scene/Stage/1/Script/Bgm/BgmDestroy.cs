using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmDestroy : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (!GameManagerScript.GetPlayerAlive())
        {
            Destroy(gameObject);
        }
	}
}
