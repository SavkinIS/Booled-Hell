using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;

namespace Assets.Scripts
{
    public class Moving
    {
        public ReactiveProperty<float> Speed { get; set; }
    }
}
