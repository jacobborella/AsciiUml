﻿using AsciiUml.Commands;

namespace AsciiUml
{
    internal class ClearSelection : ICommand
    {
        public State Execute(State state)
        {
            return Program.ClearSelection(state);
        }
    }
}