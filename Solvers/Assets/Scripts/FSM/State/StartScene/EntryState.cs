using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.CONTROLLER;
using DG.Tweening;

namespace SOLVERS.FSM.STATE
{
    public class EntryState : State
    {
        StartSceneController _startSceneController;

        public EntryState(StartSceneController startSceneController)
        {
            _startSceneController = startSceneController;
        }

        public override void CheckStateChange() 
        {
            if(Input.anyKeyDown) _startSceneController.FSM.SetState(StartSceneController.State.Login);
        }

        public override void OnStateEnter() 
        {
            _startSceneController.StartGo.SetActive(true);
            FadeOut();
        }

        void FadeIn()
        {
            _startSceneController.PressTxt.DOColor(new Color(0, 0, 0, 1), 1.3f).onComplete += FadeOut;
        }

        void FadeOut()
        {
            _startSceneController.PressTxt.DOColor(new Color(0, 0, 0, 0), 1.3f).onComplete += FadeIn;
        }

        void ClearTweening()
        {
            _startSceneController.PressTxt.color = new Color(0, 0, 0, 1);
            DOTween.Kill(_startSceneController.PressTxt);
        }

        public override void OnStateExit() 
        {
            ClearTweening();
            _startSceneController.StartGo.SetActive(false);
        }
    }
}