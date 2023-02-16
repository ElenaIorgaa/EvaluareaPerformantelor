using BookShopGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace UnitTestProject1
{
    
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
  

        public void TestMutation1()
        {
            double[] value = { 1.1d, 4.2d, 5.2d, 9.7d };
            double[] value1 = { 9.0d, 1.3d, 7.8d, 2.8d };
            double[] value2 = { 7.6d, 4.3d, 8.8d, 2.9d };
            double[] value3 = { 1.8d, 5.3d, 8.3d, 9.9d };
            double[][] indivizi = { value, value1, value2, value3 };

            double F = 1.0d;
            int gena = 1;

            Assert.AreEqual(2.3d, BookShopGUI.Rezolvare.Mutation(indivizi, gena, F));
        }

        [TestMethod]
        public void TestRecommend1()
        {

            int noOfUsers = 10;
            int populationCount = 50;
            int maxNrOfGenerations = 6000;
            int CR = 30;
            double F = 0.9;
            int noOfItems = 18;
            double[][] userRatings = new double[noOfUsers][];
            List<KeyValuePair<int, double>> alreadyGivenRatings = new List<KeyValuePair<int, double>>()
            {
                new KeyValuePair<int, double>(1,1),
                new KeyValuePair<int, double>(2,1),
                new KeyValuePair<int, double>(3,1),
                new KeyValuePair<int, double>(4,1),
                new KeyValuePair<int, double>(5,1),

            };
            List<Carte> listOfProducts = new List<Carte>();
            listOfProducts.Add(new Carte(0, "Colt alb", "Jack London"));
            listOfProducts.Add(new Carte(1, "Ion", "Liviu Rebreanu"));
            listOfProducts.Add(new Carte(2, "Mara", "Ioan Slavici"));
            listOfProducts.Add(new Carte(3, "Luceafarul", "Mihai Eminescu"));
            listOfProducts.Add(new Carte(4, "Amintiri din copilarie", "Ion Creanga"));
            listOfProducts.Add(new Carte(5, "Doua lozuri", "I. L. Caragiale"));
            listOfProducts.Add(new Carte(6, "Plumb", "George Bacovia"));
            listOfProducts.Add(new Carte(7, "The Call of the Wild", "Jack London"));
            listOfProducts.Add(new Carte(8, "To Build a Fire", "Jack London"));
            listOfProducts.Add(new Carte(9, "The Sea Wolf", "Jack London"));
            listOfProducts.Add(new Carte(10, "Love of Life", "Jack London"));
            listOfProducts.Add(new Carte(11, "Capitan la cincisprezece ani", "Jules Verne"));
            listOfProducts.Add(new Carte(12, "Ocolul pamantului in optzeci de zile", "Jules Verne"));
            listOfProducts.Add(new Carte(13, "O calatorie spre centrul pamantului", "Jules Verne"));
            listOfProducts.Add(new Carte(14, "Fratii Ki", "Jules Verne"));
            listOfProducts.Add(new Carte(15, "Mihail Strogoff", "Jules Verne"));
            listOfProducts.Add(new Carte(16, "Cinci saptamani in balon", "Jules Verne"));
            listOfProducts.Add(new Carte(17, "Invitatie la vals", "Mihail Drumes"));


            Assert.AreEqual("Colt alb", BookShopGUI.Rezolvare.Recommend(noOfItems, noOfUsers, maxNrOfGenerations, CR, F, userRatings, alreadyGivenRatings, populationCount, listOfProducts));

        }

        [TestMethod]
        public void TestRecommendDifferentRecommandations()
        {
            int noOfUsers = 10;
            int populationCount = 50;
            int maxNrOfGenerations = 6000;
            int CR = 30;
            double F = 0.9;
            int noOfItems = 18;
            double[][] userRatings1 = new double[noOfUsers][];
            double[][] userRatings2 = new double[noOfUsers][];

            List<KeyValuePair<int, double>> alreadyGivenRatings1 = new List<KeyValuePair<int, double>>()
            {
                new KeyValuePair<int, double>(1,1),
                new KeyValuePair<int, double>(2,1),
                new KeyValuePair<int, double>(3,1),
                new KeyValuePair<int, double>(4,1),
                new KeyValuePair<int, double>(5,1),
            };
            List<KeyValuePair<int, double>> alreadyGivenRatings2 = new List<KeyValuePair<int, double>>()
            {
                new KeyValuePair<int, double>(1,5),
                new KeyValuePair<int, double>(2,5),
                new KeyValuePair<int, double>(3,5),
                new KeyValuePair<int, double>(4,5),
                new KeyValuePair<int, double>(5,5),
            };
            List<Carte> listOfProducts = new List<Carte>();
            listOfProducts.Add(new Carte(0, "Colt alb", "Jack London"));
            listOfProducts.Add(new Carte(1, "Ion", "Liviu Rebreanu"));
            listOfProducts.Add(new Carte(2, "Mara", "Ioan Slavici"));
            listOfProducts.Add(new Carte(3, "Luceafarul", "Mihai Eminescu"));
            listOfProducts.Add(new Carte(4, "Amintiri din copilarie", "Ion Creanga"));
            listOfProducts.Add(new Carte(5, "Doua lozuri", "I. L. Caragiale"));
            listOfProducts.Add(new Carte(6, "Plumb", "George Bacovia"));
            listOfProducts.Add(new Carte(7, "The Call of the Wild", "Jack London"));
            listOfProducts.Add(new Carte(8, "To Build a Fire", "Jack London"));
            listOfProducts.Add(new Carte(9, "The Sea Wolf", "Jack London"));
            listOfProducts.Add(new Carte(10, "Love of Life", "Jack London"));
            listOfProducts.Add(new Carte(11, "Capitan la cincisprezece ani", "Jules Verne"));
            listOfProducts.Add(new Carte(12, "Ocolul pamantului in optzeci de zile", "Jules Verne"));
            listOfProducts.Add(new Carte(13, "O calatorie spre centrul pamantului", "Jules Verne"));
            listOfProducts.Add(new Carte(14, "Fratii Ki", "Jules Verne"));
            listOfProducts.Add(new Carte(15, "Mihail Strogoff", "Jules Verne"));
            listOfProducts.Add(new Carte(16, "Cinci saptamani in balon", "Jules Verne"));
            listOfProducts.Add(new Carte(17, "Invitatie la vals", "Mihail Drumes"));


            Assert.AreNotEqual(BookShopGUI.Rezolvare.Recommend(noOfItems, noOfUsers, maxNrOfGenerations, CR, F, userRatings1, alreadyGivenRatings1, populationCount, listOfProducts),
                BookShopGUI.Rezolvare.Recommend(noOfItems, noOfUsers, maxNrOfGenerations, CR, F, userRatings2, alreadyGivenRatings2, populationCount, listOfProducts));

        }

        [TestMethod]

        public void TestGenerateUserRatings1()
        {
            BookShopGUI.Rezolvare.GenerateUserRatings("TrialUsersRatings.txt");
            StreamReader file = new StreamReader("TrialUsersRatings.txt");
            Assert.IsNotNull(file.ReadLine());

        }

        [TestMethod]
        public void TestGenerateUserRatings2()
        {
            //BookShopGUI.Rezolvare.GenerateUserRatings();
            StreamReader file = new StreamReader("TrialUsersRatings.txt");
            String line = "";
            List<double> lstOfValues = new List<double>();
            while ((line = file.ReadLine()) != null)
            {

                lstOfValues.Add(Double.Parse(line));
            }
            Assert.AreEqual(180, lstOfValues.Count);

        }


        [TestMethod]
        public void TestGenerateUserRatingsValuesBetween1And5()
        {
            //BookShopGUI.Rezolvare.GenerateUserRatings();
            StreamReader file = new StreamReader("TrialUsersRatings.txt");
            String line = "";
            List<double> lstOfValues = new List<double>();
            while ((line = file.ReadLine()) != null)
            {

                lstOfValues.Add(Double.Parse(line));
            }
            for(int i = 0; i < lstOfValues.Count; i++)
            {
                Assert.IsTrue(lstOfValues[i]>= 1 && lstOfValues[i] <= 5);
            }
            

        }
        [TestMethod]
        public void TestGenerateInitialPopulation1()
        {
            List<KeyValuePair<int, double>> alreadyGivenRatings = new List<KeyValuePair<int, double>>()
            {
                new KeyValuePair<int, double>(1,1),
                new KeyValuePair<int, double>(2,1),
                new KeyValuePair<int, double>(3,1),
                new KeyValuePair<int, double>(4,1),
                new KeyValuePair<int, double>(5,1),

            };
            int noOfItems = 18;
            int populationCount = 10;
            BookShopGUI.Rezolvare.GenerateInitialPopulation(alreadyGivenRatings, noOfItems, populationCount,"TrialPopulation1.txt");
            StreamReader file = new StreamReader("TrialPopulation1.txt");
            Assert.IsNotNull(file.ReadLine());

        }
        [TestMethod]
        public void TestGenerateInitialPopulation2()
        {

            StreamReader file = new StreamReader("TrialPopulation1.txt");
            String line = "";
            List<double> lstOfValues = new List<double>();
            while ((line = file.ReadLine()) != null)
            {

                lstOfValues.Add(Double.Parse(line));
            }
            Assert.AreEqual(180, lstOfValues.Count);
            

        }

        [TestMethod]
        public void TestGenerateInitialPopulationBetween1And5()
        {

            StreamReader file = new StreamReader("TrialPopulation1.txt");
            String line = "";
            List<double> lstOfValues = new List<double>();
            while ((line = file.ReadLine()) != null)
            {

                lstOfValues.Add(Double.Parse(line));
            }
            for (int i = 0; i < lstOfValues.Count; i++)
            {
                Assert.IsTrue(lstOfValues[i] >= 1 && lstOfValues[i] <= 5);
            }

        }
        

        [TestMethod]
        public void TestReadUserRatings()
        {
            int noOfUsers = 10;
            int noOfItems = 18;
            double[][] userRatings = BookShopGUI.Rezolvare.ReadUsersRatings(noOfUsers, noOfItems,"TrialUsersRatings.txt");
            Assert.IsNotNull(userRatings);


        }
        [TestMethod]
        public void TestReadPopulation()
        {
            int populationCount = 10;
            int noOfItems = 18;
            double[][] userRatings = BookShopGUI.Rezolvare.ReadPopulation(populationCount, noOfItems);
            Assert.IsNotNull(userRatings);


        }
    
        [TestMethod]
        public void TestCosineSimilarityV()
        {
            double[] v1 = { 1, 2, 3 };
            double[] v2 = { 4, 5, 6 };
            Assert.AreEqual(0.97463, BookShopGUI.Rezolvare.GetCosineSimilarityV(v1, v2), 1e-5);
        }
        [TestMethod]
        public void TestFitnessScore()
        {
            double[][] weights = {
            new double[] { 1, 2, 3 },
            new double[] { 4, 5, 6 },
            new double[] { 7, 8, 9 }
    };
            double[] userWeights = { 3, 4, 5 };
            Assert.AreEqual(-0.99922, BookShopGUI.Rezolvare.FitnessScore(weights, userWeights), 1e-5);
        }
        
        [TestMethod]
        public void TestSelection()
        {
            double[][] userRatings={new double[] { 1, 2, 3 },
        new double[] { 4, 5, 6 },
        new double[] { 7, 8, 9 }
    };
            double[] individPotential= { 3, 4, 5 };
            double[] individExistent = { 1, 2, 3 };
            double[] val = {1,2,3};
            Assert.AreEqual(val.ToString(), BookShopGUI.Rezolvare.Selection(userRatings, individPotential, individExistent).ToString());
        }
      
        [TestMethod]
        public void TestCrossover()
        {
            int noOfItems = 18;
            int populationCount = 10;
            int CR = 30;
            double F = 0.9;
            int punctDivizare = 1;
            Random rand = new Random();
            List<int> listOfAlreadyRatedItems = new List<int>();
            double[][] indivizi = BookShopGUI.Rezolvare.ReadPopulation(populationCount, noOfItems);
            double[] sol = BookShopGUI.Rezolvare.Crossover(punctDivizare, noOfItems, CR, indivizi, F, rand, listOfAlreadyRatedItems);
            Assert.AreEqual(noOfItems,sol.Length);
        }
        [TestMethod]
        public void TestCrossover2()
        {
            int noOfItems = 18;
            int populationCount = 10;
            int CR = 30;
            double F = 0.9;
            int punctDivizare = 1;
            Random rand = new Random();
            List<int> listOfAlreadyRatedItems = new List<int>();
            double[][] indivizi = BookShopGUI.Rezolvare.ReadPopulation(populationCount, noOfItems);
            double[] sol = BookShopGUI.Rezolvare.Crossover(punctDivizare, noOfItems, CR, indivizi, F, rand, listOfAlreadyRatedItems);
            Assert.IsNotNull(sol);
        }

        [TestMethod]

        public void TestRecommendEmptyProductsList()
        {

            int noOfUsers = 10;
            int populationCount = 50;
            int maxNrOfGenerations = 6000;
            int CR = 30;
            double F = 0.9;
            int noOfItems = 18;
            double[][] userRatings = new double[noOfUsers][];
            List<KeyValuePair<int, double>> alreadyGivenRatings = new List<KeyValuePair<int, double>>()
            {
                new KeyValuePair<int, double>(1,1),
                new KeyValuePair<int, double>(2,1),
                new KeyValuePair<int, double>(3,1),
                new KeyValuePair<int, double>(4,1),
                new KeyValuePair<int, double>(5,1),

            };
            List<Carte> listOfProducts = new List<Carte>();

       
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => BookShopGUI.Rezolvare.Recommend(
                noOfItems, noOfUsers, maxNrOfGenerations, CR, F, userRatings, alreadyGivenRatings, populationCount, listOfProducts));

        }

    }


}

