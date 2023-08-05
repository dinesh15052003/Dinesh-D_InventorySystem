using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingManager : MonoBehaviour
{
    public AudioManager audioManager;

    public Transform parentPlayer;

    [SerializeField] private List<GameObject> collectableList = new List<GameObject>();

    private Dictionary<string, GameObject> prefabIndexPairs = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        InitializePrefabIndexPairs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void InitializePrefabIndexPairs()
    {
        for (int i = 0; i < collectableList.Count; i++)
        {
            prefabIndexPairs[collectableList[i].name] = collectableList[i];
        }
    }
    public void DropObject(string name, int count)
    {
        if (count > 0)
        {
            audioManager.PlayItemDropSound();
            GameObject prefab = Instantiate(prefabIndexPairs[name]);
            if (prefab.CompareTag("Weapon"))
            {
                GameObject.Find("BagManager").GetComponent<BagManager>().DestroyGun();
                BagManager.hasWeapon = false;
            }
            prefab.transform.position = new Vector3(parentPlayer.position.x, parentPlayer.position.y + 0.27f, parentPlayer.position.z);
            prefab.gameObject.GetComponent<BaseItem>().count = count;
        }
    }
}
