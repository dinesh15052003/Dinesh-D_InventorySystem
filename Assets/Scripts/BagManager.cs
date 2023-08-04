using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject bagScrollView;
    public GameObject scrollViewContent;
    public GameObject bagContentTemplate;

    [Header("Right Hand")]
    public GameObject rightHand;

    [Header("Gun Prefabs")]
    public GameObject M416;
    public GameObject AKM;

    private GameObject gunPrefab;

    public Dictionary<string, GameObject> bagItemsList = new Dictionary<string, GameObject>();
    public Dictionary<string, string> gunBulletPairs = new Dictionary<string, string>();

    public static bool hasWeapon = false;
    public static string currentGun = "";
    public static int availbleBulletCount = 0;
    public static TMP_Text currentBulletCountText;
    // Start is called before the first frame update
    void Start()
    {
        gunBulletPairs.Add("M416", "9mm Ammo");
        gunBulletPairs.Add("AKM", "7mm Ammo");
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            availbleBulletCount = int.Parse(bagItemsList[gunBulletPairs[currentGun]].transform.GetChild(3).GetComponent<TMP_Text>().text);
            currentBulletCountText = bagItemsList[gunBulletPairs[currentGun]].transform.GetChild(3).GetComponent<TMP_Text>();
        }
        catch (System.Exception ex)
        {

        }
        
    }
    public void AddBagContent(Sprite sprite, string name, int count, bool isWeapon)
    { 
        if (isWeapon)
        {
            if (name == "M416")
            {
                gunPrefab = Instantiate(M416, rightHand.transform);
                currentGun = name;
            }
            else if(name == "AKM")
            {
                gunPrefab = Instantiate(AKM, rightHand.transform);
                currentGun = name;
            }
            hasWeapon = true;
        }

        if (!bagItemsList.ContainsKey(name) || (bagItemsList.ContainsKey(name) && bagItemsList[name] == null))
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
    public void OnBagBtnClicked()
    {
        bagScrollView.SetActive(!bagScrollView.activeSelf);
    }
    public void DestroyGun()
    {
        Destroy(gunPrefab);
    }
}
