using TMPro;
using UnityEngine;

namespace UI
{
    public class TaskManager: MonoBehaviour
    {
        public TextMeshProUGUI taskDescription;

        public void SetTask(GameTask task)
        {
            FinishTask();
            taskDescription.text = task.description;
            gameObject.SetActive(true);
        }

        public void FinishTask() => 
            gameObject.SetActive(false);
    }
}