using Newtonsoft.Json;
using System;

namespace Bari.Model
{
    public class Message
    {
        private Guid id;
        public Guid Id
        {
            get
            {
                if (id == Guid.Empty)
                    id = Guid.NewGuid();
                return id;
            }
            set
            {
                id = value;
            }
        }

        //public Guid Id { get; } = Guid.NewGuid();

        private int idRequisicao;
        public int IdRequisicao
        {
            get
            {
                if (idRequisicao == 0)
                    idRequisicao = new Random().Next(100);
                return idRequisicao;
            }
            set 
            {
                idRequisicao = value;
            }
            
        }
        private DateTime timeStamp;
        public DateTime TimeStamp 
        {
            get
            {
                if (timeStamp.Equals(DateTime.MinValue))
                    timeStamp = DateTime.Now;
                return timeStamp; 
            }
            set 
            {
                timeStamp = value;
            } 
        }
        public string Mensagem { get; set; }

        public Message() { }
        public Message(string message)
        {
            Id = Guid.NewGuid();
            IdRequisicao = new Random().Next(100);
            TimeStamp = DateTime.Now;
            Mensagem = message;
        }

    }
}
