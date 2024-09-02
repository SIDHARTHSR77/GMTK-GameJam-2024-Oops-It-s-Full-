using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class ObjectPlacer : MonoBehaviour
{
    public ReadyToggle ToggleScript;
    bool PlaceObject;
    //public Transform objectPrefab;

    public ObjectTypesSO activeObjectType;
    public GameObject gridSpace;
    public ContactFilter2D collisonLayer;
    Vector2 Mousepos;
    bool clickTrue = false;

    bool isOccupied = false;
    Collider2D[] collisonList = new Collider2D[5];
    
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        
        if (hit.collider != null && hit.collider.gameObject == gridSpace)
        {
            clickTrue = true;
        }
        else{
            clickTrue = false;
        }
        
        PlaceObject = ToggleScript.isToggleOn;

        if(Input.GetMouseButtonDown(0) && clickTrue && PlaceObject && !EventSystem.current.IsPointerOverGameObject()){
            if(!CanPlaceObject(activeObjectType) ){    
                Mousepos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
                Instantiate(activeObjectType.prefab,Mousepos,Quaternion.identity);}
        }

        
    }

    public void SetActiveObjectType(ObjectTypesSO objectTypesSO){
        activeObjectType = objectTypesSO;
    }

    private bool CanPlaceObject(ObjectTypesSO objectTypesSO){
        PolygonCollider2D objectcollider = objectTypesSO.prefab.GetComponent<PolygonCollider2D>();

        int colnum = objectcollider.OverlapCollider(collisonLayer,collisonList);  
        //Debug.Log("" + colnum);
        return isOccupied;
       
    }
}
