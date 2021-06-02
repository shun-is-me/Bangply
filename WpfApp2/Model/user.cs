using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    class user
    {
        private string Id;

        public string uId
        {
            get { return Id; }
            set { Id = value; }
        }

        private string Pwd;

        public string uPwd
        {
            get { return Pwd; }
            set { Pwd = value; }
        }

        private string Nname;

        public string uNname
        {
            get { return Nname; }
            set { Nname = value; }
        }

    }
}
