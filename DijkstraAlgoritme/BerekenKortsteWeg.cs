using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgoritme
{

    public class BerekenKortsteWeg
    {
        // Globale variabele die de grootte van de gebruikte vierkante matrix
        // bepaalt. (= ook meteen het aantal gebruikte 'nodes' in de 'gewogen graaf')
        static int grootteMatrix = 7;

        /// <summary>
        /// Functie voor het zoeken naar de weg via de 'set met de kleinste waarden' in een
        /// vierkante matrix op basis van het algoritme van Dijkstra.
        /// </summary>
        /// <param name="matrix">De gebruikte matrix</param>
        /// <param name="startGetal">startGetal is telkens het beginpunt van de set kleinste waarden.</param>
        public void GebruikAlgoritme(int[,] matrix, int startGetal)
        {
            int[] kleinsteWaarden = new int[grootteMatrix]; // De array 'kleinsteWaarden'[i]
                                     // zal steeds de korste afstand bevatten
                                     // van het startpunt tot aan [i]

            // de array korstePad[i] zal 'waar'
            // zijn als de laatste node inbegrepen
            // is in de korste afstand (= 'kortste pad')
            // als alle andere paden met elkaar zijn
            // vergeleken.
            bool[] kortstePad = new bool[grootteMatrix];

            // We starten door alle afstanden op oneindig
            // te zetten en de array kortstePad[] op 'onwaar'.
            for (int i = 0; i < grootteMatrix; i++)
            {
                kleinsteWaarden[i] = int.MaxValue;
                kortstePad[i] = false;
            }

            // We weten dat de afstand van een node
            // naar zichzelf ALTIJD nul is.
            kleinsteWaarden[startGetal] = 0;

            // We gaan vervolgens op zoek naar het kortste pad
            // tussen 2 noden. Dit proces herhalen we langs 
            // verschillende noden tot we het kortste pad
            // tussen de 2 noden te pakken hebben
            for (int teller = 0; teller < grootteMatrix - 1; teller++)
            {
                // We beginnen met een eerste 'kortste pad'
                // tussen twee punten - dat we nog niet hebben
                // gehad - te berekenen en noemen deze afstand
                // de 'tijdelijkKortsteAfstand'.
                int tijdelijkKortsteAfstand = minAfstand(kleinsteWaarden, kortstePad);

                // Vervolgens moeten we aanduiden dat we
                // deze afstand al hebben berekend.
                kortstePad[tijdelijkKortsteAfstand] = true;

                // Daarna gaan we alle mogelijke andere routes
                // tussen de 2 nodes berekenen.
                for (int teller2 = 0; teller2 < grootteMatrix; teller2++)

                    // Indien er een korter pad tussenzit, passen we onze
                    // tussentijds kortste afstand aan.
                    if (!kortstePad[teller2] && matrix[tijdelijkKortsteAfstand, teller2] != 0 &&
                         kleinsteWaarden[tijdelijkKortsteAfstand] != int.MaxValue && kleinsteWaarden[tijdelijkKortsteAfstand] + matrix[tijdelijkKortsteAfstand, teller2] < kleinsteWaarden[teller2])
                        kleinsteWaarden[teller2] = kleinsteWaarden[tijdelijkKortsteAfstand] + matrix[tijdelijkKortsteAfstand, teller2];
            }

            // Uiteindelijke oplossing tonen
            toonOplossing(kleinsteWaarden);

            //---------------------------------------------------------------------------------------------------------------------------

            // Hieronder staan de twee gebruikte hulpmethodes.


            /// <summary>
            /// Deze functie gaat op zoek naar de minimum waarde (= kleinste afstand)
            /// van het 'volgende' kleinste getal.
            /// </summary>
            /// <param name="setKleinsteGetallen">numerieke array met alle 'kleinste' afstanden </param>
            /// <param name="setKortsteWegOfNiet">booleaanse array 'setKortsteWegOfNiet' om aan
            // te geven of het getal al of niet de kleinste waarde heeft</param>
            /// <returns>minimum waarde van het volgende 'kleinste' getal</returns>
            int minAfstand(int[] setKleinsteGetallen,
                            bool[] setKortsteWegOfNiet)
            {
                // Starten met de kleinst mogelijke waarde
                int kleinsteGetal = int.MaxValue, kleinsteIndex = -1;

                for (int teller = 0; teller < grootteMatrix; teller++)
                    if (setKortsteWegOfNiet[teller] == false && setKleinsteGetallen[teller] <= kleinsteGetal)
                    {
                        kleinsteGetal = setKleinsteGetallen[teller];
                        kleinsteIndex = teller;
                    }

                return kleinsteIndex;
            }

            /// <summary>
            /// Functie om de berekende set van kleinste getallen (= kleinste afstand) te tonen
            /// </summary>
            /// <param name="setKleinsteGetallen"></param>
            /// <param name="getal"></param>
            void toonOplossing(int[] setKleinsteGetallen)
            {
                Console.WriteLine("Eindpunt\t\tKortste afstand tot '0'");
                for (int teller = 0; teller < BerekenKortsteWeg.grootteMatrix; teller++)
                    Console.Write(teller + " \t\t\t\t\t " + setKleinsteGetallen[teller] + "\n");
            }
        }
    }
}
