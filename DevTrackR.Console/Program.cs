// See https://aka.ms/new-console-template for more information

/*Console.WriteLine("Digite o seu nome.");

var nome = Console.ReadLine();

Console.WriteLine($"Olá, {nome}");

var umaString = "Essa é uma string";
var numeroInt = 5;
var numeroFloat = 5.4f;
var numeroDouble = 5.4;
var numeroDecimal = 5.3m;
var array = new int[3] { 1, 2, 3 };
var caractere = 'a';
var date = new DateTime(1992, 12, 1);

Console.WriteLine("Digite uma opção de 1 a 3.");
var opcao = Console.ReadLine();

if (opcao == "1") {
    Console.WriteLine("Você entrou no menu de Cadastro.");
} else if (opcao == "2") {
    Console.WriteLine("Você entrou no menu de Reclamação.");
} else if (opcao == "3") {
    Console.WriteLine("Você entrou no menu de Atendimento de Suporte.");
} else {
    Console.WriteLine("Opção inválida.");
}

switch(opcao) {
    case "1":
        Console.WriteLine("Você entrou no menu de Cadastro.");
        break;

    case "2":
        Console.WriteLine("Você entrou no menu de Reclamação.");
        break;

    case "3":
        Console.WriteLine("Você entrou no menu de Atendimento de Suporte.");
        break;

    default:
        Console.WriteLine("Opção inválida.");
        break;
}

var valores = Console.ReadLine(); // 1 2 3 4 5
var valoresArray = valores.Split(" "); // [ "1", "2", "3", "4", "5" ]

for (var i = 0; i < valoresArray.Length; i++) {
    Console.Write(valoresArray[i] + " ");
}

Console.WriteLine();

var contador = 0;

while(contador < valoresArray.Length) {
    Console.Write(valoresArray[contador] + " ");

    contador++;
}

Console.WriteLine();

foreach (var item in valoresArray) {
    Console.Write(item + " ");
}

var notas = new List<int> { 10, 5, 3, 2, 10, 4, 5, 6, 8, 2 };

var anyNota1 = notas.Any(n => n == 1);
var firstNota10 = notas.First(n => n == 10);
var singleNota8 = notas.Single(n => n == 8);
var orderedNotas = notas.OrderBy(n => n);
var max = notas.Max();
var min = notas.Min();
var sum = notas.Sum();
var average = notas.Average();

Console.WriteLine($"Max: {max}");
Console.WriteLine($"Min: {min}");
Console.WriteLine($"Sum: {sum}");
Console.WriteLine($"Average: {average}");

foreach (var nota in orderedNotas) {
    Console.Write(nota + " ");
}*/

var pacotes = new List<Pacote>();

Console.WriteLine("----- DevTrackR - Serviço de Postagem -----");

ExibirMensagemPrincipal();

var opcao = Console.ReadLine();

while (opcao != "0")
{
    switch (opcao)
    {
        case "1":
            CadastrarPacote();
            break;

        case "2":
            AtualizarPacote();
            break;

        case "3":
            ConsultarPacote();
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    ExibirMensagemPrincipal();
    opcao = Console.ReadLine();
}

void ExibirMensagemPrincipal()
{
    Console.WriteLine("Digite o código de acordo com o que você quer.");
    Console.WriteLine("1- Cadastro de Pacote");
    Console.WriteLine("2- Atualizar Pacote");
    Console.WriteLine("3- Consultar Pacote");
    Console.WriteLine("0- Sair da aplicação.");
}

void CadastrarPacote()
{
    Console.WriteLine("Digite o titulo.");
    var titulo = Console.ReadLine();

    Console.WriteLine("Digite a descrição.");
    var descricao = Console.ReadLine();

    var pacote = new Pacote(titulo, descricao);

    pacotes.Add(pacote);

    Console.WriteLine($"Pacote com código {pacote.Codigo} foi cadastrado com sucesso.");
}

void AtualizarPacote()
{
    Console.WriteLine("Digite o código do pacote.");
    var codigo = Console.ReadLine();

    var pacote = pacotes.SingleOrDefault(p => p.Codigo == codigo);

    if (pacote == null)
    {
        Console.WriteLine("Pacote não encontrado!");
        return;
    }

    Console.WriteLine("Digite o status atual.");
    var status = Console.ReadLine();

    pacote.AtualizarStatus(status);
    Console.WriteLine("Pacote atualizado com sucesso.");
}

void ConsultarPacote()
{
    Console.WriteLine("Digite o código do pacote.");
    var codigo = Console.ReadLine();

    var pacote = pacotes.SingleOrDefault(p => p.Codigo == codigo);

    if (pacote == null)
    {
        Console.WriteLine("Pacote não encontrado!");
        return;
    }

    pacote.ExibirDetalhes();
}

var pacotePremium = new PacotePremium("Pacote premium", "Um pacote premium", "Voo ABC");
var pacote = new Pacote("Pacote Normal", "Um Pacote Normal");

var conjuntoPacotes = new List<Pacote> { pacotePremium, pacote };

foreach (var item in conjuntoPacotes)
{
    item.ExibirDetalhes();
}

public class Pacote
{
    public Pacote(string titulo, string descricao)
    {
        Titulo = titulo;
        Descricao = descricao;

        Codigo = GerarCodigo();
        DataPostagem = DateTime.Now;
        Status = "Postado.";
    }

    private string GerarCodigo()
    {
        return Guid.NewGuid().ToString();
    }

    public void AtualizarStatus(string status)
    {
        Status = status;
    }

    public virtual void ExibirDetalhes()
    {
        Console.WriteLine($"Pacote {Titulo} e Código {Codigo} com status {Status}");
    }

    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Codigo { get; set; }
    public DateTime DataPostagem { get; set; }
    public string Status { get; set; }
}

public class PacotePremium : Pacote
{
    public PacotePremium(string titulo, string descricao, string voo)
        : base(titulo, descricao)
    {
        Voo = voo;
    }

    public string Voo { get; set; }

    public override void ExibirDetalhes()
    {
        base.ExibirDetalhes();
        Console.WriteLine($"Com voo {Voo}");
    }
}