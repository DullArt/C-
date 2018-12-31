using System.Collections.Generic;

class CursoImplementacao
{
    public void Implement()
    {
            Curso charp = new Curso("C# collections", "Marcel");
            charp.Adiciona(new Aula("Trabalhando com listas",12));

            charp.Adiciona(new Aula("Criando uma Aula",20));
            charp.Adiciona(new Aula("Modelando com Coleções", 10));

            //copia e ordena
            List<Aula> aulascopiadas = new List<Aula>(charp.Aulas);
            aulascopiadas.Sort();
    }
}   