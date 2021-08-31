using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;

            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //Adiciona novo aluno
                        Console.WriteLine("Informe o nome do aluno");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a Nota");
                        if(double.TryParse(Console.ReadLine(), out double nota)){
                            aluno.Nota = nota;
                        }
                        else{
                            throw new ArgumentException("Nota deve ser um numero deciamal");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        //Lista alunos
                        foreach (var a in alunos){
                            if(!string.IsNullOrEmpty(a.Nome)) {
                                Console.WriteLine($"Aluno: {a.Nome}, Nota: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        //Media dos alunos
                        double notaTotal = 0;
                        var nrAlunos = 0;
                        double mediaGeral = 0;
                        for (int i = 0; i < alunos.Length; i++) {
                            if(!string.IsNullOrEmpty(alunos[i].Nome)) {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        mediaGeral = notaTotal / nrAlunos;

                        //Usando um enum para comparar as notas
                        Conceito conceitoGeral;
                        if (mediaGeral < 2){
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4) {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6) {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8) {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Amedia Geral é: {mediaGeral}. CONCEITO  GERAL: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine();
                opcaoUsuario = obterOpcaoUsuario();
            }

            static string obterOpcaoUsuario()
            {
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1 - Inserir Novo aluno");
                Console.WriteLine("2 - Listar alunos");
                Console.WriteLine("3 - Calcular Média geral");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine();
                return opcaoUsuario;
            }
        }
    }    
}
