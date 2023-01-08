using TMPro;
using UnityEngine;

namespace UI
{
    public class TaskManager: MonoBehaviour
    {
        public TextMeshProUGUI taskTitle;
        public TextMeshProUGUI taskDescription;

        public void SetTask(GameTask task)
        {
            taskTitle.text = task.title;
            taskDescription.text = task.description;
            gameObject.SetActive(true);
        }

        public void FinishTask(GameTask task)
        {
            gameObject.SetActive(false);
        }
    }
}