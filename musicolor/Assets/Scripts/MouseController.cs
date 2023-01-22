using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject selectedObject = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Mouse button down");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Debug.Log("Hit " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag == "petal") {
                    SelectObject(hit.transform.gameObject);
                }
                else if (hit.transform.gameObject.tag == "color") {
                    // Apply color to selected object
                    ApplyColor(hit.transform.gameObject.GetComponent<ColorPicker>().GetColor());
                }
                else {
                    DeselectObject(selectedObject);
                }
            }
            else {
                DeselectObject(selectedObject);
            }
        }
    }

    void SelectObject(GameObject obj) {
        // Unselect current object
        if (selectedObject != null)
            DeselectObject(selectedObject);
        // Select new object
        selectedObject = obj;
        Light halo = obj.GetComponent<Light>();
        if (halo != null)
            halo.enabled = true;
    }

    void DeselectObject(GameObject obj) {
        if (obj == null)
            return;
        Light halo = obj.GetComponent<Light>();
        if (halo != null)
            halo.enabled = false;
        selectedObject = null;
    }

    void ApplyColor(Colors color) {
        if (selectedObject != null) {
            selectedObject.GetComponent<Petal>().SetColor(color);
        }
    }
}
