using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FSI_estrategias_de_buscas
{
    public partial class Form1 : Form
    {
        private Algoritmos_de_busca algoritmos;
        private Capitais Vcapitais;

        private Dictionary<string, Dictionary<string, int>> grafoComPesosT;
        private Dictionary<string, Dictionary<string, int>> grafoComPesosA;
        private Dictionary<string, int> heuristicas;

        public Form1()
        {
            InitializeComponent();
            algoritmos = new Algoritmos_de_busca();
            InicializarGrafo();
            InicializarComponentesForm();
        }

        private void InicializarGrafo()
        {
            Vcapitais = new Capitais();

            grafoComPesosT = CompletarSimetricos(Vcapitais.DistanciasTerrestres);
            grafoComPesosA = CompletarSimetricos(Vcapitais.DistanciasAereas);
        }

        private void InicializarComponentesForm()
        {
            cbAlgoritmo.Items.AddRange(new string[] {
                "Busca em Largura", "Busca em Profundidade",
                "Custo Uniforme", "Gulosa", "A*"
            });

            string[] capitais = grafoComPesosT.Keys.ToArray();

            cbOrigem.Items.AddRange(capitais);
            cbDestino.Items.AddRange(capitais);
        }

        private Dictionary<string, Dictionary<string, int>> CompletarSimetricos(Dictionary<string, Dictionary<string, int>> grafo)
        {
            var origens = grafo.Keys.ToList(); 

            foreach (var origem in origens)
            {
                var destinos = grafo[origem].Keys.ToList();

                foreach (var destino in destinos)
                {
                    if (!grafo.ContainsKey(destino))
                        grafo[destino] = new Dictionary<string, int>();

                    if (!grafo[destino].ContainsKey(origem))
                        grafo[destino][origem] = grafo[origem][destino];
                }
            }

            return grafo;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtResultadoCaminho.Text = "";
            txtResultadoDist.Text = "";
            txtResultadoNos.Text = "";

            txtResultadoCaminhoA.Text = "";
            txtResultadoDistA.Text = "";
            txtResultadoNosA.Text = "";

            var algoritmo = cbAlgoritmo.SelectedItem?.ToString();
            var origem = cbOrigem.SelectedItem?.ToString();
            var destino = cbDestino.SelectedItem?.ToString();

            if (algoritmo == null || origem == null || destino == null)
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            heuristicas = new Dictionary<string, int>();
            foreach (var cidade in grafoComPesosA.Keys)
            {
                if (grafoComPesosA[cidade].ContainsKey(destino))
                    heuristicas[cidade] = grafoComPesosA[cidade][destino];
                else
                    heuristicas[cidade] = int.MaxValue;
            }

            Dictionary<string, string> resultado = null;
            Dictionary<string, string> resultadoAereo = null;

            switch (algoritmo)
            {
                case "Busca em Largura":
                    resultado = algoritmos.BuscaEmLargura(ConvertToSimpleGraph(grafoComPesosT), origem, destino);
                    resultadoAereo = algoritmos.BuscaEmLargura(ConvertToSimpleGraph(grafoComPesosA), origem, destino);
                    break;

                case "Busca em Profundidade":
                    resultado = algoritmos.BuscaEmProfundidade(ConvertToSimpleGraph(grafoComPesosT), origem, destino);
                    resultadoAereo = algoritmos.BuscaEmProfundidade(ConvertToSimpleGraph(grafoComPesosA), origem, destino);
                    break;

                case "Custo Uniforme":
                    resultado = algoritmos.BuscaCustoUniforme(grafoComPesosT, origem, destino);
                    resultadoAereo = algoritmos.BuscaCustoUniforme(grafoComPesosA, origem, destino);
                    break;

                case "Gulosa":
                    resultado = algoritmos.BuscaGulosa(grafoComPesosT, heuristicas, origem, destino);
                    resultadoAereo = algoritmos.BuscaGulosa(grafoComPesosA, heuristicas, origem, destino);
                    break;

                case "A*":
                    resultado = algoritmos.BuscaAEstrela(grafoComPesosT, heuristicas, origem, destino);
                    resultadoAereo = algoritmos.BuscaAEstrela(grafoComPesosA, heuristicas, origem, destino);
                    break;
            }

            if (resultado != null)
            {
                txtResultadoCaminho.Text = $"Caminho: {resultado["caminho_percorrido"]}";
                txtResultadoDist.Text = $"Distância: {resultado["distancia"]} Km";
                txtResultadoNos.Text = $"Nós Visitados: {resultado["numero_nos"]}";

                txtResultadoCaminhoA.Text = $"Caminho: {resultadoAereo["caminho_percorrido"]}";
                txtResultadoDistA.Text = $"Distância: {resultadoAereo["distancia"]} Km";
                txtResultadoNosA.Text = $"Nós Visitados: {resultadoAereo["numero_nos"]}";
            }
            else
            {
                txtResultadoCaminho.Text = "Caminho não encontrado.";
                txtResultadoCaminhoA.Text = "Caminho não encontrado.";
            }
        }

        private Dictionary<string, List<string>> ConvertToSimpleGraph(Dictionary<string, Dictionary<string, int>> grafoComPesos)
        {
            var grafoSimples = new Dictionary<string, List<string>>();

            foreach (var cidade in grafoComPesos)
            {
                grafoSimples[cidade.Key] = new List<string>(cidade.Value.Keys);
            }

            return grafoSimples;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
