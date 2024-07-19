using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base.Response
{
    public class ResponseModel<T>
    {
        public ResponseModel(bool Succcess = false)
        {
            this.Sucesso = Succcess;
        }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T Resposta { get; set; }
    }
}
