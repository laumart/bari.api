using System;
using Xunit;

namespace Bari.Model.Test
{
    public class UnitTest1 
    {
        private readonly Message _message;
        public UnitTest1()
        {
            _message = new Message("Helloworld");
        }
            
        [Fact]
        public void Message_Construtor_Vazio()
        {
            Message message = new Message();
            Assert.Null(message.Mensagem);
            //Assert.Empty(message.Id);
            //Assert.Empty(messsage.TimeStamp);
            //Assert.Empty(message.IdRequisicao);
        }

        [Fact]
        public void Menssage_Contrutor_NVazio()
        {
            const string Texto = "Helloworld";
            Guid guid = Guid.NewGuid();
            _message.Id = guid;
            DateTime dateTime = DateTime.Now;
            _message.TimeStamp = dateTime;
            int random = new Random().Next(100);
            _message.IdRequisicao = random;

            Assert.Equal(Texto, _message.Mensagem);
            Assert.Equal(guid, _message.Id);
            Assert.Equal(dateTime, _message.TimeStamp);
            Assert.Equal(random, _message.IdRequisicao);

        }
    }
}
