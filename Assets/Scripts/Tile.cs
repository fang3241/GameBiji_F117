using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int boardX;
    public int boardY;
    public Vector2 state;
    public SpriteRenderer spriteRenderer;
    public Sprite empty, tunas, tomat, kedelai, semangka, pagar;
    public GameManager _GM;
    public GameObject area;
    int currentSlot = 0;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        //Debug.Log("//tile : enter " + boardX + ", " + boardY);
        //if(GameManager.avail == true){
            _GM.dataTile(boardX - 1, boardY - 1, _GM._tanah[boardX - 1, boardY - 1]);
            checkArea();
        //}
        
    }

    private void OnMouseDown(){
        //cek _hand 
        if(_GM._hand != 0 && currentSlot == 0){
            //generate new array di _tanah
            _GM.addTanah(boardX - 1, boardY - 1, _GM._hand);
            spriteRenderer.sprite = _GM._ItemData.items[_GM._InventorySlot[currentSlot]].sprite;
        }
    }

    private void OnMouseExit()
    {
        //Debug.Log(boardX + ", " + boardY + " exit");
        spriteRenderer.material.color = (Color)(new Color32(255, 255, 255, 255));
    }

    public void checkArea()
    {
        spriteRenderer.material.color = (Color)(new Color32(182, 255, 182, 255));
    }
}
