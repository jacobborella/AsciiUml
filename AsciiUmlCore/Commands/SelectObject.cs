﻿using AsciiUml.Geo;

namespace AsciiUml.Commands
{
    internal class SelectObject : ICommand
    {
        public readonly int id;
        public readonly bool moveCursor;

        public SelectObject(int id, bool moveCursor)
        {
            this.id = id;
            this.moveCursor = moveCursor;
        }

        public State Execute(State state)
        {
            var idx = state.Model.FindIndex(0, m => m.Id == id);
            var elem = state.Model[idx] as ISelectable;
            if (elem == null)
                return state;

            state.SelectedIndexInModel = idx;
            state.SelectedId = id;
            if (moveCursor)
                state.TheCurser = new Cursor(elem.Pos);

            return state;
        }
    }
}