using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialToastCaller : MonoBehaviour
{
    [SerializeField] private List<string> toastList;
    private int index = 0;

    private void Start()
    {
        toastList.Add("press Right Trigger to Shoot");
        toastList.Add("press Left Trigger to Dash");
        toastList.Add("try dashing through projectiles");
        toastList.Add("press either Bumper for Special");
        StartCoroutine(QueueMessage());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator QueueMessage()
    {
        while (true)
        {
            ToastManager.Toast(toastList[index]);
            index = (index + 1 < toastList.Count) ? index + 1 : 0;
            yield return new WaitForSeconds(3);
        }
    }
}
