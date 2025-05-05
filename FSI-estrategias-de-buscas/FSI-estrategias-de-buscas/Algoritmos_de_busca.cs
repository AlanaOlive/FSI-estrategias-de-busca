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
        public Dictionary<string, string> BuscaEmLargura(Dictionary<string, List<string>> grafo, string inicio, string objetivo)
        {
            var fila = new Queue<string>();
            var visitados = new HashSet<string>();
            var pais = new Dictionary<string, string>();
            int numeroNos = 0;

            fila.Enqueue(inicio);
            visitados.Add(inicio);
            pais[inicio] = null;

            while (fila.Count > 0)
            {
                var atual = fila.Dequeue();
                numeroNos++;

                if (atual == objetivo)
                {
                    // Reconstruir caminho
                    var caminho = new List<string>();
                    string atualCaminho = objetivo;
                    while (atualCaminho != null)
                    {
                        caminho.Insert(0, atualCaminho);
                        atualCaminho = pais[atualCaminho];
                    }

                    var result = new Dictionary<string, string>
                    {
                        ["caminho_percorrido"] = string.Join(" -> ", caminho),
                        ["distancia"] = (caminho.Count - 1).ToString(),
                        ["numero_nos"] = numeroNos.ToString()
                    };
                    return result;
                }

                foreach (var vizinho in grafo[atual])
                {
                    if (!visitados.Contains(vizinho))
                    {
                        fila.Enqueue(vizinho);
                        visitados.Add(vizinho);
                        pais[vizinho] = atual;
                    }
                }
            }

            Console.WriteLine("Objetivo não encontrado (BFS).");
            return null;
        }


        // 2. Busca em Profundidade (DFS)
        public Dictionary<string, string> BuscaEmProfundidade(Dictionary<string, List<string>> grafo, string inicio, string objetivo)
        {
            var pilha = new Stack<string>();
            var visitados = new HashSet<string>();
            var pais = new Dictionary<string, string>();
            int numeroNos = 0;

            pilha.Push(inicio);
            pais[inicio] = null;

            while (pilha.Count > 0)
            {
                var atual = pilha.Pop();
                if (!visitados.Contains(atual))
                {
                    visitados.Add(atual);
                    numeroNos++;

                    if (atual == objetivo)
                    {
                        var caminho = new List<string>();
                        var atualCaminho = objetivo;
                        while (atualCaminho != null)
                        {
                            caminho.Insert(0, atualCaminho);
                            atualCaminho = pais[atualCaminho];
                        }

                        return new Dictionary<string, string>
                        {
                            ["caminho_percorrido"] = string.Join(" -> ", caminho),
                            ["distancia"] = (caminho.Count - 1).ToString(),
                            ["numero_nos"] = numeroNos.ToString()
                        };
                    }

                    foreach (var vizinho in grafo[atual])
                    {
                        if (!visitados.Contains(vizinho))
                        {
                            pilha.Push(vizinho);
                            if (!pais.ContainsKey(vizinho))
                                pais[vizinho] = atual;
                        }
                    }
                }
            }

            return null;
        }

        // 3. Busca de Custo Uniforme
        public Dictionary<string, string> BuscaCustoUniforme(Dictionary<string, Dictionary<string, int>> grafo, string inicio, string objetivo)
        {
            var fila = new PriorityQueue<string, int>();
            var visitados = new HashSet<string>();
            var pais = new Dictionary<string, string>();
            var custo = new Dictionary<string, int> { [inicio] = 0 };
            int numeroNos = 0;

            fila.Enqueue(inicio, 0);
            pais[inicio] = null;

            while (fila.Count > 0)
            {
                var atual = fila.Dequeue();
                if (visitados.Contains(atual)) continue;

                visitados.Add(atual);
                numeroNos++;

                if (atual == objetivo)
                {
                    var caminho = new List<string>();
                    var atualCaminho = objetivo;
                    while (atualCaminho != null)
                    {
                        caminho.Insert(0, atualCaminho);
                        atualCaminho = pais[atualCaminho];
                    }

                    return new Dictionary<string, string>
                    {
                        ["caminho_percorrido"] = string.Join(" -> ", caminho),
                        ["distancia"] = custo[objetivo].ToString(),
                        ["numero_nos"] = numeroNos.ToString()
                    };
                }

                foreach (var vizinho in grafo[atual])
                {
                    int novoCusto = custo[atual] + vizinho.Value;
                    if (!custo.ContainsKey(vizinho.Key) || novoCusto < custo[vizinho.Key])
                    {
                        custo[vizinho.Key] = novoCusto;
                        fila.Enqueue(vizinho.Key, novoCusto);
                        pais[vizinho.Key] = atual;
                    }
                }
            }

            return null;
        }

        // 4. Busca Gulosa
        public Dictionary<string, string> BuscaGulosa(Dictionary<string, Dictionary<string, int>> grafo, Dictionary<string, int> heuristica, string inicio, string objetivo)
        {
            var fila = new PriorityQueue<string, int>();
            var visitados = new HashSet<string>();
            var pais = new Dictionary<string, string>();
            int numeroNos = 0;

            fila.Enqueue(inicio, heuristica[inicio]);
            pais[inicio] = null;

            while (fila.Count > 0)
            {
                var atual = fila.Dequeue();
                if (visitados.Contains(atual)) continue;

                visitados.Add(atual);
                numeroNos++;

                if (atual == objetivo)
                {
                    var caminho = new List<string>();
                    var atualCaminho = objetivo;
                    while (atualCaminho != null)
                    {
                        caminho.Insert(0, atualCaminho);
                        atualCaminho = pais[atualCaminho];
                    }

                    return new Dictionary<string, string>
                    {
                        ["caminho_percorrido"] = string.Join(" -> ", caminho),
                        ["distancia"] = (caminho.Count - 1).ToString(),
                        ["numero_nos"] = numeroNos.ToString()
                    };
                }

                foreach (var vizinho in grafo[atual])
                {
                    if (!visitados.Contains(vizinho.Key))
                    {
                        fila.Enqueue(vizinho.Key, heuristica[vizinho.Key]);
                        pais[vizinho.Key] = atual;
                    }
                }
            }

            return null;
        }

        // 5. Busca A*
        public Dictionary<string, string> BuscaAEstrela(Dictionary<string, Dictionary<string, int>> grafo, Dictionary<string, int> heuristica, string inicio, string objetivo)
        {
            var fila = new PriorityQueue<string, int>();
            var custo = new Dictionary<string, int> { [inicio] = 0 };
            var pais = new Dictionary<string, string>();
            int numeroNos = 0;

            fila.Enqueue(inicio, heuristica[inicio]);
            pais[inicio] = null;

            while (fila.Count > 0)
            {
                var atual = fila.Dequeue();
                numeroNos++;

                if (atual == objetivo)
                {
                    var caminho = new List<string>();
                    var atualCaminho = objetivo;
                    while (atualCaminho != null)
                    {
                        caminho.Insert(0, atualCaminho);
                        atualCaminho = pais[atualCaminho];
                    }

                    return new Dictionary<string, string>
                    {
                        ["caminho_percorrido"] = string.Join(" -> ", caminho),
                        ["distancia"] = custo[objetivo].ToString(),
                        ["numero_nos"] = numeroNos.ToString()
                    };
                }

                foreach (var vizinho in grafo[atual])
                {
                    int novoCusto = custo[atual] + vizinho.Value;
                    if (!custo.ContainsKey(vizinho.Key) || novoCusto < custo[vizinho.Key])
                    {
                        custo[vizinho.Key] = novoCusto;
                        int prioridade = novoCusto + heuristica[vizinho.Key];
                        fila.Enqueue(vizinho.Key, prioridade);
                        pais[vizinho.Key] = atual;
                    }
                }
            }

            return null;
        }
    }
}

