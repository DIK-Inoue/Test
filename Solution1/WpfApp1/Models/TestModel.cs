using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class TestModel : BindableBase
    {
        public decimal? test = 1.5m;
        public decimal? Test
        {
            get { return test; }
            set { SetProperty(ref test, value); }
        }

        internal void ExecuteTest()
        {
            Console.WriteLine("M : " + Test);
        }
    }
}
