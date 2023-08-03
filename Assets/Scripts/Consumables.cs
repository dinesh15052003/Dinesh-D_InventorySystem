using System.Collections;
using System.Collections.Generic;
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
        Sprite image = consumables.gameObject.GetComponent<BaseItem>().image;
        string name = consumables.gameObject.GetComponent<BaseItem>().Name;
        int count = consumables.gameObject.GetComponent<BaseItem>().count;
        bagmanager.AddBagContent(image, name, count);
        Destroy(consumables);
        Destroy(gameObject);
    }
}
