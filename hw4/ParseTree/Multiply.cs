﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    public class Multiply : Operator
    {
        Multiply()
        {
            this.operation = '*';
        }
        public override int Calculate()
        {
            return this.rightSon.Calculate() * this.leftSon.Calculate();
        }
    }
}
