﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPresenterRemote
{
    internal class ItemData
    {
        public string UUID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
    internal class Config
    {
        public string ip;
        public int port;
        public ItemData beforeServiceLook;
        public ItemData normalLook;
        public ItemData beforeServiceProp;
        public ItemData pipProp;
    }
}
