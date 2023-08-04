using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text title;
    public TMP_Text countText;
    public Button dropBtn;
    public Button dropAllBtn;

    public Slider dropSlider;
    public TMP_Text dropCount;
    // Start is called before the first frame update
    void Start()
    {
        dropBtn.onClick.AddListener(OnDropButtonClicked);
        dropAllBtn.onClick.AddListener(OnDropAllButtonClicked);

        
        dropSlider.value = int.Parse(countText.text) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        dropSlider.maxValue = int.Parse(countText.text);
        dropCount.text = dropSlider.value.ToString();

        if (int.Parse(countText.text) == 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    private void OnDropButtonClicked()
    {
        GameObject.Find("DroppingManager").GetComponent<DroppingManager>().DropObject(title.text, (int)dropSlider.value);
        countText.text = (int.Parse(countText.text) - dropSlider.value).ToString();
        dropSlider.value = int.Parse(countText.text) / 2;
    }
    private void OnDropAllButtonClicked()
    {
        GameObject.Find("DroppingManager").GetComponent<DroppingManager>().DropObject(title.text, int.Parse(countText.text));
        Destroy(gameObject.transform.parent.gameObject);
    }
}
