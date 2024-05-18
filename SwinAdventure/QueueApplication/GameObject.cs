﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{   

    public class GameObject : IdentifiableObject
    {
        private string _name;
        private string _description;

        public GameObject(string[] idents, string name, string desc) : base(idents)
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public string ShortDescription
        {
            get
            {
                return Description + " (" + FirstId + ")";
            }
        }

        public virtual string FullDescription
        {
            get
            {
                return Description;
            }
        }


    }
}

