﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_learning_with_a_model
{
    public interface IObserver
    {
        void UpdateState();
    }
}
