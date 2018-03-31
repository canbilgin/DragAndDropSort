using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts
{
    public interface IFacade
    {
        void Method1();
        void Method2();
        void Method3();
        void Method4();
        void Method5();
        void Method6();
    }

    public partial class MyFacade : IFacade
    {
        public void Method1()
        {
            throw new NotImplementedException();
        }

        public void Method2()
        {
            throw new NotImplementedException();
        }

        public void Method3()
        {
            throw new NotImplementedException();
        }
    }
}
