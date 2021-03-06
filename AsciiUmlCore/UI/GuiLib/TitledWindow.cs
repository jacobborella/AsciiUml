﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsciiUml.Geo;

namespace AsciiUml.UI.GuiLib
{
    class TitledWindow : GuiComponent
    {
        private readonly string title;
        const string CloseButton = " [x] ";

        public TitledWindow(WindowManager manager, string title) : base(manager)
        {
            this.title = title;
        }

        public TitledWindow(GuiComponent parent, string title) : base(parent)
        {
            this.title = title;
        }

        public override bool HandleKey(ConsoleKeyInfo key)
        {
            return false;
        }

        public override Canvass Paint()
        {
            var size = Dimensions;
            if (Dimensions.IsFullyAutosize())
            {
                Position = Children.Single().Position - GetInnerCanvasTopLeft(); // todo find max spanning area of all children
                var childrensSize = GetSize();
                var mySize = new GuiDimensions(new Size(title.Length + CloseButton.Length), childrensSize.Height);
                size = GuiDimensions.Max(childrensSize, mySize);
            }
            else
            {
                Position = Parent.GetInnerCanvasTopLeft();
            }

            var titleline = title.PadRight(size.Width.Pixels - CloseButton.Length) + CloseButton;

            var c = new Canvass();
            c.RawPaintString(titleline, 0, 0, ConsoleColor.DarkGray, ConsoleColor.Gray);
            var line = "".PadRight(size.Width.Pixels);
            for (int y = 1; y < size.Height.Pixels; y++)
                c.RawPaintString(line, 0, y, BackGround, Foreground);

            return c;
        }

        public override void RemoveChild(GuiComponent child)
        {
            RemoveMeAndChildren();
        }

        public override Coord GetInnerCanvasTopLeft()
        {
            return new Coord(0, 1);
        }

        public override GuiDimensions GetSize()
        {
            var size = base.GetSize();
            size.Height.Pixels += 1;
            return size;
        }
    }
}
