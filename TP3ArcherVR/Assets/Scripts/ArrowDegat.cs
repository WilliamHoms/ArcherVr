using UnityEngine;
using System.Collections;

public class ArrowDegat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.transform.GetComponent<Enemy>().TakeDamage(10);

        }
    }
}
