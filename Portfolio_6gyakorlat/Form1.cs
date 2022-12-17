﻿using Portfolio_6gyakorlat.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Portfolio_6gyakorlat
{
    public partial class Form1 : Form
    {
        List<Tick> ticks;
        PortfolioEntities context = new PortfolioEntities();

        List<PortfolioItem> portfolio = new List<PortfolioItem>();
        

        public Form1()
        {
            InitializeComponent();

            ticks = context.Tick.ToList();
            dataGridView1.DataSource = ticks;
            CreatePortfolio();
        }

        private void CreatePortfolio()
        {
            
            portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = portfolio;

        }
    }
}
