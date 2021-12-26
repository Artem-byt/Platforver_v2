using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer 
{
    public class Controllers : IInitialize, IExecute, ICleanUp
    {
        private List<IInitialize> _initializeControllers;
        private List<IExecute> _iexecuteControllers;
        private List<ICleanUp> _icleanupControllers;


        internal Controllers()
        {
            _initializeControllers = new List<IInitialize>(8);
            _iexecuteControllers = new List<IExecute>(8);
            _icleanupControllers = new List<ICleanUp>(8);
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IInitialize initializecontroller)
            {
                _initializeControllers.Add(initializecontroller);
            }
            else if (controller is IExecute executecontroller)
            {
                _iexecuteControllers.Add(executecontroller);
            }
            else if (controller is ICleanUp cleanupcontroller)
            {
                _icleanupControllers.Add(cleanupcontroller);
            }
            return this;
        }

        public void Initialize()
        {
            foreach (IInitialize element in _initializeControllers)
            {
                element.Initialize();
            }
        }

        public void Execute()
        {
            for (int i = 0; i < _iexecuteControllers.Count; i++)
            {
                _iexecuteControllers[i].Execute();
            }
        }

        public void CleanUp()
        {
            foreach (ICleanUp element in _icleanupControllers)
            {
                element.CleanUp();
            }
        }

        public void RemoveAll()
        {
            _initializeControllers.Clear();
            _iexecuteControllers.Clear();
            _icleanupControllers.Clear();
        }
    }
}


