using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xam54BDRealm.Models;
using Xam54BDRealm.Repositories;
using Xam54BDRealm.ViewModels.Base;

namespace Xam54BDRealm.ViewModels
{
    internal class PersonajesViewModel : ViewModelBase
    {
        private RepositoryRealm repo;

        public PersonajesViewModel()
        {
            this.repo = new RepositoryRealm();
            List<Personaje> lista = this.repo.GetPersonajes();
            Personajes = new ObservableCollection<Personaje>(lista);//AL CAMBIAR DE VENTANA LOS DATOS SIGUEN VISIBLES, NO DESAPARECEN
        }

        private ObservableCollection<Personaje> _Personajes;

        //LA PROPIEDAD QUE DEVUELVE LA LISTA DE TODAS LAS PERSONAS SE LLAMA Personajes
        private ObservableCollection<Personaje> Personajes
        {
            get { return this._Personajes; }
            set { this._Personajes = value; OnPropertyChanged("Personajes"); }
        }


    }
   
}
