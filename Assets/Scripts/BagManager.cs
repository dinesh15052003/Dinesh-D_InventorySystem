using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject bagContentTemplate;

    public Dictionary<string, GameObject> bagItemsList = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddBagContent(Sprite sprite, string name, int count)
    {
        Debug.Log(name);
        if (!bagItemsList.ContainsKey(name))
        {
            GameObject btn = Instantiate(bagContentTemplate, scrollViewContent.transform);
            btn.transform.GetChild(1).GetComponent<Image>().sprite = sprite;
            btn.transform.GetChild(2).GetComponent<TMP_Text>().text = name;
            btn.transform.GetChild(3).GetComponent<TMP_Text>().text = count.ToString();

            bagItemsList[name] = btn;
        }
        else
        {
            TMP_Text countText = bagItemsList[name].gameObject.transform.GetChild(3).GetComponent<TMP_Text>();
            countText.text = (int.Parse(countText.text) + count).ToString();
        }
    }
}
