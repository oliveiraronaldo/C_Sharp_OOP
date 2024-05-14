
namespace CompreAqui
{
    class Cliente
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Endereco { get; private set; }

        public Cliente(string nome, string email, string cpf, string endereco)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Endereco = endereco;
        }



        public override string ToString()
        {
            return $"[Nome: {Nome}, Email: {Email}, Cpf: {Cpf}, Endereço: {Endereco}]";
        }
    }
}