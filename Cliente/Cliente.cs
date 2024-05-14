namespace Cliente
{
    class Client
    {
        public string Name { get; private set; }
        public string Endereco { get; private set; }
        public string Cpf { get; private set; }
        public int Idade { get; private set; }

        public Client(string name, string endereco, string cpf, int idade)
        {
            Name = name;
            Endereco = endereco;
            Cpf = cpf;
            Idade = idade;
        }

        public bool ValidaCPF()
        {
            return Cpf.Length != 11 ? false : true;
        }

        public override string ToString()
        {
            return $"Nome: {Name} \nEndereço: {Endereco} \nCPF: {Cpf} \nIdade: {Idade}";
        }

    }
}