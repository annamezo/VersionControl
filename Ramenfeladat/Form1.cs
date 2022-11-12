using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ramenfeladat
{
    public partial class Form1 : Form
    {
        List<Country> countries = new List<Country>();
        List<Ramen> ramens = new List<Ramen>();
        List<Brand> brands = new List<Brand>();


        public Form1()
        {
            InitializeComponent();
            LoadData("ramen.csv");
        }

        void LoadData(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            sr.ReadLine(); //átugrik az első soron
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';'); //a split felbontja az adott sort tömb elemekre
                string orszag = sor[2]; //az országot leválasztom
                string marka = sor[0];
                Country aktorszag = AddCountry(orszag);
                Brand aktmarka = AddBrand(marka);
                Ramen r = new Ramen
                {
                    ID = ramens.Count,
                    CountryFK = aktorszag.ID,
                    Country = aktorszag,
                    Rating = Convert.ToDouble(sor[3]),
                    Name = aktorszag.Name,
                    Brand = aktmarka
                };
                ramens.Add(r);

                
            }
            sr.Close();

            Country AddCountry(string orszag)
            {
                var ered = (from c in countries where c.Name.Equals(orszag) select c).FirstOrDefault();

                // var ered = countries.Where(i => i.Name.Equals(orszag)).FirstOrDefault(); //megvan-e már?

                if (ered == null) //nincs ilyen orszag a listaban
                {
                    ered = new Country
                    {
                        ID = countries.Count,
                        Name = orszag
                    };
                    countries.Add(ered);
                }
                return ered;
            }

            Country AddBrand(string marka)
            {
                var ered = (from c in brands where c.Name.Equals(marka) select c).FirstOrDefault();

                // var ered = countries.Where(i => i.Name.Equals(orszag)).FirstOrDefault(); //megvan-e már?

                if (ered == null) //nincs ilyen orszag a listaban
                {
                    ered = new Brand
                    {
                        ID = brands.Count,
                        Name = marka
                    };
                    brands.Add(ered);
                }
                return ered;
            }
        }
        
        
    }
}
