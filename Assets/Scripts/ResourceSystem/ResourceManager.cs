using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceManager : MonoBehaviour
{   
    public static ResourceManager Instance {get; private set;}
    // 触发事件
    public event EventHandler OnResourceAmountChanged;
    // 使用dict存储各个资源的数量
    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;

    // 使用Awake而不是Start，Awake run before Start, 初始化dict不以来其他资源，故使用Awake
    private void Awake(){

        Instance = this;

        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);


        // 初始化dict的各个资源数量
        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            resourceAmountDictionary[resourceType] = 0;
        }

        TestLogResourceAmountDictionary();

    }

    private void Update(){
        // if (Input.GetKeyDown(KeyCode.V))
        // {
        //     ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        //     AddResource(resourceTypeList.list[0], 2);
        // }
    }

    private void TestLogResourceAmountDictionary() {
        foreach (ResourceTypeSO resourceType in resourceAmountDictionary.Keys)
        {
            Debug.Log(resourceType.nameString + ":" + resourceAmountDictionary[resourceType]);
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount){
        resourceAmountDictionary[resourceType] += amount;

        // 如果OnResourceAmountChanged不为null，则触发此事件
        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
        // TestLogResourceAmountDictionary();
    }

    public int GetResourceAmount(ResourceTypeSO resourceType){
        return resourceAmountDictionary[resourceType];
    }
}
