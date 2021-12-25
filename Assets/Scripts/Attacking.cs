using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public Rigidbody rocketPrefab;
    public Transform Target;
    private JumpScript jS;
    private TouchingDirection gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<TouchingDirection>();
        jS = GetComponent<JumpScript>();
    }
    public void Attack()
    {
        var posToSpawn = new Vector3((float) (transform.position.x + 1.44), transform.position.y,
                (float) (transform.position.z - 0.919));
            Rigidbody rocketInstance;
            var scale = gm.scaling;
            rocketPrefab.transform.localScale = new Vector3(scale, scale, scale);
            rocketInstance = Instantiate(rocketPrefab, posToSpawn, transform.rotation) as Rigidbody;
            var ahead = Target.position - rocketInstance.transform.position;
            rocketInstance.AddForce(ahead * 100);
    }
}
