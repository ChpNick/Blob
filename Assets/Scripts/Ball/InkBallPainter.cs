using System.Collections;
using System.Collections.Generic;
using Es.InkPainter;
using UnityEngine;

public class InkBallPainter : MonoBehaviour {
    public int Force = 10;

    [SerializeField] private Brush brush;

    // Start is called before the first frame update
    void Start() {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) {
            rb.AddForce(this.transform.forward * Force, ForceMode.VelocityChange);
        }

//        rb.velocity = transform.forward * 10;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other) {
        Debug.Log("Коллизия произошла");
        Destroy(gameObject);
        
        Vector3 closestPoint = other.collider.ClosestPointOnBounds(other.GetContact(0).point);

        var paintObject = other.gameObject.GetComponent<InkCanvas>();
        if (paintObject != null) {
            paintObject.Paint(brush, closestPoint);
        }
    }
}