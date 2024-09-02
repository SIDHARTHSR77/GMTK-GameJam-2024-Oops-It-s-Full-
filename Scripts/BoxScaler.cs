using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
public class BoxScaler : MonoBehaviour
{
    public ReadyToggle ToggleScript;
    Vector2 scale;
    //Vector2 difference;
    public GameObject cardBoard;

    //public PolygonCollider2D poly;
    //bool clickTrue = false;
    bool scaleToggle = false;
    bool edgeDone = false;
    
    private void Update(){
        
        scaleToggle=ToggleScript.isToggleOn;

        if(scaleToggle && !edgeDone){
            PolyTOEdge(edgeDone);
            edgeDone = true;
        }


        if(Input.GetKey(KeyCode.D)  && !scaleToggle && !EventSystem.current.IsPointerOverGameObject()){
            scale= transform.localScale;

            scale.x+=Time.deltaTime /2;
            
            transform.localScale=scale;
        }

        if(Input.GetKey(KeyCode.A) && !scaleToggle && !EventSystem.current.IsPointerOverGameObject()){
            scale= transform.localScale;

            scale.x-=Time.deltaTime/8;

            transform.localScale=scale;

            transform.localScale = new Vector3(
            Mathf.Max(transform.localScale.x, 0.15f),
            Mathf.Max(transform.localScale.y, 0.15f));
        }

        if(Input.GetKey(KeyCode.W) && !scaleToggle && !EventSystem.current.IsPointerOverGameObject()){
            scale= transform.localScale;

            //scale.x+=Time.deltaTime;
            scale.y+=Time.deltaTime/8;

            transform.localScale=scale;
        }

        if(Input.GetKey(KeyCode.S) && !scaleToggle && !EventSystem.current.IsPointerOverGameObject()){
            scale= transform.localScale;

            //scale.x+=Time.deltaTime;
            scale.y-=Time.deltaTime/8;

            transform.localScale=scale;

            transform.localScale = new Vector3(
            Mathf.Max(transform.localScale.x, 0.15f),
            Mathf.Max(transform.localScale.y, 0.15f));
        }

        
    }
    
    public void PolyTOEdge(bool edgeDone){
        PolygonCollider2D poly = GetComponent<PolygonCollider2D>();
        Vector2[] polypoints = poly.points;
        EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
        edge.points = polypoints; 
        Destroy(poly) ;
    }
}
