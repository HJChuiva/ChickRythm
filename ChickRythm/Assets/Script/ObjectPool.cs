using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//오브젝트 풀링 클래스 만듬
public class ObjectInfo
{
    public GameObject goPrefab;
    public int count;
    public Transform tfPoolParent;
}

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] ObjectInfo[] objectInfo = null;

    //큐타입으로 만들어 선입선출로 제작
    public Queue<GameObject> noteQueue = new Queue<GameObject>();

    void Start()
    {
        instance = this;
        noteQueue = InsertQueue(objectInfo[0]);
    }


    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo)
    {
        Queue<GameObject> t_queue = new Queue<GameObject>();
        for (int i = 0; i < p_objectInfo.count; i++)
        {
            GameObject t_clone = Instantiate(p_objectInfo.goPrefab, transform.position, Quaternion.identity);
            t_clone.SetActive(false);       //바로 비활성화
            if (p_objectInfo.tfPoolParent != null)
                t_clone.transform.SetParent(p_objectInfo.tfPoolParent);
            else
                t_clone.transform.SetParent(this.transform);

            t_queue.Enqueue(t_clone);
        }
        return t_queue;
    }
}
