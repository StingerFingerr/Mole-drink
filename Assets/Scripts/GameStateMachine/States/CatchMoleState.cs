using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace GameStateMachine
{
    public class CatchMoleState: BaseState
    {
        public TaskManager taskManager;
        public GameTask catchMoleTask;
        
        public List<Hole> holes;
        public Mole mole;
        
        public float changeHoleFrequency;
        
        private Coroutine _catchingCoroutine;
        
        public override void Enter()
        {
            taskManager.SetTask(catchMoleTask);
            onEnter?.Invoke();
            mole.onCatch.OnPressed += Exit;
            
            StartCoroutine(AppearanceHoles());
        }

        public override void Exit()
        {
            taskManager.FinishTask();
            mole.onCatch.OnPressed -= Exit;
            StopCoroutine(_catchingCoroutine);
            
            nextState?.Enter();
        }

        private IEnumerator AppearanceHoles()
        {
            foreach (var hole in holes)
            {
                hole.Show();
                yield return new WaitForSeconds(.4f);
            }

            _catchingCoroutine = StartCoroutine(CatchMole());
        }

        private IEnumerator CatchMole()
        {
            while (true)
            {
                yield return new WaitForSeconds(changeHoleFrequency);
                mole.ChangeHole(GetRandomHole());
            }
        }

        private Hole GetRandomHole() => 
            holes[Random.Range(0, holes.Count)];
    }
}