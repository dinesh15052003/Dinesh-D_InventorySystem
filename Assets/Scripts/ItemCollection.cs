using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    public GameObject scrollView;

    public GameObject scrollViewContent;
    public GameObject buttonTemplate;

    private Dictionary<GameObject, GameObject> nearbyItems = new Dictionary<GameObject, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        scrollView.SetActive(true);

        if (!nearbyItems.ContainsKey(other.gameObject))
        {
            GameObject btn = Instantiate(buttonTemplate, scrollViewContent.transform);
            btn.transform.GetChild(1).GetComponent<Image>().sprite = other.gameObject.GetComponentInParent<BaseItem>().image;
            btn.transform.GetChild(2).GetComponent<TMP_Text>().text = other.gameObject.GetComponentInParent<BaseItem>().Name;
            btn.transform.GetChild(3).GetComponent<TMP_Text>().text = other.gameObject.GetComponentInParent<BaseItem>().count.ToString();
            if (other.gameObject.transform.parent.CompareTag("Weapon"))
            {
                btn.transform.GetChild(4).GetComponent<TMP_Text>().text = other.gameObject.GetComponentInParent<BaseItem>().Description;
            }
            btn.transform.GetComponent<Consumables>().consumables = other.gameObject.transform.parent.gameObject;
            nearbyItems.Add(other.gameObject, btn);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        scrollView.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        scrollView.SetActive(false);

        if (nearbyItems.ContainsKey(other.gameObject))
        {
            GameObject obj = nearbyItems[other.gameObject];
            Destroy(obj);
            nearbyItems.Remove(other.gameObject);
        }
    }
}
