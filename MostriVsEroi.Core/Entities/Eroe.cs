using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public class Eroe
    {
        public int Id { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public int IdArma { get; set; }
        public int IdGiocatore { get; set; }
        public int Livello { get; set; }
        public int PuntiAccumulati { get; set; }
        public int PuntiVita { get; set; }

        public void CalcolaLivello()
        {
            switch (PuntiAccumulati)
            {
                case int n when (n <= 29):
                    Livello = 1;
                    PuntiVita += 20;
                    break;
                case int n when (n > 29 && n <=59):
                    Livello = 2;
                    PuntiVita += 40;
                    break;
                case int n when (n > 59 && n <= 89):
                    Livello = 3;
                    PuntiVita += 60;
                    break;
                case int n when (n > 89 && n <= 119):
                    Livello = 4;
                    PuntiVita += 80;
                    break;
                case int n when (n >119):
                    Livello = 5;
                    PuntiVita += 100;
                    break;
            }
        }


    }
    public enum CategoriaEnum
    {
        Guerriero =1,
        Mago = 2,
        Cultista = 3,
        Orco = 4,
        SignoreDelMale = 5
    }
}
