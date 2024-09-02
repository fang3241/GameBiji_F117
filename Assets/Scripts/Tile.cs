using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int boardX;
    public int boardY;
    public SpriteRenderer spriteRenderer;
    public Sprite empty, tunas, tomat, kedelai, semangka, pagar;
    public GameManager _GM;
    public GameObject area;
    int currentSlot = 0;
    public int direction = 0; // 0 = null; 1= Up; 2 = Left; 3 = Right; 4 = Down
    public int state = 0; // 0 = null; 1 = tunas; 2 = tumbuh; 
    public int toNextState = 0; // 0 = null; else = berapa hari lagi buat ke state selanjutnya
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
        if(_GM._state == "none"){
            _GM.dataTile(boardX - 1, boardY - 1, _GM._tanah[boardX - 1, boardY - 1]);
            checkArea();
        }
        
    }

    private void OnMouseDown(){
        //cek _hand 
        if(_GM._hand != 0 && currentSlot == 0 && _GM._state == "none"){
            _GM.addTanah(boardX - 1, boardY - 1, _GM._hand);
            //tentuin arah
            Time.timeScale = 0.25f;
            _GM.darkTint(1);
            //generate ui panah 4 arah + cancel
            _GM.plantingUI(1);
            _GM.setupG(boardX, boardY);
            _GM._state = "planting";
            
            //_GM.darkTint(0);
            //Time.timeScale = 1.0f;
            //_GM.plantingUI(0);
            //change sprite
            //spriteRenderer.sprite = _GM._ItemData.items[_GM._InventorySlot[currentSlot]].sprite;
            Debug.Log("//Tile "+ boardX + ", " + boardY + " change to " + _GM._ItemData.items[_GM._InventorySlot[currentSlot]].name);
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

    public void setDir(int dir){
        direction = dir;
        Debug.Log("//Tile "+ boardX + ", " + boardY + " change dir to " + direction);
    }

    public void changeSprite(Sprite newSprite){
        spriteRenderer.sprite = newSprite;
    }
}
