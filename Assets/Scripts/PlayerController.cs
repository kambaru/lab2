using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem ;

public class PlayerController : MonoBehaviour{
    public Vector2 moveValue;    
    public float speed;
    private int count;
    private int numPickups = 4;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    void Start() {
        count = 0;
        winText.text = " ";
        SetCountText();
    }

    void OnMove(InputValue value) {
        moveValue = value.Get<Vector2>() ;
    }
    void FixedUpdate() {
        Vector3 movement = new Vector3 (moveValue.x,0.0f, moveValue.y);
        GetComponent <Rigidbody>().AddForce(movement*speed*Time.fixedDeltaTime);
    }

    /*OnTriggerEnter is a function called when other game object's collider (config as trigger) collides
    with collider of game obj that has tis script as a component)*/ 
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "PickUp") { //tag checks if its right object
            other.gameObject.SetActive(false); //collide = set obj as inactive
            count++;
            SetCountText();
        }
    }

    private void SetCountText(){
        scoreText.text = "Score: " + count.ToString();
        if(count == numPickups){
            winText.text = "You Win!";
        }
    }

}
