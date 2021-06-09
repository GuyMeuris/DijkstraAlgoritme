using System;

namespace DijkstraAlgoritme
{
    /*   Deze applicatie werd geschreven door Guy Meuris op 20/05/2021
         en is een praktische uitwerking van het algoritme van Dijkstra.
         De app zoekt steeds de 'kortste' weg.
         Voor het maken van de afbeelding heb ik eerst zelf de tekening
         online gemaakt op de website 'https://graphonline.ru/en/', een
         website die speciaal ontworpen is om 'de kortste weg' te vinden
         in elke zelf gemaakte 'gewogen graaf'.
         Vervolgens heb ik aan de hand van de opgave een matrix opgesteld
         (met de richtlijnen van Dijkstra), zodat de computer vanuit deze
         matrix de kortste weg van startpunt '0' naar elke ander punt kan 
         berekenen.
         
        https://www.geeksforgeeks.org/csharp-program-for-dijkstras-shortest-path-algorithm-greedy-algo-7/
     */

    class Program
    {
        static void Main(string[] args)
        {

            int[,] matrix = new int[,] { { 0, 4, 7, 5, 0, 0, 0 },
                                         { 4, 0, 3, 0, 5, 0, 0 },
                                         { 7, 3, 0, 1, 2, 6, 0 },
                                         { 5, 0, 1, 0, 0, 8, 0 },
                                         { 0, 5, 2, 0, 0, 3, 6 },
                                         { 0, 0, 6, 8, 3, 0, 2 },
                                         { 0, 0, 0, 0, 6, 2, 0 } };

            BerekenKortsteWeg kortsteWeg = new BerekenKortsteWeg();
            kortsteWeg.GebruikAlgoritme(matrix, 0);
        }
    
    }
}
