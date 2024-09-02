using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    //public Rigidbody2D rb;
    public ReadyToggle rdyTog;
    Vector2 difference;
    bool clickTrue = false;
    // Start is called before the first frame update
    void Start()
    {
         Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        
        if (Input.GetMouseButton(0) && hit.collider != null && hit.collider.gameObject.tag == "Object")
        {
            clickTrue = true;
            if(Input.GetKey(KeyCode.Q)){
                hit.collider.transform.Rotate(0,0,Time.deltaTime * 55);
              }

            if(Input.GetKey(KeyCode.E)){
                hit.collider.transform.Rotate(0,0,Time.deltaTime * -55);
              }
        }
        else{
            clickTrue = false;
        }

    
      
    }

    private void OnMouseDown()
  {
    difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
      
  }
  
    private void OnMouseDrag()
    {
      if(rdyTog.isToggleOn){
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
      }
    }
}
