using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ReadyToggle : MonoBehaviour
{
    public GameObject Ready_Button;
    public GameObject moneyObj;
    public Transform cardBoard;
    public float minBoardSize;
    private TMP_Text tMP_Text;
    public bool isToggleOn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        tMP_Text =moneyObj.GetComponent<TMP_Text>();
        //tMP_Text.text = "Your Expenditure!";  
    }

    public void OnToggleChange(bool toggle){
        if (toggle){
            isToggleOn = true;
            Destroy(Ready_Button);
        }
        if(toggle && cardBoard.localScale.x > minBoardSize){
            //tMP_Text.text = "Money = "+ minBoardSize;
            Destroy(Ready_Button);
        }
    }
}
