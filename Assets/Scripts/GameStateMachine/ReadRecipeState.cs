using System.Collections.Generic;
using Cinemachine;
using UI;
using UnityEngine;

namespace GameStateMachine
{
    public class ReadRecipeState: BaseState
    {
        public InteractableObject recipesBook;
        public TaskManager taskManager;
        public MessageWindow messageWindow;
        public ClosableWindow recipe;
        public CinemachineFreeLook freeLook;
        
        public GameTask findRecipeTask;
        public GameMessage readRecipeMessage;
        
        public override void Enter()
        {
            Subscribe();
            SetTask();
        }

        public override void Exit()
        {
            freeLook.enabled = true;
            
            nextState?.Enter();
        }

        private void SetTask()
        {
            taskManager.SetTask(findRecipeTask);
        }

        private void FinishTask()
        {
            recipesBook.OnPressed -= FinishTask;
            
            recipesBook.Interact();
            freeLook.enabled = false;
            
            taskManager.FinishTask(findRecipeTask);
            messageWindow.ShowMessage(readRecipeMessage, OpenRecipe);
        }

        private void OpenRecipe()
        {
            recipe.gameObject.SetActive(true);
            recipe.OnClose += Continue;
        }

        private void Continue()
        {
            recipe.OnClose -= Continue;
            recipe.gameObject.SetActive(false);
            
            Destroy(recipesBook.gameObject);
            
            Exit();
        }

        private void Subscribe()
        {
            recipesBook.OnPressed += FinishTask;
        }
    }
}