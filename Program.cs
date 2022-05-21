using System;

namespace Hangman;

public class Program
{
    public static void Main(string[] args)
    {   
        
        Console.Title = "Hangman";
        Console.SetWindowSize(Convert.ToInt32(Console.LargestWindowWidth / 1.44) , Convert.ToInt32(Console.LargestWindowHeight / 1.25));
        GameWord boogyWoogy = new GameWord();
        string userInput;
        string finalWord;
        int playerGuesses = 5;
        bool failSafe = true;

        Console.WriteLine(@"
                                                                                                                                                                      
                                                                                                                                                                      
hhhhhhh                                                                                                                                                               
h:::::h                                                                                                                                                               
h:::::h                                                                                                                                                               
h:::::h                                                                                                                                                               
 h::::h hhhhh              aaaaaaaaaaaaa        nnnn  nnnnnnnn            ggggggggg   ggggg        mmmmmmm    mmmmmmm          aaaaaaaaaaaaa        nnnn  nnnnnnnn    
 h::::hh:::::hhh           a::::::::::::a       n:::nn::::::::nn         g:::::::::ggg::::g      mm:::::::m  m:::::::mm        a::::::::::::a       n:::nn::::::::nn  
 h::::::::::::::hh         aaaaaaaaa:::::a      n::::::::::::::nn       g:::::::::::::::::g     m::::::::::mm::::::::::m       aaaaaaaaa:::::a      n::::::::::::::nn 
 h:::::::hhh::::::h                 a::::a      nn:::::::::::::::n     g::::::ggggg::::::gg     m::::::::::::::::::::::m                a::::a      nn:::::::::::::::n
 h::::::h   h::::::h         aaaaaaa:::::a        n:::::nnnn:::::n     g:::::g     g:::::g      m:::::mmm::::::mmm:::::m         aaaaaaa:::::a        n:::::nnnn:::::n
 h:::::h     h:::::h       aa::::::::::::a        n::::n    n::::n     g:::::g     g:::::g      m::::m   m::::m   m::::m       aa::::::::::::a        n::::n    n::::n
 h:::::h     h:::::h      a::::aaaa::::::a        n::::n    n::::n     g:::::g     g:::::g      m::::m   m::::m   m::::m      a::::aaaa::::::a        n::::n    n::::n
 h:::::h     h:::::h     a::::a    a:::::a        n::::n    n::::n     g::::::g    g:::::g      m::::m   m::::m   m::::m     a::::a    a:::::a        n::::n    n::::n
 h:::::h     h:::::h     a::::a    a:::::a        n::::n    n::::n     g:::::::ggggg:::::g      m::::m   m::::m   m::::m     a::::a    a:::::a        n::::n    n::::n
 h:::::h     h:::::h     a:::::aaaa::::::a        n::::n    n::::n      g::::::::::::::::g      m::::m   m::::m   m::::m     a:::::aaaa::::::a        n::::n    n::::n
 h:::::h     h:::::h      a::::::::::aa:::a       n::::n    n::::n       gg::::::::::::::g      m::::m   m::::m   m::::m      a::::::::::aa:::a       n::::n    n::::n
 hhhhhhh     hhhhhhh       aaaaaaaaaa  aaaa       nnnnnn    nnnnnn         gggggggg::::::g      mmmmmm   mmmmmm   mmmmmm       aaaaaaaaaa  aaaa       nnnnnn    nnnnnn
                                                                                   g:::::g                                                                            
                                                                       gggggg      g:::::g                                                                            
                                                                       g:::::gg   gg:::::g                                                                            
                                                                        g::::::ggg:::::::g                                                                            
                                                                         gg:::::::::::::g                                                                             
                                                                           ggg::::::ggg                                                                               
                                                                              gggggg                                                                                  
");
        System.Threading.Thread.Sleep(1000);

        do
        {
            Console.WriteLine("\n \nChoose a word longer than 4 letters or a phrase shorter than 16 letters with no special characters.");
            userInput = Console.ReadLine();
            finalWord = GameWord.FixedSpace(userInput);
        }
        while (GameWord.WordCheck(finalWord) == false);
        Console.Clear();

        string underScored = GameWord.Underscore(finalWord);
        Console.WriteLine(underScored);


        char[] finalWordArr = (finalWord.ToUpper()).ToCharArray();


        char[] underScoredArr = underScored.ToCharArray();


        while (true)
        {
            LoopEnd:
            string prePlayerInput = (Console.ReadLine()).ToUpper();
            while (prePlayerInput == "" || prePlayerInput.Length > 1 || GameWord.HasSpecialChars(prePlayerInput))
            {
                Console.WriteLine("Please type a letter.");
                
                prePlayerInput = Console.ReadLine().ToUpper();
            }
            char playerInput = Convert.ToChar(prePlayerInput);
            foreach (char allchars in boogyWoogy.usedLetterArr)
                {
                    if (playerInput == allchars)
                    {
                        Console.WriteLine("You already chose this letter.\n ");
                        goto LoopEnd;
                    }
                }
            failSafe = true;

            for (int ind = 0; ind < finalWordArr.Length; ind++)
            {
                
                if (playerInput == finalWordArr[ind] && playerGuesses > 0)
                {
                    Console.Clear();
                    underScoredArr[ind] = finalWordArr[ind];
                    Console.WriteLine(underScoredArr);
                    Console.WriteLine("player guesses = " + playerGuesses);
                    GameWord.HangedMan(playerGuesses);
                    boogyWoogy.AvailableLetters(playerInput);
                    failSafe = false;

                }
                else if (ind == (finalWordArr.Length - 1) && playerGuesses > 0 && failSafe)
                {
                    Console.Clear();
                    playerGuesses--;
                    Console.WriteLine(underScoredArr);
                    Console.WriteLine("Wrong, try again.");
                    Console.WriteLine("player guesses = " + playerGuesses);
                    GameWord.HangedMan(playerGuesses);
                    boogyWoogy.AvailableLetters(playerInput);
                    break;
                }


            }
            if (playerGuesses == 0)
            {
                Console.Clear();
                GameWord.Animation();
                GameWord.Animation();
                Console.WriteLine("The word was: " + finalWord.ToUpper());
                Console.ReadLine();
                break;
            }


            if (underScoredArr.SequenceEqual(finalWordArr))
            {
                Console.Clear();
                Console.WriteLine("\nThe hanged man is alive, you saved him and he left back to his family.");
                Console.ReadLine();
                Console.WriteLine("\nThe word was: " + finalWord.ToUpper());
                break;
            }

        }
    }
}

