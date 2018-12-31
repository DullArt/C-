using System;
using System.Collections.Generic;

class LinkedList
{
    //elementos não precisam estar em sequencia em memoria
            // cada elemento sabe quem é o anterior e o proximo
            // cada elemento é um nó que contém um valor

    public void Link()
    {
            LinkedList<string> dias = new LinkedList<string>();
            var d4 = dias.AddFirst("Quarta");
            //cada elemento é um nó LinkedListNode<T>
            Console.WriteLine(d4.Value);
            //
            var d2 = dias.AddBefore(d4, "segunda");
            var d3 = dias.AddAfter(d2, "terça");
            var d6 = dias.AddAfter(d4, "sexta");
            var d7 = dias.AddAfter(d6, "sábado");
            var d5 = dias.AddBefore(d6, "quinta");
            var d1 = dias.AddBefore(d2, "domingo");

            foreach(var d in dias)
            {
                Console.Write(d);
            }

            var quarta = dias.Find("quarta");
            dias.Remove(d4);
    }
}