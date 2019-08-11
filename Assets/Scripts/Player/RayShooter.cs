using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour {
    private Camera _camera;
    public int TimeMiss = 1;
    public GameObject Projector;

    // Use this for initialization
    void Start() {
        _camera = GetComponent<Camera>();

//        убирает курсор мыши 
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            
            Debug.Log("Выстрел");

            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point); // Создание в этой точке луча методом ScreenPointToRay()

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                
                Quaternion projectorRotation = Quaternion.FromToRotation(-Vector3.forward, hit.normal);

                Instantiate(Projector, hit.point + hit.normal * 0.25f, projectorRotation);
               
//                StartCoroutine(SphereIndicator(hit.point));
            }
        }
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