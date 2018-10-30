using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("Hello");
        StartCoroutine("Seconds");
	}

    IEnumerator Hello() {
        while(true) {
            print("Hello");
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator Seconds() {
        for(int i = 1; ; i++) {
            print(i);
            yield return new WaitForSeconds(1);

            if (i == 25) {
                StopCoroutine("Hello");
            }
        }
    }
}
