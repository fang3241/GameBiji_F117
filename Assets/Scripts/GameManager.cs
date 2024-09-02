using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public EntityData _ED;
    public ItemData _ItemData;
    public GameObject[] InventoryBtn;
    public int _hand;
    public int[] _InventorySlot;
    public int[,] _tanah;
    public GameObject _darkTint;
    public GameObject _plantingUI;
    public int _x, _y;  //-1 = null
    public GameObject _tiles;
    public string _state = "none";

    // Start is called before the first frame update
    void Start()
    {
        _InventorySlot = new int[10];
        for(int i = 0; i < 10; i++){
            _InventorySlot[i] = 0;
        }

        _tanah = new int[9, 9];
        for(int i = 0; i < 9; i++){
            for(int j = 0; j < 9; j++){
                _tanah[i, j] = 0;
            }
        }
        changeInventory(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dataTile(int x, int y, int idItem){
        Debug.Log("//GameManager : enter " + x + ", " + y + "; id: " + idItem);
    }

    public void InventoryClick(int slot){
        Debug.Log("//GameManager : InventoryClick " + slot);
        if(_hand == slot){
            _hand = 0;
        }
        else{
            _hand = slot;
        }
        Debug.Log("//GameManager : _hand " + _hand);
    }

    public void changeInventory(int slot, int itemID){
        if(itemID != -1){
            _InventorySlot[slot] = itemID;
            Debug.Log("//GameManager : changeInventory.name: " + _ItemData.items[slot].name);
            Debug.Log("//GameManager : changeInventory.sprite: " + _ItemData.items[slot].sprite);
            InventoryBtn[slot].GetComponent<Image>().sprite = _ItemData.items[slot].sprite;
            Debug.Log("//GameManager : changeInventory " + slot + "; " + itemID);
        }
    }

    public void addTanah(int x, int y, int slot){
        //cek selot tanah
        if(_tanah[x, y] == 0){
            _tanah[x, y] = _hand;
            Debug.Log("//GameManager : addTanah " + x + ", " + y + "; slot: " + _hand);
        }
        //[!]TODO bikin pengecualian buat pupuk & potion
    }

    public void darkTint(int state){
        if(state == 0){
            _darkTint.SetActive(false);
        }
        else if(state == 1){
            _darkTint.SetActive(true);
        }
    }

    public void plantingUI(int state){
        if(state == 0){
            _plantingUI.SetActive(false);
        }
        else if(state == 1){
            _plantingUI.SetActive(true);
        }
    }

    public void setupG(int x, int y){
        _x = x;
        _y = y;
    }

    GameObject findCurrentTile(GameObject tiles, int x, int y)
    {
        foreach (Transform child in tiles.transform) // Loop through each child of the current GameObject
        {
            Tile tileScript = child.GetComponent<Tile>(); // Get the script attached to the child
            if (tileScript != null && tileScript.boardX == x && tileScript.boardY == y)
            {
                return child.gameObject; // Return the child GameObject if the value matches
            }
        }

        return null; // Return null if no matching child is found
    }

    public void setDirection(int dir){  // 0 = null; 1= Up; 2 = Left; 3 = Right; 4 = Down
        if(_x != -1 && _y != -1){
            if(dir != 0){
                GameObject currentTile = findCurrentTile(_tiles, _x, _y);
                Tile tileData = currentTile.GetComponent<Tile>();
                tileData.setDir(dir);
                tileData.changeSprite(_ItemData.items[_InventorySlot[_hand]].sprite);
            }
            darkTint(0);
            Time.timeScale = 1.0f;
            plantingUI(0);
            _x = -1;
            _y = -1;
            _state = "none";
            _hand = 0;
        }
    }
}
