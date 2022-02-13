namespace GestaoClientesMSA.Models
{
    public class Telefone
    {
        // id
        public virtual int Id { get; protected set; }

        // size 30, required
        public virtual string Numero { get; set; }

        // required, 
        public virtual TelefoneTipo Tipo { get; set; }

        // relationship to cliente
        public virtual Cliente Cliente { get; set; }
    }
}
