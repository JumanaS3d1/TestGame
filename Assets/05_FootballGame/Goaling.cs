using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goaling : MonoBehaviour
{
    public Rigidbody ball;
    public Transform shootPos;
    float shootingForce = 3000;
    bool pressed= false;
    public GameObject captin;

    // Start is called before the first frame update
    void Start()
    {
        captin.GetComponent<Animator>().Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)&& !pressed) {
            pressed = true;
            captin.GetComponent<Animator>().Play("Shoot");
            Rigidbody shot = Instantiate(ball, shootPos.position, shootPos.rotation) as Rigidbody;
            shot.AddForce(shootPos.forward * shootingForce);
            //Invoke("ShootToGoal", .1f);          
        }
    }

    void ShootToGoal() {
       

    }
}
