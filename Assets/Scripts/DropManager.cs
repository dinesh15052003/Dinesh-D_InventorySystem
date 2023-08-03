using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropManager : MonoBehaviour
{
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
    }
    private void OnDropButtonClicked()
    {
        countText.text = (int.Parse(countText.text) - dropSlider.value).ToString();
        dropSlider.value = int.Parse(countText.text) / 2;
    }
    private void OnDropAllButtonClicked()
    {
        countText.text = "0";
        dropSlider.value = int.Parse(countText.text) / 2;
    }
}
