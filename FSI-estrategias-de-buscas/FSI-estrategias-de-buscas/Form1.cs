using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FSI_estrategias_de_buscas
{
    public partial class Form1 : Form
    {
        private Algoritmos_de_busca algoritmos;

        private Dictionary<string, List<string>> grafoSimples;
        private Dictionary<string, Dictionary<string, int>> grafoComPesos;
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

            grafoSimples = new Dictionary<string, List<string>>
            {
                ["Brasilia"] = new List<string> { "Goiania", "Belo Horizonte" },
                ["Goiania"] = new List<string> { "Brasilia", "Cuiaba" },
                ["Belo Horizonte"] = new List<string> { "Brasilia", "Rio de Janeiro" },
                ["Rio de Janeiro"] = new List<string> { "Belo Horizonte", "Sao Paulo" },
                ["Sao Paulo"] = new List<string> { "Rio de Janeiro", "Curitiba" },
                ["Cuiaba"] = new List<string> { "Goiania" },
                ["Curitiba"] = new List<string> { "Sao Paulo" }
            };

            grafoComPesos = new Dictionary<string, Dictionary<string, int>>
            {
                ["Brasilia"] = new Dictionary<string, int> { ["Goiania"] = 209, ["Belo Horizonte"] = 740 },
                ["Goiania"] = new Dictionary<string, int> { ["Brasilia"] = 209, ["Cuiaba"] = 934 },
                ["Belo Horizonte"] = new Dictionary<string, int> { ["Brasilia"] = 740, ["Rio de Janeiro"] = 434 },
                ["Rio de Janeiro"] = new Dictionary<string, int> { ["Belo Horizonte"] = 434, ["Sao Paulo"] = 429 },
                ["Sao Paulo"] = new Dictionary<string, int> { ["Rio de Janeiro"] = 429, ["Curitiba"] = 408 },
                ["Cuiaba"] = new Dictionary<string, int> { ["Goiania"] = 934 },
                ["Curitiba"] = new Dictionary<string, int> { ["Sao Paulo"] = 408 }
            };

            heuristicas = new Dictionary<string, int>
            {
                ["Brasilia"] = 600,
                ["Goiania"] = 500,
                ["Cuiaba"] = 900,
                ["Belo Horizonte"] = 400,
                ["Rio de Janeiro"] = 200,
                ["Sao Paulo"] = 100,
                ["Curitiba"] = 0
            };
        }

        private void InicializarComponentesForm()
        {
            cbAlgoritmo.Items.AddRange(new string[] {
            "Busca em Largura", "Busca em Profundidade",
            "Custo Uniforme", "Gulosa", "A*"
        });

            cbOrigem.Items.AddRange(grafoSimples.Keys.ToArray());
            cbDestino.Items.AddRange(grafoSimples.Keys.ToArray());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtResultadoCaminho.Text = "";
            txtResultadoDist.Text += "";
            txtResultadoNos.Text += "";

            var algoritmo = cbAlgoritmo.SelectedItem?.ToString();
            var origem = cbOrigem.SelectedItem?.ToString();
            var destino = cbDestino.SelectedItem?.ToString();

            if (algoritmo == null || origem == null || destino == null)
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            Dictionary<string, string> resultado = null;

            switch (algoritmo)
            {
                case "Busca em Largura":
                    resultado = algoritmos.BuscaEmLargura(grafoSimples, origem, destino);
                    break;
                case "Busca em Profundidade":
                    resultado = algoritmos.BuscaEmProfundidade(grafoSimples, origem, destino);
                    break;
                case "Custo Uniforme":
                    resultado = algoritmos.BuscaCustoUniforme(grafoComPesos, origem, destino);
                    break;
                case "Gulosa":
                    resultado = algoritmos.BuscaGulosa(grafoComPesos, heuristicas, origem, destino);
                    break;
                case "A*":
                    resultado = algoritmos.BuscaAEstrela(grafoComPesos, heuristicas, origem, destino);
                    break;
            }
            string res = "";


            if (resultado != null)
            {
                txtResultadoCaminho.Text = $"Caminho: {resultado["caminho_percorrido"]}";
                txtResultadoDist.Text = $"Distância: {resultado["distancia"]} Km";
                txtResultadoNos.Text = $"Nós Visitados: {resultado["numero_nos"]}";
            }
            else
            {
                res = "Caminho não encontrado.";
                txtResultadoCaminho.Text = res;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
