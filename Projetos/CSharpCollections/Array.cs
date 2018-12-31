using System;
using System.Linq;

class Array
{
    public static void Arrays()
    {
            string aulaIntro = "Introdução às coleções";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSets = "Trabalhando com Coleções";
            // string[] aulas = new string[]
            // {
            //     aulaIntro, 
            //     aulaModelando,
            //     aulaSets
            // };

            //coleção de tamanho fixo
            string[] aulas = new string[3];
            aulas[0] = aulaIntro;
            aulas[1] = aulaModelando;
            aulas[2] = aulaSets;
            
            aulas[0] = "Trabalhando com arrays";
            Imprimir(aulas);
            
            Console.WriteLine(Array.IndexOf(aulas,aulaModelando));
            Console.WriteLine(Array.LastIndexOf(aulas, aulaSets));
            
            // Array.Reverse();
            Array.Resize(ref aulas, 2);
            Array.Resize(ref aulas, 3);
            aulas[aulas.Length - 1] = "Conclusão";

            Array.Sort(aulas);

            //copy 
            string[] copia  = new string[2];
            //destino, index inicial, novo array, posição inicial, quantidade 
            Array.Copy(aulas, 1, copia, 0, 2);

            //clone 
            string[] clo = aulas.Clone() as string[];
            //remove
            Array.Clear(clo, 1, 2);

            Console.ReadLine();

        }

    }
        public static void Imprimir(string[] aulas)
        {
            // foreach (var aula in aulas)
            // {
            //     Console.WriteLine(aula);
            // }

            for(int i=0; i<aulas.Length; i++)
            {
                Console.WriteLine(aulas[i]);
            }

        }
}
