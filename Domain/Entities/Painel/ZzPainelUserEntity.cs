using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Painel
{
    public class ZzPainelUserEntity
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string cpf { get; set; }
        public string claims { get; set; }
        public DateTime create_time { get; set; }
        public DateTime? edit_time { get; set; }
        public bool excluido { get; set; }
        public DateTime? ban_time { get; set; }
        public int validations_wrong { get; set; }
        public DateTime? timeout { get; set; }
    }
}
