using UnityEngine;
using DG.Tweening;
public class konbu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.DOMove(new Vector3(-1017f, 0f, 0f), 3f).SetLoops(-1, LoopType.Restart);
   

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
