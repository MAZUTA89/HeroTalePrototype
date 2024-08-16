using System;
using System.Collections.Generic;

namespace HTP.Machine.States
{
    public interface IUnitState
    {
        void Enter();
        void Exit();
        void Perform();
    }
}
