using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBall : MonoBehaviour {
    public int Force = 10;
    public GameObject[] Projector;
    
    private void Awake() {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        rb.AddForce(this.transform.forward * Force, ForceMode.VelocityChange);
//        rb.velocity = transform.forward * 10;
    }

//    private void OnTriggerEnter(Collider other) {
//        Debug.Log("Коллизия произошла");
//        Destroy(gameObject);
        
//        Vector3 hit = other.ClosestPointOnBounds(transform.position);
        
//        Quaternion projectorRotation = Quaternion.FromToRotation(-Vector3.forward, hit);
        
//        int rndInt = Random.Range(0, Projector.Length);

//        int rndRotation = Random.Range(0, 360);

//        GameObject _projector;
//        _projector = Instantiate(Projector[rndInt], hit, projectorRotation);
//        _projector.transform.Rotate(0, 0, rndRotation);
//        _projector.transform.SetParent(other.transform);
        
//    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Коллизия произошла");
        Destroy(gameObject);
        
        ContactPoint hit = other.GetContact(0);
        
        Quaternion projectorRotation = Quaternion.FromToRotation(-Vector3.forward, hit.normal);

        int rndInt = Random.Range(0, Projector.Length);

        int rndRotation = Random.Range(0, 360);

        GameObject _projector;
        _projector = Instantiate(Projector[rndInt], hit.point + hit.normal * 0.15f, projectorRotation);
        _projector.transform.Rotate(0, 0, rndRotation);
        _projector.transform.SetParent(other.transform);
    }
}