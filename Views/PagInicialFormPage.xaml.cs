﻿using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System_Cont.Models;
using LiveCharts.Wpf.Charts.Base;

namespace System_Cont.Views
{
    /// <summary>
    /// Interação lógica para PagInicialFormPage.xam
    /// </summary>
    public partial class PagInicialFormPage : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection LastHourSeries { get; set; }
        public SeriesCollection LastHourSeries1 { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public PagInicialFormPage()
        {
            InitializeComponent();
            Loaded += PagInicialFormPage_Loaded;

            SeriesCollection = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> {25,52,61,89},
                    StackMode = StackMode.Values,
                    DataLabels = true
                },
                 new StackedColumnSeries
                {
                    Values = new ChartValues<double> {-15,-75,-16,-49},
                    StackMode = StackMode.Values,
                    DataLabels = true
                }
            };
            LastHourSeries = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(3),
                        new ObservableValue(1),
                        new ObservableValue(9),
                        new ObservableValue(4),
                        new ObservableValue(5),
                        new ObservableValue(3),
                        new ObservableValue(1),
                        new ObservableValue(2),
                        new ObservableValue(3),
                        new ObservableValue(7),
                    }
                }
            };
            LastHourSeries1 = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(13),
                        new ObservableValue(11),
                        new ObservableValue(9),
                        new ObservableValue(14),
                        new ObservableValue(5),
                        new ObservableValue(3),
                        new ObservableValue(12),
                        new ObservableValue(2),
                        new ObservableValue(3),
                        new ObservableValue(7),
                    }
                }
            };
            Labels = new[] { "Feb 7", "Feb 8", "Feb 9", "Feb 10" };
            Formatter = value => value.ToString();
            DataContext = this;    
        }

        private void PagInicialFormPage_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new RecebimentoDAO();

                txtGanhoAnual.Text = "R$ " + Convert.ToString(dao.SomaRecebimento());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            try
            {
                var dao = new DespesaDAO();

                txtTotalDespesa.Text = "R$ " + Convert.ToString(dao.SomaDespesa());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // GRAFICO LUCROS MESAIS
            try
            {
                var dao = new RecebimentoDAO();

                double[] listMes = dao.LucroMensal();
                LucroMensal.Values = new ChartValues<double> { listMes[0], listMes[1], listMes[2], listMes[3], listMes[4], listMes[5], listMes[6], listMes[7], listMes[8], listMes[9], listMes[10], listMes[11]};


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // GRAFICO DE DESPESAS ALUGUEL
            try
            {
                var dao = new DespesaDAO();

                DespesaAluguel.Value = dao.DespesaAlugue();
                DespesaAluguelText.Text = dao.DespesaAlugue() + " K";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // GRAFICO DE DESPESAS ENERGIA
            try
            {
                var dao = new DespesaDAO();

                DespesaEnergia.Value = dao.DespesaEnergia();
                DespesaEnergiaText.Text = dao.DespesaEnergia() + " K";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // GRAFICO DE DESPESAS AGUA 
            try
            {
                var dao = new DespesaDAO();

                DespesaAgua.Value = dao.DespesaAgua();
                DespesaAguaText.Text = dao.DespesaAgua() + " K";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // GRAFICO DE DESPESAS INTERNET
            try
            {
                var dao = new DespesaDAO();

                DespesaInternet.Value = dao.DespesaInternet();
                DespesaInternetText.Text = dao.DespesaInternet() + " K";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
