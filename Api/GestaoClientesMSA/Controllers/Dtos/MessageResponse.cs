namespace GestaoClientesMSA.Controllers.Dtos
{
    public class MessageResponse
    {
        public bool Status { get; set; }
        public string Mensagem { get; set; }

        public MessageResponse(string mensagem, bool status = true)
        {
            Mensagem = mensagem;
            Status = status;
        }
    }
}
