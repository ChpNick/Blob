using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour {
    private Camera _camera;
    public int TimeMiss = 1;

    [SerializeField] private GameObject ball;

    // Use this for initialization
    void Start() {
        _camera = GetComponent<Camera>();

//        убирает курсор мыши 
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            Debug.Log("Выстрел");

            CreateBall();

//                StartCoroutine(SphereIndicator(hit.point));
        }
    }

    private void CreateBall() {
        Vector3 thePosition = transform.TransformPoint(Vector3.forward * 2);
        Instantiate(ball, thePosition, transform.rotation);
    }


    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(TimeMiss);

        Destroy(sphere);
    }

    void OnGUI() {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}