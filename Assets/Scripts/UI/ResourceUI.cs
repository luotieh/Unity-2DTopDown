using System.Collections;
using System.Collections.Generic;
using System.Resources;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ResourceUI : MonoBehaviour
{
    private ResourceTypeListSO resourceTypeList;
    private Dictionary<ResourceTypeSO, Transform> resourceTypeTransformDictionary;
    private void Awake(){
        // 获取resourceTypeList
        resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        resourceTypeTransformDictionary = new Dictionary<ResourceTypeSO, Transform>();

        Transform resourceTemplate = transform.Find("resourceTemplate");
        resourceTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            Transform resourceTransform =  Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);
            // 定位
            Vector2 initPosition = new Vector2(-110, -15);
            float offsetAmount = -160f;
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(initPosition.x + offsetAmount * index, initPosition.y);
            
            // 添加image
            resourceTransform.Find("image").GetComponent<Image>().sprite = resourceType.sprite;
            // set当前resourceType的Transform
            resourceTypeTransformDictionary[resourceType] = resourceTransform;
            

            index++;
        }
    }

    private void Start(){
        ResourceManager.Instance.OnResourceAmountChanged += ResourceManager_OnResourceAmountChanged;

        UpdateResourceAmount();
    }

    // 仅当添加Resource时，更新UI数据
    private void ResourceManager_OnResourceAmountChanged(object sender, System.EventArgs e){
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount(){
        foreach (ResourceTypeSO resourceType in resourceTypeList.list){
            Transform resourceTransform = resourceTypeTransformDictionary[resourceType];

            // 获取数量
            int resourceAmount = ResourceManager.Instance.GetResourceAmount(resourceType);
            resourceTransform.Find("text").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
        }
    }

}
