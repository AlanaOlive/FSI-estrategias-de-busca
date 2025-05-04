using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSI_estrategias_de_buscas
{
    internal class Algoritmos_de_busca
    {
        // 1. Busca em Largura (BFS)
        public void BuscaEmLargura(Dictionary<string, List<string>> grafo, string inicio, string objetivo)
        {
            var fila = new Queue<string>();
            var visitados = new HashSet<string>();
            fila.Enqueue(inicio);

            while (fila.Count > 0)
            {
                var atual = fila.Dequeue();
                if (atual == objetivo)
                {
                    Console.WriteLine("Objetivo encontrado (BFS): " + atual);
                    return;
                }

                if (!visitados.Contains(atual))
                {
                    visitados.Add(atual);
                    foreach (var vizinho in grafo[atual])
                    {
                        fila.Enqueue(vizinho);
                    }
                }
            }

            Console.WriteLine("Objetivo não encontrado (BFS).");
        }

        // 2. Busca em Profundidade (DFS)
        public void BuscaEmProfundidade(Dictionary<string, List<string>> grafo, string inicio, string objetivo)
        {
            var pilha = new Stack<string>();
            var visitados = new HashSet<string>();
            pilha.Push(inicio);

            while (pilha.Count > 0)
            {
                var atual = pilha.Pop();
                if (atual == objetivo)
                {
                    Console.WriteLine("Objetivo encontrado (DFS): " + atual);
                    return;
                }

                if (!visitados.Contains(atual))
                {
                    visitados.Add(atual);
                    foreach (var vizinho in grafo[atual])
                    {
                        pilha.Push(vizinho);
                    }
                }
            }

            Console.WriteLine("Objetivo não encontrado (DFS).");
        }

        // 3. Busca de Custo Uniforme
        public void BuscaCustoUniforme(Dictionary<string, Dictionary<string, int>> grafo, string inicio, string objetivo)
        {
            var fila = new PriorityQueue<string, int>();
            var visitados = new HashSet<string>();
            fila.Enqueue(inicio, 0);

            while (fila.Count > 0)
            {
                var atual = fila.Dequeue();
                if (visitados.Contains(atual)) continue;
                visitados.Add(atual);

                if (atual == objetivo)
                {
                    Console.WriteLine("Objetivo encontrado (Custo Uniforme): " + atual);
                    return;
                }

                foreach (var vizinho in grafo[atual])
                {
                    fila.Enqueue(vizinho.Key, vizinho.Value);
                }
            }

            Console.WriteLine("Objetivo não encontrado (Custo Uniforme).");
        }

        // 4. Busca Gulosa
        public void BuscaGulosa(Dictionary<string, Dictionary<string, int>> grafo, Dictionary<string, int> heuristica, string inicio, string objetivo)
        {
            var fila = new PriorityQueue<string, int>();
            var visitados = new HashSet<string>();
            fila.Enqueue(inicio, heuristica[inicio]);

            while (fila.Count > 0)
            {
                var atual = fila.Dequeue();
                if (visitados.Contains(atual)) continue;
                visitados.Add(atual);

                if (atual == objetivo)
                {
                    Console.WriteLine("Objetivo encontrado (Gulosa): " + atual);
                    return;
                }

                foreach (var vizinho in grafo[atual])
                {
                    fila.Enqueue(vizinho.Key, heuristica[vizinho.Key]);
                }
            }

            Console.WriteLine("Objetivo não encontrado (Gulosa).");
        }

        // 5. Busca A*
        public void BuscaAEstrela(Dictionary<string, Dictionary<string, int>> grafo, Dictionary<string, int> heuristica, string inicio, string objetivo)
        {
            var fila = new PriorityQueue<string, int>();
            var custo = new Dictionary<string, int> { [inicio] = 0 };
            fila.Enqueue(inicio, heuristica[inicio]);

            while (fila.Count > 0)
            {
                var atual = fila.Dequeue();

                if (atual == objetivo)
                {
                    Console.WriteLine("Objetivo encontrado (A*): " + atual);
                    return;
                }

                foreach (var vizinho in grafo[atual])
                {
                    int novoCusto = custo[atual] + vizinho.Value;
                    if (!custo.ContainsKey(vizinho.Key) || novoCusto < custo[vizinho.Key])
                    {
                        custo[vizinho.Key] = novoCusto;
                        int prioridade = novoCusto + heuristica[vizinho.Key];
                        fila.Enqueue(vizinho.Key, prioridade);
                    }
                }
            }

            Console.WriteLine("Objetivo não encontrado (A*).");
        }
    }
}

