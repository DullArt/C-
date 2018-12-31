using System;
using System.Collections.Generic;

class SetsAndDictionary
{
    public void Sets()
    {
               //SETS = CONJUNTOS
               // Duas propriedades do set
                // 1. não permite duplicidade
                // 2. os elementos não são mantidos em ordem específica.

                //declarando set de alunos
                ISet<string> alunos = new HashSet<string>();
                alunos.Add("Vanessa Torini");
                alunos.Add("Ana Losnak");
                alunos.Add("Rafael Nercesseian");

                Curso c = new Curso("C# colecoes","Marcelo Oliveira");
                c.Adiciona(new Aula("Trabalhando com listas", 21));
                c.Adiciona(new Aula("Criando uma Aula",21));

                Aluno a1 = new Aluno("Vanessa Tonini", 323434);
                Aluno a2 = new Aluno("Ana Losnak", 343434);
                Aluno a3 = new Aluno("Rafael Nercessian", 33343);

                c.Matricula(a1);
                c.Matricula(a2);
                c.Matricula(a3);
                
                foreach(var aluno in c.Alunos)
                {
                    Console.WriteLine(aluno);
                }

               Aluno are = c.BuscaMatriculado(5617);
    }   
}