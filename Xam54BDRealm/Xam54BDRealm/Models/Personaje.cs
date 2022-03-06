using Realms;
using System;
using System.Collections.Generic;
using System.Text;
using Xam54BDRealm.ViewModels;

namespace Xam54BDRealm.Models
{
    internal class Personaje : RealmObject
    {
        public int IdPersonaje { get; set; }
        public string Nombre { get; set; }
        public string Serie { get; set; }

    
    }
   
}
