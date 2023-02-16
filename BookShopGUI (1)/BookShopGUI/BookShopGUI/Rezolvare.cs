using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookShopGUI
{
    public class Rezolvare
    {
        /// <summary>
        /// This is the method that will generate some random user ratings
        /// are write them to a file.
        /// </summary>
        public static void GenerateUserRatings(String fileName)
        {
            double[][] userRatings = new double[10][];
            Random rand = new Random();
            StreamWriter file = new StreamWriter(fileName);
            int k = 0;
            for (int i = 0; i < 10; i++)
            {
                userRatings[i] = new double[18];
                for (int j = 0; j < 18; j++)
                {

                    //k = k + 0.1;
                    userRatings[i][j] = rand.NextDouble() * 4 + 1;
                    file.WriteLine(userRatings[i][j]);
                }
            }
            file.Close();
            
        }
        /// <summary>
        /// This will generate an initial population of random values for our user. 
        /// He will already have some rated items that will remain in place and then for the rest of unrated items
        /// random values will be generated so as to have a starting point for our item weights that are going to be
        /// changed during our algorithm.
        /// </summary>
        /// <param name="alreadyGivenRatings"></param> is the list of items that the user has already rated with their ratings
        /// <param name="noOfItems"></param> is the number of items
        /// <param name="populationCount"></param> is how many items are in the population
        public static void GenerateInitialPopulation(List<KeyValuePair<int, double>> alreadyGivenRatings, int noOfItems, int populationCount, String fileName)
        {
            Random rand = new Random();
            StreamWriter file = new StreamWriter(fileName);
            double[][] population = new double[populationCount][];
            List<int> listOfAlreadyRatedItems = new List<int>();
            //adaugam deja rating-urile date
            for (int i = 0; i < populationCount; i++)
            {
                double[] myUserRating = new double[noOfItems];
                foreach (KeyValuePair<int, double> item in alreadyGivenRatings)
                {
                    listOfAlreadyRatedItems.Add(item.Key);//instead of generating a new value for the rating that was already given
                    //we initialize it with its actual value so the prediction can be as accurate as possible
                    myUserRating[item.Key] = item.Value;

                }
                //pentru restul dam un rating random
                for (int k = 0; k < noOfItems; k++)
                {
                    if (!listOfAlreadyRatedItems.Contains(k))//if the rating wasn't already given
                        myUserRating[k] = rand.NextDouble() * 4 + 1;

                }
                population[i] = myUserRating;
            }
            Console.WriteLine("Populatia: ");
            for (int i = 0; i < populationCount; i++)//then we write all the values to the file
            {
                for (int j = 0; j < noOfItems; j++)
                {
                    file.WriteLine(population[i][j]);
                }
            }
            file.Close();
        }
        /// <summary>
        /// This method reads from a file the ratings that the other users gave.
        /// </summary>
        /// <param name="noOfUsers"></param> is the number of users that have fully rated all the items
        /// <param name="noOfItems"></param> is the number of items that are in store
        /// <returns></returns>
        public static double[][] ReadUsersRatings(int noOfUsers, int noOfItems, String fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            String line = "";
            List<double> lstOfValues = new List<double>();
            double[][] userRatings = new double[noOfUsers][];

            while ((line = sr.ReadLine()) != null)
            {

                lstOfValues.Add(Double.Parse(line));
            }
            int k = 0;
            for (int i = 0; i < noOfUsers; i++)
            {
                userRatings[i] = new double[noOfItems];
                for (int j = 0; j < noOfItems; j++)
                {
                    userRatings[i][j] = lstOfValues.ElementAt(k);//we do this because we extracted all the values from the file
                    //in a vector and then we have to generate the matrix that represents the ratings of the users
                    k++;
                }
            }
            sr.Close();
            return userRatings;

        }
        /// <summary>
        /// This is the method that reads from file the population with randomly generated value
        /// </summary>
        /// <param name="populationCount"></param> is how many individuals we have in the population
        /// <param name="noOfItems"></param> is how many items we have in store , basically the length of one individual
        /// <returns></returns>
        public static double[][] ReadPopulation(int populationCount, int noOfItems)
        {
            StreamReader sr = new StreamReader("Population.txt");
            List<double> lstOfValues2 = new List<double>();
            String line = "";

            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
                lstOfValues2.Add(Double.Parse(line));
            }

            int p = 0;
            double[][] population = new double[populationCount][];
            for (int i = 0; i < populationCount; i++)
            {
                population[i] = new double[noOfItems];
                for (int j = 0; j < noOfItems; j++)
                {
                    population[i][j] = lstOfValues2.ElementAt(p);//we do this because we extracted all the values from the file
                    //in a vector and then we have to generate the matrix that represents the initial population
                    p++;
                }
            }
            sr.Close();
            return population;
        }
        /// <summary>
        /// This is a function that computes the cosine similarity between two different individuals
        /// in order to check how similar two individuals are.
        /// </summary>
        /// <param name="v1"></param> is the first individual
        /// <param name="v2"></param> is the second individual
        /// <returns></returns>
        public static double GetCosineSimilarityV(double[] v1, double[] v2)
        {
            int N = 0;
            N = ((v2.Length < v1.Length) ? v2.Length : v1.Length);//we check which vector has the biggest length
                                                                  //even though in our case all should have the same size
            double dot = 0d;//we have to initialize the dot product
            double mag1 = 0d;//first magnitude
            double mag2 = 0d;//and second magnitude with zero
            for (int n = 0; n < N; n++)
            {
                dot += v1[n] * v2[n];//we compute the dot product
                mag1 += Math.Pow(v1[n], 2);//we compute the first magnitude
                mag2 += Math.Pow(v2[n], 2);//we compute the secind magnitude
            }
            return dot / (Math.Sqrt(mag1) * Math.Sqrt(mag2));//the result is the dor product/ magnitude
        }

        /// <summary>
        /// This is the function that computes the fitness score using the cosine similarity.
        /// </summary>
        /// <param name="weights"></param> is the matrix that contain the ratings given by the other users
        /// <param name="userWeights"></param> is the predicted ratings that we have for our current user
        /// <returns></returns>
        public static double FitnessScore(double[][] weights, double[] userWeights)
        {

            double sumSimilarities = 0;
            double score = 0d;

            double maxScore = 0d;
            for (int i = 0; i < weights.Length; i++)
            {
                double similary = GetCosineSimilarityV(weights[i], userWeights);//we compute the similarity for our vector
                //with each individual from the user ratings so we can perform the comparison
                score += similary;
                if (similary > maxScore)
                    maxScore = similary;
            }
            return -maxScore;//we return this so that we can compare minimizing the function
        }
        /// <summary>
        /// Is the function that computes the mutation 
        /// </summary>
        /// <param name="indivizi"></param> are the inidividuals taken into consideration while mutating
        /// <param name="gena"></param> is the current gene what we perform the mutation on
        /// <param name="F"></param> is the amplification factor
        /// <returns></returns>
        public static double Mutation(double[][] indivizi, int gena, double F)
        {
            return indivizi[3][gena] + F * (indivizi[1][gena] - indivizi[2][gena]);
        }
        /// <summary>
        /// This is the function that will perform the crossover which will be either
        /// initialized with the mutation value or the value of the primary individual.
        /// </summary>
        /// <param name="punctDivizare"></param> is the division point used so we don't risk ending up with no mutation at all
        /// <param name="noOfItems"></param> is the number of items in the store
        /// <param name="CR"></param> is the crossover rate, a probability with which we will perform the mutation
        /// <param name="indivizi"></param> are the invividuals from that population
        /// <param name="F"></param> is the amplification factor used in mutation
        /// <param name="rand"></param> is the random generator
        /// <returns></returns>
        public static double[] Crossover(int punctDivizare, int noOfItems, int CR, double[][] indivizi, double F, Random rand, List<int> listOfAlreadyRatedItems)
        {

            double[] inidividPotential = new double[noOfItems];


            for (int gena = 0; gena < noOfItems; gena++)
            {
                if (gena == punctDivizare || rand.Next(0, 100) < CR)
                {
                    inidividPotential[gena] = Mutation(indivizi, gena, F);//we perform the mutation if the conditions are met
                }
                else
                {
                    inidividPotential[gena] = indivizi[0][gena];//otherwise we just initialize it with the first individual
                }
            }
            return inidividPotential;
        }
        /// <summary>
        /// This is the function that performs the selection by choosing either the evistent individual or the one we computed through
        /// mutation and crossover.
        /// </summary>
        /// <param name="userRatings"></param> are the ratings given by the other users
        /// <param name="individPotential"></param> is the potential individual that make take the place of the existing one
        /// <param name="individExistent"></param> is the parameter that is already in the population
        /// <param name="nrIndivid"></param> is the individual that we are currently performing the selection on
        /// <returns></returns>
        public static double[] Selection(double[][] userRatings, double[] individPotential, double[] individExistent)
        {
            double fitnessIndividPotential = FitnessScore(userRatings, individPotential);//we compute the fitness scores
                                                                                         //so we can compare the individuals
            double fitnessIndividExistent = FitnessScore(userRatings, individExistent);

            if (fitnessIndividPotential <= fitnessIndividExistent)
            {
                return individPotential;
            }
            else
            {
                return individExistent;
            }

        }
        /// <summary>
        /// Is the function that performs the differential evolutionary algorithm 
        /// in order to return an item recommendation
        /// </summary>
        /// <param name="noOfItems"></param> is the number of items in the store
        /// <param name="noOfUsers"></param> is the number of users
        /// <param name="maxNumberOfGenerations"></param> is the maximum number of generations
        /// <param name="CR"></param> is the crossover rate used for mutation
        /// <param name="F"></param> is the amplification factor used for mutation
        /// <param name="userRatings"></param> are the ratings that the other users have given
        /// <param name="alreadyGivenRatings"></param> are the ratings that the user has already given
        /// <param name="populationCount"></param> is the number of individuals from the population
        /// <param name="listOfItems"></param> is the list of items that are in the store
        /// <returns></returns>

        public static String Recommend(int noOfItems, int noOfUsers, int maxNumberOfGenerations, int CR, double F, double[][] userRatings,
                     List<KeyValuePair<int, double>> alreadyGivenRatings, int populationCount, List<Carte> listOfItems)
        {
            Random rand = new Random();
            double[][] population = new double[populationCount][];
            GenerateInitialPopulation(alreadyGivenRatings, noOfItems, populationCount,"Population.txt");//we initialize a random initial population
            //GenerateUserRatings("UsersRatings.txt");

            userRatings = ReadUsersRatings(noOfUsers, noOfItems, "UserRatings.txt");//we read from file the ratings that were already given by
            //the other users
            population = ReadPopulation(populationCount, noOfItems);//and the initial population
            List<int> listOfAlreadyRatedItems = new List<int>();
            foreach (KeyValuePair<int, double> item in alreadyGivenRatings)
            {
                listOfAlreadyRatedItems.Add(item.Key);
                //g = g + item.Key;

            }

            for (int i = 0; i < maxNumberOfGenerations; i++)//we iterate through all the generations
            {

                double[][] newPopulation = new double[populationCount][];//we initialize the vector of the new population
                //that is going to be generated after the current generation is performed
                //int nrIndivid = 0;
                for (int p = 0; p < population.Length; p++)
                //foreach (double[] individExistent in population)
                {
                    double[][] indivizi = new double[populationCount][];
                    //indivizi[0] = individExistent;
                    indivizi[0] = population[p];
                    //we randomly select 3 inidividuals that have to be different from one another
                    int firstRandomlySelectedMember = rand.Next(1, populationCount);
                    int secondRandomlySelectedMember = rand.Next(1, populationCount);
                    while (secondRandomlySelectedMember == firstRandomlySelectedMember)
                        secondRandomlySelectedMember = rand.Next(1, populationCount);
                    int thirdRandomlySelectedMember = rand.Next(1, populationCount);
                    while (thirdRandomlySelectedMember == firstRandomlySelectedMember || thirdRandomlySelectedMember == secondRandomlySelectedMember)
                        thirdRandomlySelectedMember = rand.Next(1, populationCount);
                    indivizi[1] = population[firstRandomlySelectedMember];
                    indivizi[2] = population[secondRandomlySelectedMember];
                    indivizi[3] = population[thirdRandomlySelectedMember];
                    double[] individPotential = new double[noOfItems];
                    int punctDivizare = rand.Next(0, noOfItems);//it's the division point where 
                    while (listOfAlreadyRatedItems.Contains(punctDivizare))
                        punctDivizare = rand.Next(0, noOfItems);
                    //we perform the mutation independent of the crossover rate

                    individPotential = Crossover(punctDivizare, noOfItems, CR, indivizi, F, rand, listOfAlreadyRatedItems);//we perform the crossover to get
                                                                                                                           //the potential individual and in this function we also perform the mutation
                                                                                                                           //because according to the formula
                                                                                                                           //if we don't perform the mutation we will have the existent individual

                    for (int j = 0; j < listOfAlreadyRatedItems.Count; j++)//we should always keep the already given ratings so the similarities don't change
                    //as they want to and end up makeing no sense
                    {
                        individPotential[alreadyGivenRatings[j].Key] = alreadyGivenRatings[j].Value;
                    }

                    newPopulation[p] = population[p];//we initialize the individual from the new population
                    //with the existing one

                    newPopulation[p] = Selection(userRatings, individPotential, population[p]);
                    //we select whether we want the existing 
                    // nrIndivid++;
                }
                population = newPopulation;
            }
            double max = -9999999999999999d;
            double[] solutie = new double[noOfItems];
            //here we get the vector of solutions that will have 
            //the best individual from our population
            for (int i = 0; i < population.Length; i++)
            {
                if (FitnessScore(userRatings, population[i]) > max)
                {
                    max = FitnessScore(userRatings, population[i]);
                    solutie = population[i];
                }
            }
            double[] myUserRating = new double[noOfItems];
            //here we get the list of items that were already rated so we don't risk 
            //giving a recommendation for an item the user has already read
            double maxItem = -9999999999999999d;
            int indexSolutie = 0;
            for (int i = 0; i < solutie.Length; i++)
            {
                if (!listOfAlreadyRatedItems.Contains(i))
                {
                    if (solutie[i] > maxItem)
                    {
                        maxItem = solutie[i];
                        indexSolutie = i;
                    }
                }

            }
            //we return the name of the book we recommend
            return listOfItems.ElementAt(indexSolutie).name;
        }
    }
}
