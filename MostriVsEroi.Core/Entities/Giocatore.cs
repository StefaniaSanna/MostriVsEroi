using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public class Giocatore
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public List<Eroe> eroi { get; set; } = new List<Eroe>();

        public void SetAdmin()
        {
            Eroe eroe = eroi.FirstOrDefault(eroi => eroi.Livello >=3);
            if (eroe == null)
                IsAdmin = false;
            else
                IsAdmin = true;
        }

         


    }
}
