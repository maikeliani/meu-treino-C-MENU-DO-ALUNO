using System;


namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Aluno[] alunos = new Aluno[5];
            var indiceAluno=0;
            string opcaoUsuario = ObterOpcaoUsuario(); 

            while (opcaoUsuario.ToUpper() != "X")   // transforma o " x" em maiúsculo e compara 
            {
                switch (opcaoUsuario)
                {
                    case "1" :
                    
                        Console.WriteLine("Informe o nome do aluno e tecle ENTER: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome= Console.ReadLine();

                        Console.WriteLine("Informe a nota e tecle ENTER: ");

                        /*var nota= decimal.Parse(Console.ReadLine());
                        aluno.Nota= nota;
                        --->  Na linha acima como Nota na struct é decimal e o readLine()
                         retorna string usei Parse */
                        if ( decimal.TryParse(Console.ReadLine(),out decimal nota))
                        {
                            aluno.Nota=nota;
                        }
                        else
                        {
                            throw new Exception("Valor da not deve ser decimal!");
                        }

                        alunos[indiceAluno]= aluno;
                        indiceAluno++; 
                        break;    

                    case "2":
                        foreach (var a in alunos)
                        {
                            if( !string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine ($" ALUNO:  {a.Nome}     NOTA: {a.Nota}");
                            }
                            
                        }
                    break;

                    case "3":
                    {
                    
                    decimal notaTotal=0;
                    var nrAlunos=0;

                     for (int i=0; i<alunos.Length;i++)
                        if( !string.IsNullOrEmpty(alunos[i].Nome))
                        {
                             notaTotal= notaTotal + alunos[i].Nota;
                            nrAlunos++;
                        }                             
                    var mediaGeral= notaTotal/nrAlunos;
                    Conceito conceitoGeral;

                    if(mediaGeral<2)
                    {
                        conceitoGeral=Conceito.E;
                    }
                    
                    else if(mediaGeral<4)
                    {
                        conceitoGeral= Conceito.D;
                    }
                    else if(mediaGeral<6)
                    {
                        conceitoGeral= Conceito.C;
                    }
                    else if(mediaGeral<8)
                    {
                        conceitoGeral= Conceito.B;
                    }
                    else
                    {
                       conceitoGeral=Conceito.A; 
                    }
                    Console.WriteLine ($" A média geral é: {mediaGeral}     CONCEITO: {conceitoGeral}");
                    }
                    break;
                    
                 default:
                    {
                        throw new Exception(" DIGITE APENAS NUMEROS");
                    }

                }   

                
                opcaoUsuario= ObterOpcaoUsuario();

            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("       informe a opção dsesejada: ");
            Console.WriteLine("       1- Inserir novo aluno");
            Console.WriteLine("       2- Listar alunos");
            Console.WriteLine("       3- Calcular média geral");
            Console.WriteLine("       X- Sair ");
            Console.WriteLine();

            string opcaoUsuario= Console.ReadLine();
            return opcaoUsuario;
            // esse método captura e retorna a opçao do usuario
            
        }
    }
}
