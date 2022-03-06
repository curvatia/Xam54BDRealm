using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xam54BDRealm.Models;

namespace Xam54BDRealm.Repositories
{
    internal class RepositoryRealm
    {
        //NEW
        private Realm conexionrealm;
        Transaction transaction;

        public RepositoryRealm()
        {
            //CREAMOS EL OBJETO QUE NOS PERMITIRA CONECTARNOS
            //CON REALM EN CADA DISPOSITIVO
            this.conexionrealm = Realm.GetInstance();//CREA UNA INSTANCIA DE LA BBDD DEL DISPOSITIVO
        }

        //METODO PARA DEVOLVER TODOS LOS OBJETOS PERSONAJES
        public List<Personaje> GetPersonajes()
        {
            List<Personaje> lista = this.conexionrealm.All<Personaje>().ToList();
            return lista;
        }
                
        public Personaje BuscarPersonaje(int idpersonaje)
        {
            //RECUPERAMOS TODOS LOS PERSONAJES INICIALES
            List<Personaje> lista = this.GetPersonajes();

            //BUSCAMOS UN PERSONAJE EN CONCRETO
            Personaje personaje = lista.FirstOrDefault(z => z.IdPersonaje == idpersonaje);
            return personaje;
        }

        public int GetMaximoPersonaje()
        {
            //RECUPERAMOS TODOS LOS PERSONAJES ACUMULADOS
            List<Personaje> lista = this.GetPersonajes();
            return lista.Count + 1;
        }

        //METODO PARA INSERTAR EN REALM
        public void InsertarPersonaje(Personaje personaje)
        {
            transaction = conexionrealm.BeginWrite();
            var entry = conexionrealm.Add(personaje);
            transaction.Commit();
            //this.conexionrealm.Write(() =>
            //{
            //    //CREAMOS UN NUEVO PERSONAJE PARA INSERTAR
            //    //EN EL METODO WRITE
            //    Personaje newpersonaje = new Personaje();
            //    newpersonaje.IdPersonaje = this.GetMaximoIdPersonaje();
            //    newpersonaje.Nombre = personaje.Nombre;
            //    newpersonaje.Serie = personaje.Serie;
            //});
        }

        //METODO PARA MODIFICAR EN REALM
        public void ModificarPersonaje(Personaje personaje)
        {
            //BUSCAMOS UN PERSONAJE EN CONCRETO
            Personaje existepersonaje = this.BuscarPersonaje(personaje.IdPersonaje);

            //UTILIZAMOS TRANSACCIONES PARA MODIFICAR EL PERSONAJE
            using (var trans = this.conexionrealm.BeginWrite())
            {
                //EL IdPersonaje SALE DESHABILITADO SOLO DEJA MODIFICAR Nombre Y Serie
                existepersonaje.Nombre = personaje.Nombre;
                existepersonaje.Serie = personaje.Serie;   
                trans.Commit();
            }
        }

        //METODO PARA ELIMINAR EN REALM
        public void EliminarPersonaje(int idpersonaje)
        {
            //BUSCAMOS UN PERSONAJE EN CONCRETO
            Personaje personaje = this.BuscarPersonaje(idpersonaje);

            //UTILIZAMOS TRANSACCIONES PARA ELIMINAR EL PERSONAJE
            if (personaje != null)
            {
                using (var trans = this.conexionrealm.BeginWrite())
                {
                    this.conexionrealm.Remove(personaje);
                    trans.Commit();
                }
            }
        }


    }
}
