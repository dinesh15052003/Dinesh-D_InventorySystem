using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Consumables : MonoBehaviour
{
    public GameObject consumables;

    private BagManager bagmanager;

    // Start is called before the first frame update
    void Start()
    {
        bagmanager = GameObject.Find("BagManager").GetComponent<BagManager>();
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClick()
    {
        bool isWeapon = consumables.gameObject.CompareTag("Weapon");
        if (isWeapon && BagManager.hasWeapon)
        {
            GameObject.Find("Error Text").GetComponent<TMP_Text>().text = "Only one gun can be equipped at a time. Drop the gun to equip another.";
            StartCoroutine(SetGameObjectToFalse());
            return;
        }
        Sprite image = consumables.gameObject.GetComponent<BaseItem>().image;
        string name = consumables.gameObject.GetComponent<BaseItem>().Name;
        int count = consumables.gameObject.GetComponent<BaseItem>().count;
        bagmanager.AddBagContent(image, name, count, isWeapon);
        Destroy(consumables);
        Destroy(gameObject);
    }
    private System.Collections.IEnumerator SetGameObjectToFalse()
    {
        yield return new WaitForSeconds(1f);

        GameObject.Find("Error Text").GetComponent<TMP_Text>().text = "";
    }
}
