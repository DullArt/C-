using System;
using System.Collections.Generic;
using System.Linq;

class Listas
{
    private static void Lists()
    {
                string aulaIntro = "Introdução às coleções";
                string aulaModelando = "Modelando a Classe Aula";
                string aulaSets = "Trabalhando com Coleções";

                // List<string> aulas = new List<string>
                // {
                //     aulaIntro,
                //     aulaModelando,
                //     aulaSets
                // };

                //lista dinamica
                List<string> aulas = new List<string>();
                aulas.Add(aulaIntro);
                aulas.Add(aulaModelando);
                aulas.Add(aulaSets);

                Imprimir(aulas);
                
                Console.WriteLine("A primeira aula "+aulas.First());
                Console.WriteLine("A última aula é "+aulas.Last());

                //
                aulas.First(aula => aula.Contains("Trabalhando"));
                aulas.Last(aula => aula.Contains("Trabalhando"));
                
                //primeiro ou null 
                aulas.FirstOrDefault();
                
                aulas.Reverse();
                //remove, removeAt, and...
                aulas.RemoveAt(aulas.Count -1);
                //copia 
                List<string> copia = aulas.GetRange(aulas.Count -2,2);

                //clonagem 
                List<string> clone = new List<string>(aulas);
                clone.RemoveRange(clone.Count - 2,2);

        }  


        private static void Imprimir(List<string> aulas)
        {
            foreach(var aula in aulas)
            {
                Console.WriteLine(aula);
            }

            // for(int i=0; i<aulas.Count;i++)
            // {
            //     Console.WriteLine(aulas[i]);
            // }

            aulas.ForEach(aula => 
            {
                Console.WriteLine(aula);
            });
        }


        void comparacao()
        {
                Aula aulaIntro = new Aula("Introdução às coleções",20);
                Aula aulaModelando = new Aula("Modelando a Classe Aula",18);
                Aula aulaSets = new Aula("Trabalhando com Coleções",12);

                List<Aula> aulas = new List<Aula>();
                aulas.Add(aulaIntro);
                aulas.Add(aulaModelando);
                aulas.Add(aulaSets);

                Imprimir(aulas);

                //Icomparable
                aulas.Sort();   
                //
                aulas.Sort((este, outro) => este.Tempo.CompareTo(outro.Tempo));

        }

        private static void Imprimir(List<Aula> aulas)
        {
            foreach(var aula in aulas)
            {
                Console.WriteLine(aula);
            }
        }
    
   
}