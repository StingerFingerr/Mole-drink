using TMPro;
using UnityEngine;

namespace UI
{
    public class TaskManager: MonoBehaviour
    {
        public AudioSource audioSource;
        public TextMeshProUGUI taskDescription;

        public void SetTask(GameTask task)
        {
            FinishTask();
            audioSource.Play();
            taskDescription.text = task.description;
            gameObject.SetActive(true);
        }

        public void FinishTask() => 
            gameObject.SetActive(false);
    }
}