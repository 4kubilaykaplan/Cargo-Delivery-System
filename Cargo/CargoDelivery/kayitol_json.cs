using System;
using System.Collections.Generic;
using System.Text;

namespace CargoDelivery
{
    class kayitol_json
    {
        public String username;
        public String email;
        public String password;
        public kayitol_json(String username,String email,String password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }
    }
}
